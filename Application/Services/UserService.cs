using Microsoft.EntityFrameworkCore;
using Infrastructure.Contexts;
using Hr.Application.Models.UserModels;
using Domain.Entities.Common;

namespace Hr.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            return await _context.Users
                .Select(c => new UserViewModel
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FatherName = c.FatherName,
                    Age = c.Age,
                    PhoneNumber = c.PhoneNumber
                })
                .ToListAsync();
        }
        
        public async Task<UserViewModel> GetById(Guid id)
        {
            return await _context.Users
                .Where(t => t.Id == id)
                .Select(c => new UserViewModel
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FatherName = c.FatherName,
                    Age = c.Age,
                    PhoneNumber = c.PhoneNumber
                })
                .FirstOrDefaultAsync() 
                    ?? throw new Exception("Not Found");        
        }

        public async Task<User> Create(UserCreateModel userCreateModel)
        {
            if (userCreateModel == null)
                throw new Exception("Not Found");

            var user = new User
            {
                FirstName = userCreateModel.FirstName,
                LastName = userCreateModel.LastName,
                FatherName = userCreateModel.FatherName,
                Age = userCreateModel.Age,
                PhoneNumber = userCreateModel.PhoneNumber,
                PassportNumber = userCreateModel.PassportNumber
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(UserUpdateModel userUpdateModel)
        {
            var user = _context.Users.FirstOrDefault(t => t.Id == userUpdateModel.Id) 
                ?? throw new Exception("Not Found");

            user.FirstName = userUpdateModel.FirstName;
            user.LastName = userUpdateModel.LastName;
            user.FatherName = userUpdateModel.FatherName;
            user.Age = userUpdateModel.Age;
            user.PhoneNumber = userUpdateModel.PhoneNumber;
            user.PassportNumber = userUpdateModel.PassportNumber;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Delete(Guid id)
        {
            var user = _context.Users.FirstOrDefault(t => t.Id == id) 
                ?? throw new Exception("Not Found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
