using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Persistence.Repositories
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public UserRepository(ApplicationDbContext context, ILogger<User> logger):base(context, logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public async Task<User> AddUser(User u)
        {
            User usr = await _dbContext.User.FirstOrDefaultAsync(obj => obj.Email == u.Email);
            if (usr == null)
            {
                await AddAsync(u);
                return await _dbContext.User.FirstOrDefaultAsync(obj => obj.Email  == u.Email);
            }
            else
            {
                throw new Exception("User with this login id already exists");
            }
        }

    }
}
