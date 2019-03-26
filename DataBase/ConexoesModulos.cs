using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastros.DataBase;

namespace SYSCom.DataBase
{
    public class ConexoesModulos
    {
        [Export(typeof(IConexoesModulos))]
        public class con_cadastro : IConexoesModulos
        {
            public void ConexaoCadastro(string conexao)
            {
                Cadastro_DBContext cadastro = new Cadastro_DBContext(conexao);
                cadastro.Database.CreateIfNotExists();
                CadastroInitialize.Inicializa(cadastro);
            }
        }
    }
}
