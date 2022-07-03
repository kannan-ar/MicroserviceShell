using Shell.API.Domain.Repositories;
using Shell.API.Domain.Services;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Application.Services.Implementations
{
    public class RowService : IRowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Row>> GetRowsByPageAsync(string pageName)
        {
            return await _unitOfWork.RowRepository.GetRowsByPageAsync(pageName);
        }

        public async Task InsertRow(Row row)
        {
            await _unitOfWork.RowRepository.InsertAsync(row);
        }

        public async Task<Row> UpdateRow(string pageName, int rowIndex, Row row)
        {
            return await _unitOfWork.RowRepository.UpdateRowAsync(pageName, rowIndex, row);
        }

        public async Task UpsertRow(string pageName, int rowIndex, Row row)
        {
            await _unitOfWork.RowRepository.InsertOrUpdateRowAsync(pageName, rowIndex, row);
        }

        public async Task DeleteRow(string pageName, int rowIndex)
        {
            await _unitOfWork.RowRepository.DeleteRow(pageName, rowIndex);
        }

        public async Task<Row> ChangePageNameAsync(string oldPageName, string newPageName)
        {
            return await _unitOfWork.RowRepository.ChangePageNameAsync(oldPageName, newPageName);
        }
    }
}
