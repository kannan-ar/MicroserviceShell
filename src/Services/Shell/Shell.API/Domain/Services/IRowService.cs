using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Domain.Services
{
    public interface IRowService
    {
        Task<IEnumerable<Row>> GetRowsByPageAsync(string pageName);
        Task InsertRow(Row row);
        Task<Row> UpdateRow(string pageName, int rowIndex, Row row);
        Task UpsertRow(string pageName, int rowIndex, Row row);
        Task DeleteRow(string pageName, int rowIndex);
        Task<Row> ChangePageNameAsync(string oldPageName, string newPageName);
    }
}
