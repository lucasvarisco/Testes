<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PaginaBlogs.aspx.cs" Inherits="Blogs.PaginaBlogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <script>
        document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.tooltipped');
    var instances = M.Tooltip.init(elems);
  });</script>
    
    <div class="row alinhamento1">
        
        <div class="col s3">
    <p> <asp:TextBox ID="txtNomeBlog" placeholder="Nome Blog" MaxLength="80" runat="server"></asp:TextBox> </p>
    <p> <asp:TextBox ID="txtTemaBlog" placeholder="Tema Blog" runat="server"></asp:TextBox> </p>
    <p class="red-text"> <asp:Label ID="lblCampoBranco" runat="server" Text="Campo obrigatório não preenchido!" Visible="False"></asp:Label></p>
    <p class="red-text"> <asp:Label ID="lblBlogExistente" runat="server" Text="Já existe um blog com este nome!" Visible="False"></asp:Label></p>
    <p class="lbl-align green-text"> 
        <asp:Label ID="lblBlogCriado" runat="server" Text="Blog criado com sucesso!" Visible="False"></asp:Label></p>
    <p> <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnCriar" runat="server" Text="Criar um blog" OnClick="btnCriar_Click" /> </p>
    <p> <asp:Button CssClass="btn textoplano" style="height: 100px; word-break: break-word; white-space: normal; line-height: 1.75em; color:#1976D2; border: 1.5px solid #1976D2;border-radius: 5px;box-shadow: 0 8px 16px 0 #ccc; margin-top: 25%;" ID="btnPlanos" runat="server" Text="Seja um membro administrador também" OnClick="btnPlanos_Click" Visible="False" /></p>  
        </div>
        
        <div class="col s8">
    <p  style="height: 5px"> <label for="lblListaBlogs">Acesse um blog abaixo</label> </p>
    <p> <asp:DropDownList AutoPostBack="true" ID="ddlListaBlogs" runat="server" OnSelectedIndexChanged="ddlListaBlogs_SelectedIndexChanged"> </asp:DropDownList>
        <asp:LinkButton CssClass="tooltipped" data-position="right" data-tooltip="Excluir blog" ID="LinkbtnLixeiraBlog" runat="server" OnClick="LinkbtnLixeiraBlog_Click" Visible="False" OnClientClick="return confirm ('Quer mesmo excluir o blog?');">
            <i class="material-icons" style="color:grey">delete</i>
        </asp:LinkButton> 
            </p>
    <p class="red-text"> <asp:Label ID="lblBlogExcluido" runat="server" Text="Blog deletado com sucesso!" Visible="False"></asp:Label></p>
    <p  style="height: 5px"> <label for="lblTemaBlog">Tema</label> </p>
    <p> <asp:Label ID="lblTemaBlog" runat="server" Text="Label"></asp:Label> 
            </p>
    <p  style="height: 5px"> <label for="lblTemas">Posts</label></p>
    <p> <asp:DropDownList ID="ddlListaPosts" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlListaPosts_SelectedIndexChanged"></asp:DropDownList>
        <asp:LinkButton Cssclass="tooltipped" data-position="right" data-tooltip="Excluir post" ID="LinkbtnLixeiraPost" runat="server" OnClick="LinkbtnLixeiraPost_Click" Visible="False" OnClientClick="return confirm ('Quer mesmo excluir o post?');">
            <i class="material-icons" style="color:grey">delete</i>
        </asp:LinkButton>
    </p>
    <p class="red-text"> <asp:Label ID="lblPostExcluido" runat="server" Text="Post deletado com sucesso!" Visible="False"></asp:Label></p>
    <p> <asp:Label ID="lblCriadoPor" runat="server" Text="Criado por "></asp:Label> 
        <asp:Label ID="lblAutorPost" runat="server" Text="Label"></asp:Label> 
        <asp:Label ID="lblCriadoEm" runat="server" Text=" em "></asp:Label>
        <asp:Label ID="lblHoraPost" runat="server" Text="Label"></asp:Label> 
        </p>
    <p  style="height: 5px"> <label ID="lblDesc" runat="server" visible="false" for="lblTextoPost">Descrição do post</label></p>
    <p> <asp:Label ID="lblTextoPost" runat="server" Text="Label"></asp:Label> </p>
    <p> <asp:TextBox ID="txtNovoPost" placeholder="Titulo Post" MaxLength="80" runat="server"></asp:TextBox> </p>
    <p> <asp:TextBox ID="txtTemaPost" placeholder="Texto Post" runat="server"></asp:TextBox> </p>
    <p class="lbl-align red-text"> <asp:Label ID="lblEmBranco" runat="server" Text="Campo obrigatório não preenchido!" Visible="False"></asp:Label></p>
    <p class="lbl-align red-text"> <asp:Label ID="lblPostExistente" runat="server" Text="Post de mesmo nome já existente neste blog!" Visible="False"></asp:Label></p>
    <p class="lbl-align green-text"> <asp:Label ID="lblPostCriado" runat="server" Text="Post criado com sucesso!" Visible="False"></asp:Label></p>
    <p> <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnCriarPost" runat="server" Text="Criar post" OnClick="btnCriarPost_Click" />
        <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnCriacaoPost" runat="server" OnClick="btnCriacaoPost_Click" Text="Criar um post neste blog" style="float:left"/>
        <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnIrBlog" runat="server" Text="Ler a descrição do post" OnClick="btnIrBlog_Click" style="float:right"/> </p>
    </div>
        
        <div class="col s1">
     <p class="center-align"> 
         <asp:LinkButton Cssclass="tooltipped" data-position="left" data-tooltip="Gerenciar usuários" ID="LinkbtnGerenciador" runat="server" OnClick="LinkbtnGerenciador_Click" Visible="False">
         <i  class="small material-icons" style="color:grey">group</i></asp:LinkButton></p>
     <p class="center-align"> 
         <asp:LinkButton Cssclass="tooltipped" data-position="left" data-tooltip="Estatísticas" ID="LinkbtnEstatisticas" runat="server" OnClick="LinkbtnEstatisticas_Click">
         <i  class="small material-icons" style="color:grey">assessment</i></asp:LinkButton></p>
     <p class="center-align"> 
         <asp:LinkButton Cssclass="tooltipped" data-position="left" data-tooltip="Dados pessoais" ID="LinkbtnDadosPessoais" runat="server" OnClick="LinkbtnDadosPessoais_Click">
         <i  class="small material-icons" style="color:grey">account_circle</i></asp:LinkButton></p>
     <p class="center-align"> 
         <asp:LinkButton Cssclass="tooltipped" data-position="left" data-tooltip="Sair" ID="LinkbtnSair" runat="server" OnClick="LinkbtnSair_Click">
         <i  class="small material-icons" style="color:grey">arrow_back</i></asp:LinkButton></p>
    </div>

</div>
</asp:Content>
