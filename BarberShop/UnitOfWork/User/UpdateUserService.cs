using BarberShop.Context;
using BarberShop.DTO.ResponseResult;
using BarberShop.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.UnitOfWork.User
{
    public class UpdateUserService
    {
        private readonly UserManager<T_User> _userManager;
        private readonly BarberShopDbContext _context;
        public UpdateUserService(UserManager<T_User> userManager, BarberShopDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<ResponseDTO> UpdateAsync(string Username,string FullName ,string PhoneNumber, IFormFile ImageUrl)
        {
            var user = await _userManager.FindByIdAsync(Username);
            if (user != null)
            {
                if (ImageUrl != null)
                {
                    if (ImageUrl.Length > 1048576)
                    {
                        var error = new ResponseDTO
                        {
                            Message = "حجم فایل تصویر بیشتر از ۱ مگابایت است",
                            IsSuccess = false,
                            StatusCode = StatusCodes.Status400BadRequest,
                            Data = null
                        };
                        return error;
                    }
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(ImageUrl.FileName);
                    if (!allowedExtensions.Contains(fileExtension.ToLower()))
                    {
                        return new ResponseDTO
                        {
                            Message = "نوع فایل نامعتبر است",
                            IsSuccess = false,
                            StatusCode = StatusCodes.Status400BadRequest,
                            Data = null
                        };
                    }
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }
                    var fileName = Guid.NewGuid().ToString() + fileExtension;
                    var url = Path.Combine(uploadFolder, fileName);
                    using (var fileStream = new FileStream(url, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(fileStream);
                    }
                    user.ImageUrl = url;
                }
                user.FullName = FullName;
                user.PhoneNumber = PhoneNumber;
                await _context.SaveChangesAsync();
                var success = new ResponseDTO
                {
                    Message = "کاربر با موفقیت به‌روزرسانی شد",
                    IsSuccess = true,
                    StatusCode = StatusCodes.Status200OK,
                    Data = null
                };
                return success;

            }
            else
            {
                return new ResponseDTO()
                {
                    Message = "کاربر یافت نشد",
                    IsSuccess = false,
                    StatusCode = StatusCodes.Status404NotFound,
                    Data = null
                };
            }
        }
    }
}
