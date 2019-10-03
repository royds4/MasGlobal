using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasGlobal.Presentation.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MasGlobal.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        private Uri BaseEndpoint { get; set; }
        public HomeController(IOptions<AppConfig> settings)
        {
            httpClient = new HttpClient();
            BaseEndpoint = new Uri(settings.Value.EmployeeURI);
            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            httpClient.DefaultRequestHeaders.Add("Keep-Alive", "3600");
        }
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var requestUrl = $"{BaseEndpoint}{(viewModel.SelectedEmployeeId.HasValue ? $"/{viewModel.SelectedEmployeeId}" : string.Empty)}";
                var response = await httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    viewModel.Employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
                }
                else
                {
                    ModelState.AddModelError("SelectedEmployeeId", "Not found");
                }
            }
            return View(viewModel); 
        }
    }
}
