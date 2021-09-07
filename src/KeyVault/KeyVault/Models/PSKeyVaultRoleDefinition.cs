using Azure.Security.KeyVault.Administration;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultRoleDefinition
    {
        /// <summary> The role definition ID. </summary>
        public string Id { get; }

        /// <summary> The role definition name. </summary>
        public string Name { get; }

        /// <summary> The role definition type. </summary>
        public string Type { get; }

        /// <summary> The role name. </summary>
        public string RoleName { get; set; }

        /// <summary> The role definition description. </summary>
        public string Description { get; set; }

        /// <summary> The role type. </summary>
        public string RoleType { get; set; }

        /// <summary> Role definition permissions. </summary>
        public PSKeyVaultPermission[] Permissions { get; }

        /// <summary> Role definition assignable scopes. </summary>
        public string[] AssignableScopes { get; }

        public PSKeyVaultRoleDefinition(KeyVaultRoleDefinition roleDefinition)
        {
            Id = roleDefinition.Id;
            Name = roleDefinition.Name;
            Type = roleDefinition.Type?.ToString();
            RoleName = roleDefinition.RoleName;
            Description = roleDefinition.Description;
            RoleType = roleDefinition.RoleType?.ToString();
            AssignableScopes = roleDefinition.AssignableScopes.Select(s => s.ToString()).ToArray();
            Permissions = roleDefinition.Permissions.Select(permission => new PSKeyVaultPermission(permission)).ToArray();
        }
    }
}