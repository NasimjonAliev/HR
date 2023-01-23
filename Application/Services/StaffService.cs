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
                    UserName = $"{c.User.FirstName} {c.User.LastName} {c.User.FatherName}",
                    EducationName  = c.Education.UniversityName,
                    PositionName = c.Position.Name
                })
                .ToListAsync();
        }

        public async Task<Staff> Create(StaffCreateModel staffCreateModel)
        {
            if (staffCreateModel == null)
                throw new Exception("Not Found");

            var staff = new Staff
            {
                Id = Guid.NewGuid(),
                UserId = staffCreateModel.UserId,
                EducationId = staffCreateModel.EducationId,
                PositionId = staffCreateModel.PositionId
            };

            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();

            return staff;
        }

        public async Task<Staff> Update(StaffUpdateModel staffUpdateModel)
        {
            var staff = _context.Staff.FirstOrDefault(t => t.Id == staffUpdateModel.Id)
                ?? throw new Exception("Not Found");

            staff.UserId = staffUpdateModel.UserId;
            staff.EducationId = staffUpdateModel.EducationId;
            staff.PositionId = staffUpdateModel.PositionId;

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
