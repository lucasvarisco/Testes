using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Blog_Model;

namespace Projeto_Blog_DAO
{
    public class BlogDAO : dao
    {
        public void Insert(Blog blog)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"insert into blog values(@nome_blog,@id_user,@tema_blog)";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("nome_blog", blog.nome_blog));
            cmd.Parameters.Add(new SqlParameter("id_user", blog.id_user));
            cmd.Parameters.Add(new SqlParameter("tema_blog", blog.tema_blog));

            cmd.ExecuteNonQuery();
        }
        public void DeletarUm(Blog blog)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"delete from blog where id=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", blog.id));
            cmd.ExecuteNonQuery();
        }

        public void DeletarBlogCobol(int id_blog_cobol)
        {
            BlogDAO blogDAO = new BlogDAO();
            Blog blog = new Blog();

            PostDAO postDAO = new PostDAO();
            Post post = new Post();

            ComentarioDAO comentarioDAO = new ComentarioDAO();
            Comentario comentario = new Comentario();

            var list = postDAO.ObterPostsPorBlog(id_blog_cobol);

            foreach (var item in list)
            {
                comentario.id_postagem = item.id;
                comentarioDAO.DeletarTodos(comentario);
                comentarioDAO.Dispose();

                post.id = item.id;
                postDAO.DeletarUm(post);
                postDAO.Dispose();
            }

            blog.id = id_blog_cobol;
            blogDAO.DeletarUm(blog);
            blogDAO.Dispose();
            postDAO.Dispose();
            comentarioDAO.Dispose();

        }

        public List<Blog> ObterBlogs()
        {
            List<Blog> blogs = new List<Blog>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT b.id,b.nome_blog,b.tema_blog from blog b";
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var blog = new Blog();
                blog.id = Convert.ToInt32(reader[0]);
                blog.nome_blog = reader[1].ToString();
                blog.tema_blog = reader[2].ToString();

                blogs.Add(blog);
            }
            reader.Close();
            return blogs;
        }
        public Blog ObterBlogPorId(int id)
        {
            Blog blog = new Blog();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT b.id,b.nome_blog,b.id_user,b.tema_blog from blog b where id=@id";
            select.Parameters.Add(new SqlParameter("id", id));

            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                blog.id = Convert.ToInt32(reader[0]);
                blog.nome_blog = reader[1].ToString();
                blog.id_user = Convert.ToInt32(reader[2]);
                blog.tema_blog = reader[3].ToString();
            }
            reader.Close();
            return blog;
        }
        public BlogViewModel ObterResul()
        {
            
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select COUNT(nome_blog) from blog";
            
            var r = new BlogViewModel();
            r.qntBlogs = Convert.ToInt32(select.ExecuteScalar());
                
            return r;
        }
        public bool ValidarBlog(string nome)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"select 
	                            count(*)
                                from blog b
                                where b.nome_blog = @nome
                                group by nome_blog";
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
