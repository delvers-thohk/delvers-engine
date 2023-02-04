using MessagePack;

namespace Intersect.Network.Packets.Server
{
    [MessagePackObject]
    public partial class PlayerStatsPacket : EntityPacket
    {
        //Parameterless Constructor for MessagePack
        public PlayerStatsPacket()
        {
        }

    }

}
