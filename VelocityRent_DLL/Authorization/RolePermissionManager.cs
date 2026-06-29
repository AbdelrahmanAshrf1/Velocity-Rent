
using VelocityRent.Entities.Enums;

namespace VelocityRent_DLL.Authorization
{
    public static class RolePermissionManager
    {
        public static enUserPermission GetPermission(enUserRole role)
        {
            switch(role)
            {
                case enUserRole.Admin:
                    return enUserPermission.ManageUsers
                         | enUserPermission.ManageCars
                         | enUserPermission.ManageCustomers
                         | enUserPermission.ManageRentals
                         | enUserPermission.ViewReports;

                case enUserRole.Employee:
                    return enUserPermission.ManageCars
                         | enUserPermission.ManageCustomers
                         | enUserPermission.ManageRentals;
                
                case enUserRole.Manager:
                    return enUserPermission.ManageCars
                         | enUserPermission.ViewReports;
                
                default:
                    return enUserPermission.None;
            }
        }

        public static bool HasPermission(enUserRole role , enUserPermission permission)
        {
            var permissions = GetPermission(role);
            return (permissions & permission) == permission;
        }
    }
}
