using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSCom.DataBase
{
    public class SysCom_DBContextFactory : IDbContextFactory<SysCom_DBContext>
    {
        public SysCom_DBContext Create()
        {
            try
            {

                RegistryKey registry = Registry.CurrentUser.OpenSubKey(@"Software\MAPX\SysCom\BancoDados\", false);
                var DataSource = "Data Source=" + registry.GetValue("Servidor").ToString();
                var Network = "Network Library=" + registry.GetValue("Network Library").ToString();
                var InitialCatalog = "Initial Catalog=" + registry.GetValue("DataBase").ToString();
                var UserId = "User ID=" + registry.GetValue("User").ToString();
                var Password = "Password=" + registry.GetValue("Password").ToString();

                CarregamentoSistema.conectionString = DataSource + ";" + Network + ";" + InitialCatalog + ";" + UserId + ";" + Password;
            }
            catch (Exception e)
            {
                CarregamentoSistema.conectionString = "Server=localhost,1433;Database=Dev_Syscom;user=sa,password=m4r101979;Integrated Security=True;";
            }

            return new SysCom_DBContext(CarregamentoSistema.conectionString.ToString());
        }
    }
}
