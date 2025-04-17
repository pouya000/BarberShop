using BarberShop.DTO.ResponseResult;
using MediatR;

namespace BarberShop.Feature.Command.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<ResponseDTO>
    {
        public Guid userId { get; set; }
    }
}
