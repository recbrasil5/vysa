using System.Collections.Generic;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Models.ViewModel
{
    public class PlayersFilterViewModel
    {
        public ICollection<PlayerListViewResourceModel> Players { get; set; }
        public int Count { get; set; }
    }
}