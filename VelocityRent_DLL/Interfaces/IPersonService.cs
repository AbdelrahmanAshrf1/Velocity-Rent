using DTO.Person;
using System.Collections.Generic;

namespace VelocityRent_DLL.Interfaces
{
    public interface IPersonService
    {
        Result<int> CreatePerson(CreatePersonRequest request);
        Result<bool> UpdatePerson(UpdatePersonRequest request);
        Result<bool> DeletePerson(int id);
        Result<bool> Activate(int id);
        PersonDto GetPersonByID(int id);
        List<PersonDto> GetAllPersons();
    }
}
