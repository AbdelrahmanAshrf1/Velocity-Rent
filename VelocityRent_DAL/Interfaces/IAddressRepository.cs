using System.Data.SqlClient;
using VelocityRent.Entities;

namespace Velocity_Rent_DAL.Interfaces
{
    public interface IAddressRepository
    {
        int Add(Address address,SqlConnection connection,SqlTransaction transaction);
        bool Update(Address address, SqlConnection connection, SqlTransaction transaction);
        bool Delete(int id);
        Address GetByID(int id);
        bool ChangeStatus(int id,bool status);
    }
}
