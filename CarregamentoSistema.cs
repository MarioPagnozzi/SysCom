using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYSCom
{
    public static class CarregamentoSistema
    {
        public static int Incremento { get; set; }
        public static string Mensagem { get; set; }

        public static string cabecalhoIni { get; set; }
        public static string BancoDados { get; set; }
        public static string ServidorIP { get; set; }
        public static string BibliotecaRede { get; set; }
        public static string Usuario { get; set; }
        public static string Senha { get; set; }
        public static bool SeguriteIntegrited { get; set; }
        public static bool SeguriteInfo { get; set; }
        public static string Porta { get; set; }

        public static string conectionString { get; set; }
    }
}
