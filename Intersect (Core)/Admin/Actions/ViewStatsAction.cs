using Intersect.Enums;
using MessagePack;

namespace Intersect.Admin.Actions
{
    [MessagePackObject]
    public partial class ViewStatsAction : AdminAction
    {
        //Parameterless Constructor for MessagePack
        public ViewStatsAction()
        {

        }

        public ViewStatsAction(string name)
        {
            Name = name;
        }

        [Key(1)]
        public override Enums.AdminAction Action { get; } = Enums.AdminAction.ViewStats;

        [Key(2)]
        public string Name { get; set; }

    }

}
