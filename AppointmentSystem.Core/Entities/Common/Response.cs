namespace AppointmentSystem.Core.Entities.Common
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public static Result<T> Success(T data, string message) => new Result<T> { Data = data, Message = message, IsSuccess = true };
        public static Result<T> Failure(string message) => new Result<T> { Message = message, IsSuccess = false };
    }
}
