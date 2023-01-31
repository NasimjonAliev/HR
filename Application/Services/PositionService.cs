using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Hr.Application.Models.PositionModels;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hr.Application.Services
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public PositionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PositionViewModel>> GetAll()
        {
            return await _context.Positions
                .AsNoTracking()
                .ProjectTo<PositionViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
                    ?? throw new Exception("Список позиции пусто");
        }

        public async Task<PositionViewModel> GetById(Guid id)
        {
            return await _context.Positions
                .AsNoTracking()
                .ProjectTo<PositionViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(t => t.Id == id)
                    ?? throw new Exception("Нет такой должности");
        }

        public async Task Create(PositionCreateModel positionCreateModel)
        {
            var position = _mapper.Map<Position>(positionCreateModel);

            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
        } 

        public async Task Update(PositionUpdateModel positionUpdateModel)
        {
            var position = await _context.Positions
                .FirstOrDefaultAsync(t => t.Id == positionUpdateModel.Id)
                    ?? throw new Exception("Позиция не найдено!");

            _mapper.Map(positionUpdateModel, position);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var position = await _context.Positions
                .FirstOrDefaultAsync(t => t.Id == id)
                    ?? throw new Exception("Позиция не найдено!");

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
        } 

    }
}
