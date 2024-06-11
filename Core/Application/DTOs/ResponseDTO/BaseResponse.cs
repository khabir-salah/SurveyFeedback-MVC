namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class BaseResponse<T>
    {
        public bool IsSuccessfull { get; set; }
        public T? Data {get; set;}
        public string message { get; set;}

    }
}
