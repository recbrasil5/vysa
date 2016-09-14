using System.Collections.Generic;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Models.ViewModel
{
    public class RosteredPlayerFilterViewModel
    {
        public ICollection<RosteredPlayerResourceModel> Roster { get; set; }
        public int Count { get; set; }
    }
}