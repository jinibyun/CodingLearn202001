using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithAspnetCore.Dto
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class SwaggerParameterAttribute : Attribute
    {
        public SwaggerParameterAttribute(string name, string description)
        {
            Name = name;
            ParameterType = description;
        }

        public string Name { get; private set; }
        public string DataType { get; set; }
        public string ParameterType { get; set; }
        public string Description { get; private set; }
        public bool Required { get; set; } = false;
    }
}
