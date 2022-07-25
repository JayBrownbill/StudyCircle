using System.Transactions;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace StudyCircle.API.Tests.Helpers
{
    public class ExecuteDatabaseTransactions<T> where T : class
    {
        private readonly DbContext _context;

        public ExecuteDatabaseTransactions(DbContext context)
        {
            _context = context;
        }

        public async Task<T> ExecuteAndRollbackAsync(Func<Task<T>> transaction)
        {
            await _context.Database.BeginTransactionAsync();
            var exectue = transaction;
            var result = exectue.Invoke();
            await _context.Database.RollbackTransactionAsync();

            return await result;
        }
    }
}
