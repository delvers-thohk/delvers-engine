using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Forms;
using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Editor.Networking;
using Intersect.Enums;
using Intersect.Extensions;
using Intersect.GameObjects;
using Intersect.Models;
using Intersect.GameObjects.Maps;
using Intersect.Editor.Maps;

namespace Intersect.Editor.Forms.Editors
{

    public partial class FrmCustomEditor : EditorForm
    {

        private List<IDatabaseObject> mChanged = new List<IDatabaseObject>();

        private CustomEditorType mEditorType = CustomEditorType.MapType;
        private IDatabaseObject mVariable;
        public FrmCustomEditor()
        {
            ApplyHooks();
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);

            mapTypePvpCombo.Items.AddRange(PopulateFromEnum<PvpType>(typeof(PvpType)));
            mapTypeNametagCombo.Items.AddRange(PopulateFromEnum<VisibilityLevel>(typeof(VisibilityLevel)));
            mapTypeLanternCombo.Items.AddRange(PopulateFromEnum<VisibilityLevel>(typeof(VisibilityLevel)));
            lstVariableType.Init(null, AssignEditorVariableType, null, null, null, null, null);
            lstVariable.Init(UpdateToolStripItems, AssignEditorVariable, toolStripItemNew_Click, null, null, null, null);
        }
        private void AssignEditorVariableType(Guid id)
        {
            mEditorType = ((CustomEditorType[])Enum.GetValues(typeof(CustomEditorType))).Where(x => (Guid)x.GetAmbientValue() == id).FirstOrDefault();
            UpdateEditor();
        }

        private void AssignEditorVariable(Guid id)
        {
            switch (mEditorType)
            {
                case CustomEditorType.MapType:
                    mapTypePanel.Visible = true;
                    break;
            }
            mVariable = LookupUtils.GetLookup(mEditorType.GetEntity()).Get(id);
            UpdateEditor();
        }

