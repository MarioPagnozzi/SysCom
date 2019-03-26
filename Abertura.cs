using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace SYSCom
{
    public partial class Abertura : SplashScreen
    {
        int Value = 0;
        int Maximum = 100;
        int Minimum = 0;

        public Abertura()
        {
            InitializeComponent();
           
        }

       

        private void Abertura_Load(object sender, EventArgs e)
        {
         
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = CarregamentoSistema.Mensagem;
            progressBarControl1.Increment(CarregamentoSistema.Incremento);

        }
    }
}
