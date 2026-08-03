
using System.Collections.Generic;
using System.Data.SqlClient;
using VelocityRent.Entities;

namespace Velocity_Rent_DAL.Interfaces
{
    public interface IPersonRepositroy
    {
        int Add(Person person,SqlConnection connection,SqlTransaction transaction);
        bool Update(Person person, SqlConnection connection, SqlTransaction transaction);
        bool Exists(int id);
        bool Delete(int id);
        Person GetByID(int id);
        List<Person> GetAll();
        bool ChangeStatus(int id, bool status);
    }
}
