using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDBJ
{
    public partial class ShowLogForm : Form
    {
        public ShowLogForm()
        {
            InitializeComponent();
        }



        public void UpdataLog(string text)
        {
            this.BeginInvoke((Action)(() =>
            {
                listviewLog1.ShowLog(text);
            })
                           );
        }
    }
}
