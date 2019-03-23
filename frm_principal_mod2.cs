using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System.Composition;
using System.Composition.Hosting;
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace SYSCom
{
    
    public partial class frm_principal_mod2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_principal_mod2()
        {
            Abertura abertura = new Abertura();

            abertura.Show();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
            }
            abertura.Close();

            InitializeComponent();
            carrega_form(new frm_Inicial());
            header_diahora(false);
        }

        private void ribbon_MinimizedChanged(object sender, EventArgs e)
        {
           
        }

        protected virtual void fechar_app(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            var result = XtraMessageBox.Show("Deseja encerrar o sistema ?", "Encerramento Sistema", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                fechar_app(sender, e);
            }

        }

        public void carrega_form(object formChamado)
        {
            if (this.mdi_Panel.Controls.Count > 0)
            {
                this.mdi_Panel.Controls.RemoveAt(0);
            }
            Form fh = formChamado as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.mdi_Panel.Controls.Add(fh);
            this.mdi_Panel.Tag = fh;
            fh.Show();
        }

        private void frm_principal_mod2_Load(object sender, EventArgs e)
        {
            header_Usuario.Caption = "Usuário: Administrador";
            Header_Grupo.Caption = "Grupo: Administradores";
            Header_Empresa.Caption = "Empresa Logada: Principal - LTDA ME";

           
        }

        protected virtual void chama_navegador(object sender, EventArgs e, string diretorio)
        {
            System.Diagnostics.Process.Start(diretorio);
        }

        private void btn_HomeNavegador_ItemClick(object sender, ItemClickEventArgs e)
        {
            var diretorio = @"C:\Program Files (x86)\Google\Chrome Beta\Application\chrome.exe";
           
            if (diretorio == string.Empty)
            {
                RegistryKey registry = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htm\OpenWithList");
                diretorio = registry.GetValue("a").ToString();
            }
            chama_navegador(sender, e, diretorio);
        }

        protected virtual void chama_notepad(object sender, EventArgs e, string diretorio)
        {
            System.Diagnostics.Process.Start(diretorio);
        }

        private void btn_HomeBlocoNotas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var diretorio = @"";
            
            if (diretorio == string.Empty)
            {
                diretorio = "notepad.exe";
            }
            chama_notepad(sender, e, diretorio);
        }

        protected virtual void chama_calculadora(object sender, EventArgs e, string diretorio)
        {
            System.Diagnostics.Process.Start(diretorio);
        }

        private void btn_HomeCalc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var diretorio = @"";

            if (diretorio == string.Empty)
            {
                diretorio = "calc.exe";
            }

            chama_calculadora(sender, e, diretorio);
        }

        protected virtual void chama_word(object sender, EventArgs e, string diretorio)
        {
            System.Diagnostics.Process.Start(diretorio);
        }

        private void btn_HomeWord_ItemClick(object sender, ItemClickEventArgs e)
        {
            var diretorio = @"";

            if (diretorio == string.Empty)
            {
                diretorio = "winword.exe";
            }

            chama_word(sender, e, diretorio);
        }

        protected virtual void chama_excel(object sender, EventArgs e, string diretorio)
        {
            System.Diagnostics.Process.Start(diretorio);
        }

        private void btn_HomeExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var diretorio = @"";

            if (diretorio == string.Empty)
            {
                diretorio = "excel.exe";
            }

            chama_excel(sender, e, diretorio);
        }

        protected virtual void chama_outlook(object sender, EventArgs e, string diretorio)
        {
            System.Diagnostics.Process.Start(diretorio);
        }

        private void btn_HomeOutlook_ItemClick(object sender, ItemClickEventArgs e)
        {
            var diretorio = @"thunderbird.exe";

            if (diretorio == string.Empty)
            {
                diretorio = "outlook.exe";
            }

            chama_outlook(sender, e, diretorio);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Header_Hora.Caption = DateTime.Now.ToString("HH:mm:ss");
        }

        protected void header_diahora(bool visible)
        {
            Header_DiaSemana.Caption = DateTime.Now.ToString("'Hoje é: ' dddd ', ' dd ' de ' MMMM ' de ' yyyy");

            if (!visible)
            {
                Header_DiaSemana.Visibility = BarItemVisibility.Never;
                Header_Hora.Visibility = BarItemVisibility.Never;
            }
            else
            {
                Header_DiaSemana.Visibility = BarItemVisibility.Always;
                Header_Hora.Visibility = BarItemVisibility.Always;
            }
            

            distribui_StatusBar();
        }

        protected void distribui_StatusBar()
        {
            var rectangle = Screen.FromControl(this).Bounds;
            var tamanho = 0.0;

            tamanho = (rectangle.Width - 10) * 0.20;
            header_Usuario.Width = (int)tamanho;

            tamanho = (rectangle.Width - 10) * 0.20;
            Header_Grupo.Width = (int)tamanho;

            tamanho = (rectangle.Width - 10) * 0.3;
            Header_Empresa.Width = (int)tamanho;

            tamanho = (rectangle.Width - 10) * 0.2;
            Header_DiaSemana.Width = (int)tamanho;

            tamanho = (rectangle.Width - 10) * 0.1;
            Header_Hora.Width = (int)tamanho;           

        }

        private void btn_HomeParametros_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
    }
}