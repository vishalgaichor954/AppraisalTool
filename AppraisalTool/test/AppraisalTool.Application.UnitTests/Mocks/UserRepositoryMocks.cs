using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.UnitTests.Mocks
{
    public class UserRepositoryMocks
    {
        public static Mock<IUserRepository> UserRepository()
        {
            var users = new List<User>
            {
            new User
            {
                Id= 1,
                FirstName="test",
                LastName="test",
                Email="test",
                JoinDate=DateTime.Now,
                LastAppraisalDate=DateTime.Now,
                RoleId=1,
                BranchId=1,
                AddedBy=1,
                AddedOn=DateTime.Now,
                IsDeleted=true,
                DeletedOn=DateTime.Now,
                DeletedBy=1,
                UpdatedBy=1,
                UpdatedOn=DateTime.Now,
                Branch= new Branch
                {
                    Id=1,
                    BranchCode="Test",
                    BranchName="Test",
                },
                Role=new UserRole
                {
                    Id=1,
                    Role="test",

                },
                JobRoles=new List<UserJobRoles>
                {
                    new UserJobRoles
                    {
                        Id=1,
                        JobRole=new JobRoles
                        {
                            Id=1,
                            Name="Test",
                        }
                    }
                }
            }
            };



            var userById = new User
            {

                Id = 1,
                FirstName = "test",
                LastName = "test",
                Email = "test",
                JoinDate = DateTime.Now,
                LastAppraisalDate = DateTime.Now,
                RoleId = 1,
                BranchId = 1,
                AddedBy = 1,
                AddedOn = DateTime.Now,
                IsDeleted = true,
                DeletedOn = DateTime.Now,
                DeletedBy = 1,
                UpdatedBy = 1,
                UpdatedOn = DateTime.Now,
                Branch = new Branch
                {
                    Id = 1,
                    BranchCode = "Test",
                    BranchName = "Test",
                },
                Role = new UserRole
                {
                    Id = 1,
                    Role = "test",

                },
                JobRoles = new List<UserJobRoles>
                {
                    new UserJobRoles
                    {
                        Id=1,
                        JobRole=new JobRoles
                        {
                            Id=1,
                            Name="Test",
                        }
                    }
                }

            };

            var removeUser = new RemoveUserCommandDto
            {

                Id = 1,
                Message = "test",
                Succeeded = false,


            };


            var registerUser = new CreateUserDto
            {

                Id = 1,
                FirstName = "test",
                LastName = "test",
                Email = "test",
                Password = "test",
                Message = "test",
               Succeeded=true,
            };

            var updateUser = new UpdateUserCommandDto
            {

                Id = 1,
                Message = "test",
                Succeeded = true,
            };
            var updateUserInput = new UpdateUserCommand
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Email = "test",
                JoinDate = DateTime.Now,
                LastAppraisalDate = DateTime.Now,
                RoleId = 1,
                BranchId = 1,
                Password = "test",
                PrimaryJobProfileId = 1,
                SecondaryJobProfileId = 2,

            };
            var getUserListQueryVm = new List<GetUserListQueryVm>
            {
                new GetUserListQueryVm
                {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Email = "test",
                JoinDate = DateTime.Now,
                LastAppraisalDate = DateTime.Now,
                Role = 1,
                BranchId = 1,
                Password = "test",
                PrimaryJobProfileId = 1,
                SecondaryJobProfileId = 2,
                RoleName="test",
                PrimaryJobProfileName="test",
                SecondaryJobProfileName="test",
                RevaId=1,
                RepaId=1,
                RevaName="test",
                RepaName="test",
                }
              

            };









            var getUserListQuery = getUserListQueryVm.FirstOrDefault(x => x.Id == 1);
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetAllUser()).ReturnsAsync(users);
            mockUserRepository.Setup(x => x.GetUserbyid(1)).ReturnsAsync(getUserListQuery);
            mockUserRepository.Setup(x => x.RemoveUserAsync(1)).ReturnsAsync(removeUser);
            mockUserRepository.Setup(x => x.RegisterUserAsync(userById)).ReturnsAsync(registerUser);
            mockUserRepository.Setup(x => x.UpdateUserAsync(1, updateUserInput)).ReturnsAsync(updateUser);

            return mockUserRepository;
        }
    }
}
