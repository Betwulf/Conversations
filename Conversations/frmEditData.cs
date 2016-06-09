using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConversationsCore.Repository;
using ConversationsCore.DataObjects;

namespace Conversations
{
    public partial class frmEditData : Form
    {
        private ConversationsRepository Rep { get; set; }

        public frmEditData()
        {
            InitializeComponent();
            Rep = new ConversationsRepository();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var obj = prgEdit.SelectedObject;
            if (obj is Character)
            {
                var chr = obj as Character;
                Rep.CharacterDB.SaveOrUpdateAsync(chr);
            }
            else if (obj is ConversationPartsList)
            {
                var parts = obj as ConversationPartsList;
                Rep.ConversationPartsDB.SaveOrUpdateAsync(parts);
            }
        }

        private void btnNewCharacter_Click(object sender, EventArgs e)
        {
            var chr = new Character();
            prgEdit.SelectedObject = chr;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            prgEdit.SelectedObject = Rep.CharacterDB.GetById(txtId.Text);
        }

        private void btnNewParts_Click(object sender, EventArgs e)
        {
            var chr = new ConversationPartsList();
            prgEdit.SelectedObject = chr;
        }
    }
}
