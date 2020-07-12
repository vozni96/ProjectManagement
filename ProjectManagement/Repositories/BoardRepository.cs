using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly StoreContext _dbContext;

        public BoardRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Board> GetBoardByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Board>> GetBoardsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllChangesAsync()
        {
            throw new System.NotImplementedException();
        }

       
    }
}
