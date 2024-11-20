namespace CoalStorage.Core.Common;
public class APIResponse
{
    public bool isSuccess { get; set; } = false;
    public Object Result { get; set; }
    public string Message { get; set; } = string.Empty;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
    public List<string> ErrorMessages { get; set; } = new List<string>();


}
