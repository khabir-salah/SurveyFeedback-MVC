namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Auditables
    {
        public string Id { get; set; } = new Guid().ToString().Substring(1, 5);
    }
}
