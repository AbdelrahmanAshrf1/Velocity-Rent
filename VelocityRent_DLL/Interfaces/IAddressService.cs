using DTO.Address;
namespace VelocityRent_DLL.Interfaces
{
    public interface IAddressService
    {
        Result<bool> Delete(int id);
        AddressDto GetByID(int id);
        Result<bool> Activate(int id);
    }
}
