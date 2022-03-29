<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeDocumentos.aspx.cs" Inherits="Condiciones.ListaDeDocumentos" ValidateRequest="false" %>

<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
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
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:UpdatePanel runat="server" ID="UpDatos">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td style="text-align: left;">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo Documento:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlTipoDocumento" runat="server" CssClass="DropDownList_M" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TbNombre" runat="server" CssClass="Text_Normal" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="bBuscar" runat="server" Text="Buscar" OnClick="bBuscar_Click" CssClass="Button_Normal" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="bAgregar" runat="server" Text="Agregar" OnClick="bAgregar_Click"
                                            CssClass="Button_Normal" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:GridView ID="GvDocumento" runat="server" AutoGenerateColumns="false" OnSorting="GvDocumento_Sorting"
                                AllowSorting="true" OnPageIndexChanging="GvDocumento_PageIndexChanging" AllowPaging="true"
                                PageSize="20" HeaderStyle-CssClass="GridView_Row_Header_Normal" PagerStyle-CssClass="GridView_Pager_Normal"
                                OnRowDataBound="GvDocumento_RowDataBound" RowStyle-CssClass="GridView_Row_Data_Normal"
                                OnRowCommand="GvDocumento_RowCommand" Export="Yes" CssClass="tbl-generic">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:TemplateField HeaderText="Tipo Documento" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblTipoDocumento" CssClass="Text_Normal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoDocumento.Nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" HeaderStyle-Width="300" SortExpression="Nombre" />
                                    <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" HeaderStyle-Width="300"
                                        SortExpression="Observaciones" />
                                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}"
                                        HeaderStyle-Width="80">
                                        <ItemStyle CssClass="GridView_Row_Data_Normal_Center" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Button" CommandName="Editar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-VerticalAlign="Top">
                                        <ControlStyle CssClass="EditarGridButton" />
                                    </asp:ButtonField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href='./DescargaDeDocumento.aspx?IdDocumento=<%# Eval("Id") %>' target="_blank">
                                                <asp:Image ID="IDescargar" runat="server" ImageUrl="../IMG/Icon_find.gif" /></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="GvDocumento" />
            </Triggers>
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

