using Domain.Entities;
using Hr.Application.Models.StaffModels;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hr.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext _context;
        public StaffService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<StaffViewModel>> GetAll()
        {
            return await _context.Staff
                .Select(c => new StaffViewModel
                {
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    FatherName = c.User.FatherName,
                    Age = c.User.Age,
                    PhoneNumber = c.User.PhoneNumber,
                    PassportNumber = c.User.PassportNumber,
                    EducationLevel = c.Education.EducationLevel,
                    Position = c.Position.Name,
                    Amount = c.Position.Amount,
                })
                .ToListAsync();
        }
        public async Task<StaffViewModel> GetById(Guid id)
        {
            return await _context.Staff
                .Where(t => t.Id == id)
                .Select(c => new StaffViewModel
                {
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    FatherName = c.User.FatherName,
                    Age = c.User.Age,
                    PhoneNumber = c.User.PhoneNumber,
                    PassportNumber = c.User.PassportNumber,
                    EducationLevel = c.Education.EducationLevel,
                    Position = c.Position.Name,
                    Amount = c.Position.Amount,
                })
                .FirstOrDefaultAsync()
                    ?? throw new Exception("Not Found");
        }
        public async Task<Staff> Create(StaffCreateModel staffCreateModel)
        {
            if (staffCreateModel == null)
                throw new Exception("Not Found");

            var staff = new Staff
            {
                FirstName = staffCreateModel.FirstName,
                LastName = staffCreateModel.LastName,
                FatherName = staffCreateModel.FatherName,
                Age = staffCreateModel.Age,
                PhoneNumber = staffCreateModel.PhoneNumber,
                PassportNumber = staffCreateModel.PassportNumber,
            };

            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();

            return staff;
        }

        public async Task<Staff> Update(StaffUpdateModel staffUpdateModel)
        {
            var staff = _context.Staff.FirstOrDefault(t => t.Id == staffUpdateModel.Id)
                ?? throw new Exception("Not Found");

            staff.FirstName = staffUpdateModel.FirstName;
            staff.LastName = staffUpdateModel.LastName;
            staff.FatherName = staffUpdateModel.FatherName;
            staff.Age = staffUpdateModel.Age;
            staff.PhoneNumber = staffUpdateModel.PhoneNumber;
            staff.PassportNumber = staffUpdateModel.PassportNumber;

            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();

            return staff;
        }
        public async Task<Staff> Delete(Guid id)
        {
            var staff = _context.Staff.FirstOrDefault(t => t.Id == id)
                ?? throw new Exception("Not Found");

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return staff;
        }
    }
}
