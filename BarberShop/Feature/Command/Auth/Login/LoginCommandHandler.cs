using BarberShop.DTO.ResponseResult;
using BarberShop.UnitOfWork.User;
using MediatR;

namespace BarberShop.Feature.Command.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseDTO>
    {
        private readonly UnitOfWork.User.AuthService _user;

        public LoginCommandHandler(UnitOfWork.User.AuthService user)
        {
            _user = user;
        }
        public async Task<ResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _user.LoginAsync(request.Username, request.Password);
            return result;
        }
    }
}
