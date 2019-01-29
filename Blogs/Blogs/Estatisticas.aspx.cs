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
    public partial class Estatisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopularLabelQtdBlogs();
                PopularGrid();
                PopularOutraGrid();
            }
        }
       
       
        private void PopularLabelQtdBlogs()
        {
            BlogDAO blogDAO = new BlogDAO();
            BlogViewModel blogViewModel = new BlogViewModel();
            blogViewModel = blogDAO.ObterResul();
            lblQntBlogs.Text = blogViewModel.qntBlogs.ToString();
            blogDAO.Dispose();
        }
        
        
        private void PopularGrid()
        {
            PostDAO postDAO = new PostDAO();
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            postViewModels = postDAO.ObterPostagensPorBlog();
            grdQtdPosts.DataSource = postViewModels;
            grdQtdPosts.DataBind();
            postDAO.Dispose();
        }
        private void PopularOutraGrid()
        {
            ComentarioDAO comentarioDAO = new ComentarioDAO();
            List<ComentViewModel> comentarioDAOs = new List<ComentViewModel>();
            comentarioDAOs = comentarioDAO.ObterComentariosPorPostagem();
            grdQtdComentarios.DataSource = comentarioDAOs;
            grdQtdComentarios.DataBind();
            comentarioDAO.Dispose();
        }
        
    }
}