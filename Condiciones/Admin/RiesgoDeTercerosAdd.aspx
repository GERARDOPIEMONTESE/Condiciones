<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiesgoDeTercerosAdd.aspx.cs" Inherits="Condiciones.RiesgoDeTercerosAdd" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register src="../Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Main.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Espera.css" type="text/css" />
    <script src="../Js/Condiciones.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function Confirm() {
            if ((document.getElementById("TbCodigoPais").value != '') && (document.getElementById("TbCodigo").value != '') && (document.getElementById("TbNombre").value != '')) {
                if (confirm('Desea confirmar la operación?')) {
                    document.getElementById("BAceptar").click();
                } else {
                    return false;
                }
            }
            else {
                document.getElementById("BValidar").click();
                return false;
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
                <fieldset>
                    <asp:Panel runat="server" ID="pnl" DefaultButton="BAceptar">
                        <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                            <tr>
                                <td align="center">
                                    <table border="0" cellpadding="1" cellspacing="1" align="center" width="70%">
                                        <tr>
                                            <td align="left" width="10%">
                                                <asp:Label ID="lblTipoNegocio" runat="server" Text="Tipo Negocio:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:DropDownList ID="DdlTipoNegocio" runat="server" CssClass="DropDownList_X" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="DdlTipoNegocio_SelectedIndexChanged" />
                                            </td>
                                            <td align="left" width="10%">
                                                <asp:Label ID="lblPais" runat="server" Text="Pais:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:DropDownList ID="DdlPais" runat="server" CssClass="DropDownList_X" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="DdlPais_SelectedIndexChanged" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblCompaniaSeguro" runat="server" Text="Compañia de seguro:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DdlCompaniaSeguro" runat="server" CssClass="DropDownList_X" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblFromDate" Text="Fecha Desde:" CssClass="Text_Normal" meta:resourcekey="lblFromDateResource1" />

                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" CssClass="textbox" runat="server" />
                                                <ajx:CalendarExtender ID="cerFromDate" runat="server" TargetControlID="txtFromDate" PopupPosition="Right" CssClass="calendarStyle" />
                                                <ajx:MaskedEditExtender ID="meeFromDate" runat="server" TargetControlID="txtFromDate"
                                                    MaskType="Date" OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus"
                                                    MessageValidatorTip="true" Mask="99/99/9999"/>
					                            <ajx:MaskedEditValidator ID="mevFromDate" runat="server" Display="None" InitialValue=" / / "
						                            ControlToValidate="txtFromDate" MinimumValue="01/01/1850" ControlExtender="meeFromDate"
						                            IsValidEmpty="False"  Text="*" />
                                            </td>
                                            
                                            <td>
                                                <asp:Label runat="server" ID="lblToDate" Text="Fecha hasta:" CssClass="Text_Normal" meta:resourcekey="lblToDateResource1" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtToDate" CssClass="textbox" runat="server" />
                                                <ajx:CalendarExtender ID="cerToDate" runat="server" TargetControlID="txtToDate" PopupPosition="Right" CssClass="calendarStyle" />
                                                <ajx:MaskedEditExtender ID="meeToDate" runat="server" TargetControlID="txtToDate"
                                                    MaskType="Date" OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus"
                                                    MessageValidatorTip="true" Mask="99/99/9999"/>
					                            <ajx:MaskedEditValidator ID="mevToDate" runat="server" Display="None" InitialValue=" / / "
						                            ControlToValidate="txtToDate" MinimumValue="01/01/1850" EmptyValueMessage="Fecha inválida."
						                            IsValidEmpty="False" ControlExtender="meeToDate" Text="*" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvFromDate" ControlToValidate="txtFromDate" ErrorMessage="   *" ForeColor="Red" ValidationGroup="Template" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvToDate" ControlToValidate="txtToDate" ErrorMessage="   *" ForeColor="Red" ValidationGroup="Template" />
                                            </td>


                                        </tr>
                                        <tr>
                                            <td align="left" width="10%">
                                                <asp:Label ID="lblProducto" runat="server" Text="Producto Asociado:" CssClass="Text_Normal" />
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:Label ID="lblProductAsociado" runat="server" Text="" CssClass="Text_Normal" />
                                            </td>
                                        </tr>
                                        <br />
                                        <br />
                                        
                                        <asp:CustomValidator ID="CVCompaniaSeguro" runat="server" ErrorMessage="" Text="Error al guardar" ControlToValidate="DdlCompaniaSeguro" ValidationGroup="Guardar"><img src="IMG/error.gif" alt="Error al guardar" title="Error al guardar" /></asp:CustomValidator>

                                        <table runat="server" cellpadding="1" cellspacing="1" align="center" width="50%" class="tbl-doc-assoc" id="idTableProducto">
                                        <tr>
                                            <th>
                                                Asociar Productos
                                            </th>
                                        </tr>
                                        <tr>
                                            <td class="doc-assoc">
                                                <asp:TreeView ID="IdProductos" runat="server" ShowCheckBoxes="All" Height="380px" Width="100%" Style="text-align: left; overflow: scroll" >
                                                    <NodeStyle Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                                                </asp:TreeView>
                                            </td>
                                            <%--<td class="doc-assoc">
                                                <asp:TreeView ID="TVAsociacionesActuales" runat="server" Height="380px" Width="100%" Style="text-align: left; overflow: scroll">
                                                    <NodeStyle Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                                                </asp:TreeView>
                                            </td>--%>
                                        </tr>

                                        </table>
                                        <tr>
                                            <td align="right" colspan="5" class="btn-cntnr">
                                                <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" />
                                                <asp:Button ID="BAceptar" runat="server" Text="Aceptar" OnClick="BAceptar_Click" CssClass="Button_Normal" ValidationGroup="Guardar" OnClientClick="javascript:return Confirm();" />
                                                <asp:Button ID="BValidar" runat="server" ValidationGroup="Guardar" CssClass="Invisible" />
                                            </td>
                                        </tr>
                                    </table>
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
                /div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <uc1:SessionController ID="SessionController1" runat="server" />
    </div>
    </form>
</body>
</html>
