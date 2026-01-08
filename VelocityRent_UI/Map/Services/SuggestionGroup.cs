using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velocity_Rent.Map.Controls;
using static Velocity_Rent.Map.Controls.ucSuggestionItem;

namespace Velocity_Rent.Map
{
    public class SuggestionGroup
    {
        public string Title { get; set; }
        public List<SuggestionItem> Items {  get; set; }
    }
}
