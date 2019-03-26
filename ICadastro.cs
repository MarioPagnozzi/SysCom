using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYSCom
{
    interface ICadastro
    {
        string Label { get; }
        string Caption { get; }
        Form Formulario();
    }
}
