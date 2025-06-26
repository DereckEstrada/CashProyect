using Cash.BE.Helpers;

namespace Cash.BE.Dtos;

public class ApiResponse<T> 
{
    public StatusCode StatusCode { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public PaginationDto? Pagination { get; set; }

    public void SetStatusCodeAndMessage(StatusCode statusCode)
    {
        this.StatusCode = statusCode;
        this.Message = ApiMessageHelper.Messages[statusCode];
    }
}