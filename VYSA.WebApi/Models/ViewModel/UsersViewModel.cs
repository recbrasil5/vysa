using System.Collections.Generic;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Models.ViewModel
{
    public class UsersViewModel
    {
        public ICollection<UserResourceModel> Users { get; set; }
        public int Count { get; set; }
    }
}