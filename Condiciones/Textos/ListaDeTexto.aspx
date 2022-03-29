<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeTexto.aspx.cs" Inherits="Condiciones.ListaDeTextoResumen" %>

<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
<%@ Register src="../Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Espera.css" type="text/css" />

    <script src="../Js/Condiciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" /><asp:Label runat="server" ID="Label1" CssClass="Text_SiteMap"></asp:Label>        
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:Label runat="server" ID="LSiteMap" CssClass="Text_SiteMap" />
        <asp:UpdatePanel runat="server" ID="UPDatos">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td align="left">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TbNombre" runat="server" CssClass="TextBox_M" />
                                    </td>
                                    <td>
                                        <asp:Label ID="LIdioma" runat="server" Text="Idioma:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlIdioma" runat="server" DataTextField="Nombre" DataValueField="Id" CssClass="DropDownList_SM" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="bBuscar" runat="server" Text="Buscar" OnClick="bBuscar_Click" CssClass="Button_Normal" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="bAgregar" runat="server" Text="Agregar" OnClick="bAgregar_Click" CssClass="Button_Normal" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:GridView ID="GvTextoResumen" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GvTextoResumen_PageIndexChanging" AllowPaging="true" Width="90%" HeaderStyle-CssClass="GridView_Row_Header_Normal"
                                PageSize="25" GridLines="Both" OnRowDataBound="GvTextoResumen_RowDataBound" OnRowCommand="GvTextoResumen_RowCommand" AllowSorting="true" OnSorting="GvTextoResumen_Sorting" RowStyle-CssClass="GridView_Row_Data_Normal"
                                PagerStyle-CssClass="GridView_Pager_Normal" RowStyle-VerticalAlign="Top" Export="Yes" CssClass="tbl-generic">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField SortExpression="Nombre" DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="135" />
                                    <asp:TemplateField HeaderText="Texto" SortExpression="ContenidoTexto" ItemStyle-Width="950">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblTexto" runat="server" Text='<%# Eval("ContenidoTexto") %>' CssClass="Text_Normal" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Button" CommandName="Editar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center">
                                        <ControlStyle CssClass="EditarGridButton" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Button" CommandName="Eliminar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center">
                                        <ControlStyle CssClass="EliminarGridButton" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpEsperaAccion" runat="server">
            <ProgressTemplate>
                <div class="ProgressBanner">
                    <img src="../IMG/loading.gif" alt="Cargando Página" />
                    <p>
                        Cargando Página ...
                    </p>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <uc1:SessionController ID="SessionController1" runat="server" />
    </div>
    </form>
</body>
</html>