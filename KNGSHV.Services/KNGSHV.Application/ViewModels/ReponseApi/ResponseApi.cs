namespace KNGSHV.Application.ViewModels.ReponseApi
{
    public enum StatusCode
    {
        Error,
        Success,
        InValid
    }
    public class ResponseApi<T>
    {
        public string Message { set; get; }
        public T Data { get; set; }
        public StatusCode StatusCode { get; set; }

        public ResponseApi(string message = "", StatusCode statusCode = StatusCode.Error)
        {
            this.Message = message;

            this.StatusCode = statusCode;
        }
    }
}
