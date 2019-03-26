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
//using System.Composition;
//using System.Composition.Hosting;
using System.Threading;
using DevExpress.XtraSplashScreen;
using System.IO;
using IniFileIO;
using funcoesGlobal;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using static SYSCom.DataBase.DBInicializaModulos;
using System.ComponentModel.Composition;

namespace SYSCom
{
   
    
    public partial class frm_principal_mod2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private bool fecharSistema = false;
        private string mensagem = string.Empty;

        [ImportMany]
        private IEnumerable<ICadastro> Cadastros { get; set; }

        private bool GuiaCadastro = false;

        public frm_principal_mod2()
        {
            SplashScreenManager.ShowForm(typeof(Abertura));
            bool ExisteArquivo = true;

            for (int i = 0; i <= 100; i++)
            {                
               
                if (i == 0)
                {
                    CarregamentoSistema.Mensagem = "Iniciando o Sistema...";
                    CarregamentoSistema.Incremento = i;
                }
                Thread.Sleep(100);
                
                if ((i == 1))
                {
                    CarregamentoSistema.Mensagem = "Conectando ao Banco de Dados...";
                    CarregamentoSistema.Incremento = i;
                    Thread.Sleep(50);
                    CarregamentoSistema.Mensagem = "Procurando arquivo de configuração de Banco de Dados...";

                    var diretorio = Path.GetDirectoryName(Application.ExecutablePath);
                    var dirConfigIni = diretorio + @"\Database\";

                    if (Directory.Exists(dirConfigIni))
                    {
                        if (File.Exists(dirConfigIni + "config.ini"))
                        {
                            RegistryKey registry = Registry.CurrentUser.OpenSubKey(@"Software\MAPX\SysCom\BancoDados\", false);
                            IniFile iniConfig = new IniFile(dirConfigIni + "config.ini");
                            iniConfig.ReadFile();

                            if (registry is null)
                            {
                                CarregamentoSistema.Incremento = 0;
                                ConfigIni configIni = new ConfigIni();
                                var result = configIni.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    registry = Registry.CurrentUser.CreateSubKey(@"Software\MAPX\SysCom\BancoDados\");
                                    registry.SetValue("User", CarregamentoSistema.Usuario);
                                    registry.SetValue("Password", CarregamentoSistema.Senha);
                                    registry.SetValue("DataBase", CarregamentoSistema.BancoDados);
                                    registry.SetValue("Servidor", CarregamentoSistema.ServidorIP + "," + CarregamentoSistema.Porta);
                                    registry.SetValue("Network Library", CarregamentoSistema.BibliotecaRede);
                                    registry.SetValue("Integrated Segurity", CarregamentoSistema.SeguriteIntegrited);
                                    registry.SetValue("Segurity Info", CarregamentoSistema.SeguriteInfo);
                                }
                                else
                                {
                                    fecharSistema = true;
                                    mensagem = "Não foi configurado os parametros de conexão ao banco de dados! \n" +
                                        "Verifique com o Administrador.";
                                    break;
                                }                               

                            }
                            else {

                                //checar inconsistencia config.ini e regedit
                                //DONE: Criar rotina para checar inconsistência do Arquivo Config.ini e Registro.
                                CarregamentoSistema.Mensagem = "Verificando consistência do Arquivo de Configuração do Banco de Dados...";
                                Thread.Sleep(50);

                                bool bancoDados = registry.GetValue("DataBase").ToString() == iniConfig.GetKey("ConexaoBD", "DataBase").Value;

                                if (!bancoDados)
                                {
                                    fecharSistema = true;
                                    mensagem = "Arquivo de Configuração do Banco de Dados Inconsistente! \n" +
                                        "Verifique com o Administrador." + iniConfig.GetKey("ConexaoBD", "DataBase").Value;                                    
                                    break;
                                }

                                bool servidor = registry.GetValue("Servidor").ToString() == iniConfig.GetKey("ConexaoBD", "Servidor").Value;

                                if (!servidor)
                                {
                                    fecharSistema = true;
                                    mensagem = "Arquivo de Configuração do Banco de Dados Inconsistente! \n" +
                                        "Verifique com o Administrador.";
                                    break;
                                }

                                bool user = FuncoesGerais.Compara(registry.GetValue("User").ToString(), iniConfig.GetKey("ConexaoBD", "User").Value);

                                if (!user)
                                {
                                    fecharSistema = true;
                                    mensagem = "Arquivo de Configuração do Banco de Dados Inconsistente! \n" +
                                        "Verifique com o Administrador.";
                                    break;
                                }

                                bool password = FuncoesGerais.Compara(registry.GetValue("Password").ToString(), iniConfig.GetKey("ConexaoBD", "Password").Value);

                                if (!password)
                                {
                                    fecharSistema = true;
                                    mensagem = "Arquivo de Configuração do Banco de Dados Inconsistente! \n" +
                                        "Verifique com o Administrador.";
                                    break;
                                }

                                bool network = registry.GetValue("Network Library").ToString() == iniConfig.GetKey("ConexaoBD", "Network Library").Value;

                                if (!network)
                                {
                                    fecharSistema = true;
                                    mensagem = "Arquivo de Configuração do Banco de Dados Inconsistente! \n" +
                                        "Verifique com o Administrador.";
                                    break;
                                }

                                bool intsegurity = registry.GetValue("Integrated Segurity").ToString() == iniConfig.GetKey("ConexaoBD", "Integrated Segurity").Value;

                                if (!intsegurity)
                                {
                                    fecharSistema = true;
                                    mensagem = "Arquivo de Configuração do Banco de Dados Inconsistente! \n" +
                                        "Verifique com o Administrador.";
                                    break;
                                }

                                bool segurityInfo = registry.GetValue("Segurity Info").ToString() == iniConfig.GetKey("ConexaoBD", "Segurity Info").Value;

                                if (!segurityInfo)
                                {
                                    fecharSistema = true;
                                    mensagem = "Arquivo de Configuração do Banco de Dados Inconsistente! \n" +
                                        "Verifique com o Administrador.";
                                    break;
                                }

                                var DataSource = "Data Source=" + registry.GetValue("Servidor").ToString();
                                var Network = "Network Library=" + registry.GetValue("Network Library").ToString();
                                var InitialCatalog = "Initial Catalog=" + registry.GetValue("DataBase").ToString();
                                var UserId = "User ID=" + registry.GetValue("User").ToString();
                                var Password = "Password=" + registry.GetValue("Password").ToString();

                                CarregamentoSistema.conectionString = DataSource + ";" + Network + ";" + InitialCatalog + ";" + UserId + ";" + Password;
                                
                                if (CarregamentoSistema.conectionString.ToString() == string.Empty)
                                {
                                    fecharSistema = true;
                                    mensagem = "Não foi possível criar a 'string' de conexão ao Banco de Dados!" +
                                        "Verifique com o Administrador.";
                                    break;
                                }
                                                               
                                
                                //TODO: Criar Rotina de Conexão de Banco de Dados
                            }
                        }
                        else
                        {
                            CarregamentoSistema.Mensagem = "Criando Arquivo de Configuração: " + dirConfigIni + "config.ini";
                            Thread.Sleep(50);

                            ExisteArquivo = false;
                            try
                            {
                                File.Create(dirConfigIni + "config.ini").Close();
                            }
                            catch (Exception e)
                            {
                                CarregamentoSistema.Mensagem = e.Message;
                            }
                            Thread.Sleep(50);

                        }
                    }
                    else
                    {
                        ExisteArquivo = false;
                        try
                        {
                            Directory.CreateDirectory(dirConfigIni);
                            File.Create(dirConfigIni + "config.ini").Close();
                            
                        }
                        catch(Exception e)
                        {
                            CarregamentoSistema.Mensagem = e.Message;
                        }
                        Thread.Sleep(50);

                    }

                    if (!ExisteArquivo)
                    {
                        CarregamentoSistema.Incremento = 0;
                        ConfigIni configIni = new ConfigIni();
                        var result = configIni.ShowDialog();
                        
                        if (result == DialogResult.OK)
                        {
                            IniFile iniFile = new IniFile(dirConfigIni + "config.ini");
                            iniFile.SetSectionData(CarregamentoSistema.cabecalhoIni);
                            iniFile.SetKeyData(CarregamentoSistema.cabecalhoIni, "Servidor", CarregamentoSistema.ServidorIP + "," + CarregamentoSistema.Porta);
                            iniFile.SetKeyData(CarregamentoSistema.cabecalhoIni, "DataBase", CarregamentoSistema.BancoDados);
                            iniFile.SetKeyData(CarregamentoSistema.cabecalhoIni, "Network Library", CarregamentoSistema.BibliotecaRede);
                            iniFile.SetKeyData(CarregamentoSistema.cabecalhoIni, "User", FuncoesGerais.Codifica(CarregamentoSistema.Usuario));
                            iniFile.SetKeyData(CarregamentoSistema.cabecalhoIni, "Password", FuncoesGerais.Codifica(CarregamentoSistema.Senha));
                            iniFile.SetKeyData(CarregamentoSistema.cabecalhoIni, "Integrated Segurity", CarregamentoSistema.SeguriteIntegrited.ToString());
                            iniFile.SetKeyData(CarregamentoSistema.cabecalhoIni, "Segurity Info", CarregamentoSistema.SeguriteInfo.ToString());

                            iniFile.SaveFile();
                            RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Software\MAPX\SysCom\BancoDados\");
                            
                            registry.SetValue("User", CarregamentoSistema.Usuario);
                            registry.SetValue("Password", CarregamentoSistema.Senha);
                            registry.SetValue("DataBase", CarregamentoSistema.BancoDados);
                            registry.SetValue("Servidor", CarregamentoSistema.ServidorIP + "," + CarregamentoSistema.Porta);
                            registry.SetValue("Network Library", CarregamentoSistema.BibliotecaRede);
                            registry.SetValue("Integrated Segurity", CarregamentoSistema.SeguriteIntegrited);
                            registry.SetValue("Segurity Info", CarregamentoSistema.SeguriteInfo);

                            CarregamentoSistema.Mensagem = "Arquivo de Configuração Criado!";
                            Thread.Sleep(50);
                        }
                        else
                        {
                            fecharSistema = true;
                            break;
                        }

                        
                    }


                    Thread.Sleep(50);
                }
                Thread.Sleep(100);

                if (i == 2)
                {
                    var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                           new DirectoryCatalog("."));

                    var container = new CompositionContainer(catalog);
                    PluginHost host = new PluginHost();
                    container.ComposeParts(this, host);

                    CarregamentoSistema.Mensagem = "Carregando Módulos...";
                    Thread.Sleep(50);

                    foreach (Func<string> modulos in host.GetNames)
                    {
                        if (modulos() == "Cadastros")
                        {
                            CarregamentoSistema.Mensagem = "Carregando Módulo de Cadastros ... OK!";
                            GuiaCadastro = true;
                            Thread.Sleep(50);
                        }

                    }
                }
                Thread.Sleep(100);
                

            }

            

            SplashScreenManager.CloseForm();

          

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

            if (fecharSistema)
            {
                XtraMessageBox.AllowCustomLookAndFeel = true;
                XtraMessageBox.Show(mensagem, "Encerramento do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fechar_app(sender, e);
            }

            rb_Cadastros.Visible = GuiaCadastro;


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