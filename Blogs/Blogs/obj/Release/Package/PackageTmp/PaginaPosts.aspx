<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PaginaPosts.aspx.cs" Inherits="Blogs.PaginaPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="title-page lbl-ne lbl-size" style="text-align:center;">
        <p> <span>Dados Cadastrais</span> </p>
    </div>
    <div class="row lbl-align">
        
        <div class="col s3"> 
            </div>
        
        <div class="col s6">    
    <p> <label for="txtNome">Nome</label><asp:TextBox ID="txtNome" runat="server" ReadOnly="True"></asp:TextBox> </p>
    <p> <label for="txtEmail">E-mail</label><asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox> </p>
    <p> <label for="txtSenha">Senha</label></p>
    <p> <asp:TextBox ID="txtSenhaAntiga" placeholder="Senha antiga" runat="server" TextMode="Password"></asp:TextBox> </p>
    <p> <asp:TextBox ID="txtSenhaNova" placeholder="Senha nova" runat="server" TextMode="Password"></asp:TextBox> </p>
    <p class="lbl-align red-text"> <asp:Label ID="lblCampoBranco" runat="server" Text="Campo não preenchido!" Visible="false"></asp:Label></p>
    <p class="lbl-align red-text"> <asp:Label ID="lblSenhaErrada" runat="server" Text="Senha não confere!" Visible="false"></asp:Label></p>
    <p class="lbl-align green-text"> <asp:Label ID="lblSenhaAlterada" runat="server" Text="Senha alterada com sucesso!" Visible="false"></asp:Label></p>
    <p> <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnNovaSenha" runat="server" Text="Alterar senha" OnClick="btnNovaSenha_Click" OnClientClick="return confirm ('Deseja realmente alterar sua senha?');" /> </p>
            </div>

        <div class="col s3" style="word-break: break-word; white-space: normal; line-height: 1.75em; border: 1.5px solid #42576d; border-radius: 5px; box-shadow: 0 8px 16px 0 #ccc; margin-top: 2%;"> 
    <p> <asp:Label ID="lblTextoPlano" runat="server" Text="Você conta hoje com o plano"></asp:Label> </p>
    <p> <asp:Label CssClass="lbl-ne lbl-size" ID="lblTipoPlano" runat="server" Text="Label"></asp:Label> </p>
    <p> <asp:Button  CssClass="btn #1565c0 blue darken-2" ID="btnMudarPlano" runat="server" Text="Mudar de plano" OnClick="btnMudarPlano_Click" OnClientClick="return confirm ('Deseja realmente mudar de plano?');"/> </p>
</div>
        </div>
       
</asp:Content>
