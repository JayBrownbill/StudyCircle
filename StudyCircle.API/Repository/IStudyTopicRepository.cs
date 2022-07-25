using StudyCircle.API.Models;

namespace StudyCircle.API.Repository
{
    public interface IStudyTopicRepository
    {
        // Creation of topics
        Task<StudyTopic> AddTopic(StudyTopic topic);
        Task<IReadOnlyCollection<Guid>> AddTopics(List<StudyTopic> topic);


        // Editing of topics
        Task<Guid> UpdateTopic(StudyTopic topic); 


        // Retrieval of topics
        Task<StudyTopic?> GetTopicById(Guid id);
        Task<IReadOnlyCollection<StudyTopic>> GetAllTopics();
        Task<IReadOnlyCollection<StudyTopic>> GetAllTopicsByUserId(Guid userId);
        IReadOnlyCollection<StudyTopic> GetRangeOfTopics(List<Guid> subjectIds);

        
        // Deletion & removal of topics
        Task<int> RemoveTopicById(Guid id);
        Task<IReadOnlyCollection<Guid>> RemoveRangeOfTopics(List<Guid> subjectId);
        IReadOnlyCollection<string> RemoveAllTopicsRelatedToUser(Guid userId);
    }
}
