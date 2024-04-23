namespace SmartDJ.Server;


public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;

    public ServiceResponse()
    {
    }

    public ServiceResponse(T data)
    {
        Data = data;
    }

    public ServiceResponse(T? data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }
    public ServiceResponse(string message)
    {
        Data = default(T);
        Success = false;
        Message = message;
    }
}