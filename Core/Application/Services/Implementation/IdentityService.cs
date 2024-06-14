using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;
using System.Security.Claims;
using System.Security.Principal;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class IdentityService : IIdentityService
    {
        private readonly IUsersRegRepository _userRegRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersUnregRepository _userRepo;
        private readonly IHttpContextAccessor _contextAccessor;
        public IdentityService(IUsersRegRepository userRegRepo, IUnitOfWork unitOfWork, IUsersUnregRepository userRepo, IHttpContextAccessor contextAccessor)
        {
            _userRegRepo = userRegRepo;
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
            _contextAccessor = contextAccessor;
        }
       
        private bool IsEmailExist(string email)
        {
            var isExist = _userRegRepo.Get(s => s.Email == email);
            if(isExist != null)
            {
                return true;
            }
            return false;
        }

        private bool IsUserExist(string email)
        {
            var isExist = _userRepo.Get(u => u.Email == email);
            if (isExist == null)
                return false;
            return true;
        }

        public BaseResponse<UsersRegResponseModel> Register(UsersRegRequestModel request)
        {
            var check = IsEmailExist(request.Email);
            if (check)
            {
                return new BaseResponse<UsersRegResponseModel>
                {
                    IsSuccessfull = false,
                    Data = null,
                    message = "Email Already Exist"
                };
            }
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);
            var user = new UsersReg
            {
                Email = request.Email,
                Password = hashPassword,
                salt = salt,
                Role = "Client",
                ConfirmPassword = request.ConfirmPassword,
                FullName = request.FullName,
                UserName = request.UserName,
            };
            _userRegRepo.Add(user);
            _unitOfWork.Save();
            return new BaseResponse<UsersRegResponseModel>
            {
                IsSuccessfull = true,
                message = "Registration Successfull",
                Data = new UsersRegResponseModel
                {
                    Email = user.Email,
                    Role = user.Role,
                    UserName = user.UserName,
                    UsersRegId = user.Id,
                }
            };
        }



        public BaseResponse<UsersRegResponseModel> Login(UserLoginRequestModel request)
        {
            var check = _userRegRepo.Get(l => l.Email == request.Email);
            if (check != null)
            {
                var password = BCrypt.Net.BCrypt.Verify( request.Password, check.Password);
                if (password)
                {
                    return new BaseResponse<UsersRegResponseModel>
                    {
                        IsSuccessfull = true,
                        message = "Login Successfull",
                        Data = new UsersRegResponseModel
                        {
                            Email = check.Email,
                            Role = check.Role,
                            UserName = check.UserName,
                            UsersRegId = check.Id,
                        }
                    };
                }
                else
                {
                    return new BaseResponse<UsersRegResponseModel>
                    {
                        IsSuccessfull = false,
                        message = "Invalid Credential",
                        Data = null,
                    };
                }
            }
            return new BaseResponse<UsersRegResponseModel>
            {
                IsSuccessfull = false,
                message = "Invalid Credential",
                Data = null,
            };

        }



        public BaseResponse<UsersRegResponseModel> Get(string Id)
        {
            var user = _userRegRepo.Get(s => s.Id == Id);
            if (user == null)
            {
                return new BaseResponse<UsersRegResponseModel>
                {
                    IsSuccessfull = false,
                    message = "User Not Found",
                    Data = null,
                };
            }
            return new BaseResponse<UsersRegResponseModel>
            {
                IsSuccessfull = true,
                message = "Successfull",
                Data = new UsersRegResponseModel
                {
                    Email = user.Email,
                    UsersRegId = user.Id,
                    UserName = user.UserName,
                    Role = user.Role,
                }
            };
        }

        public BaseResponse<UsersUnregResponseModel> Add(string email)
        {
            var isExist = IsUserExist(email);
            if (isExist)
            {
                return new BaseResponse<UsersUnregResponseModel>
                {
                    IsSuccessfull = false,
                    Data = null,
                    message = "User Already Exist",
                };
            }
            var user = new UsersUnreg
            {
                Email = email,
            };
            _userRepo.Add(user);
            _unitOfWork.Save();
            return new BaseResponse<UsersUnregResponseModel>
            {
                IsSuccessfull = true,
                message = "Successfull",
                Data = new UsersUnregResponseModel
                {
                    Email = user.Email,
                    UsersUnregId = user.Id
                }
            };
        }

        public  UsersReg GetCurrentUser()
        {
            var userId = _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _userRegRepo.Get(a => a.Id == userId);
            return user;
        }
    }
}
