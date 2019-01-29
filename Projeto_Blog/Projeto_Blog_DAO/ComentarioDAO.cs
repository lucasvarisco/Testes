using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Blog_Model;


namespace Projeto_Blog_DAO
{
    public class ComentarioDAO : dao
    {
        public void Insert(Comentario comentario)
        {
            DateTime hora = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"insert into comentario(coment,horario,id_comentarista,id_postagem) values(@coment,@horario,@id_comentarista,@id_postagem)";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("@coment", comentario.coment));
            cmd.Parameters.Add(new SqlParameter("@horario", hora));
            cmd.Parameters.Add(new SqlParameter("@id_comentarista", comentario.id_comentarista));
            cmd.Parameters.Add(new SqlParameter("@id_postagem", comentario.id_postagem));

            cmd.ExecuteNonQuery();
        }
        public void DeletarTodos(Comentario comentario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"delete from comentario where id_postagem=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", comentario.id_postagem));
            cmd.ExecuteNonQuery();
        }
        public void DeletarUm(ComentarioViewModel comentario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"delete from comentario where id=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", comentario.id_comentarios));
            cmd.ExecuteNonQuery();
        }
        public List<Comentario> ObterComentarios()
        {
            List<Comentario> comentarios = new List<Comentario>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT c.id,c.coment,c.horario,c.id_comentarista,c.id_postagem from comentario c";
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var comentario = new Comentario();
                comentario.id = Convert.ToInt32(reader[0]);
                comentario.horario = Convert.ToDateTime(reader[1]);
                comentario.id_comentarista = Convert.ToInt32(reader[2]);
                comentario.id_postagem = Convert.ToInt32(reader[3]);

                comentarios.Add(comentario);
            }
            reader.Close();
            return comentarios;
        }
        public List<ComentarioViewModel> ObterComentariosPorPost(int id)
        {
            var coment = new List<ComentarioViewModel>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select c.id,c.id_comentarista,c.id_postagem,c.coment,c.horario,u.usuar from comentario c join usuario u on u.id=c.id_comentarista where c.id_postagem = @id order by horario desc";
            select.Parameters.Add(new SqlParameter("id", id));
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var c = new ComentarioViewModel();
                c.id_comentarios = Convert.ToInt32(reader[0]);
                c.id_comentarista = Convert.ToInt32(reader[1]);
                c.id_postagem = Convert.ToInt32(reader[2]);
                c.coment = reader[3].ToString();
                c.horario = Convert.ToDateTime(reader[4]);
                c.usuar = reader[5].ToString();
                
                coment.Add(c);
            }
            reader.Close();
            return coment;
        }
        public ComentViewModel ObterResul(int id)
        {

            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select COUNT(coment) from comentario where id_postagem=@id";
            select.Parameters.Add(new SqlParameter("id", id));

            var c = new ComentViewModel();
            c.qtdComentarios = Convert.ToInt32(select.ExecuteScalar());

            return c;
        }
        public List<ComentViewModel> ObterComentariosPorPostagem()
        {
            var resul = new List<ComentViewModel>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select b.nome_blog,p.titulo_post,COUNT(*) from comentario c right join post p on p.id = c.id_postagem left join blog b on b.id = p.id_blog group by B.nome_blog,p.titulo_post";

            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var r = new ComentViewModel();
                r.nome_blog = reader[0].ToString();
                r.nome_post = reader[1].ToString();
                r.qtdComentarios = Convert.ToInt32(reader[2]);
                resul.Add(r);
            }
            reader.Close();
            return resul;
        }
    }
}
