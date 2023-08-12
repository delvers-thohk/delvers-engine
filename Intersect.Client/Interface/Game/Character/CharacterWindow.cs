using System;
using System.Collections.Generic;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Network.Packets.Server;
using Intersect.Client.Entities;

namespace Intersect.Client.Interface.Game.Character
{

    public partial class CharacterWindow
    {

        //Equipment List
        public List<EquipmentItem> Items = new List<EquipmentItem>();

        Label mAbilityPwrLabel;

        Button mAddAbilityPwrBtn;

        Button mAddAttackBtn;

        Button mAddDefenseBtn;

        Button mAddMagicResistBtn;

        Button mAddSpeedBtn;

        //Stats
        Label mAttackLabel;

        private ImagePanel mCharacterContainer;

        private Label mCharacterLevelAndClass;

        private Label mCharacterName;

        private ImagePanel mCharacterPortrait;

        private string mCharacterPortraitImg = "";

        //Controls
        private WindowControl mCharacterWindow;

        private string mCurrentSprite = "";

        Label mDefenseLabel;

        private ItemProperties mItemProperties = null;

        Label mMagicRstLabel;

        Label mPointsLabel;

        Label mSpeedLabel;

        public ImagePanel[] PaperdollPanels;

        public string[] PaperdollTextures;

        //Location
        public int X;

        public int Y;

        //Extra Buffs
        ClassBase mPlayer;

        Label mHpRegen;

        int HpRegenAmount;

        Label mManaRegen;

        int ManaRegenAmount;

        Label mLifeSteal;

        int LifeStealAmount = 0;

        Label mAttackSpeed;

        Label mExtraExp;

        int ExtraExpAmount = 0;

        Label mLuck;

        int LuckAmount = 0;

        Label mTenacity;

        int TenacityAmount = 0;

        Label mCooldownReduction;

        int CooldownAmount = 0;

        Label mManaSteal;

        int ManaStealAmount = 0;
        Player Player = Globals.Me;

