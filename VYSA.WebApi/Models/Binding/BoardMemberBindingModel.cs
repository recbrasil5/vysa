using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VYSA.WebApi.Models.Binding
{
    public class BoardMemberBindingModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int KeyValueId { get; set; }
    }
}