<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeGrupoClausulas.aspx.cs" Inherits="Condiciones.GrupoClausulas.ListaDeGrupoClausulas" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
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
    <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
    <div class="PaginaPortal">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:UpdatePanel runat="server" ID="UpDatos">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnl" DefaultButton="BBuscar">
                    <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                        <tr style="background-color: #e5ebf7">
                            <td style="text-align: left;">
                                <table border="0" cellpadding="1" cellspacing="1" width="90%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="LTipoGrupo" runat="server" Text="Tipo:" CssClass="Text_Normal" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlTipoGrupoClausula" runat="server" 
                                                CssClass="DropDownList_M" AutoPostBack="true" EnableViewState="true" 
                                                OnSelectedIndexChanged="DdlTipoGrupoClausula_SelectedIndexChanged" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="Text_Normal" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlPais" runat="server" CssClass="DropDownList_M" 
                                                AutoPostBack="true" EnableViewState="true" 
                                                OnSelectedIndexChanged="DdlPais_SelectedIndexChanged" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LProducto" runat="server" Text="Producto:" CssClass="Text_Normal" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlProducto" runat="server" AutoPostBack="true" CssClass="DropDownList_XX" EnableViewState="true" OnSelectedIndexChanged="DdlProducto_SelectedIndexChange" OnDataBound="DropDownList_DataBound" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LCodigoTarifa" runat="server" Text="Tarifa:" CssClass="Text_Normal" />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TbCodigoTarifa" Width="40px" CssClass="Text_Normal" EnableViewState="true" />
                                            <ajx:AutoCompleteExtender ID="AceCodigoTarifa" runat="server" ServicePath="~/Servicios/ServicioAutocompletarTarifa.asmx" ServiceMethod="GetSuggestions" TargetControlID="TbCodigoTarifa" MinimumPrefixLength="1"
                                                CompletionSetCount="12" ContextKey="">
                                            </ajx:AutoCompleteExtender>
                                            <asp:DropDownList ID="DdlPlanes" runat="server" CssClass="DropDownList_XX" DataTextField="Nombre" AutoPostBack="true" DataValueField="Codigo" OnDataBound="DropDownList_DataBoundEmptyCode" EnableViewState="true"
                                                Visible="false">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="LSufijo" runat="server" Text="Sufijo:" CssClass="Text_Normal" EnableViewState="true" />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TbSufijo" Width="40px" CssClass="Text_Normal" />
                                            <ajx:AutoCompleteExtender ID="AceSufijo" runat="server" ServicePath="~/Servicios/ServicioAutocompletarSufijo.asmx" ServiceMethod="GetSuggestions" TargetControlID="TbSufijo" MinimumPrefixLength="1" CompletionSetCount="12">
                                            </ajx:AutoCompleteExtender>
                                        </td>
                                        <td class="btn-cntnr">
                                            <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" />
                                        </td>
                                        <td class="btn-cntnr">
                                            <asp:Button ID="BNuevo" runat="server" Text="Nuevo" OnClick="BNuevo_Click" CssClass="Button_Normal" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <br />
                                <asp:GridView ID="GvGruposClausulas" runat="server" 
                                    PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="20" 
                                    Width="70%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                    AllowPaging="True" AllowSorting="True" 
                                    OnRowDataBound="GvGruposClausulas_RowDataBound" 
                                    OnRowCommand="GvGruposClausulas_RowCommand" 
                                    OnPageIndexChanging="GvGruposClausulas_PageIndexChanging" RowStyle-CssClass="GridView_Row_Data_Normal"
                                    PagerType="DropDownList" ExportPDF="Yes" CssClass="tbl-generic" 
                                    EmptyDataText="No hay registros">
                                    <Columns>
                                        <asp:BoundField HeaderText="Id" DataField="Id" />
                                        <asp:BoundField HeaderText="Tipo" DataField="NombreTipoGrupoClausula" />
                                        <asp:BoundField HeaderText="Pais" DataField="NombreLocacion" />
                                        <asp:BoundField HeaderText="Producto" DataField="Producto" />
                                        <asp:BoundField HeaderText="Sufijo" DataField="Sufijo" />
                                        <asp:BoundField HeaderText="Es Anual" DataField="EsAnual" />
                                        <asp:BoundField HeaderText="Modalidad" DataField="TipoModalidad" />
                                        <asp:BoundField HeaderText="Texto Resumen" DataField="NombreTextoResumen" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Editar" ItemStyle-HorizontalAlign="Center">
                                            <ControlStyle CssClass="EditarGridButton" />
                                        </asp:ButtonField>
                                        <asp:ButtonField ButtonType="Button" CommandName="Copiar" ItemStyle-HorizontalAlign="Center">
                                            <ControlStyle CssClass="CopiarGridButton" />
                                        </asp:ButtonField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                            <ItemTemplate>
                                                <asp:Button CssClass="EliminarGridButton" ID="BEliminar" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <%--<asp:BoundField  HeaderText="IdContenidoClausula" DataField="Id"/>--%>
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="GvGruposClausulas" />
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
        <uc1:SessionController ID="SessionController1" runat="server" />
    </div>
    </form>
</body>
</html>
