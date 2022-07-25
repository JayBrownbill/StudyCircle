namespace StudyCircle.API.Models
{
    public class StudyTopic
    {
        public Guid StudyTopicId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; } = Guid.Empty;

        public string Name { get; set; } = "Unnamed";

        public decimal GoalPercentage { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateCompleted { get; set; } = null;

        public DateTime? WhenLastActive { get; set; } = null;

        public DateTime? LongestSession { get; set; } = null;


        public User? UserAccount { get; set; }
    }
}
