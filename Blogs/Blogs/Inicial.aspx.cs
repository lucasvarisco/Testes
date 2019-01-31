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
    public partial class Inicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            if (!string.IsNullOrWhiteSpace(txtLogin.Text) && !string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                lblBrancoInválida.Visible = false;
                lblBranco.Visible = false;
                lblInvalido.Visible = false;
                if (usuarioDao.ValidarLogin(txtLogin.Text,txtSenha.Text) == true)
                {
                    Usuario usuario = new Usuario();
                    if (usuarioDao.ObterUsuarioPorLogin(txtLogin.Text).tipo == 'i')
                    {
                        lblInvalido.Visible = true;
                    }
                    else
                    {
                        Session["usuario"] = txtLogin.Text;
                        Response.Redirect("PaginaBlogs.aspx");
                    }
                }
                else
                {
                    lblBrancoInválida.Visible = true;
                    lblInvalido.Visible = false;
                    lblBranco.Visible = false;
                }
                usuarioDao.Dispose();
            }
            else
            {
                lblBrancoInválida.Visible = false;
                lblBranco.Visible = true;
                lblInvalido.Visible = false;
            }
                
        }


        protected void LinkbtnRecuperacao_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecuperacaoSenha.aspx");
        }

        protected void LinkbtnRegistre_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cadastro.aspx");
        }
    }
}
