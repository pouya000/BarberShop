using BarberShop.DTO.ResponseResult;
using BarberShop.UnitOfWork.User;
using MediatR;

namespace BarberShop.Feature.Command.User.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseDTO>
    {
        private readonly UpdateUserService _user;

        public UpdateUserCommandHandler(UpdateUserService user)
        {
            _user = user;
        }
        public async Task<ResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _user.UpdateAsync(request.UserName,request.FullName,request.PhoneNumber,request.ImageUrl);
            return result;
        }
    }
}
