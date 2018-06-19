using Dal.Services;
using System;
using System.Collections.Generic;
using Dal;
using Dal.Model;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FielderLinq
{
    public class FielderTests
    {
        [Fact]
        public void GetUsers()
        {
            //Arrange
            var userService = new UserService(GetDbContext());

            //Act
            var users = userService.GetUsers(new List<int> { 1 });

            //Assert
            users.Should().HaveCount(1);
        }

        private DummyDbContext GetDbContext()
        {

            var builder = new DbContextOptionsBuilder<DummyDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var options = builder.Options;
            var dbContext = new DummyDbContext(options);

            dbContext.Users.Add(new User
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last"
            });

            dbContext.Users.Add(new User
            {
                Id = 2,
                FirstName = "First",
                LastName = "Last"
            });

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
