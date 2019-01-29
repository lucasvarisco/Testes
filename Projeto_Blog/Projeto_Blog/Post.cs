using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Blog_Model
{
    public class Post
    {
        public Post()
        {
            hora = DateTime.Now;
        }
        public int id { get; set; }
        public string titulo_post { get; set; }
        public DateTime hora { get; set; }
        public string texto_post { get; set; }
        public int id_blog { get; set; }
        public int id_criador { get; set; }
        public string user_name { get; set; }

    }
}
