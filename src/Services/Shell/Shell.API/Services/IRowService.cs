using Shell.API.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Services
{
    public interface IRowService
    {
        Task<IEnumerable<Row>> GetAsync();
        Task AddRow(Row row);
    }
}
