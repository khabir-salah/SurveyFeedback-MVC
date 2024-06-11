namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Auditables
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0,6);
    }
}
