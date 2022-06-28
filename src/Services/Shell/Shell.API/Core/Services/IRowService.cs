using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Core.Services
{
    public interface IRowService
    {
        Task<IEnumerable<Row>> GetRowsByPageAsync(string pageName);
        Task InsertRow(Row row);
    }
}
