<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Estatisticas.aspx.cs" Inherits="Blogs.Estatisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
    <p> <asp:Label ID="lblTexto" runat="server" Text="Nosso site conta hoje com"></asp:Label>  </p>
    <p> <asp:Label CssClass="lbl-ne lbl-size" ID="lblQntBlogs" runat="server" Text="Label"></asp:Label>  </p>
    <p style="margin-bottom: 3%"> <asp:Label ID="lblTexto2" runat="server" Text="blogs"></asp:Label>  </p>
    </div>
    
    <div class="row lbl-align alinhamento2">

        <div class="col s5 estatistica">
    <p> <asp:GridView ID="grdQtdPosts" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="nome_blog" HeaderText="Blog" />
                    <asp:BoundField DataField="qtdPosts" HeaderText="Quantidade de posts" />
                </Columns>
            </asp:GridView>
    </p>
        </div>

        <div class="col s1"></div>
        
        <div class="col s6 estatistica" >    
    <p> <asp:GridView ID="grdQtdComentarios" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="nome_blog" HeaderText="Blog" />
                    <asp:BoundField DataField="nome_post" HeaderText="Post" />
                    <asp:BoundField DataField="qtdComentarios" HeaderText="Comentários" />
                </Columns>
            </asp:GridView>
    </p>
         </div>

       </div>
</asp:Content>
