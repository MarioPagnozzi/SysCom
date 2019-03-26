using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SYSCom.DataBase
{
    public class DBInicializaModulos
    {
        [ImportMany]
        private IEnumerable<ICadastro> cadastros { get; set; }
        [ImportMany]
        private IEnumerable<IConexoesModulos> conModulos { get; set; }

        public void Inicializa(SysCom_DBContext context)
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            PluginHost host = new PluginHost();
            container.ComposeParts(this, host);


            foreach (Func<string> metodo in host.GetNames)
            {
                if (metodo() == "Cadastros")
                {
                    conModulos.FirstOrDefault().ConexaoCadastro(CarregamentoSistema.conectionString);

                }
            }
        }
        public class PluginHost
        {
            [ImportMany]
            public IEnumerable<Func<string>> GetNames { get; set; }
        }
    }
    
}
