using System;
using System.Collections.Generic;

namespace VYSA.WebApi.Services
{
    public class BaseService
    {
        public class QueryObject
        {
            public String Query { get; set; }
            public List<Object> FilterParameters { get; set; }
        }
    }
}