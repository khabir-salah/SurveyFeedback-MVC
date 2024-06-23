namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class AnalysisViewModel
    {
        public string QuestionText { get; set; }
        public List<ResponseCount> ResponseCounts { get; set; }

    }

    public class ResponseCount
    {
        public string OptionText { get; set; }
        public int Count { get; set; }
    }
}
