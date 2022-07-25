using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Xunit;

namespace StudyCircle.API.Tests.Helpers
{
    
    public class RollbackDatabaseTransactionTest
    {
        [Fact(Skip = "Function not flushed out yet.")]
#pragma warning disable CS1998
        public async Task RollbackDatabaseTransaction_Successful()
#pragma warning restore CS1998
        {
            //ExecuteDatabaseTransactions<StudyTopic> rollbackHelper =
            //    new ExecuteDatabaseTransactions<StudyTopic>(_context);

            //Func<Task<StudyTopic>>? transaction = async () =>
            //{
            //    StudyTopic subject = _fixture
            //        .Build<StudyTopic>()
            //        .Without(s => s.UserAccount)
            //        .With(s => s.StudyTopicId, topicId)
            //        .Create();

            //    await _subjectRepository.AddTopic(subject);
            //    return await _subjectRepository.GetTopicById(topicId);
            //};

            //var act = rollbackHelper.ExecuteAndRollbackAsync(transaction);
        }
    }
}
