using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto_Blog_DAO;
using Projeto_Blog_Model;

namespace Blogs
{
    public partial class PaginaPostagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id_post = Convert.ToInt32(Session["post"]);
                string usuar = Session["usuario"].ToString();
                PopularLabelBlogs();
                PopularLabelTextPost();
                PopularLabelAutorPost();
                PopularGrid();
            }
        }
        

        private void PopularLabelTextPost()
        {
            string nome = "";
            int id_post = Convert.ToInt32(Session["post"]);
            PostDAO postDAO = new PostDAO();
            var lista = postDAO.ObterTextoPorPost(id_post);
            lista.ForEach(item => nome = item.titulo_post);
            lblNomePost.Text = nome;
            var list = postDAO.ObterTextoPorPost(id_post);
            list.ForEach(item => nome = item.texto_post);
            lblTextoPost.Text = nome;
            var lis = postDAO.ObterTextoPorPost(id_post);
            lis.ForEach(item => nome = item.user_name);
            lblCriadorPost.Text = nome;
            var li = postDAO.ObterTextoPorPost(id_post);
            li.ForEach(item => nome = item.hora.ToString());
            lblHorarioPost.Text = nome;
            postDAO.Dispose();
        }

        private void PopularLabelBlogs()
        {
            int id_blogs = 0;
            int id_post = Convert.ToInt32(Session["post"]);
            PostDAO postDAO = new PostDAO();
            var lista = postDAO.ObterTextoPorPost(id_post);
            lista.ForEach(item => id_blogs = item.id_blog);
            BlogDAO blogDAO = new BlogDAO();
            var list = blogDAO.ObterBlogPorId(id_blogs);
            lblTemaBlog.Text = list.tema_blog;
            var lis = blogDAO.ObterBlogPorId(id_blogs);
            lblNomeBlog.Text = lis.nome_blog;
            blogDAO.Dispose();
            postDAO.Dispose();
        }

        private void PopularLabelAutorPost()
        {
            
                string nome = "";
                string hora = "";
                int id_post = Convert.ToInt32(Session["post"]);
                PostDAO postDAO = new PostDAO();
                var list = postDAO.ObterTextoPorPost(id_post);
                list.ForEach(item => nome = item.user_name);
                lblCriadorPost.Text = nome;
                list.ForEach(item => hora = item.hora.ToString());
                lblHorarioPost.Text = hora;
                postDAO.Dispose();
            
        }

        private void PopularGrid()
        {
            ComentarioDAO comentarioDAO = new ComentarioDAO();
            List<ComentarioViewModel> listaComentarioViewModel = new List<ComentarioViewModel>();
            ComentarioViewModel comentario = new ComentarioViewModel();
            comentario.id_comentarios = Convert.ToInt32(Session["post"]);
            listaComentarioViewModel = comentarioDAO.ObterComentariosPorPost(comentario.id_comentarios);
            grdComentarios.DataSource = listaComentarioViewModel;
            grdComentarios.DataBind();
            comentarioDAO.Dispose();
        }

        protected void btnComentar_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrWhiteSpace(txtComentario.Text))
           {
                lblBranco.Visible = false;
                ComentarioDAO comentarioDAO = new ComentarioDAO();
                UsuarioDAO usuarioDAO = new UsuarioDAO();

                string usuar = Session["usuario"].ToString();
                Usuario usuario = new Usuario();
                usuario = usuarioDAO.ObterUsuarioPorLogin(usuar);

                Comentario comentario = new Comentario();
                comentario.coment = txtComentario.Text;
                comentario.id_comentarista = usuario.id;
                comentario.id_postagem = Convert.ToInt32(Session["post"]);
                comentarioDAO.Insert(comentario);
                comentarioDAO.Dispose();
                usuarioDAO.Dispose();
                Response.Redirect("PaginaPostagem.aspx");
           }
            else
            {
                lblBranco.Visible = true;
            }
            
        }

        protected void btnRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaBlogs.aspx");
        }

        protected void grdComentarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idx = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(grdComentarios.DataKeys[idx]["id_comentarios"]);
            ComentarioViewModel comentario = new ComentarioViewModel();
            comentario.id_comentarios = id;
            ComentarioDAO comentarioDAO = new ComentarioDAO();
            comentarioDAO.DeletarUm(comentario);
            comentarioDAO.Dispose();
            PopularGrid();
        }

        protected void grdComentarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            if (usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).tipo != 'm')
            {
                e.Row.Cells[3].Visible = false;
            }
            usuarioDAO.Dispose();
        }
    }
}