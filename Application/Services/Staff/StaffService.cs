using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Hr.Application.Models.StaffModels;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hr.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StaffService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StaffViewModel>> GetAll()
        {
            return await _context.Staff
                .AsNoTracking()
                .ProjectTo<StaffViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
                    ?? throw new Exception("Список сотрудников пусто");               
        }

        public async Task<StaffViewModel> GetById(Guid id)
        {
            return await _context.Staff
                .AsNoTracking()
                .Where(t => t.Id == id)
                .ProjectTo<StaffViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
                    ?? throw new Exception("Сотрудник не найден!");
        }

        public async Task Create(StaffCreateModel staffCreateModel)
        {
            var staff = _mapper.Map<Staff>(staffCreateModel);

            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StaffUpdateModel staffUpdateModel)
        {
            var staff = await _context.Staff
                .FirstOrDefaultAsync(t => t.Id == staffUpdateModel.Id)
                    ?? throw new Exception("Сотрудник не найден!");

            _mapper.Map(staffUpdateModel, staff);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var staff = _context.Staff
                .FirstOrDefault(t => t.Id == id)
                    ?? throw new Exception("Сотрудник не найден!");

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
        }
    }
}
