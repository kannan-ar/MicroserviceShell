using AutoMapper;
using Shell.API.Data;
using Shell.API.Models.DTOs;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Services.Implementations
{
    public class RowService : IRowService
    {
        private readonly IDbRepository<Models.Entities.Row> _repository;

        public RowService(IDbRepository<Models.Entities.Row> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Models.Entities.Row>> GetAllAsync()
        {
            return (await _repository.GetAllAsync());
        }

        public async Task AddRow(Models.Entities.Row row)
        {
            await _repository.Add(row);
        }
    }
}
