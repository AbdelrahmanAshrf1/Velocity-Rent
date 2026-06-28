public class Result<T> where T : class
{
    public bool Success { get; }
    public string Message { get; }
    public T Data { get; }

    private Result(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static Result<T> Successfully(T data) => new Result<T>(true, string.Empty, data);
    public static Result<T> Failure(string message) => new Result<T>(false, message, null);
}