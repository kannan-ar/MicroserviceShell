using Shell.API.Core.Repositories;
using Shell.API.Core.Services;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Services.Implementations
{
    public class RowService : IRowService
    {
        private readonly IRowRepository _repository;

        public RowService(IRowRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Row>> GetAllAsync()
        {
            return (await _repository.GetAllAsync());
        }

        public async Task AddRow(Row row)
        {
            await _repository.InsertAsync(row);
        }
    }
}
