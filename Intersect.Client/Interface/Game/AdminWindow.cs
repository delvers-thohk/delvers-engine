using System;

using Intersect.Admin.Actions;
using Intersect.Client.Core;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects.Maps.MapList;
using static Intersect.Client.Framework.File_Management.GameContentManager;

namespace Intersect.Client.Interface.Game
{

    partial class AdminWindow
    {

        //Graphics
        public ImagePanel PanelFace;
        
        public ImagePanel FacePanel;

        private ComboBox DropdownAccess;

        private Label LabelAccess;

        //Controls
        private WindowControl mAdminWindow;

        private Button ButtonBan;

        //Windows
        BanMuteBox mBanMuteWindow;

        private CheckBox CheckboxChronological;

        private ComboBox DropdownFace;

        private Label LabelFace;

        //Player Mod Buttons
        private Button ButtonKick;

        private Button ButtonKill;

        private Label LabelChronological;

        private TreeControl mMapList;

        private Label LabelMapList;

        private Button ButtonMute;

        //Player Mod Labels
        private Label LabelName;

        //Player Mod Textboxes
        private TextBox TextboxName;

        private Button ButtonSetFace;

        private Button ButtonSetPower;

        private Button ButtonSetSprite;

        private ComboBox DropdownSprite;

        private Label LabelSprite;

        private Button ButtonUnban;

        private Button ButtonUnmute;

        private Button ButtonWarpMeTo;

        private Button ButtonWarpToMe;
        
        private Button ButtonOverworldReturn;

        private Button ButtonViewStats;
        
        private Button ButtonViewInventory;

        public ImagePanel PanelSprite;

        public ImagePanel SpritePanel;

