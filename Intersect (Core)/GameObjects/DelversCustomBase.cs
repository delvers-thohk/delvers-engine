using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Intersect.Enums;
using Intersect.GameObjects.Conditions;
using Intersect.GameObjects.Events;
using Intersect.Models;
using Intersect.Utilities;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace Intersect.GameObjects
{

    public partial class DelversCustomBase : DatabaseObject<DelversCustomBase>
    {

        public DelversCustomBase()
        {
            Initialize();
        }

        [JsonConstructor]
        public DelversCustomBase(Guid id) : base(id)
        {
            Initialize();
        }    

        private void Initialize()
        {
            Name = "New Custom";
        }
    }

}
