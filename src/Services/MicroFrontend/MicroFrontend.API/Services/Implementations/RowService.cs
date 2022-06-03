using AutoMapper;
using MicroFrontend.API.Data;
using MicroFrontend.API.Models.DTOs;
using Entities = MicroFrontend.API.Models.Entities;

namespace MicroFrontend.API.Services.Implementations
{
    public class RowService : IRowService
    {
        private readonly IMapper _mapper;
        private readonly IDbRepository<Models.Entities.Row> _repository;
        public RowService(IMapper mapper, IDbRepository<Entities.Row> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<Row>> GetAsync()
        {
            return _mapper.Map<IEnumerable<Row>>(await _repository.GetAllAsync());
        }

        public async Task AddRow(Row row)
        {
            await _repository.Add(_mapper.Map<Entities.Row>(row));
        }
    }
}
