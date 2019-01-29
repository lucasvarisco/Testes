using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto_Blog_Model;
using Projeto_Blog_DAO;
using System.Web.UI.HtmlControls;

namespace Blogs
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularGrid();
                PopularAtivos();
                PopularInativos();
            }
        }

        protected void PopularAtivos()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel = usuarioDAO.ObterAtivos();
            lblAtivosTotal.Text = usuarioViewModel.qtdAtivos.ToString();
            usuarioDAO.Dispose();
        }
        protected void PopularInativos()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel = usuarioDAO.ObterInativos();
            lblInativosTotal.Text = usuarioViewModel.qtdInativos.ToString();
            usuarioDAO.Dispose();
        }
        protected void TipoUser()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = new Usuario();
            if (usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).tipo == 'i')
            {
                usuarioDAO.Dispose();
                Response.Redirect("Inicial.aspx");
            }
            else if (usuarioDAO.ObterUsuarioPorLogin(Session["usuario"].ToString()).tipo != 'm')
            {
                usuarioDAO.Dispose();
                Response.Redirect("PaginaBlogs.aspx");
            }

        }
        private void PopularGrid()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> listaUsuario = new List<Usuario>();

            listaUsuario = usuarioDAO.ObterTodosUsuarios();
        
            grdUsuarios.DataSource = listaUsuario;
            grdUsuarios.DataBind();
            usuarioDAO.Dispose();
        }

        protected void grdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idx = Convert.ToInt32(e.CommandArgument);

            int id_u = Convert.ToInt32(grdUsuarios.DataKeys[idx].Value);

            Usuario usuario = new Usuario();

            if (e.CommandName == "Excluir")
            {
                UsuarioDAO obter = new UsuarioDAO();
                lblAtivar.Visible = false;
                lblInativar.Visible = false;
                lblPoucoModerador.Visible = false;
                lblAlterarTipo.Visible = false;
                lblAlterarInativo.Visible = false;
                if ((obter.ObterModeradores() == false && id_u != obter.ObterUsuarioPorLogin(Session["usuario"].ToString()).id) || (obter.ObterModeradores() == true))
                {
                    using (UsuarioDAO td = new UsuarioDAO())
                    {
                        td.DeletarUmUsuario(id_u);
                    }
                    TipoUser();
                    PopularGrid();
                    PopularAtivos();
                    PopularInativos();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    if (usuarioDAO.ObterUsuarioPorId(id_u).tipo == 'i')
                    {
                        lblInativar.Visible = true;
                    }
                    else
                    {
                        lblAtivar.Visible = true;
                    }
                    usuarioDAO.Dispose();
                }
                else
                {
                    lblPoucoModerador.Visible = true;
                }
                obter.Dispose();

            }
            else if (e.CommandName == "Alterar")
            {
                UsuarioDAO obter = new UsuarioDAO();
                lblAtivar.Visible = false;
                lblInativar.Visible = false;
                lblPoucoModerador.Visible = false;
                lblAlterarTipo.Visible = false;
                lblAlterarInativo.Visible = false;
                if ((obter.ObterModeradores() == false && id_u != obter.ObterUsuarioPorLogin(Session["usuario"].ToString()).id) || (obter.ObterModeradores() == true))
                {
                    using (UsuarioDAO td = new UsuarioDAO())
                    {
                        td.TornarModerador(id_u);
                    }
                    TipoUser();
                    PopularGrid();
                    PopularAtivos();
                    PopularInativos();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    if (usuarioDAO.ObterUsuarioPorId(id_u).tipo == 'i')
                    {
                        lblAlterarInativo.Visible = true;
                    }
                    else
                    {
                        lblAlterarTipo.Visible = true;
                    }
                    usuarioDAO.Dispose();
                }
                else
                {
                    lblPoucoModerador.Visible = true;
                }
                obter.Dispose();
            }
        }
    }
}