namespace NUShop.Utilities.DTOs
{
    public class GenericResult
    {
        public GenericResult()
        {
        }

        public GenericResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public GenericResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public GenericResult(bool isSuccess, object data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Error { get; set; }
    }
}