using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Hr.Application.Models.EducationModels;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hr.Application.Services
{
    public class EducationService : IEducationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EducationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EducationViewModel>> GetAll()
        {
            return await _context.Educations
                .AsNoTracking()
                .ProjectTo<EducationViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
                    ?? throw new Exception("Список Educations пусто");
        }

        public async Task<EducationViewModel> GetById(Guid id)
        {
            return await _context.Educations
                .AsNoTracking()
                .ProjectTo<EducationViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(t => t.id == id)
                    ?? throw new Exception("Нет такой Education");
        }

        public async Task Create(EducationCreateModel educationCreateModel)
        {
            var education = _mapper.Map<Education>(educationCreateModel);

            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();
        }

        public async Task Update(EducationUpdateModel educationUpdateModel)
        {
            var education = await _context.Educations
                .FirstOrDefaultAsync(t => t.Id == educationUpdateModel.id)
                    ?? throw new Exception("Позиция не найдено!");

            _mapper.Map(educationUpdateModel, education);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var education = await _context.Educations
                .FirstOrDefaultAsync(t => t.Id == id)
                    ?? throw new Exception("Позиция не найдено!");

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
        }
    }
}
