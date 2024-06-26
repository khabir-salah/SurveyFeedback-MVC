﻿using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IIdentityService
    {
        BaseResponse<UsersRegResponseModel> Register(UsersRegRequestModel request);


        BaseResponse<UsersRegResponseModel> Login(UserLoginRequestModel request);

        BaseResponse<UsersUnregResponseModel> GetUnreg(string Id);
        BaseResponse<UsersRegResponseModel> Get(string email);
        BaseResponse<UsersUnregResponseModel> Add(string email);
        UsersReg GetCurrentUser();


    }
}
