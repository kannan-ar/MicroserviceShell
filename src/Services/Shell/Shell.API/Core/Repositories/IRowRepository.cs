using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Core.Repositories
{
    public interface IRowRepository : IDbRepository<Row>
    {
        Task<IEnumerable<Row>> GetRowsByPageAsync(string pageName);
        Task<Row> UpdateRowAsync(string pageName, int rowIndex, Row row);
        Task InsertOrUpdateRowAsync(string pageName, int rowIndex, Row row);
        Task DeleteRow(string pageName, int rowIndex);
    }
}
