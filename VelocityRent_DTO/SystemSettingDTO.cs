using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SystemSettingDTO
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public SystemSettingDTO(int iD, string name, string value)
        {
            ID = iD;
            Name = name;
            Value = value;
        }
    }
}
