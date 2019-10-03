using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.BusinessLogic.Common
{
    public class OperationResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
