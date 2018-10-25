using Newtonsoft.Json;

namespace moneygoes.Models.DTOs
{
    public class Error
    {
        public static ErrorDto GetError(int code, string message)
        {
            return new ErrorDto
            {
                Data = message,
                ErrorCode = code
            };
        }

        public static ErrorDto GetError(int code, object message)
        {
            return new ErrorDto
            {
                Data = JsonConvert.SerializeObject(message),
                ErrorCode = code
            };
        }
    }

    public class ErrorDto
    {
        public string Data { get; set; }
        public int ErrorCode { get; set; }
    }
}