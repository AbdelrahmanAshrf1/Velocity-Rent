using DTO;
using DTO.Person;
using Riok.Mapperly.Abstractions;
using VelocityRent.Entities;

namespace VelocityRent_DLL.Mappers
{
    [Mapper]
    public partial class PersonMapper
    {
        public partial PersonDto ToDto(Person person);
        public partial Person ToEntity(AddPersonDto dto);
    }
}
