using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto_Blog_Model;
using Projeto_Blog_DAO;

namespace Blogs
{
    public partial class RecuperacaoSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNovaSenha.Visible = false;
            btnCadastroNovaSenha.Visible = false;
        }

        protected void btnConfirma_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            if (!string.IsNullOrWhiteSpace(txtSenhaRecuperacao.Text) && !string.IsNullOrWhiteSpace(txtNomeRecuperacao.Text))
            {
                lblEmBranco.Visible = false;
                if (usuarioDao.ValidarNovaSenha(txtNomeRecuperacao.Text, txtSenhaRecuperacao.Text) == true)
                {
                    lblNomeResposta.Visible = false;
                    txtNovaSenha.Visible = true;
                    btnCadastroNovaSenha.Visible = true;
                    txtNomeRecuperacao.Visible = false;
                    txtSenhaRecuperacao.Visible = false;
                    btnConfirma.Visible = false;
                }
                else
                {
                    lblNomeResposta.Visible = true;
                    lblEmBranco.Visible = false;
                }
            }
            else
            {
                lblEmBranco.Visible = true;
                lblNomeResposta.Visible = false;
            }
                usuarioDao.Dispose();
        }

        protected void btnCadastroNovaSenha_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarios = new UsuarioDAO();
            if (!string.IsNullOrWhiteSpace(txtNovaSenha.Text))
            {
                lblCampoBranco.Visible = false;
                Usuario usuario = new Usuario();
                usuario.id = usuarios.ObterUsuarioPorNome(txtNomeRecuperacao.Text).id;
                usuario.senha = txtNovaSenha.Text;
                usuarios.AtualizarSenha(usuario);
                usuarios.Dispose();
                Response.Redirect("Inicial.aspx");
            }
            else
            {
                txtNovaSenha.Visible = true;
                btnCadastroNovaSenha.Visible = true;
                lblCampoBranco.Visible = true;
            }
            usuarios.Dispose();
        }
    }
}