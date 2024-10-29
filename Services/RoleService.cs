using Repositories.Interfaces;
using Repositories;
using Services.Interfaces;
using BusinessObjects.Models;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService()
        {
            this.roleRepository = new RoleRepository();
        }

        public void AddRole(Role role) => roleRepository.AddRole(role);
        public void DeleteRole(int roleId) => roleRepository.DeleteRole(roleId);
        public List<Role> GetAllRoles() => roleRepository.GetAllRoles();
        public Role GetRoleById(int roleId) => roleRepository.GetRoleById(roleId);
        public void UpdateRole(Role role) => roleRepository.UpdateRole(role);

    }
}
