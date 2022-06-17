using Shell.API.Models.DTOs;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Services
{
    public interface IRowService
    {
        Task<IEnumerable<Models.Entities.Row>> GetAllAsync();
        Task AddRow(Models.Entities.Row row);
    }
}
