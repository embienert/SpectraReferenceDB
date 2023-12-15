using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SpectraReferenceDB {
    public partial class OpenDatDialog : Form {
        public OpenDatDialog() {
            InitializeComponent();
            Point cursorPos = MousePosition;
            Location = new Point(cursorPos.X - Width / 2, cursorPos.Y - Height / 2);
        }

        private void SUser_CheckedChanged(object sender, EventArgs e) {
            ENumHeaderRows.Enabled = SUser.Checked;
        }

        public bool isAutomatic() {
            return SAutomatic.Checked;
        }

        public bool isUser() {
            return SUser.Checked;
        }

        public int getValue() {
            return Convert.ToInt32(ENumHeaderRows.Value);
        }
    }
}
