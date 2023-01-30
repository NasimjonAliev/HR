using Microsoft.EntityFrameworkCore;
using Infrastructure.Contexts;
using Hr.Application.Models.UserModels;
using Domain.Entities.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Hr.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            return await _context.Users
                .AsNoTracking()
                .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
                    ?? throw new Exception("Not Found");
        }
        
        public async Task<UserViewModel> GetById(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(t => t.Id == id)
                .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync() 
                    ?? throw new Exception("Not Found");        
        }

        public async Task<UserUpdateModelById> GetByIdUpdate(Guid id)
        {
            return await _context.Users
                .Where(t => t.Id == id)
                .ProjectTo<UserUpdateModelById>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
                ?? throw new Exception("Not Found");
        }

        public async Task Create(UserCreateModel userCreateModel)
        {
            var user = _mapper.Map<User>(userCreateModel);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserUpdateModel userUpdateModel)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(t => t.Id == userUpdateModel.Id)
                    ?? throw new Exception("Not Found");

            _mapper.Map(userUpdateModel, user);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(t => t.Id == id) 
                    ?? throw new Exception("Not Found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
