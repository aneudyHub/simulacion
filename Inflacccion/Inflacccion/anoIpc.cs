using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inflacccion
{
    class anoIpc
    {
        public string periodo { get; set; }
        public string indice1 { get; set; }
        public string indice2 { get; set; }
        public string inflaccion { get; set; }

        public anoIpc() {
        
        }
        public anoIpc(string periodo,string indice1,string indice2,string inflaccion) {
            this.periodo = periodo;
            this.indice1 = indice1;
            this.indice2 = indice2;
            this.inflaccion = inflaccion;
        }
    }
}
