using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto_Blog_DAO;
using Projeto_Blog_Model;
using INTEGRACAO;

namespace Blogs
{
    public partial class PaginaBlogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TipoUser();
                PopularListBlogs();
                PopularLabelTemaPost();
                PopularListPost();
                PopularLabelAutorPost();
            }
        }
        private void PopularListBlogs()
        {
            BlogDAO blogDAO = new BlogDAO();
            var list = blogDAO.ObterBlogs();
            ddlListaBlogs.DataSource = list;
            ddlListaBlogs.DataValueField = "id";
            ddlListaBlogs.DataTextField = "nome_blog";
            ddlListaBlogs.DataBind();
            PopularLabelTemaPost();
            lblTextoPost.Visible = false;
            btnIrBlog.Visible = true;
            TipoUser();
            blogDAO.Dispose();
            lblBlogExcluido.Visible = false;
            lblPostCriado.Visible = false;
        }
        private void PopularListPost()
        {
            PostDAO postDAO = new PostDAO();
            try
            {
                var list = postDAO.ObterPostsPorBlog(Convert.ToInt32(ddlListaBlogs.SelectedItem.Value));
                ddlListaPosts.DataSource = list;
                ddlListaPosts.DataValueField = "id";
                ddlListaPosts.DataTextField = "titulo_post";
                ddlListaPosts.DataBind();
                PopularLabelAutorPost();
                lblTextoPost.Visible = false;
                btnIrBlog.Visible = true;
                TipoUser();
                postDAO.Dispose();
                lblBlogExcluido.Visible = false;
                lblPostExcluido.Visible = false;
            }
            catch (Exception)
            {

            }

        }
        private void DeletarUmPost(int postagem)
        {
            ComentarioDAO comentarioDAO = new ComentarioDAO();
            Comentario comentario = new Comentario();

            PostDAO postDAO = new PostDAO();
            Post post = new Post();

            comentario.id_postagem = postagem;
            comentarioDAO.DeletarTodos(comentario);
            comentarioDAO.Dispose();

            post.id = postagem;
            postDAO.DeletarUm(post);
            postDAO.Dispose();
        }
        private void PopularLabelTextPost()
        {
            string nome = "";
            PostDAO postDAO = new PostDAO();
            var list = postDAO.ObterTextoPorPost(Convert.ToInt32(ddlListaPosts.SelectedItem.Value));
            list.ForEach(item => nome = item.texto_post);
            lblTextoPost.Text = nome;
            postDAO.Dispose();
        }
        private void PopularLabelAutorPost()
        {
            lblCriadoPor.Visible = true;
            lblAutorPost.Visible = true;
            lblCriadoEm.Visible = true;
            lblHoraPost.Visible = true;
            if (!string.IsNullOrWhiteSpace(ddlListaPosts.Text))
            {
                string nome = "";
                string hora = "";
                PostDAO postDAO = new PostDAO();
                var list = postDAO.ObterTextoPorPost(Convert.ToInt32(ddlListaPosts.SelectedItem.Value));
                list.ForEach(item => nome = item.user_name);
                lblAutorPost.Text = nome;
                list.ForEach(item => hora = item.hora.ToString());
                lblHoraPost.Text = hora;
                postDAO.Dispose();
            }
            else
            {
                lblCriadoPor.Visible = false;
                lblAutorPost.Visible = false;
                lblCriadoEm.Visible = false;
                lblHoraPost.Visible = false;
            }
        }
        private void PopularLabelTemaPost()
        {
            BlogDAO blogDAO = new BlogDAO();
            try
            {
                var list = blogDAO.ObterBlogPorId(Convert.ToInt32(ddlListaBlogs.SelectedItem.Value));
                lblTemaBlog.Text = list.tema_blog;

            }
            catch (Exception)
            {

            }
            blogDAO.Dispose();
        }

        protected void TipoUser()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = new Usuario();
            if (usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).tipo == 'c')
            {
                txtNomeBlog.Visible = false;
                txtTemaBlog.Visible = false;
                btnCriar.Visible = false;
                lblTextoPost.Visible = false;
                txtNovoPost.Visible = false;
                txtTemaPost.Visible = false;
                btnCriarPost.Visible = false;
                btnCriacaoPost.Visible = false;
                lblDesc.Visible = false;
                btnPlanos.Visible = true;
            }
            else if (usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).tipo == 'a')
            {
                lblTextoPost.Visible = false;
                txtNovoPost.Visible = false;
                txtTemaPost.Visible = false;
                btnCriarPost.Visible = false;
                btnCriacaoPost.Visible = true;
                lblDesc.Visible = false;
            }
            else if (usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).tipo == 'm')
            {
                LinkbtnLixeiraPost.Visible = true;
                LinkbtnLixeiraBlog.Visible = true;
                lblTextoPost.Visible = false;
                txtNovoPost.Visible = false;
                txtTemaPost.Visible = false;
                btnCriarPost.Visible = false;
                btnCriacaoPost.Visible = true;
                lblDesc.Visible = false;
                LinkbtnGerenciador.Visible = true;
            }
            usuarioDAO.Dispose();
        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
            lblEmBranco.Visible = false;
            lblPostCriado.Visible = false;
            lblPostExistente.Visible = false;
            lblPostExcluido.Visible = false;
            if (!string.IsNullOrWhiteSpace(txtNomeBlog.Text) && !string.IsNullOrWhiteSpace(txtTemaBlog.Text))
            {
                using (BlogDAO blogDAO = new BlogDAO())
                {
                    if (!blogDAO.ValidarBlog(txtNomeBlog.Text))
                    {
                        lblCampoBranco.Visible = false;
                        lblBlogCriado.Visible = true;
                        lblBlogExistente.Visible = false;
                        BlogDAO blogs = new BlogDAO();
                        UsuarioDAO usuarioDAO = new UsuarioDAO();

                        string usuar = Session["usuario"].ToString();
                        Usuario usuario = new Usuario();
                        usuario = usuarioDAO.ObterUsuarioPorLogin(usuar);

                        Blog blog = new Blog();
                        blog.nome_blog = txtNomeBlog.Text;
                        blog.id_user = usuario.id;
                        blog.tema_blog = txtTemaBlog.Text;
                        blogs.Insert(blog);
                        blogs.Dispose();
                        usuarioDAO.Dispose();
                        txtNomeBlog.Text = "";
                        txtTemaBlog.Text = "";
                        PopularListBlogs();
                        PopularListPost();
                    }
                    else
                    {
                        lblBlogExistente.Visible = true;
                        lblCampoBranco.Visible = false;
                        lblBlogCriado.Visible = false;
                    }

                }


            }
            else
            {
                lblCampoBranco.Visible = true;
                lblBlogExistente.Visible = false;
                lblBlogCriado.Visible = false;
            }
        }

        protected void btnIrBlog_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ddlListaPosts.Text))
            {
                Session["post"] = ddlListaPosts.SelectedItem.Value;
                Response.Redirect("PaginaPostagem.aspx");
            }

        }
        protected void ApagarMensagens()
        {
            lblBlogCriado.Visible = false;
            lblBlogExcluido.Visible = false;
            lblCampoBranco.Visible = false;
            lblEmBranco.Visible = false;
            lblPostCriado.Visible = false;
            lblPostExcluido.Visible = false;
            lblPostExistente.Visible = false;
        }
        protected void ddlListaBlogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopularListPost();
            PopularLabelTemaPost();
            lblTextoPost.Visible = false;
            ApagarMensagens();

        }

        protected void ddlListaPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTextoPost.Visible = false;
            btnIrBlog.Visible = true;
            TipoUser();
            PopularLabelAutorPost();
            ApagarMensagens();
        }


        protected void btnCriarPost_Click(object sender, EventArgs e)
        {
            lblEmBranco.Visible = false;
            lblPostCriado.Visible = false;
            lblPostExistente.Visible = false;
            lblBlogCriado.Visible = false;
            lblBlogExistente.Visible = false;
            lblCampoBranco.Visible = false;
            using (PostDAO postexiste = new PostDAO())
            {
                if (!postexiste.ValidarPost(Convert.ToInt32(ddlListaBlogs.SelectedItem.Value), txtNovoPost.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtNovoPost.Text) && !string.IsNullOrWhiteSpace(txtTemaPost.Text))
                    {
                        lblPostCriado.Visible = true;
                        PostDAO postDAO = new PostDAO();
                        UsuarioDAO usuarioDAO = new UsuarioDAO();

                        string usuar = Session["usuario"].ToString();
                        Usuario usuario = new Usuario();
                        usuario = usuarioDAO.ObterUsuarioPorLogin(usuar);

                        Post post = new Post();
                        post.id_criador = usuario.id;
                        post.titulo_post = txtNovoPost.Text;
                        post.texto_post = txtTemaPost.Text;
                        post.id_blog = Convert.ToInt32(ddlListaBlogs.SelectedItem.Value);
                        postDAO.Insert(post);
                        postDAO.Dispose();
                        usuarioDAO.Dispose();
                        txtNovoPost.Text = "";
                        txtTemaPost.Text = "";
                        PopularListPost();
                        PopularLabelAutorPost();
                    }
                    else
                    {
                        lblEmBranco.Visible = true;
                    }
                }
                else
                {
                    lblPostExistente.Visible = true;
                }
            }
        }

        protected void btnCriacaoPost_Click(object sender, EventArgs e)
        {
            txtNovoPost.Visible = true;
            txtTemaPost.Visible = true;
            btnCriarPost.Visible = true;
            btnCriacaoPost.Visible = false;
            lblEmBranco.Visible = false;
            lblPostCriado.Visible = false;
            lblPostExistente.Visible = false;
            lblBlogCriado.Visible = false;
            lblBlogExistente.Visible = false;
            lblPostExcluido.Visible = false;
            lblCampoBranco.Visible = false;
            lblBlogExcluido.Visible = false;
        }

        protected void LinkbtnLixeiraBlog_Click(object sender, EventArgs e)
        {
            BlogDAO blogDAO = new BlogDAO();
            Blog blog = new Blog();

            PostDAO postDAO = new PostDAO();
            Post post = new Post();

            ComentarioDAO comentarioDAO = new ComentarioDAO();
            Comentario comentario = new Comentario();

            var list = postDAO.ObterPostsPorBlog(Convert.ToInt32(ddlListaBlogs.SelectedItem.Value));

            foreach (var item in list)
            {
                DeletarUmPost(item.id);
            }

            blog.id = Convert.ToInt32(ddlListaBlogs.SelectedItem.Value);
            blogDAO.DeletarUm(blog);
            blogDAO.Dispose();
            PopularListBlogs();
            PopularListPost();
            PopularLabelAutorPost();
            PopularLabelTemaPost();
            PopularLabelTextPost();
            lblBlogExcluido.Visible = true;
        }

        protected void LinkbtnLixeiraPost_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ddlListaPosts.Text))
            {
                DeletarUmPost(Convert.ToInt32(ddlListaPosts.SelectedItem.Value));
            }
            PopularListPost();
            PopularLabelAutorPost();
            lblPostExcluido.Visible = true;
        }


        protected void LinkbtnGerenciador_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void LinkbtnEstatisticas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estatisticas.aspx");
        }

        protected void LinkbtnDadosPessoais_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPosts.aspx");
        }

        protected void LinkbtnSair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Inicial.aspx");
        }

        protected void btnPlanos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPosts.aspx");
        }

        protected void LinkbtnDados_Click(object sender, EventArgs e)
        {
            BlogDAO blogDAO = new BlogDAO();
            var list = blogDAO.ObterBlogs();
            Class1 NOME = new Class1();
            bool retorno = NOME.GRAVAR(ref list);
            if (retorno)
            {
                lblExportado.Visible = true;
            }
            blogDAO.Dispose();
        }
    }
}