﻿using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IFeedbackService
    {
        BaseResponse<ICollection<SurveyResponseViewModel>> GetFeedbackById(string Id);
        bool IsFeedbackExist(string email, string SurveyId);

    }
}
