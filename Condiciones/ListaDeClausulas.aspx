<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="ListaDeClausulas.aspx.cs" Inherits="Condiciones.ListaDeClausulas" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
<%@ Register src="Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="CSS/Espera.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:UpdatePanel ID="UpClausulas" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnl" DefaultButton="bBuscar">
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td>
                            <table border="0" cellpadding="1" cellspacing="1" width="70%">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTipoClausula" runat="server" Text="Cláusula:" CssClass="Text_Normal_R" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlTipoClausula" runat="server" CssClass="DropDownList_M" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblCodigo" runat="server" Text="Código:" CssClass="Text_Normal_R" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TbCodigo" runat="server" CssClass="TextBox_S" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Nombre:" CssClass="Text_Normal_R" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TbNombre" runat="server" CssClass="TextBox_M" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="bBuscar" runat="server" Text="Buscar" OnClick="bBuscar_Click" CssClass="Button_Normal" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BAgregar" runat="server" Text="Agregar" OnClick="bAgregar_Click" CssClass="Button_Normal" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:GridView ID="GvClausula" runat="server" AutoGenerateColumns="false" AllowSorting="true" OnSorting="GvClausula_Sorting" OnPageIndexChanging="GvClausula_PageIndexChanging" AllowPaging="true" PageSize="25" PagerStyle-CssClass="GridView_Pager_Normal"
                                HeaderStyle-CssClass="GridView_Row_Header_Normal" OnRowDataBound="GvClausula_RowDataBound" OnRowCommand="GvClausula_RowCommand" RowStyle-CssClass="GridView_Row_Data_Normal" Export="Yes" class="tbl-generic" >
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:TemplateField HeaderText="Idioma" SortExpression="Idioma">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblIdioma" runat="server" CssClass="Text_Normal" Text='<%# DataBinder.Eval(Container.DataItem, "Idioma") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo Clausula" SortExpression="TipoClausula">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblTipoClausula" runat="server" CssClass="Text_Normal" Text='<%# DataBinder.Eval(Container.DataItem, "TipoClausula") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" HeaderStyle-Width="100" SortExpression="Codigo" />
                                    <asp:BoundField HeaderText="Orden" DataField="OrdenPredefinido" HeaderStyle-Width="100" SortExpression="OrdenPredefinido" />
                                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-Width="750" SortExpression="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblNombre" runat="server" CssClass="Text_Normal" Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Button" CommandName="Editar" ItemStyle-HorizontalAlign="Center">
                                        <ControlStyle CssClass="EditarGridButton" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
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
    </div>
    <uc1:SessionController ID="SessionController1" runat="server" />
    </form>
</body>
</html>
