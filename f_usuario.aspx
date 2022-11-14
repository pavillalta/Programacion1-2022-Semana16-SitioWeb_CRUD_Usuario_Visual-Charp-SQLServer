<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="f_usuario.aspx.cs" Inherits="Semana16_SitioWebCRUDUsuario.f_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p class="text-center" style="font-size: large; color: #0066FF">
        <strong>INGRESO DE USUARIOS</strong></p>
    <table align="center" style="width: 60%; border: 1px solid #3399FF; background-color: #CCFFFF">
        <tr>
            <td style="width: 141px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>Usuarios del sistema</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong>Usuario</strong></td>
            <td>
                <asp:TextBox ID="txtusuario" runat="server" Width="200px" Height="28px"></asp:TextBox>
            </td>
            <td rowspan="15">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idusuario" DataSourceID="SqlDataSource_usuario" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True" Font-Size="Larger">
            <Columns>
                <asp:BoundField DataField="idusuario" HeaderText="idusuario" InsertVisible="False" ReadOnly="True" SortExpression="idusuario" />
                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                <asp:BoundField DataField="clave" HeaderText="clave" SortExpression="clave" />
                <asp:BoundField DataField="nivel" HeaderText="nivel" SortExpression="nivel" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>

            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong>Clave</strong></td>
            <td>
                <asp:TextBox ID="txtclave" runat="server" Width="200px" Height="27px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong>Nivel</strong></td>
            <td>
                <asp:DropDownList ID="lstnivel" runat="server" Height="30px" Width="205px">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong></strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong></strong></td>
            <td>
                <asp:Button ID="bnuevo" runat="server" OnClick="bnuevo_Click" Text="Nuevo" Width="110px" />
&nbsp;<asp:Button ID="bguardar" runat="server" Text="Guardar" Width="110px" OnClick="bguardar_Click" />
                &nbsp;<asp:Button ID="bmodificar" runat="server" Text="Modificar" Width="110px" OnClick="bmodificar_Click" />
&nbsp;<asp:Button ID="bactualizar" runat="server" Text="Actualizar" Width="110px" OnClick="bactualizar_Click" />
            &nbsp;<asp:Button ID="beliminar" runat="server" Text="Eliminar" Width="110px" OnClick="beliminar_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px"><strong></strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px">&nbsp;</td>
            <td>
                Buscar por código de usuario</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px">&nbsp;</td>
            <td>
                <asp:TextBox ID="txtbuscar" runat="server" Width="215px" Height="28px"></asp:TextBox>
            &nbsp;<asp:Button ID="bbuscar" runat="server" Text="Buscar" Width="111px" OnClick="bbuscar_Click" Height="30px" />
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px">&nbsp;</td>
            <td>
                <asp:Label ID="lblmensaje" runat="server" Text="mensaje"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 141px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
    </p>
    <p>

          <center>

        <asp:SqlDataSource ID="SqlDataSource_usuario" runat="server" ConnectionString="<%$ ConnectionStrings:loginConnectionString %>" SelectCommand="SELECT * FROM [usuarios]"></asp:SqlDataSource>
    </center>


    <p>
    </p>
    <p>
    </p>
</asp:Content>
