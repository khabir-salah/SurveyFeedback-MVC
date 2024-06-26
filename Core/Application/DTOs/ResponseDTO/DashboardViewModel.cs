namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class DashboardViewModel
    {
        public int ResponseCount { get; set; }
        public int SurveyCount { get; set; }
        

    }

    public class SearchModel
    {
        public string Title { get; set; }
        public string SurveyId { get; set; }
    }

    public class SurveySearchViewModel
    {
        public string Title { get; set; }
        public ICollection<SearchModel> SearchResults { get; set; }
    }
}