        //Init
        public CharacterWindow(Canvas gameCanvas)
        {
            mCharacterWindow = new WindowControl(gameCanvas, Strings.Character.title, false, "CharacterWindow");
            mCharacterWindow.DisableResizing();

            mCharacterName = new Label(mCharacterWindow, "CharacterNameLabel");
            mCharacterName.SetTextColor(Color.White, Label.ControlState.Normal);

            mCharacterLevelAndClass = new Label(mCharacterWindow, "ChatacterInfoLabel");
            mCharacterLevelAndClass.SetText("");

            mCharacterContainer = new ImagePanel(mCharacterWindow, "CharacterContainer");

            mCharacterPortrait = new ImagePanel(mCharacterContainer);

            PaperdollPanels = new ImagePanel[Options.EquipmentSlots.Count + 1];
            PaperdollTextures = new string[Options.EquipmentSlots.Count + 1];
            for (var i = 0; i <= Options.EquipmentSlots.Count; i++)
            {
                PaperdollPanels[i] = new ImagePanel(mCharacterContainer);
                PaperdollTextures[i] = "";
                PaperdollPanels[i].Hide();
            }

            var equipmentLabel = new Label(mCharacterWindow, "EquipmentLabel");
            equipmentLabel.SetText(Strings.Character.equipment);

            var statsLabel = new Label(mCharacterWindow, "StatsLabel");
            statsLabel.SetText(Strings.Character.stats);

            mAttackLabel = new Label(mCharacterWindow, "AttackLabel");

            mAddAttackBtn = new Button(mCharacterWindow, "IncreaseAttackButton");
            mAddAttackBtn.Clicked += _addAttackBtn_Clicked;

            mDefenseLabel = new Label(mCharacterWindow, "DefenseLabel");
            mAddDefenseBtn = new Button(mCharacterWindow, "IncreaseDefenseButton");
            mAddDefenseBtn.Clicked += _addDefenseBtn_Clicked;

            mSpeedLabel = new Label(mCharacterWindow, "SpeedLabel");
            mAddSpeedBtn = new Button(mCharacterWindow, "IncreaseSpeedButton");
            mAddSpeedBtn.Clicked += _addSpeedBtn_Clicked;

            mAbilityPwrLabel = new Label(mCharacterWindow, "AbilityPowerLabel");
            mAddAbilityPwrBtn = new Button(mCharacterWindow, "IncreaseAbilityPowerButton");
            mAddAbilityPwrBtn.Clicked += _addAbilityPwrBtn_Clicked;

            mMagicRstLabel = new Label(mCharacterWindow, "MagicResistLabel");
            mAddMagicResistBtn = new Button(mCharacterWindow, "IncreaseMagicResistButton");
            mAddMagicResistBtn.Clicked += _addMagicResistBtn_Clicked;

            mPointsLabel = new Label(mCharacterWindow, "PointsLabel");

            for (var i = 0; i < Options.EquipmentSlots.Count; i++)
            {
                Items.Add(new EquipmentItem(i, mCharacterWindow));
                Items[i].Pnl = new ImagePanel(mCharacterWindow, "EquipmentItem" + i);
                Items[i].Setup();
            }

            var extraBuffsLabel = new Label(mCharacterWindow, "ExtraBuffsLabel");
            extraBuffsLabel.SetText(Strings.Character.ExtraBuffs);

            mHpRegen = new Label(mCharacterWindow, "HpRegen");
            mManaRegen = new Label(mCharacterWindow, "ManaRegen");
            mLifeSteal = new Label(mCharacterWindow, "Lifesteal");
            mAttackSpeed = new Label(mCharacterWindow, "AttackSpeed");
            mExtraExp = new Label(mCharacterWindow, "ExtraExp");
            mLuck = new Label(mCharacterWindow, "Luck");
            mTenacity = new Label(mCharacterWindow, "Tenacity");
            mCooldownReduction = new Label(mCharacterWindow, "CooldownReduction");
            mManaSteal = new Label(mCharacterWindow, "Manasteal");

            mCharacterWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        //Update Button Event Handlers
        void _addMagicResistBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendUpgradeStat((int) Stat.MagicResist);
        }

        void _addAbilityPwrBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendUpgradeStat((int) Stat.AbilityPower);
        }

