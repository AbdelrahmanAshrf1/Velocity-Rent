using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SystemSettingDto
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
