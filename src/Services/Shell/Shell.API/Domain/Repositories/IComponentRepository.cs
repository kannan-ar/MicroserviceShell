using System.Collections.Generic;
using System.Threading.Tasks;
using ModalEntities = Shell.API.Models.Entities;

namespace Shell.API.Domain.Repositories
{
    public interface IComponentRepository : IDbRepository<ModalEntities.Component>
    {
        Task<IEnumerable<ModalEntities.Component>> GetComponentsAsync(bool requireAuthentication);
        Task<ModalEntities.Component> GetComponentAsync(string componentName);
        Task<ModalEntities.Component> UpdateComponentAsync(string componentName, ModalEntities.Component component);
        Task<bool> IsComponentExistsAsync(string componentName);
        Task DeleteComponentAsync(string componentName);
    }
}
