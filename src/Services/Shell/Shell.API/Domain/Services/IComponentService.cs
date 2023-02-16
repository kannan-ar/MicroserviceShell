using System.Collections.Generic;
using System.Threading.Tasks;
using ModalEntities = Shell.API.Models.Entities;

namespace Shell.API.Domain.Services
{
    public interface IComponentService
    {
        Task<IEnumerable<ModalEntities.Component>> GetComponentsAsync(bool isAuthenticated);
        Task<ModalEntities.Component> GetComponentAsync(string componentName);
        Task<bool> IsComponentExistsAsync(string componentName);
        Task InsertComponentAsync(ModalEntities.Component component);
        Task<ModalEntities.Component> UpdateComponent(string componentName, ModalEntities.Component component);
        Task DeleteComponentAsync(string componentName);
    }
}
