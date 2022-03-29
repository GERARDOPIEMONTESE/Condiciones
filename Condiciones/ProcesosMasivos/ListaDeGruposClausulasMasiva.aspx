<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeGruposClausulasMasiva.aspx.cs" Inherits="Condiciones.ProcesosMasivos.ListaDeGruposClausulasMasiva" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register TagPrefix="wuc" TagName="ContenidosClausula" Src="~/Controles/WucContenidosClausula.ascx" %>
<%@ Register TagPrefix="wl" TagName="Leyenda" Src="~/Controles/WucLeyenda.ascx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Espera.css" type="text/css" />
    <script src="../Js/Condiciones.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OkButtonClick(id) {
            document.getElementById(id).click();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:Label ID="LFuncionalidad" runat="server" Text="" CssClass="Text_SiteMap"></asp:Label>
        <asp:ScriptManager ID="SManager" runat="server" EnablePageMethods="true" />
        <asp:UpdatePanel runat="server" ID="UPDatos">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td style="text-align: left;">
                            <table border="0" cellpadding="1" cellspacing="1" width="80%">
                                <tr>
                                    <td>
                                        <asp:Label ID="LTipoGrupo" runat="server" Text="Tipo:" CssClass="Text_Normal_R"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlTipoGrupoClausula" runat="server" CssClass="DropDownList_M" AutoPostBack="true" OnSelectedIndexChanged="DdlTipoGrupoClausula_SelectedIndexChanged" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="Text_Normal_R"></asp:Label>
                                    </td>
                                    <td class="btn-cntnr-large">
                                        <asp:Button runat="server" ID="BPaises" Text="Seleccionar" CssClass="Button_Normal" OnClick="BPaises_Click" CausesValidation="false" />
                                        <asp:Panel runat="server" ID="PPaises" CssClass="PanelModalPopUpExtender modal-bkg" Style="display: none;" DefaultButton="BAplicarPaises">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GvPaises" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="10" Width="400" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                            OnPageIndexChanging="GvPaises_PageIndexChanging" AllowPaging="True" AllowSorting="True" OnRowDataBound="GvPaises_RowDataBound" RowStyle-CssClass="GridView_Row_Data_Normal" CssClass="tbl-generic">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label runat="server" ID="LTodos" Text="Todos " CssClass="Text_Normal" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:CheckBox runat="server" ID="CbSeleccionaPais" CssClass="Text_Normal" AutoPostBack="true" OnCheckedChanged="SeleccionarTodos" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="CbSeleccionaPais" CssClass="Text_Normal" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                                            </Columns>
                                                        </asp:GridView>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="btn-cntnr-large">
                                                        <asp:Button ID="BAplicarPaises" runat="server" CausesValidation="false" Text="Aceptar" CssClass="Button_Normal" OnClick="BAplicarPaises_Click" />
                                                        <asp:Button ID="BCancelarPaises" runat="server" Text="Cancelar" CssClass="Button_Normal" OnClick="BCancelarPaises_Click" />
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <ajx:ModalPopupExtender ID="MpePaises" runat="server" TargetControlID="BPaises" PopupControlID="PPaises" BackgroundCssClass="ModalPopupExtender"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="LProducto" runat="server" Text="Producto:" CssClass="Text_Normal_R" />
                                    </td>
                                    <td>
                                        <asp:UpdatePanel runat="server" ID="UpProducto">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DdlProducto" runat="server" DataValueField="Codigo" DataTextField="CodigoYNombre" OnDataBound="DropDownList_DataBound" OnSelectedIndexChanged="DdlProducto_SelectedIndexChanged" AutoPostBack="true"
                                                    CssClass="DropDownList_M">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="LCodigoTarifa" runat="server" Text="Tarifa:" CssClass="Text_Normal"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="TbCodigoTarifa" Width="40px" CssClass="Text_Normal"></asp:TextBox>
                                        <ajx:AutoCompleteExtender ID="AceCodigoTarifa" runat="server" ServicePath="~/Servicios/ServicioAutocompletarTarifa.asmx" ServiceMethod="GetSuggestions" TargetControlID="TbCodigoTarifa" MinimumPrefixLength="1"
                                            CompletionSetCount="12" ContextKey="">
                                        </ajx:AutoCompleteExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="LSufijo" runat="server" Text="Sufijo:" CssClass="Text_Normal"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="TbSufijo" Width="40px" CssClass="Text_Normal"></asp:TextBox>
                                        <ajx:AutoCompleteExtender ID="AceSufijo" runat="server" ServicePath="~/Servicios/ServicioAutocompletarSufijo.asmx" ServiceMethod="GetSuggestions" TargetControlID="TbSufijo" MinimumPrefixLength="1" CompletionSetCount="12">
                                        </ajx:AutoCompleteExtender>
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BBuscar" runat="server" CausesValidation="false" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BTextosResumen" runat="server" Text="Textos" CssClass="Button_Normal" Visible="false" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BDocumentos" runat="server" Text="Documentos" CssClass="Button_Normal" Visible="false" />
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="BCotenidoClausulaRango" runat="server" Text="Contenido" CssClass="Button_Normal" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:UpdatePanel runat="server" ID="UpClausulas">
                                <ContentTemplate>
                                    <asp:GridView  ID="GvGruposClausulas" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="10" Width="500" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                        AllowPaging="false" AllowSorting="True" OnRowDataBound="GvGruposClausulas_RowDataBound" RowStyle-CssClass="GridView_Row_Data_Normal" class="tbl-generic">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label runat="server" ID="LTodos" Text="Todos " CssClass="Text_Normal" />
                                                            </td>
                                                            <td align="center">
                                                                <asp:CheckBox runat="server" ID="CbGrupoClausula" CssClass="Text_Normal" AutoPostBack="true" OnCheckedChanged="SeleccionarTodosGruposClausulas" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="CbGrupoClausula" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Id" DataField="Id" />
                                            <asp:BoundField HeaderText="Tipo" DataField="NombreTipoGrupoClausula" />
                                            <asp:BoundField HeaderText="Pais" DataField="NombreLocacion" />
                                            <asp:BoundField HeaderText="Producto" DataField="Producto" />
                                            <asp:BoundField HeaderText="Sufijo" DataField="Sufijo" />
                                            <asp:BoundField HeaderText="Modalidad" DataField="TipoModalidad" />
                                            <asp:BoundField HeaderText="Texto Resumen" DataField="NombreTextoResumen" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Panel runat="server" ID="PContenidoClausulaRango" CssClass="PanelModalPopUpExtender modal-bkg modal-small-padd" style="display: none;" Width="760px" Height="660px">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="tbl-empty">
                                            <tr>
                                                <td colspan="2">
                                                    <h3>Contenido</h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table style="margin-top: 15px;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTipoClausula" runat="server" Text="Tipo Cláusula:" CssClass="Text_Normal" />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DdlTipoClausula" runat="server" AutoPostBack="true" CssClass="DropDownList_M" OnSelectedIndexChanged="DdlTipoClausula_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LTipoCobertura" runat="server" Text="Tipo Cobertura:" CssClass="Text_Normal" />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DdlTipoCobertura" runat="server" CssClass="DropDownList_M" />
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 15px"><td colspan="2"></td></tr>
                                                        <!-- INICIO - Clausula Dependencia -->
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LClausulasPadre" runat="server" Text="Dependencias" CssClass="Text_Normal" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="IbClausulasPadre" ImageUrl="../IMG/Up.gif" />
                                                                <asp:Panel runat="server" ID="PClausulasPadre" CssClass="PanelModalPopUpExtender" DefaultButton="BAplicarClausulasPadre">
                                                                    <ajx:ModalPopupExtender ID="MpeClausulasPadre" runat="server" TargetControlID="IbClausulasPadre" PopupControlID="PClausulasPadre" BackgroundCssClass="ModalPopupExtender" CancelControlID="BCancelarClausulasPadre"
                                                                        X="450" Y="50" />
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <div style="max-height: 400px; overflow: auto; min-width: 300px; max-width: 500px;">
                                                                                    <asp:GridView ID="GvClausulasPadre" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="15" Width="100%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                                                        AllowPaging="false" AllowSorting="true" OnRowDataBound="GvClausulasPadre_RowDataBound" OnPageIndexChanging="GvClausulasPadre_PageIndexChanging" RowStyle-CssClass="GridView_Row_Data_Normal" CssClass="tbl-generic">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox runat="server" ID="CbPadre" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField HeaderText="Id" DataField="Id" />
                                                                                            <asp:BoundField HeaderText="Clausula" DataField="NombreClausula" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="btn-cntnr">
                                                                                <asp:Button ID="BAplicarClausulasPadre" runat="server" CausesValidation="false" Text="Aceptar" CssClass="Button_Normal" OnClick="BAplicarClausulasPadre_Click" />
                                                                                <asp:Button ID="BCancelarClausulasPadre" runat="server" Text="Cancelar" CssClass="Button_Normal" />
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <!-- FIN - Clausula Dependencia -->
                                                        <tr>
                                                            <td colspan="2">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="LTipoImpresion" runat="server" Text="Tipo Impresion" CssClass="Text_Normal" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DdlTipoImpresionClausula" runat="server" CssClass="DropDownList_M" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="LTipoContenidoImpresion" Text="Contenido Impresión" CssClass="Text_Normal" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DdlTipoContenidoImpresion" runat="server" CssClass="DropDownList_M" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CheckBox ID="CbEvaluableEnAsistencia" runat="server" Text="Evaluable En Asistencia" CssClass="Text_Normal" Checked="true" Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBox ID="CbVisibleEnAsistencia" runat="server" Text="Visible En Asistencia" CssClass="Text_Normal" Checked="true" Visible="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <asp:Label runat="server" ID="LMensajeError" Visible="false" CssClass="Text_Error"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="GvClausulas" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" PageSize="10" Width="220" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                        AllowPaging="True" AllowSorting="True" OnRowDataBound="GvGruposClausulas_RowDataBound" OnPageIndexChanging="GvClausulas_PageIndexChanging" RowStyle-CssClass="GridView_Row_Data_Normal" CssClass="tbl-generic">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox runat="server" ID="CbClausula" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                                                <ItemStyle CssClass="GridView_Row_Data_Normal" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Id" DataField="Id" />
                                                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                                        </Columns>
                                                    </asp:GridView>                                                    
                                                </td>
                                                <td align="right">
                                                    <table>                                                        
                                                        <tr>
                                                            <td colspan="2">
                                                                <wuc:ContenidosClausula runat="server" ID="CcContenidosClausula" />
                                                            </td>
                                                        </tr>                                                        
                                                    </table>
                                                </td>                                                
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table border="0" cellpadding="1" cellspacing="1" style="float: right">
                                    <tr>
                                        <td align="right" class="btn-cntnr-large">
                                            <asp:Button ID="BAgregarContenido" runat="server" CausesValidation="false" Text="Agregar" CssClass="Button_Normal" OnClick="BAgregarContenido_Click" ValidationGroup="MASIVO" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                                            <asp:Button ID="BEliminarContenido" runat="server" CausesValidation="false" Text="Eliminar" CssClass="Button_Normal" OnClick="BEliminarContenido_Click" ValidationGroup="MASIVO" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                                            <asp:Button ID="BAplicarContenido" runat="server" CausesValidation="false" Text="Modificar" CssClass="Button_Normal" OnClick="BAplicarContenido_Click" ValidationGroup="MASIVO" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                                            <asp:Button ID="BCancelarContenido" runat="server" Text="Cancelar" CssClass="Button_Normal" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <asp:ObjectDataSource ID="OdsTipoContenidoImpresion" runat="server" SelectMethod="Buscar" TypeName="Backend.Homes.TipoContenidoImpresionHome"></asp:ObjectDataSource>
                            </asp:Panel> 
                            <ajx:ModalPopupExtender ID="MpeContenidoClausulaRango" runat="server" TargetControlID="BCotenidoClausulaRango" PopupControlID="PContenidoClausulaRango" BackgroundCssClass="ModalPopupExtender" DropShadow="false"
                                CancelControlID="BCancelarContenido" RepositionMode="RepositionOnWindowResizeAndScroll" />
                        </td>
                    </tr>
                    <!-- Modificacion masiva de textos -->
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Panel runat="server" ID="PTextosResumen" CssClass="PanelModalPopUpExtender" Style="display: none;" Width="500px">
                                <ajx:ModalPopupExtender ID="MpeTextosResumen" runat="server" TargetControlID="BTextosResumen" PopupControlID="PTextosResumen" BackgroundCssClass="ModalPopupExtender" CancelControlID="BCancelarTextoResumen"
                                    X="180" Y="50" />
                                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                                    <tr>
                                        <td style="text-align: left;">
                                            <asp:Label ID="LNombreTexto" runat="server" Text="Nombre:" CssClass="Text_Normal" />
                                            <asp:TextBox runat="server" ID="TbNombreTexto" Width="150px" CssClass="Text_Normal" />
                                            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="BBuscarTexto_Click" CssClass="Button_Normal" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GvTextosResumen" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="20" Width="100%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                AllowPaging="true" OnRowDataBound="GvTextosResumen_RowDataBound" OnRowCreated="GvDocumentos_RowCreated" AllowSorting="true" OnPageIndexChanging="GvTextosResumen_PageIndexChanging" RowStyle-VerticalAlign="Top"
                                                RowStyle-CssClass="GridView_Row_Data_Normal" CssClass="tbl-generic">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="CbTextoResumen" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="LPlanFamiliar" runat="server" Text="Tipo Plan" CssClass="Text_Normal" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:ObjectDataSource ID="OdsTipoPlan" runat="server" SelectMethod="Buscar" TypeName="Backend.Homes.TipoPlanHome"></asp:ObjectDataSource>
                                                            <asp:DropDownList ID="DdlTipoPlan" runat="server" DataSourceID="OdsTipoPlan" DataTextField="Descripcion" DataValueField="Id" CssClass="DropDownList_SM">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="LbTituloResumen" runat="server" Text="Texto Resumen"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="LbTextoResumen" runat="server" Text='<%#((String)Eval("ContenidoTexto")).Length < 30?Eval("ContenidoTexto"):((String)Eval("ContenidoTexto")).Substring(0,30) + "..." %>'></asp:Label>
                                                            <ajx:HoverMenuExtender ID="HoverMenuExtender1" PopDelay="30" runat="server" HoverCssClass="popupHoverPanel" PopupControlID="PopupMenu" TargetControlID="LbTextoResumen" PopupPosition="Right">
                                                            </ajx:HoverMenuExtender>
                                                            <asp:Panel ID="PopupMenu" runat="server" Width="100%" Style="display: none" CssClass="popupHoverPanel">
                                                                <div style="max-height: 500px; max-width: 400px; width: 100%; overflow: auto; border-color: Black; border-width: thin;">
                                                                    <asp:Label ID="lblCode" runat="server" CssClass="MuestraTexto" BorderColor="ActiveBorder" BorderWidth="2px" Text='<%# Eval("ContenidoTexto") %>' />
                                                                </div>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <span class="Text_Normal"><b><i>No se han encontrado textos</i></b></span></EmptyDataTemplate>
                                            </asp:GridView>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="BAplicarTextoResumen" runat="server" CausesValidation="false" Text="Aceptar" CssClass="Button_Normal" OnClick="BAplicarTextoResumen_Click" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                                            <asp:Button ID="BCancelarTextoResumen" runat="server" Text="Cancelar" CssClass="Button_Normal" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Panel runat="server" ID="PDocumentos" CssClass="PanelModalPopUpExtender" Style="display: none;" DefaultButton="BAplicarDocumentos" >
                                <ajx:ModalPopupExtender ID="MpeDocumentos" runat="server" TargetControlID="BDocumentos" PopupControlID="PDocumentos" BackgroundCssClass="ModalPopupExtender" CancelControlID="BCancelarDocumentos"
                                    X="450" Y="100" />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GvDocumentos" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="10" Width="300" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                AllowPaging="True" AllowSorting="True" OnRowDataBound="GvDocumentos_RowDataBound" RowStyle-CssClass="GridView_Row_Data_Normal" CssClass="tbl-generic">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="CbAplicaDocumento" CssClass="Text_Normal" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Tipo" DataField="Nombre" />
                                                    <asp:TemplateField HeaderText="Adjunto">
                                                        <ItemTemplate>
                                                            <asp:ObjectDataSource ID="OdsDocumento" runat="server" SelectMethod="BuscarDocumentoDTO" TypeName="Backend.Homes.DocumentoHome"></asp:ObjectDataSource>
                                                            <asp:DropDownList ID="DdlDocumento" runat="server" DataSourceID="OdsDocumento" CssClass="DropDownList_XX" DataTextField="Nombre" DataValueField="Id">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="BAplicarDocumentos" runat="server" CausesValidation="false" Text="Aceptar" CssClass="Button_Normal" OnClick="BAplicarDocumentos_Click" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" />
                                            <asp:Button ID="BCancelarDocumentos" runat="server" Text="Cancelar" CssClass="Button_Normal" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
