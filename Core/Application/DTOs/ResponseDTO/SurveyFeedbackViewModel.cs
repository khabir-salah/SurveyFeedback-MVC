namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class SurveyFeedbackViewModel
    {
        public string ErrorMessage { get; set; }
        public bool ShowSurveyForm { get; set; }
        public SurveyResponseModel Survey { get; set; }
        public string Email { get; set; }
        public string SurveyId { get; set; }
    }

    public class SubmitResponseViewModel
    {
        public SurveyRequestModels Survey { get; set; }
        public string Email { get; set; }
        public string SurveyId { get; set; }
    }
}
