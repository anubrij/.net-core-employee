using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Employee_API.Helper
{
    public class ApiResponse<T> 
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool HasError { get; set; }
        public object Result { get; set; }
        public string[] Error { get; set; }

        public static ApiResponse<T> CreateSuccessResponse(HttpStatusCode statusCode, T Result)
        {
            return new ApiResponse<T>()
            {
                StatusCode = statusCode,
                Result = Result,
            };
        }
        public static ApiResponse<T> CreateErrorResponse(HttpStatusCode statusCode, string errorMessage)
        {
            return CreateErrorResponse(statusCode , new string[] {errorMessage});
        }
        public static ApiResponse<T> CreateErrorResponse(HttpStatusCode statusCode, string[] errorMessage)
        {
            return new ApiResponse<T>()
            {
                HasError = true,
                StatusCode = statusCode,
                Error = errorMessage
            };
        }
    }
}

  