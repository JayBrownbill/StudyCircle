using StudyCircle.API.Enums;

namespace StudyCircle.API.Models
{
    public class User : Account
    {
        public string DisplayName { get; set; } = string.Empty;
        public ProgressionTypeMultiplier ProgressionMultiplier { get; set; }

        public DateTime DateLastActive { get; set; }
        
        public List<StudyTopic> Subjects { get; set; } = new List<StudyTopic>();

    }
}
