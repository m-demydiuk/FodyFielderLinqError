using System.Collections.Generic;
using System.Linq;
using Dal.Dto;

namespace Dal.Services
{
    public class UserService
    {
        private readonly DummyDbContext _dbContext;

        public UserService(DummyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<UserViewModel> GetUsers(ICollection<int> ids)
        {
            var where =  _dbContext.Users.Where(user => ids.Contains(user.Id));

            var workingSelect = where.Select(user => new UserViewModel()).ToList();

            var notWorkingSelect = where.Select(user => new UserViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            });

            return notWorkingSelect.ToList();
        }
    }
}