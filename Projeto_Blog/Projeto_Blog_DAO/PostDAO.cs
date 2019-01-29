using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Blog_Model;


namespace Projeto_Blog_DAO
{
    public class PostDAO : dao
    {
        public void Insert(Post post)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"insert into post values(@titulo_post,@hora,@texto_post,@id_blog,@id_criador)";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("titulo_post", post.titulo_post));
            cmd.Parameters.Add(new SqlParameter("hora", post.hora));
            cmd.Parameters.Add(new SqlParameter("texto_post", post.texto_post));
            cmd.Parameters.Add(new SqlParameter("id_blog", post.id_blog));
            cmd.Parameters.Add(new SqlParameter("id_criador", post.id_criador));

            cmd.ExecuteNonQuery();
        }
        public void DeletarTodos(Post post)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"delete from post where id_blog=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", post.id_blog));
            cmd.ExecuteNonQuery();
        }
        public void DeletarUm(Post post)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"delete from post where id=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", post.id));
            cmd.ExecuteNonQuery();
        }
        public List<Post> ObterPosts()
        {
            List<Post> posts = new List<Post>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT p.id,p.titulo_post,p.hora,p.texto_post,p.id_blog,p.id_criador from post p";
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var post = new Post();
                post.id = Convert.ToInt32(reader[0]);
                post.titulo_post = reader[1].ToString();
                post.hora = Convert.ToDateTime(reader[2]);
                post.texto_post = reader[3].ToString();
                post.id_blog = Convert.ToInt32(reader[4]);
                post.id_criador= Convert.ToInt32(reader[5]);

                posts.Add(post);
            }
            reader.Close();
            return posts;
        }
        public List<Post> ObterPostsPorBlog(int id)
        {
            List<Post> posts = new List<Post>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT p.id,p.titulo_post,p.texto_post,p.id_blog,p.id_criador from post p join blog on blog.id = p.id_blog where blog.id=@id";
            select.Parameters.Add(new SqlParameter("id", id));
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var post = new Post();
                post.id = Convert.ToInt32(reader[0]);
                post.titulo_post = reader[1].ToString();
                post.texto_post = reader[2].ToString();
                post.id_blog = Convert.ToInt32(reader[3]);
                post.id_criador = Convert.ToInt32(reader[4]);
                posts.Add(post);
            }
            reader.Close();
            return posts;
        }
        public List<Post> ObterTextoPorPost(int id)
        {
            List<Post> posts = new List<Post>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT p.id,p.titulo_post,p.hora,p.texto_post,p.id_blog,p.id_criador,u.usuar from post p join usuario u on u.id=p.id_criador where p.id=@id";
            select.Parameters.Add(new SqlParameter("id", id));
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var post = new Post();
                post.id = Convert.ToInt32(reader[0]);
                post.titulo_post = reader[1].ToString();
                post.hora = Convert.ToDateTime(reader[2]);
                post.texto_post = reader[3].ToString();
                post.id_blog = Convert.ToInt32(reader[4]);
                post.id_criador = Convert.ToInt32(reader[5]);
                post.user_name = reader[6].ToString();
                posts.Add(post);
            }
            reader.Close();
            return posts;
        }

        public PostViewModel ObterResul(int id)
        {

            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select COUNT(titulo_post) from post where id_blog=@id";
            select.Parameters.Add(new SqlParameter("id", id));

            var p = new PostViewModel();
            p.qtdPosts = Convert.ToInt32(select.ExecuteScalar());

            return p;
        }
        public List<PostViewModel> ObterPostagensPorBlog()
        {
            var resul = new List<PostViewModel>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select b.nome_blog,COUNT(*) from post p join blog b on b.id = p.id_blog group by B.nome_blog";
            
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var r = new PostViewModel();
                r.nome_blog = reader[0].ToString();
                r.qtdPosts = Convert.ToInt32(reader[1]);
                resul.Add(r);
            }
            reader.Close();
            return resul;
        }
        public bool ValidarPost(int id_blog,string nome)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"select 
	                            count(*)
                                from post p
								join blog as b on b.id = p.id_blog
								where p.titulo_post = @nome AND b.id = @id_blog
								group by p.titulo_post";
            cmd.Parameters.Add(new SqlParameter("id_blog", id_blog));
            cmd.Parameters.Add(new SqlParameter("nome", nome));

            cmd.CommandText = comando;
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