        void _addSpeedBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendUpgradeStat((int) Stat.Speed);
        }

        void _addDefenseBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendUpgradeStat((int) Stat.Defense);
        }

        void _addAttackBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendUpgradeStat((int) Stat.Attack);
        }

        //Methods
        public void Update()
        {
            if (mCharacterWindow.IsHidden)
            {
                return;
            }

            mCharacterName.Text = Player.Name;
            mCharacterLevelAndClass.Text = Strings.Character.levelandclass.ToString(
                Player.Level, ClassBase.GetName(Player.Class)
            );

            //Load Portrait
            //UNCOMMENT THIS LINE IF YOU'D RATHER HAVE A FACE HERE GameTexture faceTex = Globals.ContentManager.GetTexture(Framework.Content.TextureType.Face, Player.Face);
            var entityTex = Globals.ContentManager.GetTexture(
                Framework.Content.TextureType.Entity, Player.Sprite
            );

            /* UNCOMMENT THIS BLOCK IF YOU"D RATHER HAVE A FACE HERE if (Player.Face != "" && Player.Face != _currentSprite && faceTex != null)
             {
                 _characterPortrait.Texture = faceTex;
                 _characterPortrait.SetTextureRect(0, 0, faceTex.GetWidth(), faceTex.GetHeight());
                 _characterPortrait.SizeToContents();
                 Align.Center(_characterPortrait);
                 _characterPortrait.IsHidden = false;
                 for (int i = 0; i < Options.EquipmentSlots.Count; i++)
                 {
                     _paperdollPanels[i].Hide();
                 }
             }
             else */
            if (!string.IsNullOrWhiteSpace(Player.Sprite) && Player.Sprite != mCurrentSprite && entityTex != null)
            {
                for (var z = 0; z < Options.PaperdollOrder[1].Count; z++)
                {
                    var paperdoll = "";
                    if (Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z]) > -1)
                    {
                        var equipment = Player.MyEquipment;
                        if (equipment[Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z])] > -1 &&
                            equipment[Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z])] <
                            Options.MaxInvItems)
                        {
                            var itemNum = Player
                                .Inventory[equipment[Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z])]]
                                .ItemId;

                            if (ItemBase.TryGet(itemNum, out var itemDescriptor))
                            {
                                paperdoll = Player.Gender == 0
                                    ? itemDescriptor.MalePaperdoll : itemDescriptor.FemalePaperdoll;
                                PaperdollPanels[z].RenderColor = itemDescriptor.Color;
                            }
                        }
                    }
                    else if (Options.PaperdollOrder[1][z] == "Player")
                    {
                        PaperdollPanels[z].Show();
                        PaperdollPanels[z].Texture = entityTex;
                        PaperdollPanels[z].SetTextureRect(0, 0, entityTex.GetWidth() / Options.Instance.Sprites.NormalFrames, entityTex.GetHeight() / Options.Instance.Sprites.Directions);
                        PaperdollPanels[z].SizeToContents();
                        PaperdollPanels[z].RenderColor = Player.Color;
                        Align.Center(PaperdollPanels[z]);
                    }

                    if (string.IsNullOrWhiteSpace(paperdoll) && !string.IsNullOrWhiteSpace(PaperdollTextures[z]) && Options.PaperdollOrder[1][z] != "Player")
                    {
                        PaperdollPanels[z].Texture = null;
                        PaperdollPanels[z].Hide();
                        PaperdollTextures[z] = "";
                    }
                    else if (paperdoll != "" && paperdoll != PaperdollTextures[z])
                    {

                        var paperdollTex = Globals.ContentManager.GetTexture(
                            Framework.Content.TextureType.Paperdoll, paperdoll
                        );

                        PaperdollPanels[z].Texture = paperdollTex;
                        if (paperdollTex != null)
                        {
                            PaperdollPanels[z]
                                .SetTextureRect(
                                    0, 0, PaperdollPanels[z].Texture.GetWidth() / Options.Instance.Sprites.NormalFrames,
                                    PaperdollPanels[z].Texture.GetHeight() / Options.Instance.Sprites.Directions
                                );

                            PaperdollPanels[z]
                                .SetSize(
                                    PaperdollPanels[z].Texture.GetWidth() / Options.Instance.Sprites.NormalFrames,
                                    PaperdollPanels[z].Texture.GetHeight() / Options.Instance.Sprites.Directions
                                );

                            PaperdollPanels[z]
                                .SetPosition(
                                    mCharacterContainer.Width / 2 - PaperdollPanels[z].Width / 2,
                                    mCharacterContainer.Height / 2 - PaperdollPanels[z].Height / 2
                                );
                        }

                        PaperdollPanels[z].Show();
                        PaperdollTextures[z] = paperdoll;
                    }
                    else if (string.Equals("Helmet", Options.PaperdollOrder[1][z], StringComparison.Ordinal) && String.IsNullOrEmpty(paperdoll) && !String.IsNullOrEmpty(Player.Hair))
                        {
                        var paperdollTex = Globals.ContentManager.GetTexture(
                            Framework.Content.TextureType.Paperdoll, Player.Hair
                        );

                        PaperdollPanels[z].Texture = paperdollTex;
                        if (paperdollTex != null)
                        {
                            PaperdollPanels[z]
                                .SetTextureRect(
                                    0, 0, PaperdollPanels[z].Texture.GetWidth() / Options.Instance.Sprites.NormalFrames,
                                    PaperdollPanels[z].Texture.GetHeight() / Options.Instance.Sprites.Directions
                                );

                            PaperdollPanels[z]
                                .SetSize(
                                    PaperdollPanels[z].Texture.GetWidth() / Options.Instance.Sprites.NormalFrames,
                                    PaperdollPanels[z].Texture.GetHeight() / Options.Instance.Sprites.Directions
                                );

                            PaperdollPanels[z]
                                .SetPosition(
                                    mCharacterContainer.Width / 2 - PaperdollPanels[z].Width / 2,
                                    mCharacterContainer.Height / 2 - PaperdollPanels[z].Height / 2
                                );
                        }

                        PaperdollPanels[z].Show();
                        PaperdollTextures[z] = paperdoll;
                    }
                }
            }
            else if (Player.Sprite != mCurrentSprite && Player.Face != mCurrentSprite)
            {
                mCharacterPortrait.IsHidden = true;
                for (var i = 0; i < Options.EquipmentSlots.Count; i++)
                {
                    PaperdollPanels[i].Hide();
                }
            }

            mAttackLabel.SetText(
                Strings.Character.stat0.ToString(Strings.Combat.stat0, Player.Stat[(int) Stat.Attack])
            );

            mDefenseLabel.SetText(
                Strings.Character.stat2.ToString(Strings.Combat.stat2, Player.Stat[(int) Stat.Defense])
            );

            mSpeedLabel.SetText(
                Strings.Character.stat4.ToString(Strings.Combat.stat4, Player.Stat[(int) Stat.Speed])
            );

            mAbilityPwrLabel.SetText(
                Strings.Character.stat1.ToString(Strings.Combat.stat1, Player.Stat[(int) Stat.AbilityPower])
            );

            mMagicRstLabel.SetText(
                Strings.Character.stat3.ToString(Strings.Combat.stat3, Player.Stat[(int) Stat.MagicResist])
            );

            mPointsLabel.SetText(Strings.Character.points.ToString(Player.StatPoints));
            mAddAbilityPwrBtn.IsHidden = Player.StatPoints == 0 ||
                                         Player.Stat[(int) Stat.AbilityPower] == Options.MaxStatValue;

            mAddAttackBtn.IsHidden =
                Player.StatPoints == 0 || Player.Stat[(int) Stat.Attack] == Options.MaxStatValue;

            mAddDefenseBtn.IsHidden = Player.StatPoints == 0 ||
                                      Player.Stat[(int) Stat.Defense] == Options.MaxStatValue;

            mAddMagicResistBtn.IsHidden = Player.StatPoints == 0 ||
                                          Player.Stat[(int) Stat.MagicResist] == Options.MaxStatValue;

            mAddSpeedBtn.IsHidden =
                Player.StatPoints == 0 || Player.Stat[(int) Stat.Speed] == Options.MaxStatValue;

            UpdateExtraBuffs();

            for (var i = 0; i < Options.EquipmentSlots.Count; i++)
            {
                if (Player.MyEquipment[i] > -1 && Player.MyEquipment[i] < Options.MaxInvItems)
                {
                    if (Player.Inventory[Player.MyEquipment[i]].ItemId != Guid.Empty)
                    {
                        Items[i]
                            .Update(
                                Player.Inventory[Player.MyEquipment[i]].ItemId,
                                Player.Inventory[Player.MyEquipment[i]].ItemProperties
                            );

                        UpdateExtraBuffs(Player.Inventory[Player.MyEquipment[i]].ItemId);
                    }
                    else
                    {
                        Items[i].Update(Guid.Empty, mItemProperties);
                    }
                }
                else
                {
                    Items[i].Update(Guid.Empty, mItemProperties);
                }
            }
        }

        /// <summary>
        /// Update Extra Buffs Effects like hp/mana regen and items effect types
        /// </summary>
        public void UpdateExtraBuffs()
        {
            mPlayer = ClassBase.Get(Player?.Class ?? Guid.Empty);

            //Getting HP and Mana Regen
            if (mPlayer != null)
            {
                HpRegenAmount = mPlayer.VitalRegen[0];
                mHpRegen.SetText(Strings.Character.HealthRegen.ToString(HpRegenAmount));
                ManaRegenAmount = mPlayer.VitalRegen[1];
                mManaRegen.SetText(Strings.Character.ManaRegen.ToString(ManaRegenAmount));
            }

            CooldownAmount = 0;
            LifeStealAmount = 0;
            TenacityAmount = 0;
            LuckAmount = 0;
            ExtraExpAmount = 0;
            ManaStealAmount = 0;

            mLifeSteal.SetText(Strings.Character.Lifesteal.ToString(0));
            mExtraExp.SetText(Strings.Character.ExtraExp.ToString(0));
            mLuck.SetText(Strings.Character.Luck.ToString(0));
            mTenacity.SetText(Strings.Character.Tenacity.ToString(0));
            mCooldownReduction.SetText(Strings.Character.CooldownReduction.ToString(0));
            mManaSteal.SetText(Strings.Character.Manasteal.ToString(0));

            mAttackSpeed.SetText(Strings.Character.AttackSpeed.ToString(Player.CalculateAttackTime() / 1000f));
        }

        /// <summary>
        /// Update Extra Buffs Effects like hp/mana regen and items effect types
        /// </summary>
        /// <param name="itemId">Id of item to update extra buffs</param>
        public void UpdateExtraBuffs(Guid itemId)
        {
            var item = ItemBase.Get(itemId);

            if (item == null)
            {
                return;
            }

            //Getting HP and Mana Regen
            if (item.VitalsRegen[0] != 0)
            {
                HpRegenAmount += item.VitalsRegen[0];
                mHpRegen?.SetText(Strings.Character.HealthRegen.ToString(HpRegenAmount));
            }

            if (item.VitalsRegen[1] != 0)
            {
                ManaRegenAmount += item.VitalsRegen[1];
                mManaRegen?.SetText(Strings.Character.ManaRegen.ToString(ManaRegenAmount));
            }

            //Getting extra buffs
            if (item.Effects.Find(effect => effect.Type != ItemEffect.None && effect.Percentage > 0) != default)
            {
                foreach(var effect in item.Effects)
                {
                    if (effect.Percentage <= 0)
                    {
                        continue;
                    }

                    switch (effect.Type)
                    {
                        case ItemEffect.CooldownReduction:
                            CooldownAmount += effect.Percentage;
                            mCooldownReduction?.SetText(Strings.Character.CooldownReduction.ToString(CooldownAmount));

                            break;
                        case ItemEffect.Lifesteal:
                            LifeStealAmount += effect.Percentage;
                            mLifeSteal?.SetText(Strings.Character.Lifesteal.ToString(LifeStealAmount));

                            break;
                        case ItemEffect.Tenacity:
                            TenacityAmount += effect.Percentage;
                            mTenacity?.SetText(Strings.Character.Tenacity.ToString(TenacityAmount));

                            break;
                        case ItemEffect.Luck:
                            LuckAmount += effect.Percentage;
                            mLuck?.SetText(Strings.Character.Luck.ToString(LuckAmount));

                            break;
                        case ItemEffect.EXP:
                            ExtraExpAmount += effect.Percentage;
                            mExtraExp?.SetText(Strings.Character.ExtraExp.ToString(ExtraExpAmount));

                            break;
                        case ItemEffect.Manasteal:
                            ManaStealAmount += effect.Percentage;
                            mManaSteal?.SetText(Strings.Character.Manasteal.ToString(ManaStealAmount));

                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Show the window
        /// </summary>
        public void Show()
        {
            mCharacterWindow.IsHidden = false;
        }

        /// <summary>
        /// </summary>
        /// <returns>Returns if window is visible</returns>
        public bool IsVisible()
        {
            return !mCharacterWindow.IsHidden;
        }

        /// <summary>
        /// Hide the window
        /// </summary>
        public void Hide()
        {
            mCharacterWindow.IsHidden = true;
        }

        /// <summary>
        /// Sets player
        /// </summary>
        /// <param name="player"></param>
        public void SetPlayer(Player player = null)
        {
            Player = player;
        }
    }

}
