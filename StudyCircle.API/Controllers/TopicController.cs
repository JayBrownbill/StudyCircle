using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using StudyCircle.API.Models;
using StudyCircle.API.Repository;

namespace StudyCircle.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]/")]
    public class TopicController : ControllerBase
    {
        private readonly IStudyTopicRepository _topicRepository;
        public TopicController(IStudyTopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<StudyTopic>> GetAll()
        {
            return await _topicRepository.GetAllTopics();
        }


        [HttpGet("{studyId}")]
        public async Task<StudyTopic?> GetTopicById(Guid studyId)
        {
            return await _topicRepository.GetTopicById(studyId);
        }

        [HttpGet("RelatedToUser/{userId}")]
        public async Task<IReadOnlyCollection<StudyTopic>> GetAllTopicsRelatedToUser(Guid userId)
        {
            return await _topicRepository.GetAllTopicsByUserId(userId);
        }

        [HttpPost("AddTopic")]
        public async Task<StudyTopic> AddNewStudyTopic(StudyTopic topic)
        {
            return await _topicRepository.AddTopic(topic);
        }

        [HttpGet("Remove")]
        public async void DeleteTopic(Guid studyId)
        {
            await _topicRepository.RemoveTopicById(studyId);
        }
    }
}
