<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeGrupoCondiciones.aspx.cs"
    Inherits="Condiciones.Consulta.ListaDeGrupoCondiciones" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
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
                <asp:Panel runat="server" ID="pnl" DefaultButton="BBuscar">
                    <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                        <tr style="background-color: #e5ebf7">
                            <td style="text-align: left;">
                                <table border="0" cellpadding="1" cellspacing="1" class="tbl-menu">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPais" runat="server" Text="País" CssClass="Text_Normal" meta:resourceKey="country" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlPais" runat="server" CssClass="DropDownList_M" AutoPostBack="true"
                                                OnSelectedIndexChanged="DdlPais_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="LProducto" runat="server" Text="Producto" CssClass="Text_Normal" meta:resourceKey="product" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlProducto" runat="server" DataValueField="Id" DataTextField="CodigoYNombre"
                                                AutoPostBack="true" CssClass="DropDownList_M" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LUpgrade" runat="server" Text="Upgrade" CssClass="Text_Normal" meta:resourceKey="upgrade" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlUpgrade" runat="server" DataValueField="Id" DataTextField="CodigoYNombre"
                                                AutoPostBack="true" CssClass="DropDownList_M" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LProductoSinEmision" runat="server" Text="Negocio" CssClass="Text_Normal" meta:resourceKey="business" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlProductoSinEmision" runat="server" DataValueField="Id" DataTextField="Nombre"
                                                AutoPostBack="true" CssClass="DropDownList_M" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LSufijo" runat="server" Text="Sufijo/Plan" CssClass="Text_Normal" meta:resourceKey="sufix" />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TbSufijo" Width="40px" CssClass="Text_Normal inpt-txt" />
                                            <ajx:AutoCompleteExtender ID="AceSufijo" runat="server" ServicePath="~/Servicios/ServicioAutocompletarSufijo.asmx"
                                                ServiceMethod="GetSuggestions" TargetControlID="TbSufijo" MinimumPrefixLength="1"
                                                CompletionSetCount="12">
                                            </ajx:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIdioma" runat="server" class="DropDownList_S" AutoPostBack="true" OnSelectedIndexChanged="DdlIdioma_SelectedIndexChanged">
                                                <asp:ListItem Text="ES" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="EN" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="PT" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="btn-cntnr">
                                            <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" meta:resourceKey="search" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div align="center">
                    <br />
                    <asp:GridView ID="GvGruposClausulas" runat="server" PagerStyle-CssClass="GridView_Pager_Normal"
                        BorderWidth="0px" PageSize="20" Width="60%" HeaderStyle-CssClass="GridView_Row_Header_Normal"
                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnRowDataBound="GvGruposClausulas_RowDataBound"
                        OnRowCommand="GvGruposClausulas_RowCommand" RowStyle-CssClass="GridView_Row_Data_Normal"
                        OnPageIndexChanging="GvGruposClausulas_PageIndexChanging" Export="Yes" class="tbl-generic">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField HeaderText="Condiciones del Tipo de Grupo" DataField="NombreTipoGrupoClausula" meta:resourceKey="conditionsb" />
                            <asp:BoundField HeaderText="País" DataField="NombreLocacion" meta:resourceKey="countryb" />
                            <asp:BoundField HeaderText="Producto" DataField="Producto" meta:resourceKey="productb" />
                            <asp:BoundField HeaderText="Sufijo" DataField="Sufijo" meta:resourceKey="sufixb" />
                            <asp:BoundField HeaderText="Modalidad" DataField="TipoModalidad" meta:resourceKey="modalityb" />
                            <asp:ButtonField ButtonType="Button" CommandName="VerDetalle" ItemStyle-HorizontalAlign="Center"
                                ControlStyle-CssClass="VerDetalleGridButton" />
                        </Columns>
                    </asp:GridView>
                    <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpEsperaAccion" runat="server">
            <ProgressTemplate>
                <div class="ProgressBanner">
                    <img src="../IMG/loading.gif" alt="Cargando Página" />
                    <p>
                        <asp:Literal ID="ltrLoading" runat="server" Text="Cargando Página ..." meta:resourceKey="loading"></asp:Literal>
                    </p>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
