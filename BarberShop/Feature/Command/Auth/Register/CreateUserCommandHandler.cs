using BarberShop.DTO.ResponseResult;
using BarberShop.UnitOfWork.User;
using MediatR;

namespace BarberShop.Feature.Command.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseDTO>
    {
        private readonly UnitOfWork.User.AuthService _user;

        public CreateUserCommandHandler(UnitOfWork.User.AuthService user)
        {
            _user = user;
        }
        public async Task<ResponseDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _user.RegisterAsync(request.UserName,request.Password,request.FullName,request.Bio,request.ImageUrl,request.StartTime,request.EndTime,request.PhoneNumber,request.UserRole);
            return result;

        }
    }
}
