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
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicial.aspx");
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarios = new UsuarioDAO();
            lblUsuarioCriado.Visible = false;
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtNome.Text) && !string.IsNullOrWhiteSpace(txtSenha.Text) && !string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtSenhaRecuperacao.Text))
            {
                lblNaoPreenchido.Visible = false;
                if (!usuarios.ValidarUser(txtUser.Text))
                {
                    lblUsuarioExistente.Visible = false;
                    if (!usuarios.ValidarEmail(txtEmail.Text))
                    {
                        Usuario usuario = new Usuario();
                        usuario.nome = txtNome.Text;
                        usuario.senha = txtSenha.Text;
                        usuario.email = txtEmail.Text;
                        usuario.usuar = txtUser.Text;
                        usuario.tipo = getTipoUsuarioFromRdbAdm();
                        usuario.recuperacao = txtSenhaRecuperacao.Text;
                        usuarios.Insert(usuario);
                        usuarios.Dispose();
                        lblUsuarioExistente.Visible = false;
                        lblEmailExistente.Visible = false;
                        lblUsuarioCriado.Visible = true;
                    }
                    else
                    {
                        lblEmailExistente.Visible = true;
                        lblUsuarioExistente.Visible = false;
                        lblUsuarioCriado.Visible = false;
                    }
                }
                else
                {
                    lblUsuarioCriado.Visible = false;
                    lblEmailExistente.Visible = false;
                    lblUsuarioExistente.Visible = true;
                }
            }
            else
            {
                lblNaoPreenchido.Visible = true;
                lblEmailExistente.Visible = false;
                lblUsuarioCriado.Visible = false;
                lblUsuarioExistente.Visible = false;
            }
            usuarios.Dispose();
        }

        protected char getTipoUsuarioFromRdbAdm()
        {
            return rdbAdm.Checked ? 'a' : 'c';
        }

        protected void rdbAdm_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
