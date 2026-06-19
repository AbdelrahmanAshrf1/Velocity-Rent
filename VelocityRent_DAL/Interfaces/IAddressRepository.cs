using VelocityRent.Entities;

namespace Velocity_Rent_DAL.Interfaces
{
    public interface IAddressRepository
    {
        int Add(Address address);
        bool Update(Address address);
        bool Delete(int id);
        Address GetByID(int id);
    }
}
