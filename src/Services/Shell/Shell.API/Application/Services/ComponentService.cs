using Shell.API.Domain.Repositories;
using Shell.API.Domain.Services;
using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Application.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComponentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Component> GetComponentAsync(string componentName)
        {
            return await _unitOfWork.ComponentRepository.GetComponentAsync(componentName);
        }

        public async Task<IEnumerable<Component>> GetComponentsAsync(bool isAuthenticated)
        {
            return isAuthenticated ? 
                await _unitOfWork.ComponentRepository.GetAsync() :
                await _unitOfWork.ComponentRepository.GetComponentsAsync(false);
        }

        public async Task<bool> IsComponentExistsAsync(string componentName)
        {
            return await _unitOfWork.ComponentRepository.IsComponentExistsAsync(componentName);
        }

        public async Task InsertComponentAsync(Component component)
        {
            await _unitOfWork.ComponentRepository.InsertAsync(component);
        }


        public async Task<Component> UpdateComponent(string componentName, Component component)
        {
            return await _unitOfWork.ComponentRepository.UpdateComponentAsync(componentName, component);
        }

        public async Task DeleteComponentAsync(string componentName)
        {
            await _unitOfWork.ComponentRepository.DeleteComponentAsync(componentName);
        }
    }
}
