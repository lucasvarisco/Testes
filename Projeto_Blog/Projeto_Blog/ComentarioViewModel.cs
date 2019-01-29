using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Blog_Model
{
    public class ComentarioViewModel
    {
        public int id_comentarios { get; set; }
        public string coment { get; set; }
        public DateTime horario { get; set; }
        public string usuar { get; set; }
        public int id_comentarista { get; set; }
        public int id_postagem { get; set; }
    }
}
