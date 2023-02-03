using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

using DarkUI.Forms;

using Intersect.Editor.Content;
using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Editor.Networking;
using Intersect.Enums;
using Intersect.Extensions;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.Utilities;

namespace Intersect.Editor.Forms.Editors
{

    public partial class FrmCustomEditor : EditorForm
    {

        private List<ItemBase> mChanged = new List<ItemBase>();

        private string mCopiedItem;

        private ItemBase mEditorItem;

        public FrmCustomEditor()
        {
            ApplyHooks();
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);

            lstGameObjects.Init(null, AssignEditorItem, null, null, null, null, null);
        }
        private void AssignEditorItem(Guid id)
        {
            mEditorItem = ItemBase.Get(id);
            UpdateEditor();
        }

        protected override void GameObjectUpdatedDelegate(GameObjectType type)
        {
            if (type == GameObjectType.Item)
            {
                InitEditor();
                if (mEditorItem != null && !ItemBase.Lookup.Values.Contains(mEditorItem))
                {
                    mEditorItem = null;
                    UpdateEditor();
                }
            }
            else if (type == GameObjectType.Class ||
                     type == GameObjectType.Projectile ||
                     type == GameObjectType.Animation ||
                     type == GameObjectType.Spell)
            {
                frmItem_Load(null, null);
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

        private void frmItem_Load(object sender, EventArgs e)
        {           
            InitLocalization();
            UpdateEditor();
        }

        private void InitLocalization()
        {
            Text = Strings.CustomEditor.title;
            grpVariables.Text = Strings.CustomEditor.variables;
           
           
            //Searching/Sorting
            txtSearch.Text = Strings.CustomEditor.searchplaceholder;
            

            btnSave.Text = Strings.CustomEditor.save;
            btnCancel.Text = Strings.CustomEditor.cancel;


        }

        private void UpdateEditor()
        {
            if (mEditorItem != null)
            {
                if (mChanged.IndexOf(mEditorItem) == -1)
                {
                    mChanged.Add(mEditorItem);
                    mEditorItem.MakeBackup();
                }
            }
            else
            {
            }
        }

        private void FrmItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.CurrentEditor = -1;
        }

        #region "Item List - Folders, Searching, Sorting, Etc"

        public void InitEditor()
        {
            var items = new List<KeyValuePair<Guid, KeyValuePair<string, string>>>();
            var editorTypes = Enum.GetValues(typeof(CustomEditorType));
            foreach(var editorType in editorTypes)
            {
                items.Add(new KeyValuePair<Guid, KeyValuePair<string, string>>((Guid)((CustomEditorType) editorType).GetAmbientValue(), 
                    new KeyValuePair<string, string>(((CustomEditorType)editorType).GetEnumDescription(), "")));
            }
            lstGameObjects.Repopulate(items.ToArray(), new List<string>(), false, CustomSearch(), txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            InitEditor();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = Strings.ItemEditor.searchplaceholder;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = Strings.ItemEditor.searchplaceholder;
        }

        private bool CustomSearch()
        {
            return !string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != Strings.ItemEditor.searchplaceholder;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == Strings.ItemEditor.searchplaceholder)
            {
                txtSearch.SelectAll();
            }
        }


        #endregion
    }

}
