<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="Blogs.Inicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div style="text-align: center;">
    <div class="title-page" style="text-align: center;">
        <p><span class="tamanho">Entre</span> </p>
    </div>
    <div class="estatistica caixatexto">
    <p style="margin-left:8%; margin-right:8%;">
        <asp:TextBox ID="txtLogin" placeholder="Login" runat="server" style="margin-top:2%"></asp:TextBox>
    </p>
    <p style="margin-left:8%; margin-right:8%;">
        <asp:TextBox ID="txtSenha" placeholder="Senha" runat="server" TextMode="Password"></asp:TextBox>
    </p>
        <p class="lbl-align red-text">
          <asp:Label ID="lblBrancoInválida" runat="server" Text="Usuário ou senha não conferem!" Visible="False"></asp:Label>
        </p>
        <p class="lbl-align red-text">
          <asp:Label ID="lblBranco" runat="server" Text="Campo obrigatório em branco!" Visible="False"></asp:Label>
        </p>
         <p class="lbl-align red-text">
          <asp:Label ID="lblInvalido" runat="server" Text="Usuário inativo!" Visible="false"></asp:Label>
        </p>
        <p style="margin-left:8%; display: flex;">
        <asp:LinkButton ID="LinkbtnRecuperacao" runat="server" OnClick="LinkbtnRecuperacao_Click" style="margin-bottom:2%">Esqueci minha senha</asp:LinkButton>
    </p>
        <p>
        <asp:Button Cssclass="btn #1565c0 blue darken-2" ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" /></p>
       <p> <asp:Label ID="lblRegistrando" runat="server" Text="Ainda não é usuário do blog? "></asp:Label>
        <asp:LinkButton ID="LinkbtnRegistre" runat="server" OnClick="LinkbtnRegistre_Click">Registre-se aqui</asp:LinkButton>
    </p>
    </div>
    </div>
   
        
</asp:Content>
