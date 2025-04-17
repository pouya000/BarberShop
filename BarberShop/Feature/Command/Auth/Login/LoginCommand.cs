using BarberShop.DTO.ResponseResult;
using MediatR;

namespace BarberShop.Feature.Command.Auth.Login
{
    public class LoginCommand() : IRequest<ResponseDTO>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
