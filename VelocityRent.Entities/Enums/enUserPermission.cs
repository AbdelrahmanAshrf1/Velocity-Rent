using System;

namespace VelocityRent.Entities.Enums
{
    [Flags]
    public enum enUserPermission
    {
        None = 0,
        ManageUsers = 1,
        ManageCars = 2,
        ManageCustomers = 4,
        ManageRentals = 8,
        ViewReports = 16
    };
}
