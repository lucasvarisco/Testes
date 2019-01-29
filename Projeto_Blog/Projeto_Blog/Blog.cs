using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Blog_Model
{
    public class Blog
    {
        public int id { get; set; }
        public string nome_blog { get; set; }
        public int id_user { get; set; }
        public string tema_blog { get; set; }
    }
}
