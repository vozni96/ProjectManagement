using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Data;
using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    public class ColumnService
    {
        private readonly ProjectManagementDbContext _dbContext;

        public ColumnService(ProjectManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Column viewModel)
        {
        }

        public void Update(Column column)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
