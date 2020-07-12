using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CardRepository
    {
        private readonly StoreContext _dbContext;

        public CardRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        
        
    }
}