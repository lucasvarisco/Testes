using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Blog_Model;


namespace Projeto_Blog_DAO
{
    public class UsuarioDAO : dao
    {
        public void Insert(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"insert into usuario values(@nome,@senha,@email,@usuar,@tipo,@recuperacao)";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("nome", usuario.nome));
            cmd.Parameters.Add(new SqlParameter("senha", usuario.senha));
            cmd.Parameters.Add(new SqlParameter("email", usuario.email));
            cmd.Parameters.Add(new SqlParameter("usuar", usuario.usuar));
            cmd.Parameters.Add(new SqlParameter("tipo", usuario.tipo));
            cmd.Parameters.Add(new SqlParameter("recuperacao", usuario.recuperacao));

            cmd.ExecuteNonQuery();
        }
        public void AtualizarSenha(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"update usuario set senha = @senha where id = @id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("senha", usuario.senha));
            cmd.Parameters.Add(new SqlParameter("id", usuario.id));

            cmd.ExecuteNonQuery();
        }
        public Usuario ObterUsuarioPorLogin(string usuar)
        {
            Usuario usuario = new Usuario();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT * from usuario where usuar=@usuar";
            select.Parameters.Add(new SqlParameter("usuar", usuar));

            var reader = select.ExecuteReader();
            if (reader.Read())
            {
                usuario.id = Convert.ToInt32(reader[0]);
                usuario.nome = reader[1].ToString();
                usuario.senha = reader[2].ToString();
                usuario.email = reader[3].ToString();
                usuario.usuar = reader[4].ToString();
                usuario.tipo = Convert.ToChar(reader[5]);
                usuario.recuperacao = reader[6].ToString();
            }
            reader.Close();
            return usuario;
        }
        public Usuario ObterUsuarioPorNome(string nome)
        {
            Usuario usuario = new Usuario();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT * from usuario where nome=@nome";
            select.Parameters.Add(new SqlParameter("nome", nome));

            var reader = select.ExecuteReader();
            if (reader.Read())
            {
                usuario.id = Convert.ToInt32(reader[0]);
                usuario.nome = reader[1].ToString();
                usuario.senha = reader[2].ToString();
                usuario.email = reader[3].ToString();
                usuario.usuar = reader[4].ToString();
                usuario.tipo = Convert.ToChar(reader[5]);
                usuario.recuperacao = reader[6].ToString();
            }
            reader.Close();
            return usuario;
        }
        public Usuario ObterUsuarioPorId(int id)
        {
            Usuario usuario = new Usuario();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT * from usuario where id=@id";
            select.Parameters.Add(new SqlParameter("id", id));

            var reader = select.ExecuteReader();
            if (reader.Read())
            {
                usuario.id = Convert.ToInt32(reader[0]);
                usuario.nome = reader[1].ToString();
                usuario.senha = reader[2].ToString();
                usuario.email = reader[3].ToString();
                usuario.usuar = reader[4].ToString();
                usuario.tipo = Convert.ToChar(reader[5]);
                usuario.recuperacao = reader[6].ToString();
            }
            reader.Close();
            return usuario;
        }
        public Usuario ObterUsuarioPorTipo(string usuar)
        {
            Usuario usuario = new Usuario();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT u.tipo from usuario u where usuar=@usuar";
            select.Parameters.Add(new SqlParameter("usuar", usuar));

            var reader = select.ExecuteReader();
            if (reader.Read())
            {
                usuario.tipo = Convert.ToChar(reader[5]);
            }
            reader.Close();
            return usuario;
        }

