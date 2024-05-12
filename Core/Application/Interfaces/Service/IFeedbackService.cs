namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IFeedbackService
    {
        void GiveFeedback(RequestModelFeedbackDTO request);


        List<FeedbackDTO> GetFeedbacks(string title);
    }
}
