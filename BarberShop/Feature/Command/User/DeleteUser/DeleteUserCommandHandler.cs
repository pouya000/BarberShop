using BarberShop.DTO.ResponseResult;
using BarberShop.UnitOfWork.User;
using MediatR;

namespace BarberShop.Feature.Command.User.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseDTO>
    {
        private readonly DeleteUserService _user;
        public DeleteUserCommandHandler(DeleteUserService user)
        {
            _user = user;
        }
        public async Task<ResponseDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _user.DeleteUser(request.userId);
            return result;
        }
    }
}
