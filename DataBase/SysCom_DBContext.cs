using SYSCom.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSCom.DataBase
{
    public class SysCom_DBContext : DbContext
    {
        [ImportMany]
        private IEnumerable<ICadastro> Cadastros { get; set; }

        public SysCom_DBContext(string conexao) : base(conexao)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SysCom_DBContext, Configuration>());
        }
    }
}
