<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Blogs.Usuarios" %>

<%@ Import Namespace="Projeto_Blog_Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        tr td:nth-child(4) {
            font-size: 22px;
        }
    </style>

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.tooltipped');
            var instances = M.Tooltip.init(elems);
        });</script>

    <div style="text-align: center;">
        <div class="title-page" style="text-align: center;">
            <p><span class="tamanho">Lista de Usuários</span> </p>
        </div>
        <div class="estatistica caixatexto3">


            <div>
                <p class="lbl-align green-text">
                    <asp:Label ID="lblInativar" runat="server" Text="Usuário inativado com sucesso!" Visible="false"></asp:Label>
                </p>
                <p class="lbl-align green-text">
                    <asp:Label ID="lblAtivar" runat="server" Text="Usuário reativado com sucesso!" Visible="false"></asp:Label>
                </p>
                <p class="lbl-align red-text">
                    <asp:Label ID="lblPoucoModerador" runat="server" Text="Não é possível excluir todos os moderadores!" Visible="false"></asp:Label>
                </p>
                <p class="lbl-align green-text">
                    <asp:Label ID="lblAlterarTipo" runat="server" Text="Tipo do usuário alterado com sucesso!" Visible="false"></asp:Label>
                </p>
                <p class="lbl-align red-text">
                    <asp:Label ID="lblAlterarInativo" runat="server" Text="Um usuário inativo não pode se tornar moderador!" Visible="false"></asp:Label>
                </p>
            </div>
            <div style="margin-left: 3%; margin-right: 3%; margin-top: 3%; margin-bottom: 3%">
                <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grdUsuarios_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="Nome" />
                        <asp:BoundField DataField="usuar" HeaderText="Usuário" />
                        <asp:BoundField DataField="email" HeaderText="E-mail" />
                        <asp:TemplateField HeaderText="Situação">
                            <ItemTemplate>
                                <asp:Label Text='<%# (Container.DataItem as Usuario).tipo.ToString() == "i" ? "Inativo" : "Ativo" %>' ID="lblSituacao"
                                    runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Moderação">
                            <ItemTemplate>
                                <asp:Label Visible="<%# (Container.DataItem as Usuario).moderador %>" ID="iconeModerador"
                                    runat="server">
                                       <i class="material-icons" style="color:grey">check</i>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Adicionar/Retirar Moderador">
                            <ItemTemplate>
                                <asp:LinkButton CssClass="tooltipped" data-position="left" data-tooltip="Ativar/Inativar" ID="LinkbtnModerador"
                                    OnClientClick="return confirm ('Deseja realmente alterar o tipo deste usuário?');"
                                    CommandName="Alterar"
                                    CommandArgument="<%#((GridViewRow)Container).RowIndex%>"
                                    runat="server">
                            <i class="material-icons" style="color:grey">camera_front</i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ativar/Inativar Usuário">
                            <ItemTemplate>
                                <asp:LinkButton CssClass="tooltipped" data-position="left" data-tooltip="Ativar/Inativar" ID="LinkbtnLixeiraUser"
                                    OnClientClick="return confirm ('Quer mesmo excluir este usuário?');"
                                    CommandName="Excluir"
                                    CommandArgument="<%#((GridViewRow)Container).RowIndex%>"
                                    runat="server">
                            <i class="material-icons" style="color:grey">delete_forever</i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div style="white-space: normal; line-height: 1.75em; border-radius: 5px; box-shadow: 0 0px 16px 0 #ccc; margin-top: 2%; margin-left: 40%; margin-right: 40%; text-align: center; margin-bottom: 3%;">
        <p>
            <asp:Label ID="lblAtivos" runat="server" Text="Ativos: " Visible="true"></asp:Label>
            <asp:Label ID="lblAtivosTotal" runat="server" Text="Label" Visible="true"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblInativos" runat="server" Text="Inativos: " Visible="true"></asp:Label>
            <asp:Label ID="lblInativosTotal" runat="server" Text="Label" Visible="true"></asp:Label>
        </p>
    </div>
</asp:Content>
