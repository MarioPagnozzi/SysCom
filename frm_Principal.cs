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
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var rectangle = Screen.FromControl(this).Bounds;
            Size = new Size(rectangle.Width, rectangle.Height);
            Location = new Point(0, 0);
            Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size(workingRectangle.Width, workingRectangle.Height);
            pnl_Menu.Width = 250;
        }

        protected virtual void btn_Sair(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected virtual void recolher_expande_menu(object sender, EventArgs e)
        {
            if (pnl_Menu.Width == 250)
            {
                pnl_Menu.Width = 70;
                img_logo1.Visible = false;
                img_recolher.Visible = false;
                img_expandir.Visible = true;
                img_logo2.Visible = true;
                panel1.Visible = false;
                img_arremate.Visible = false;
            }
            else
            {
                pnl_Menu.Width = 250;
                img_expandir.Visible = false;
                img_recolher.Visible = true;
                img_logo1.Visible = true;
                img_logo2.Visible = false;
                panel1.Visible = true;
                img_arremate.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Deseja encerrar o sistema ?","Encerramento do Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btn_Sair(sender, e);
            }
        }

        private void img_recolher_Click(object sender, EventArgs e)
        {
            this.recolher_expande_menu(sender, e);
        }
    }
}
