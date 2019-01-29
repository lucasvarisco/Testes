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
    public partial class PaginaPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (UsuarioDAO usuarioDAO = new UsuarioDAO())
                {
                    int id = usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).id;
                    Projeto_Blog_Model.Usuario usuario = new Projeto_Blog_Model.Usuario();
                    usuario = usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString());
                    txtNome.Text = usuario.nome;
                    txtEmail.Text = usuario.email;
                    usuarioDAO.Dispose();
                }
                PopularLabelTipoPlano();
            }
        }

        protected void btnMudarPlano_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            int id = usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).id;
            usuarioDAO.Atualizar(id);
            usuarioDAO.Dispose();
            Response.Redirect("PaginaPosts.aspx");
        }

        private void PopularLabelTipoPlano()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            char tipo = usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).tipo;
            if(tipo == 'a')
            {
                lblTipoPlano.Text = "ADMINISTRADOR";
            }
            else if(tipo == 'c')
            {
                lblTipoPlano.Text = "COMUM";
            }
            else
            {
                lblTipoPlano.Text = "MODERADOR";
                btnMudarPlano.Visible = false;
            }
            usuarioDAO.Dispose();
        }

        protected void btnNovaSenha_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarios = new UsuarioDAO();
            if (!string.IsNullOrWhiteSpace(txtSenhaAntiga.Text) && !string.IsNullOrWhiteSpace(txtSenhaNova.Text))
            {
                if (usuarios.ValidarLogin(usuarios.ObterUsuarioPorLogin(Session["usuario"].ToString()).usuar, txtSenhaAntiga.Text))
                {
                    Usuario usuario = new Usuario();
                    usuario.id = usuarios.ObterUsuarioPorLogin(Session["usuario"].ToString()).id;
                    usuario.senha = txtSenhaNova.Text;
                    usuarios.AtualizarSenha(usuario);
                    usuarios.Dispose();
                    lblCampoBranco.Visible = false;
                    lblSenhaAlterada.Visible = true;
                    lblSenhaErrada.Visible = false;
                }
                else
                {
                    lblCampoBranco.Visible = false;
                    lblSenhaAlterada.Visible = false;
                    lblSenhaErrada.Visible = true;
                }
            }
            else
            {
                lblCampoBranco.Visible = true;
                lblSenhaAlterada.Visible = false;
                lblSenhaErrada.Visible = false;
            }
            usuarios.Dispose();
        }
    }
}
