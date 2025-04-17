using BarberShop.Context;
using BarberShop.DTO.ResponseResult;

namespace BarberShop.UnitOfWork.User
{
    public class DeleteUserService
    {
        private readonly BarberShopDbContext _context;
        public DeleteUserService(BarberShopDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDTO> DeleteUser(Guid id)
        {
            var user = await _context.T_Users.FindAsync(id);
            if(user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                var success = new ResponseDTO
                {
                    Message = "کاربر با موفقیت حذف شد",
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status500InternalServerError

                };
                return success;
            }
            else
            {
                var error = new ResponseDTO
                {
                    Message = "کاربر یافت نشد",
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status500InternalServerError
                }; 
                return error;
            }
        }
    }
}
