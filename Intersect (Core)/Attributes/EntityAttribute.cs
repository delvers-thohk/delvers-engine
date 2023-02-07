using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intersect.Models;

namespace Intersect.Attributes
{
    public class EntityAttribute : Attribute
    {
        public Type type;
        public EntityAttribute(Type type)
        {
            this.type = type;
        }
    }
}
