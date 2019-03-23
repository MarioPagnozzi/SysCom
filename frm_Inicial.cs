using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYSCom
{
    public partial class frm_Inicial : Form
    {
        public frm_Inicial()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void frm_Inicial_Load(object sender, EventArgs e)
        {
            lbl_DiaSemana.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
        }
    }
}