        //Init
        public AdminWindow(Base gameCanvas)
        {
            mAdminWindow = new WindowControl(gameCanvas, Strings.Admin.title, false, nameof(AdminWindow));
            mAdminWindow.SetSize(200, 560);
            mAdminWindow.SetPosition(
                (Graphics.Renderer.ScreenWidth - mAdminWindow.Width) / 2,
                (Graphics.Renderer.ScreenHeight - mAdminWindow.Height) / 2
            );
            mAdminWindow.DisableResizing();
            mAdminWindow.Margin = Margin.Zero;
            mAdminWindow.Padding = Padding.Zero;

            LabelName = new Label(mAdminWindow, nameof(LabelName));
            LabelName.Text = Strings.Admin.name;
            TextboxName = new TextBox(mAdminWindow, nameof(TextboxName));
            Interface.FocusElements.Add(TextboxName);

            LabelAccess = new Label(mAdminWindow, nameof(LabelAccess));
            LabelAccess.Text = Strings.Admin.access;
            DropdownAccess = new ComboBox(mAdminWindow, nameof(DropdownAccess));
            DropdownAccess.AddItem(Strings.Admin.access0).UserData = "None";
            DropdownAccess.AddItem(Strings.Admin.access1).UserData = "Moderator";
            DropdownAccess.AddItem(Strings.Admin.access2).UserData = "Admin";
            ButtonSetPower = new Button(mAdminWindow, nameof(ButtonSetPower)) { Text = Strings.Admin.setpower };
            ButtonSetPower.Clicked += _setPowerButton_Clicked;

            ButtonWarpToMe = new Button(mAdminWindow, nameof(ButtonWarpToMe));
            ButtonWarpToMe.Text = Strings.Admin.warp2me;
            ButtonWarpToMe.Clicked += _warpToMeButton_Clicked;

            ButtonWarpMeTo = new Button(mAdminWindow, nameof(ButtonWarpMeTo));
            ButtonWarpMeTo.Text = Strings.Admin.warpme2;
            ButtonWarpMeTo.Clicked += _warpMeToButton_Clicked;

            ButtonOverworldReturn = new Button(mAdminWindow, nameof(ButtonOverworldReturn));
            ButtonOverworldReturn.Text = Strings.Admin.OverworldReturn;
            ButtonOverworldReturn.Clicked += _overWorldReturn_Clicked;

            ButtonKick = new Button(mAdminWindow, nameof(ButtonKick));
            ButtonKick.Text = Strings.Admin.kick;
            ButtonKick.Clicked += _kickButton_Clicked;

            ButtonKill = new Button(mAdminWindow, nameof(ButtonKill));
            ButtonKill.Text = Strings.Admin.kill;
            ButtonKill.Clicked += _killButton_Clicked;

            ButtonBan = new Button(mAdminWindow, nameof(ButtonBan));
            ButtonBan.Text = Strings.Admin.ban;
            ButtonBan.Clicked += _banButton_Clicked;

            ButtonUnban = new Button(mAdminWindow, nameof(ButtonUnban));
            ButtonUnban.Text = Strings.Admin.unban;
            ButtonUnban.Clicked += _unbanButton_Clicked;

            ButtonMute = new Button(mAdminWindow, nameof(ButtonMute));
            ButtonMute.Text = Strings.Admin.mute;
            ButtonMute.Clicked += _muteButton_Clicked;

            ButtonUnmute = new Button(mAdminWindow, nameof(ButtonUnmute));
            ButtonUnmute.Text = Strings.Admin.unmute;
            ButtonUnmute.Clicked += _unmuteButton_Clicked;

            ButtonViewStats = new Button(mAdminWindow, nameof(ButtonViewStats))
            {
                Text = Strings.Admin.stats
            };

            ButtonViewStats.SetBounds(6, 104, 80, 18);
            ButtonViewStats.Clicked += _viewStatsButton_Clicked;

            ButtonViewInventory = new Button(mAdminWindow, nameof(ButtonViewInventory))
            {
                Text = Strings.Admin.inventory,
                FontName = "sourcesanspro",
                FontSize = 8
            };

            ButtonViewInventory.SetBounds(144, 104, 50, 18);
            ButtonViewInventory.Clicked += _viewInventoryButton_Clicked;

            mAdminWindow.LoadJsonUi(UI.InGame, Graphics.Renderer.GetResolutionString(), true);

            LabelSprite = new Label(mAdminWindow, nameof(LabelSprite));
            LabelSprite.SetPosition(6, 132);
            LabelSprite.Text = Strings.Admin.sprite;
            DropdownSprite = new ComboBox(mAdminWindow, nameof(DropdownSprite));
            DropdownSprite.SetBounds(6, 148, 80, 18);
            DropdownSprite.AddItem(Strings.Admin.none);
            var sprites = Globals.ContentManager.GetTextureNames(Framework.Content.TextureType.Entity);
            Array.Sort(sprites, new AlphanumComparatorFast());
            foreach (var sprite in sprites)
            {
                DropdownSprite.AddItem(sprite);
            }
            DropdownSprite.ItemSelected += _spriteDropdown_ItemSelected;

            ButtonSetSprite = new Button(mAdminWindow, nameof(ButtonSetSprite))
            {
                Text = Strings.Admin.setsprite
            };

            ButtonSetSprite.SetBounds(6, 168, 80, 18);
            ButtonSetSprite.Clicked += _setSpriteButton_Clicked;
            PanelSprite = new ImagePanel(mAdminWindow, nameof(PanelSprite));
            PanelSprite.SetSize(50, 50);
            PanelSprite.SetPosition(115, 134);
            SpritePanel = new ImagePanel(PanelSprite);

            LabelFace = new Label(mAdminWindow, nameof(LabelFace));
            LabelFace.SetPosition(6, 192);
            LabelFace.Text = Strings.Admin.face;
            DropdownFace = new ComboBox(mAdminWindow, nameof(DropdownFace));
            DropdownFace.SetBounds(6, 208, 80, 18);
            DropdownFace.AddItem(Strings.Admin.none);
            var faces = Globals.ContentManager.GetTextureNames(Framework.Content.TextureType.Face);
            Array.Sort(faces, new AlphanumComparatorFast());
            foreach (var face in faces)
            {
                DropdownFace.AddItem(face);
            }
            DropdownFace.ItemSelected += _faceDropdown_ItemSelected;
            ButtonSetFace = new Button(mAdminWindow, nameof(ButtonSetFace))
            {
                Text = Strings.Admin.setface
            };

            ButtonSetFace.SetBounds(6, 228, 80, 18);
            ButtonSetFace.Clicked += _setFaceButton_Clicked;
            PanelFace = new ImagePanel(mAdminWindow, nameof(PanelFace));
            PanelFace.SetSize(50, 50);
            PanelFace.SetPosition(115, 194);

            LabelAccess = new Label(mAdminWindow, nameof(LabelAccess));
            LabelAccess.SetPosition(6, 252);
            LabelAccess.Text = Strings.Admin.access;

            DropdownAccess = new ComboBox(mAdminWindow, nameof(DropdownAccess));
            DropdownAccess.SetBounds(6, 268, 80, 18);
            DropdownAccess.AddItem(Strings.Admin.access0).UserData = "None";
            DropdownAccess.AddItem(Strings.Admin.access1).UserData = "Moderator";
            DropdownAccess.AddItem(Strings.Admin.access2).UserData = "Admin";

            ButtonSetPower = new Button(mAdminWindow, nameof(ButtonSetPower))
            {
                Text = Strings.Admin.setpower
            };

            ButtonSetPower.SetBounds(6, 288, 80, 18);
            ButtonSetPower.Clicked += _setPowerButton_Clicked;

            CreateMapList();
            LabelMapList = new Label(mAdminWindow, nameof(LabelMapList))
            {
                Text = Strings.Admin.maplist
            };

            LabelMapList.SetPosition(4f, 314);

            LabelMapList = new Label(mAdminWindow, nameof(LabelMapList)) { Text = Strings.Admin.maplist };
            CheckboxChronological = new CheckBox(mAdminWindow, nameof(CheckboxChronological));
            CheckboxChronological.SetToolTipText(Strings.Admin.chronologicaltip);
            CheckboxChronological.SetPosition(mAdminWindow.Width - 24, 314);
            CheckboxChronological.CheckChanged += _chkChronological_CheckChanged;
            LabelChronological = new Label(mAdminWindow, nameof(LabelChronological))
            {
                Text = Strings.Admin.chronological
            };
            LabelChronological.SetPosition(CheckboxChronological.X - 30, 314);

            CreateMapList();
            mAdminWindow.LoadJsonUi(UI.InGame, Graphics.Renderer.GetResolutionString(), true);
            UpdateMapList();
        }

