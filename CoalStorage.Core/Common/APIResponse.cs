using System.Net;

namespace CoalStorage.Core.Common
{

    public class APIResponse
    {
        public bool isSuccess { get; set; }
        public Object Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; }

        public APIResponse()
        {
            ErrorMessages = new List<string>();
            StatusCode = HttpStatusCode.BadRequest;
            isSuccess = false;
        }

    }
}
