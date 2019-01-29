using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Blog_Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string usuar { get; set; }
        public char tipo { get; set; }
        public string recuperacao { get; set; }

        public bool moderador
        {
            get
            {
                return tipo == 'm';
            }
        }
    }
}
