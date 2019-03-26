using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cadastros;

namespace SYSCom
{
    public class Cadastros
    {
        [Export(typeof(ICadastro))]
        public class Cadastro_Cliente : ICadastro
        {
            public string Label
            {
                get { return "Cliente"; }
            }
            public string Caption
            {
                get { return "Cadastro de Cliente"; }
            }
            public Form Formulario()
            {
                return new Form1();
            }
        }
    }
}
