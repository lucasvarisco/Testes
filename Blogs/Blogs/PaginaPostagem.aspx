<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PaginaPostagem.aspx.cs" Inherits="Blogs.PaginaPostagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.tooltipped');
            var instances = M.Tooltip.init(elems);
        });</script>

    <div class="lbl-align alinhamento2">
        <p>
            <asp:Label CssClass="lbl-ne lbl-size" ID="lblBlog" runat="server" Text="Blog"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblNomeBlog" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label CssClass="lbl-ne lbl-size" ID="Label1" runat="server" Text="Tema"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblTemaBlog" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label CssClass="lbl-ne lbl-size" ID="lblPost" runat="server" Text="Post"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblNomePost" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label CssClass="lbl-ne lbl-size" ID="lblDescPost" runat="server" Text="Descrição"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblTextoPost" runat="server" Text="Label"></asp:Label>
        </p>
    </div>


    <div class="row">

        <div class="col s1">
        </div>
        <div class="col s10">

            <p>
                <asp:Label ID="lblCriadoPor" runat="server" Text="Criado por "></asp:Label>
                <asp:Label ID="lblCriadorPost" runat="server" Text="Label "></asp:Label>
                <asp:Label ID="lblEm" runat="server" Text=" em "></asp:Label>
                <asp:Label ID="lblHorarioPost" runat="server" Text="Label"></asp:Label>
            </p>

            <p>
                <asp:GridView ID="grdComentarios" ItemStyle-Wrap="True" runat="server" AutoGenerateColumns="False" OnRowCommand="grdComentarios_RowCommand" DataKeyNames="id_comentarios" OnRowCreated="grdComentarios_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="coment" HeaderText="Comentários" />
                        <asp:BoundField DataField="usuar" HeaderText="Usuário" />
                        <asp:BoundField DataField="horario" HeaderText="Horário" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CssClass="tooltipped" data-position="right" data-tooltip="Excluir" ID="LinkbtnLixeiraBlog"
                                    OnClientClick="return confirm ('Quer mesmo excluir o comentário?');"
                                    CommandName="Excluir"
                                    CommandArgument="<%#((GridViewRow)Container).RowIndex%>"
                                    runat="server">
                            <i class="material-icons" style="color:grey">delete</i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </p>
            <p class="estatistica caixatexto2">
                <asp:TextBox ID="txtComentario" placeholder="Escreva um comentário" runat="server" Style="border: none"></asp:TextBox>
            </p>
            <p class="lbl-align red-text">
                <asp:Label ID="lblBranco" runat="server" Text="Campo não preenchido!" Visible="false"></asp:Label>
            </p>
            <p>
                <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnComentar" runat="server" Text="Comentar" OnClick="btnComentar_Click" Style="float: left" />
                <asp:Button CssClass="btn #1565c0 blue darken-2" ID="btnRetornar" runat="server" Text="Voltar" OnClick="btnRetornar_Click" Style="float: right" />
            </p>
        </div>
        <div class="col s1">
        </div>
    </div>
    <div>
        <tr>
            <td style="vertical-align: bottom;" class="rodape">
                <div style="width: 100%; text-align: center; padding-top: 10px; float: left; height: 33px; background-color:aqua">
                    <%: DateTime.Now.Year %>
                    <asp:Label ID="lblDescPawer" runat="server" Text=" © Lucas Mendes. Todos os direitos reservados."></asp:Label>
                </div>
            </td>
        </tr>
    </div>
</asp:Content>
