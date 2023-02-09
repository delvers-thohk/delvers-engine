using MessagePack;
using System;

namespace Intersect.Network.Packets.Server
{
    [MessagePackObject]
    public partial class EquipmentFragment
    {
        [Key(0)]
        public string Name { get; set; }

        [Key(1)]
        public Color RenderColor { get; set; }
    }

    [MessagePackObject]
    public partial class CharacterPacket : IntersectPacket
    {
        //Parameterless Constructor for MessagePack
        public CharacterPacket()
        {
        }

        public CharacterPacket(
            Guid id,
            string name,
            string sprite,
            string hair,
            string face,
            int level,
            string className,
            EquipmentFragment[] equipment
        )
        {
            Id = id;
            Name = name;
            Sprite = sprite;
            Hair = hair;
            Face = face;
            Level = level;
            ClassName = className;
            Equipment = equipment;
        }

        [Key(0)]
        public Guid Id { get; set; }

        [Key(1)]
        public string Name { get; set; }

        [Key(2)]
        public string Sprite { get; set; }

        [Key(3)]
        public string Hair { get; set; }

        [Key(4)]
        public string Face { get; set; }

        [Key(5)]
        public int Level { get; set; }

        [Key(6)]
        public string ClassName { get; set; }

        [Key(7)]
        public EquipmentFragment[] Equipment { get; set; }

    }

}
