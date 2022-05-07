using System;

namespace ApiFactura.Model
{
    public class ApiResult
    {
        public Object Data { get; set; }
        public bool State { get; set; }
        public string Message { get; set; }
        public ApiResult()
        {

        }
        public ApiResult(Object result)
        {
            Data = result;
        }
        public ApiResult(bool state, Object result, string message)
        {
            Data = result;
            State = state;
            Message = message;
        }
        public ApiResult(Object result, string message)
        {
            Data = result;
            Message = message;
        }
    }
}