        public bool ValidarLogin(string login, string senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"select 
	                            count(*)
                                from usuario as u
                                where u.usuar = @login and u.senha = @senha
                                group by nome,senha ";
            cmd.Parameters.Add(new SqlParameter("login", login));
            cmd.Parameters.Add(new SqlParameter("senha", senha));
            cmd.CommandText = comando;
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            else { return false; }
        }
        public bool ValidarNovaSenha(string nome, string recuperacao)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"select 
	                            count(*)
                                from usuario as u
                                where u.nome = @nome and u.recuperacao = @recuperacao
                                group by nome,recuperacao";
            cmd.Parameters.Add(new SqlParameter("nome", nome));
            cmd.Parameters.Add(new SqlParameter("recuperacao", recuperacao));
            cmd.CommandText = comando;
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool ValidarUser(string user)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"select 
	                            count(*)
                                from usuario as u
                                where u.usuar = @user
                                group by nome,senha ";
            cmd.Parameters.Add(new SqlParameter("user", user));

            cmd.CommandText = comando;
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            else { return false; }
        }
        public bool ValidarEmail(string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"select 
	                            count(*)
                                from usuario as u
                                where u.email = @email
                                group by nome,senha ";
            cmd.Parameters.Add(new SqlParameter("email", email));

            cmd.CommandText = comando;
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            else { return false; }
        }
        public Usuario Atualizar(int id)
        {
            Usuario usuario = new Usuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"update usuario set tipo = case when tipo = 'c' then 'a' when tipo = 'a' then 'c' when tipo = 'm' then 'm' end where id=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", id));
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                usuario.id = Convert.ToInt32(reader[0]);
            }
            reader.Close();
            return usuario;
        }
        public Usuario TornarModerador(int id)
        {
            Usuario usuario = new Usuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"update usuario set tipo = case when tipo = 'c' then 'm' when tipo = 'a' then 'm' when tipo = 'm' then 'c' when tipo = 'i' then 'i' end where id=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", id));
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                usuario.id = Convert.ToInt32(reader[0]);
            }
            reader.Close();
            return usuario;
        }
        public List<Usuario> ObterTodosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "SELECT u.id,u.nome,u.senha,u.email,u.usuar,u.tipo,u.recuperacao from usuario u";
            var reader = select.ExecuteReader();
            while (reader.Read())
            {
                var usuario = new Usuario();
                usuario.id = Convert.ToInt32(reader[0]);
                usuario.nome = reader[1].ToString();
                usuario.senha = reader[2].ToString();
                usuario.email = reader[3].ToString();
                usuario.usuar = reader[4].ToString();
                usuario.tipo = Convert.ToChar(reader[5]);
                usuario.recuperacao = reader[6].ToString();

                usuarios.Add(usuario);
            }
            reader.Close();
            return usuarios;
        }
        public Usuario DeletarUmUsuario(int id)
        {
            Usuario usuario = new Usuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
            var comando = @"update usuario set tipo = case when tipo = 'c' then 'i' when tipo = 'a' then 'i' when tipo = 'm' then 'i' when tipo = 'i' then 'c' end where id=@id";
            cmd.CommandText = comando;
            cmd.Parameters.Add(new SqlParameter("id", id));
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                usuario.id = Convert.ToInt32(reader[0]);
            }
            reader.Close();
            return usuario;
        }
        public UsuarioViewModel ObterInativos()
        {

            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select COUNT(nome) from usuario where tipo='i'";

            var p = new UsuarioViewModel();
            p.qtdInativos = Convert.ToInt32(select.ExecuteScalar());

            return p;
        }
        public UsuarioViewModel ObterAtivos()
        {

            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select COUNT(nome) from usuario where tipo!='i'";

            var p = new UsuarioViewModel();
            p.qtdAtivos = Convert.ToInt32(select.ExecuteScalar());

            return p;
        }
        public bool ObterModeradores()
        {

            SqlCommand select = new SqlCommand();
            select.Connection = connection;
            select.CommandType = System.Data.CommandType.Text;
            select.CommandText = "select COUNT(nome) from usuario where tipo='m'";

            if (Convert.ToInt32(select.ExecuteScalar()) > 1)
            {
                return true;
            }
            else { return false; }
        }
    }
}
