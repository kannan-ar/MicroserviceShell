using MicroFrontend.API.Models.DTOs;

namespace MicroFrontend.API.Services
{
    public interface IRowService
    {
        Task<IEnumerable<Row>> GetAsync();
        Task AddRow(Row row);
    }
}
