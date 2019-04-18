using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Security
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public sealed class ApiDemandAttribute : Attribute
    {
        public ApiDemandAttribute(string demand)
        {
            Demand = demand;
        }

        public string Demand { get; private set; }
    }
}