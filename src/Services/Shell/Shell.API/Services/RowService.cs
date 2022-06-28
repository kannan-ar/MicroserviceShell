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

        public async Task<IEnumerable<Row>> GetRowsByPageAsync(string pageName)
        {
            return await _repository.GetRowsByPageAsync(pageName);
        }

        public async Task InsertRow(Row row)
        {
            await _repository.InsertAsync(row);
        }
    }
}
