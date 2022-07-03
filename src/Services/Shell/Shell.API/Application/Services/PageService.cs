using AutoMapper;
using MediatR;
using Shell.API.Domain.Events;
using Shell.API.Domain.Repositories;
using Shell.API.Domain.Services;
using Shell.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Application.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public PageService(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task InsertPage(PageMetaData metaData)
        {
            await _unitOfWork.PageRepository.InsertAsync(_mapper.Map<PageMetaData>(metaData));
        }

        public async Task<IEnumerable<PageMetaData>> GetPagesAsync()
        {
            return await _unitOfWork.PageRepository.GetAsync();
        }

        public async Task<PageMetaData> GetPageAsync(string pageName)
        {
            return await _unitOfWork.PageRepository.GetPage(pageName);
        }

        public async Task<bool> IsPageExists(string pageName)
        {
            return (await _unitOfWork.PageRepository.GetPage(pageName)) != null;
        }

        public async Task UpsertPage(string pageName, PageMetaData metaData)
        {
            await _unitOfWork.PageRepository.InsertOrUpdatePageAsync(pageName, metaData);
        }

        public async Task<PageMetaData> UpdatePage(string pageName, PageMetaData metaData)
        {
            if(string.Compare(pageName, metaData.PageName, true) == 0)
            {
                return await _unitOfWork.PageRepository.UpdatePageAsync(pageName, metaData);
            }
            else
            {
                try
                {
                    await _unitOfWork.BeginTransactionAsync();

                    await _mediator.Publish(new PageNameChangedEvent(pageName, metaData.PageName));
                    var result = await _unitOfWork.PageRepository.InsertOrUpdatePageAsync(pageName, metaData);
                    await _unitOfWork.CommitChangesAsync();
                    return result;
                }
                catch(Exception ex)
                {
                    await _unitOfWork.RollbackChangesAsync();
                    return null;
                }
               
            }
        }

        public async Task DeletePage(string pageName)
        {
            await _unitOfWork.PageRepository.DeletePageAsync(pageName);
        }
    }
}
