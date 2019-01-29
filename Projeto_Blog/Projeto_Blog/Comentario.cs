using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Blog_Model
{
    public class Comentario
    {
        
          
        

        public int id { get; set; }
        public string coment { get; set; }
        public DateTime horario { get; set; }
        
        public int id_comentarista { get; set; }
        public int id_postagem { get; set; }

        public void hora()
        {
            DateTime hora = DateTime.Now;
            horario = hora;
        }
    }
}
