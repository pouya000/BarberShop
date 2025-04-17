namespace BarberShop.DTO.ResponseResult
{
    public class ResponseDTO
    {
        public string Message { get; set; } = null!;

        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }

        public object? Data { get; set; }
    }
}
