using System.Collections.Generic;

using static Velocity_Rent.Map.Controls.ucSuggestionItem;

namespace Velocity_Rent.Map
{
    public class SuggestionGroup
    {
        public string Title { get; set; }
        public List<SuggestionItem> Items {  get; set; }
    }
}
