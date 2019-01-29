<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecuperacaoSenha.aspx.cs" Inherits="Blogs.RecuperacaoSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="text-align: center;">
    <div class="title-page" style="text-align: center;">
        <p><span class="tamanho">Recuperação de senha</span> </p>
    </div>
    <div class="estatistica caixatexto">
    
    <p style="margin-left:8%; margin-right:8%;"> 
        <asp:TextBox ID="txtNomeRecuperacao" placeholder="Nome completo" runat="server" style="margin-top:2%"></asp:TextBox>
    </p>
    <p style="margin-left:8%; margin-right:8%;"> 
        <asp:TextBox ID="txtSenhaRecuperacao" placeholder="CPF(apenas números)" type="number" runat="server" style="margin-top:2%"></asp:TextBox>
    </p>
    <p class="lbl-align red-text"> <asp:Label ID="lblNomeResposta" runat="server" Text="Nome e resposta não conferem!" Visible="False"></asp:Label></p>
    <p class="lbl-align red-text"> <asp:Label ID="lblEmBranco" runat="server" Text="Campo obrigatório não preenchido!" Visible="False"></asp:Label></p>
    <p> <asp:Button CssClass="btn #1565c0 blue darken-2" style="margin-bottom: 3%;" ID="btnConfirma" runat="server" Text="Confirma" OnClick="btnConfirma_Click" /></p>
    <p style="margin-left:8%; margin-right:8%;"> <asp:TextBox ID="txtNovaSenha" placeholder="Nova senha" runat="server" TextMode="Password"></asp:TextBox></p>
    <p class="lbl-align red-text"> <asp:Label ID="lblCampoBranco" runat="server" Text="Campo obrigatório não preenchido!" Visible="False"></asp:Label></p>
    <p> <asp:Button CssClass="btn #1565c0 blue darken-2" style="margin-bottom: 3%;" ID="btnCadastroNovaSenha" runat="server" Text="Cadastro Senha Nova" OnClick="btnCadastroNovaSenha_Click" /></p>

        </div>
        </div>

</asp:Content>
