using DTO.Person;
using System.Collections.Generic;

namespace VelocityRent_DLL.Interfaces
{
    public interface IPersonService
    {
        bool Exists(int id);
        bool HasUser(int id);
        Result<int> CreatePerson(CreatePersonRequest request);
        Result<bool> UpdatePerson(UpdatePersonRequest request);
        Result<bool> DeletePerson(int id);
        Result<bool> Activate(int id);
        PersonDto GetPersonByID(int id);
        List<PersonDto> GetAllPersons();
    }
}
