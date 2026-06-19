
using System.Collections.Generic;
using VelocityRent.Entities;

namespace Velocity_Rent_DAL.Interfaces
{
    public interface IPersonRepositroy
    {
        int Add(Person person);
        bool Update(Person person);
        bool Delete(int id);
        Person GetByID(int id);
        List<Person> GetAll();
    }
}
