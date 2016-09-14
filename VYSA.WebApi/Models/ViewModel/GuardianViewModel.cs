using System.Collections.Generic;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Models.ViewModel
{
    public class GuardiansViewModel
    {
        public IEnumerable<GuardianResourceModel> Guardians { get; set; }
    }
}