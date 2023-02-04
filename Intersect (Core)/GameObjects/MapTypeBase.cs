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

    public partial class MapTypeBase : DatabaseObject<MapTypeBase>
    {
        [Column("LanternVisibilityLevel")]
        public VisibilityLevel LanternVisibilityLevel { get; set; }

        [Column("NametagVisibilityLevel")]
        public VisibilityLevel NametagVisibilityLevel { get; set; }

        [Column("PvpType")]
        public PvpType PvpType { get; set; }

        [Column("CanLoseItems")] 
        public bool CanLoseItems { get; set; }

        public MapTypeBase()
        {
            Initialize();
        }

        [JsonConstructor]
        public MapTypeBase(Guid id) : base(id)
        {
            Initialize();
        }    

        private void Initialize()
        {
            Name = "New Map Type";
            LanternVisibilityLevel = VisibilityLevel.All;
            NametagVisibilityLevel = VisibilityLevel.All;
            PvpType = PvpType.Disabled;
            CanLoseItems = false;
        }
    }

}
