using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StudyCircle.API.DataAccess;
using StudyCircle.API.Models;

namespace StudyCircle.API.Repository
{
    public class StudyTopicRepository : IStudyTopicRepository
    {
        private readonly StudyContext _context;
        public StudyTopicRepository(StudyContext context)
        {
            _context = context;
        }
        public async Task<StudyTopic> AddTopic(StudyTopic topic)
        {
            StudyTopic dto = new StudyTopic();

            if (_context.StudyTopic == null) return dto;

                var result = await _context.StudyTopic
                    .Where(t => t.StudyTopicId == topic.StudyTopicId)
                    .FirstOrDefaultAsync();

                if (result != null) return dto;

                await _context.StudyTopic.AddAsync(topic);
                dto = topic;

            return dto;

        }

        public async Task<IReadOnlyCollection<Guid>> AddTopics(List<StudyTopic> topics)
        {
            try
            {
                foreach (var item in topics)
                {
                    if (_context.StudyTopic != null) await _context.StudyTopic.AddAsync(item);
                }
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return new List<Guid>();
            }

            return topics.Select(t => t.StudyTopicId).ToList();
        }

        public Task<Guid> UpdateTopic(StudyTopic topic)
        {
            throw new NotImplementedException();
        }

        public async Task<StudyTopic?> GetTopicById(Guid id)
        {
            return await _context.StudyTopic.Where(subject => subject.StudyTopicId == id)
                .Include(subject => subject.UserAccount)
                .Where(subject => subject.UserAccount != null && subject.UserAccount.UserId == subject.UserId)
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<StudyTopic>> GetAllTopics()
        {
            return await _context.StudyTopic.Where(s => s.Name != string.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<StudyTopic>> GetAllTopicsByUserId(Guid userId)
        {
            return await _context.StudyTopic.Where(t => t.UserId == userId).ToListAsync();
        }

        public IReadOnlyCollection<StudyTopic> GetRangeOfTopics(List<Guid> subjectIds)
        {
            return _context.StudyTopic
                .Where(s => subjectIds
                    .Contains(s.StudyTopicId)).ToList();
        }

        public async Task<int> RemoveTopicById(Guid id)
        {
            var topicToRemove = await GetTopicById(id);
            if (topicToRemove != null)
            {
                _context.StudyTopic.Remove(topicToRemove);
            }
            return await _context.SaveChangesAsync();
        }

        public Task<IReadOnlyCollection<Guid>> RemoveRangeOfTopics(List<Guid> subjectId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<string> RemoveAllTopicsRelatedToUser(Guid userId)
        {
            var topics = _context.StudyTopic.Where(s => s.UserId == userId).ToList();
            _context.StudyTopic.RemoveRange(topics);
            _context.SaveChanges();

            return topics.Select(s => s.Name).ToList();
        }
    }
}
