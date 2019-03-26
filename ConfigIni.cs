using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SYSCom
{
    public partial class ConfigIni : DevExpress.XtraEditors.XtraForm
    {
        public ConfigIni()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregamentoSistema.BancoDados = txtBancoDados.Text;
            CarregamentoSistema.BibliotecaRede = txtBibliotecaRede.Text;
            CarregamentoSistema.SeguriteInfo = chkSeguriteInfo.Checked;
            CarregamentoSistema.SeguriteIntegrited = chkIntegrated.Checked;
            CarregamentoSistema.ServidorIP = txtIPServidor.Text;
            CarregamentoSistema.Usuario = txtUsuario.Text;
            CarregamentoSistema.Senha = txtSenha.Text;
            CarregamentoSistema.Porta = txtPorta.Text;
            CarregamentoSistema.cabecalhoIni = "ConexaoBD";

        }

        private void txtPorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}