        protected override void GameObjectUpdatedDelegate(GameObjectType type)
        {
            if (type == GameObjectType.MapType)
            {
                InitEditor();
                if (mVariable != null && !MapTypeBase.Lookup.Values.Contains(mVariable))
                {
                    mVariable = null;
                    UpdateEditor();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (var item in mChanged)
            {
                item.RestoreBackup();
                item.DeleteBackup();
            }

            Hide();
            Globals.CurrentEditor = -1;
            Dispose();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Send Changed items
            foreach (var item in mChanged)
            {
                PacketSender.SendSaveObject(item);
                item.DeleteBackup();
            }

            Hide();
            Globals.CurrentEditor = -1;
            Dispose();
        }

        private void frmCustomEditor_Load(object sender, EventArgs e)
        {
            InitLocalization();
            UpdateEditor();
        }

        private void InitLocalization()
        {
            Text = Strings.CustomEditor.title;
            grpVariableType.Text = Strings.CustomEditor.variables;
            grpVariable.Text = mEditorType.GetEnumDescription();

            //Searching/Sorting
            txtVariableTypeSearch.Text = Strings.CustomEditor.searchplaceholder;
            txtVariableSearch.Text = Strings.CustomEditor.searchplaceholder;

            btnSave.Text = Strings.CustomEditor.save;
            btnCancel.Text = Strings.CustomEditor.cancel;


        }

        private void UpdateEditor()
        {
            if (mVariable != null)
            {
                switch (mEditorType)
                {
                    case CustomEditorType.MapType:
                        AssignMapTypeEditorFields();
                        break;
                }
                if (mChanged.IndexOf(mVariable) == -1)
                {
                    mChanged.Add(mVariable);
                    mVariable.MakeBackup();
                }
            }

            UpdateToolStripItems();
        }

        private void FrmItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.CurrentEditor = -1;
        }

        #region "Item List - Folders, Searching, Sorting, Etc"

        public void InitEditor()
        {
            var variableTypes = new List<KeyValuePair<Guid, KeyValuePair<string, string>>>();
            var variableTypeValues = Enum.GetValues(typeof(CustomEditorType));
            foreach (var editorType in variableTypeValues)
            {
                variableTypes.Add(new KeyValuePair<Guid, KeyValuePair<string, string>>((Guid)((CustomEditorType)editorType).GetAmbientValue(), 
                    new KeyValuePair<string, string>(((CustomEditorType)editorType).GetEnumDescription(), "")));
            }
            lstVariableType.Repopulate(variableTypes.ToArray(), new List<string>(), false, CustomSearch(txtVariableTypeSearch.Text), txtVariableTypeSearch.Text);
            var variables = LookupUtils.GetLookup(mEditorType.GetEntity()).Select(x => new KeyValuePair<Guid, KeyValuePair<string, string>>(x.Value.Id,
                new KeyValuePair<string, string>(x.Value.Name, "")));
            lstVariable.Repopulate(variables.ToArray(), new List<string>(), false, CustomSearch(txtVariableSearch.Text), txtVariableSearch.Text);
        }

        private void txtVariableTypeSearch_TextChanged(object sender, EventArgs e)
        {
            InitEditor();
        }

        private void txtVariableTypeSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVariableTypeSearch.Text))
            {
                txtVariableTypeSearch.Text = Strings.ItemEditor.searchplaceholder;
            }
        }

        private void txtVariableTypeSearch_Enter(object sender, EventArgs e)
        {
            txtVariableTypeSearch.SelectAll();
            txtVariableTypeSearch.Focus();
        }
        private void txtVariableSearch_TextChanged(object sender, EventArgs e)
        {
            InitEditor();
        }

        private void txtVariableSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVariableSearch.Text))
            {
                txtVariableSearch.Text = Strings.ItemEditor.searchplaceholder;
            }
        }

        private void txtVariableSearch_Enter(object sender, EventArgs e)
        {
            txtVariableSearch.SelectAll();
            txtVariableSearch.Focus();
        }

        private void btnClearVariableTypeSearch_Click(object sender, EventArgs e)
        {
            txtVariableTypeSearch.Text = Strings.ItemEditor.searchplaceholder;
        }

        private void btnClearVariableSearch_Click(object sender, EventArgs e)
        {
            txtVariableSearch.Text = Strings.ItemEditor.searchplaceholder;
        }

        private static bool CustomSearch(string searchText)
        {
            return !string.IsNullOrWhiteSpace(searchText) && searchText != Strings.ItemEditor.searchplaceholder;
        }

        private void txtVariableTypeSearch_Click(object sender, EventArgs e)
        {
            if (txtVariableTypeSearch.Text == Strings.ItemEditor.searchplaceholder)
            {
                txtVariableTypeSearch.SelectAll();
            }
        }

        private void txtVariableSearch_Click(object sender, EventArgs e)
        {
            if (txtVariableSearch.Text == Strings.ItemEditor.searchplaceholder)
            {
                txtVariableSearch.SelectAll();
            }
        }

        private void mapTypeNameTxt_TextChanged(object sender, EventArgs e)
        {
            mVariable.Name = mapTypeNameTxt.Text;
            lstVariable.UpdateText(mapTypeNameTxt.Text);
        }

        private void mapTypePvpCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((MapTypeBase) mVariable).PvpType = (PvpType) mapTypePvpCombo.SelectedIndex;
        }

        private void mapTypeNametagCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((MapTypeBase) mVariable).NametagVisibilityLevel = (VisibilityLevel) mapTypeNametagCombo.SelectedIndex;
        }

        private void mapTypeLanternCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((MapTypeBase) mVariable).LanternVisibilityLevel = (VisibilityLevel) mapTypeLanternCombo.SelectedIndex;
        }

        private void mapTypeItemDropCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ((MapTypeBase) mVariable).CanLoseItems = mapTypeItemDropCheckBox.Checked;
        }

        private void toolStripItemNew_Click(object sender, EventArgs e)
        {
            ;

            PacketSender.SendCreateObject(((GameObjectType[])Enum.GetValues(typeof(GameObjectType))).Where(x => x.GetGameObjectInfo() == mEditorType.GetEntity()).FirstOrDefault());
        }

        private void toolStripItemDelete_Click(object sender, EventArgs e)
        {
            if (mVariable != null && lstVariable.Focused)
            {
                if (DarkMessageBox.ShowWarning(
                        Strings.CustomEditor.deleteprompt, Strings.CustomEditor.deletetitle, DarkDialogButton.YesNo,
                        Icon
                    ) ==
                    DialogResult.Yes)
                {
                    PacketSender.SendDeleteObject(mVariable);
                }
                mapTypePanel.Visible = false;
            }
        }

        private void UpdateToolStripItems()
        {
            toolStripItemDelete.Enabled = mVariable != null && lstVariable.Focused;
        }

        #endregion
        private void AssignMapTypeEditorFields()
        {
            var mVariableCast = (MapTypeBase) mVariable;
            mapTypeNameTxt.Text = mVariableCast.Name;
            mapTypePvpCombo.SelectedIndex = ((int)mVariableCast.PvpType);
            mapTypeNametagCombo.SelectedIndex = ((int)mVariableCast.NametagVisibilityLevel);
            mapTypeLanternCombo.SelectedIndex = ((int)mVariableCast.LanternVisibilityLevel);
            mapTypeItemDropCheckBox.Checked = mVariableCast.CanLoseItems;
        }    

        private string[] PopulateFromEnum<T>(Type type) where T : Enum
        {
            return Enum.GetValues(type).Cast<T>().Select(x => x.GetEnumDescription()).ToArray();
        }
}

}
