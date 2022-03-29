<%@ Page Language="C#" AutoEventWireup="True" EnableEventValidation="false" CodeBehind="GrupoClausula_Clausulas.aspx.cs" Inherits="Condiciones.InformacionDeGrupoClausula" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register TagPrefix="wuc" TagName="ContenidosClausula" Src="~/Controles/WucContenidosClausula.ascx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
<%@ Register src="../Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="CSS/Espera.css" type="text/css" />
    <script src="../Js/Condiciones.js" type="text/javascript"></script>
    <script src="../Js/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function recalcularPeso() {
            var response = confirm("Esta seguro que quiere recalcular el peso?");
            if(response == true){
                var hfTasa = document.getElementById('hfTasa');
                var valorTasa = hfTasa.value;
                var valorTasaCulturaEn = parseFloat(valorTasa);
                var valorTasaCulturaES = parseFloat(valorTasa.replace(',', '.'));
                if(valorTasaCulturaEn > 0){
                    var floatHfTasa = valorTasaCulturaEn;
                }else{
                    var floatHfTasa = valorTasaCulturaES;
                }
                var selectedTab = $(".ajax__tab_active").first().attr('id').match(/(\d+)/)[0];
                var idFind = "[id$='" + selectedTab + "_tbNumero']";
                var tbNumero = $(idFind).val();
                if (hfTasa.value == '')
                    alert('No hay tasa cargada para la clausula');
                else if (tbNumero == '' || tbNumero.value == '')
                    alert('Primero debe cargar la formula');
                else {
                    var pesoNuevo = floatHfTasa * tbNumero;
                    var idPesoFind = "[id$='" + selectedTab + "_txtPeso']";
                    $(idPesoFind).val(pesoNuevo);
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
        <asp:UpdatePanel runat="server" ID="UpDatos">
            <ContentTemplate>
            <asp:HiddenField ID="hfTasa" runat="server" Value="" />
                <fieldset>
                    <asp:Panel runat="server" ID="pnl" DefaultButton="BContinuar">
                        <table border="0" cellpadding="1" cellspacing="1" align="center">
                            <tr>
                                <td valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table border="0" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTipoClausula" runat="server" Text="Tipo Cláusula:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DdlTipoClausula" runat="server" CssClass="DropDownList_M" AutoPostBack="True" OnSelectedIndexChanged="DdlTipoClausula_SelectedIndexChanged" OnDataBound="DdlTipoClausula_DataBound">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblClausula" runat="server" Text="Cláusula:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LClausula" runat="server" Text="" CssClass="Text_Normal" Visible="false" />
                                                        <asp:DropDownList ID="DdlClausula" runat="server" CssClass="DropDownList_M" OnSelectedIndexChanged="DdlClausula_SelectedIndexChanged" AutoPostBack="True" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="label1" CssClass="Text_Normal" Text="Descripción Clausula:" Height="32px"></asp:Label>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="labelDescripcionClausula" CssClass="Text_Normal" Height="32px" Width="270px" OnPreRender="labelDescripcionClausula_PreRender"></asp:Label>&nbsp;
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
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LOrden" runat="server" Text="Orden:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="TbOrden" CssClass="TextBox_Xs" MaxLength="3" Text="0" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <wuc:ContenidosClausula runat="server" ID="CcContenidosClausula" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LClausulasPadre" runat="server" Text="Dependencias" CssClass="Text_Normal" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton runat="server" ID="IbClausulasPadre" ImageUrl="../IMG/Up.gif" />
                                                        <asp:Panel runat="server" ID="PClausulasPadre" CssClass="PanelModalPopUpExtender">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="GvClausulasPadre" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="10" Width="320" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                                            AllowPaging="True" AllowSorting="True" OnRowDataBound="GvClausulasPadre_RowDataBound" OnPageIndexChanging="GvClausulasPadre_OnPageIndexChanging" >
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox runat="server" ID="CbPadre" />
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                                                                    <ItemStyle CssClass="GridView_Row_Data_Normal" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="TextoIdentificatorio" DataField="TextoIdentificatorio"/>
                                                                                <asp:BoundField HeaderText="Clausula" DataField="NombreClausula" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Button ID="BAplicarClausulasPadre" runat="server" CausesValidation="false" Text="Aceptar" CssClass="Button_Normal" OnClick="BAplicarClausulasPadre_Click" />
                                                                        <asp:Button ID="BCancelarClausulasPadre" runat="server" Text="Cancelar" CssClass="Button_Normal" />
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <ajx:ModalPopupExtender ID="MpeClausulasPadre" runat="server" TargetControlID="IbClausulasPadre" BackgroundCssClass="ModalPopupExtender" DropShadow="true" PopupControlID="PClausulasPadre" CancelControlID="BCancelarClausulasPadre"
                                                            X="450" Y="150" RepositionMode="None" />
                                                    </td>
                                                </tr>
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
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="BAgregar" runat="server" Text="Agregar" OnClick="BAgregar_Click" CssClass="Button_Normal" />
                                                        <asp:Button ID="BEditar" runat="server" Text="Confirmar" Visible="false" OnClick="BEditar_Click" CssClass="Button_Normal" />
                                                        <asp:Button ID="bEliminar" runat="server" Text="Eliminar" Visible="false" OnClick="bEliminar_Click" CssClass="Button_Normal" />
                                                        <asp:Button ID="BCopiar" runat="server" Text="Copiar" Visible="false" OnClick="BCopiar_Click" CssClass="Button_Normal" />
                                                        <asp:Button ID="BFinalizarCopia" runat="server" Text="Copiar" Visible="false" OnClick="BAgregar_Click" CssClass="Button_Normal" />
                                                        <asp:Button ID="BCancelarEdicion" runat="server" Text="Cancelar" Visible="false" OnClick="BCancelarEdicion_Click" CssClass="Button_Normal" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="TvClausula" EventName="SelectedNodeChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td valign="top">
                                    <asp:UpdatePanel ID="UpMenu" runat="server">
                                        <ContentTemplate>
                                            <fieldset style="width: 600px; height: 700px; text-align: center;">
                                                <asp:TreeView ID="TvClausula" runat="server" BorderStyle="Groove" ImageSet="Inbox" NodeIndent="20" Width="600px" Height="700px" Style="text-align: left; overflow: scroll; border: solid 0px #898989" OnSelectedNodeChanged="UpMenu_SelectedNodeChanged"
                                                    NodeWrap="true">
                                                    <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                                                    <HoverNodeStyle Font-Underline="False" />
                                                    <SelectedNodeStyle BackColor="#E0E0E0" BorderStyle="Groove" Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <NodeStyle Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" ImageUrl="~/IMG/method.gif" />
                                                </asp:TreeView>
                                            </fieldset>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <br />
                                    <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" ValidationGroup="Cont" />
                                    <asp:Button ID="BContinuar" runat="server" Text="Continuar" OnClick="BContinuar_Click" CssClass="Button_Normal" ValidationGroup="Cont" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <asp:ValidationSummary runat="server" DisplayMode="BulletList" CssClass="TextError_Normal" ValidationGroup="Guardar" ID="VsValidador" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </fieldset>
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
