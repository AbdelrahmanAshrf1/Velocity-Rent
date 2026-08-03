using DTO.Address;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_DLL.Interfaces;
using VelocityRent_DLL.Mappers;

namespace VelocityRent_BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;
        public AddressService(IAddressRepository addressRepository)
        {
            _repo = addressRepository;
        }

        // Soft delete
        public Result<bool> Delete(int id)
        {
            Address address = _repo.GetByID(id);
            if(address == null) return Result<bool>.Failure("Address not found.");

            return _repo.ChangeStatus(id,false)
                ? Result<bool>.Successful(true)
                : Result<bool>.Failure("Can not Deactivate the address.");
        }

        public Result<bool> Activate(int id)
        {
            Address address = _repo.GetByID(id);
            if (address == null) return Result<bool>.Failure("Address not found.");

            return _repo.ChangeStatus(id, true)
                ? Result<bool>.Successful(true)
                : Result<bool>.Failure("Can not Activate the address.");
        }

        public AddressDto GetByID(int id)
        {
            Address address = _repo.GetByID(id);
            return address == null ? null : AddressMapper.ToDto(address);
        }

    }
}