        private void _spriteDropdown_ItemSelected(Base sender, ItemSelectedEventArgs arguments)
        {
            SpritePanel.Texture = Globals.ContentManager.GetTexture(
                Framework.Content.TextureType.Entity, DropdownSprite.Text);

            if (SpritePanel.Texture == null)
            {
                return;
            }

            var textFrameWidth = SpritePanel.Texture.Width / Options.Instance.Sprites.NormalFrames;
            var textFrameHeight = SpritePanel.Texture.Height / Options.Instance.Sprites.Directions;
            SpritePanel.SetTextureRect(0, 0, textFrameWidth, textFrameHeight);
            SpritePanel.SetSize(Math.Min(textFrameWidth, 46), Math.Min(textFrameHeight, 46));
            Align.Center(SpritePanel);
        }

        private void _faceDropdown_ItemSelected(Base sender, ItemSelectedEventArgs arguments)
        {
            FacePanel.Texture = Globals.ContentManager.GetTexture(
                Framework.Content.TextureType.Face, DropdownFace.Text);

            if (FacePanel.Texture == null)
            {
                return;
            }

            var textFrameWidth = FacePanel.Texture.Width;
            var textFrameHeight = FacePanel.Texture.Height;
            FacePanel.SetTextureRect(0, 0, textFrameWidth, textFrameHeight);
            FacePanel.SetSize(Math.Min(textFrameWidth, 46), Math.Min(textFrameHeight, 46));
            Align.Center(FacePanel);
        }

        //Methods
        public void SetName(string name)
        {
            TextboxName.Text = name;
        }

        private void CreateMapList()
        {
            mMapList = new TreeControl(mAdminWindow);
            mMapList.SetPosition(4f, 330);
            mMapList.Width = mAdminWindow.Width - 8;
            mMapList.Height = 80;
            mMapList.RenderColor = Color.FromArgb(255, 255, 255, 255);
            mMapList.MaximumSize = new Point(4096, 999999);
        }

        public void UpdateMapList()
        {
            mMapList.Dispose();
            CreateMapList();
            AddMapListToTree(MapList.List, null);
        }

        private void AddMapListToTree(MapList mapList, TreeNode parent)
        {
            TreeNode tmpNode;
            if (CheckboxChronological.IsChecked)
            {
                for (var i = MapList.OrderedMaps.Count - 1; i >= 0; i--)
                {
                    tmpNode = mMapList.AddNode(MapList.OrderedMaps[i].Name);
                    tmpNode.UserData = MapList.OrderedMaps[i].MapId;
                    tmpNode.DoubleClicked += tmpNode_DoubleClicked;
                    tmpNode.Clicked += tmpNode_DoubleClicked;
                }
            }
            else
            {
                foreach (var item in mapList.Items)
                {
                    switch (item)
                    {
                        case MapListFolder folder:
                            tmpNode = parent?.AddNode(item.Name) ?? mMapList.AddNode(item.Name);
                            tmpNode.UserData = folder;
                            AddMapListToTree(folder.Children, tmpNode);
                            break;
                        case MapListMap map:
                            tmpNode = parent?.AddNode(item.Name) ?? mMapList.AddNode(item.Name);
                            tmpNode.UserData = map.MapId;
                            tmpNode.DoubleClicked += tmpNode_DoubleClicked;
                            tmpNode.Clicked += tmpNode_DoubleClicked;
                            break;
                    }
                }
            }
        }

