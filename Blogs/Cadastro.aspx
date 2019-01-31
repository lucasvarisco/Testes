<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Blogs.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    <div class="title-page" style="text-align:center;">
        <p> <span class="tamanho2">Faça o seu cadastro</span> </p>
    </div>
    
    <p> <asp:Label ID="lblCampoObrigatorio" runat="server" Text="* Campo obrigatório"></asp:Label></p>
    <p> <label for="lblSenha">Nome completo*</label><asp:TextBox ID="txtNome" placeholder="Nome completo" MaxLength="80" runat="server"></asp:TextBox>
    </p>
    <p> <label for="lblSenha">Senha*</label><asp:TextBox ID="txtSenha" placeholder="******" runat="server" TextMode="Password"></asp:TextBox></p>
    <p> <label for="lblSenha">E-mail*</label><asp:TextBox ID="txtEmail" placeholder="email@dominio.com.br" MaxLength="40" runat="server" TextMode="Email"></asp:TextBox></p>
    <p> <label for="lblSenha">Nome de usuário*</label><asp:TextBox ID="txtUser" placeholder="Usuário válido" MaxLength="15" runat="server"></asp:TextBox>
    </p>
    <p> <label for="lblRecuperacao">CPF(apenas números)*</label><asp:TextBox ID="txtSenhaRecuperacao" type="number" placeholder="Resposta da pergunta-chave" runat="server"></asp:TextBox></p>
    <p> <label>
        <asp:RadioButton ClientIDMode="Static" ID="rdbAdm" runat="server" OnCheckedChanged="rdbAdm_CheckedChanged" />
        <span>Plano Administrador</span>
        </label></p>
    <p class="lbl-align red-text"> <asp:Label ID="lblNaoPreenchido" runat="server" Text="Campo obrigatório não preenchido!" Visible="False"></asp:Label></p>
    <p class="lbl-align red-text"> <asp:Label ID="lblUsuarioExistente" runat="server" Text="O nome de usuário já existe!" Visible="false"></asp:Label></p>
    <p class="lbl-align red-text"> <asp:Label ID="lblEmailExistente" runat="server" Text="E-mail já cadastrado!" Visible="false"></asp:Label></p>
    <p class="lbl-align green-text"> <asp:Label ID="lblUsuarioCriado" runat="server" Text="Cadastro efetuado com sucesso!" Visible="False"></asp:Label></p>
    <p style="margin-bottom: 10%;"> <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnCadastro" runat="server" Text="Cadastrar" OnClick="btnCadastro_Click" style="float:left"/>   
        <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnRetornar" runat="server" Text="Voltar" OnClick="btnRetornar_Click" style="float:right" Visible="False"/></p>
     
</asp:Content>