        void _kickButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(new KickAction(TextboxName.Text));
            }
        }

        void _killButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(new KillAction(TextboxName.Text));
            }
        }

        void _warpToMeButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(new WarpToMeAction(TextboxName.Text));
            }
        }

        void _warpMeToButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(new WarpMeToAction(TextboxName.Text));
            }
        }

        void _overWorldReturn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (!string.IsNullOrEmpty(TextboxName.Text))
            {
                PacketSender.SendAdminAction(new ReturnToOverworldAction(TextboxName.Text));
            }
        }

        void _muteButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                mBanMuteWindow = new BanMuteBox(Strings.Admin.mutecaption.ToString(TextboxName.Text),
                    Strings.Admin.muteprompt.ToString(TextboxName.Text), true, MuteUser);
            }
        }

        void MuteUser(object sender, EventArgs e)
        {
            PacketSender.SendAdminAction(new MuteAction(TextboxName.Text, mBanMuteWindow.GetDuration(),
                mBanMuteWindow.GetReason(), mBanMuteWindow.BanIp()));

            mBanMuteWindow.Dispose();
        }

        void BanUser(object sender, EventArgs e)
        {
            PacketSender.SendAdminAction(new BanAction(TextboxName.Text, mBanMuteWindow.GetDuration(),
                mBanMuteWindow.GetReason(), mBanMuteWindow.BanIp()));

            mBanMuteWindow.Dispose();
        }

        void _banButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (string.IsNullOrWhiteSpace(TextboxName.Text))
            {
                return;
            }

            var name = TextboxName.Text.Trim();

            if (string.Equals(name, Globals.Me.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            mBanMuteWindow = new BanMuteBox(Strings.Admin.bancaption.ToString(name),
                Strings.Admin.banprompt.ToString(TextboxName.Text), true, BanUser);
        }

        private void _setFaceButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(new SetFaceAction(TextboxName.Text, DropdownFace.Text));
            }
        }

        void _unmuteButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                new InputBox(Strings.Admin.unmutecaption.ToString(TextboxName.Text),
                    Strings.Admin.unmuteprompt.ToString(TextboxName.Text), true, InputBox.InputType.YesNo, UnmuteUser,
                    null, -1);
            }
        }

        void _unbanButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                new InputBox(Strings.Admin.unbancaption.ToString(TextboxName.Text),
                    Strings.Admin.unbanprompt.ToString(TextboxName.Text), true, InputBox.InputType.YesNo, UnbanUser,
                    null, -1);
            }
        }
        void _viewStatsButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(new ViewStatsAction(TextboxName.Text));
            }
        }

        void _viewInventoryButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
            }
        }

        void UnmuteUser(object sender, EventArgs e)
        {
            PacketSender.SendAdminAction(new UnmuteAction(TextboxName.Text));
        }

        void UnbanUser(object sender, EventArgs e)
        {
            PacketSender.SendAdminAction(new UnbanAction(TextboxName.Text));
        }

        void _setSpriteButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(new SetSpriteAction(TextboxName.Text, DropdownSprite.Text));
            }
        }

        void _setPowerButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (TextboxName.Text.Trim().Length > 0)
            {
                PacketSender.SendAdminAction(
                    new SetAccessAction(TextboxName.Text, DropdownAccess.SelectedItem.UserData.ToString())
                );
            }
        }

        void _chkChronological_CheckChanged(Base sender, EventArgs arguments)
        {
            UpdateMapList();
        }

        static void tmpNode_DoubleClicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendAdminAction(new WarpToMapAction((Guid) ((TreeNode) sender).UserData));
        }

        public void Update()
        {
        }

        public void Show()
        {
            mAdminWindow.IsHidden = false;
        }

        public bool IsVisible()
        {
            return !mAdminWindow.IsHidden;
        }

        public void Hide()
        {
            mAdminWindow.IsHidden = true;
        }
    }
}
