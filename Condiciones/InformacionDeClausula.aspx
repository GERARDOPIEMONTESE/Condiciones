<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformacionDeClausula.aspx.cs" Inherits="Condiciones.InformacionDeClausula" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register TagPrefix="Generar" TagName="Clausulas" Src="~/Controles/Clausulas.ascx" %>
<%@ Register src="Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Informacion de Clausula</title>
    <link rel="stylesheet" href="CSS/Main.css" type="text/css" />
    <script src="Js/Condiciones.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function ValidarNumero() {
            if (!((event.keyCode >= 48) && (event.keyCode <= 57))) {
                event.keyCode = 0;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <asp:ScriptManager ID="SManager" runat="server" EnablePageMethods="true" />
        <asp:UpdatePanel ID="UpClausulas" runat="server">
            <ContentTemplate>
                <fieldset>
                    <asp:Panel runat="server" ID="pnl" DefaultButton="bAgregar">
                        <table border="0" cellpadding="1" cellspacing="1" align="center">
                            <tr>
                                <td align="center">
                                    <asp:FormView ID="FvClausula" runat="server" DefaultMode="Insert" DataKeyNames="Id">
                                        <InsertItemTemplate>
                                            <table border="0" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblTipoClausula" runat="server" Text="Tipo Cláusula:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DdlTipoClausula" runat="server" DataSourceID="oDSTipoClausula" DataTextField="Nombre" DataValueField="Id" OnDataBound="DropDownList_DataBound" CssClass="DropDownList_M" OnSelectedIndexChanged="DropDownList_IndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblCodigo" runat="server" Text="Código:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TbCodigo" runat="server" CssClass="TextBox_M" MaxLength="10" />
                                                        <asp:RequiredFieldValidator ID="RfvNombre" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbCodigo" ErrorMessage="El codigo no puede ser vacío."><img src="IMG/error.gif" alt="El codigo no puede ser vacío." title="El codigo no puede ser vacío." /></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="CVCodigoClausula" runat="server" ErrorMessage="Codigo Existente" Text="Codigo Existente" ControlToValidate="TbCodigo" Display="None" ValidationGroup="Guardar"><img src="IMG/error.gif" alt="Codigo existente" title="Codigo existente" /></asp:CustomValidator>
                                                        <asp:CustomValidator ID="CVClausulaUsada" runat="server" ErrorMessage="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones." Text="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones."
                                                            ControlToValidate="TbCodigo" Display="None" ValidationGroup="Guardar"><img src="IMG/error.gif" alt="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones." title="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones." /> </asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="LOrden" runat="server" Text="Orden Predefinido:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="TbOrdenPredefinido" runat="server" CssClass="TextBox_Xs" onkeypress="javascript:ValidarNumero();" />
                                                        <asp:RequiredFieldValidator ID="RfvOrdenPredefinido" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbOrdenPredefinido" ErrorMessage="El orden no puede ser vacío."><img src="IMG/error.gif" alt="El orden no puede ser vacío" title="El orden no puede ser vacío" /> </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RevTbOrdenPredefinido" runat="server" ErrorMessage="Campo numérico" ControlToValidate="TbOrdenPredefinido" Display="None" ValidationExpression="\d{0,3}?" ValidationGroup="Guardar"><img src="IMG/error.gif" title="Campo numérico" alt="Campo numérico" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr style="display:none;">
                                                    <td align="right">
                                                        <asp:Label ID="lblPeso" runat="server" Text="Peso: " CssClass="Text_Normal" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="tbPeso" runat="server" CssClass="TextBox_Xs" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblTasa" runat="server" Text="Tasa: " CssClass="Text_Normal" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="tbTasa" runat="server" CssClass="TextBox_Xs" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </InsertItemTemplate>
                                        <EditItemTemplate>
                                            <table border="0" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblTipoClausula" runat="server" Text="Tipo Cláusula:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DdlTipoClausula" runat="server" DataSourceID="oDSTipoClausula" DataTextField="Nombre" DataValueField="Id" OnDataBound="DropDownList_DataBound" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "TipoClausula.Id") %>'  OnSelectedIndexChanged="DropDownList_IndexChanged" AutoPostBack="true"
                                                            CssClass="DropDownList_M" >
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblCodigo" runat="server" Text="Código:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="TbCodigo" runat="server" Text='<%# Eval("Codigo") %>' CssClass="TextBox_M" />
                                                        <asp:RequiredFieldValidator ID="RfvNombre" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbCodigo" ErrorMessage="El Codigo no puede ser vacío."><img src="IMG/error.gif" alt="El Codigo no puede ser vacío." title="El Codigo no puede ser vacío." /> </asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="CVCodigoClausula" runat="server" ErrorMessage="Codigo Existente" Text="Codigo Existente" ControlToValidate="TbCodigo" Display="None" ValidationGroup="Guardar" />
                                                        <asp:CustomValidator ID="CVClausulaUsada" runat="server" ErrorMessage="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones." Text="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones."
                                                            ControlToValidate="TbCodigo" Display="None" ValidationGroup="Guardar"><img src="IMG/error.gif" title="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones." alt="No se puede eliminar ya que actualmente esta siendo utilizada por grupos de condiciones." /></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="LOrden" runat="server" Text="Orden Predefinido:" CssClass="Text_Normal" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="TbOrdenPredefinido" runat="server" Text='<%# Eval("OrdenPredefinido") %>' CssClass="TextBox_Xs" onkeypress="javascript:ValidarNumero();" />
                                                        <asp:RequiredFieldValidator ID="RfvOrdenPredefinido" ValidationGroup="Guardar" runat="server" Display="None" ControlToValidate="TbOrdenPredefinido" ErrorMessage="El orden no puede ser vacío."><img src="IMG/error.gif" alt="El orden no puede ser vacío." title="El orden no puede ser vacío." /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RevTbOrdenPredefinido" runat="server" ErrorMessage="Campo numérico" ControlToValidate="TbOrdenPredefinido" Display="None" ValidationExpression="\d{0,3}?" ValidationGroup="Guardar"><img src="IMG/error.gif" alt="Campo numérico" title="Campo numérico" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr style="display:none;">
                                                    <td align="right">
                                                        <asp:Label ID="lblPeso" runat="server" Text="Peso: " CssClass="Text_Normal" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="tbPeso" runat="server" CssClass="TextBox_Xs" Text='<%# Eval("Peso") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblTasa" runat="server" Text="Tasa: " CssClass="Text_Normal" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="tbTasa" runat="server" CssClass="TextBox_Xs" Text='<%# Eval("Tasa") %>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                    </asp:FormView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <table border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td colspan="2">
                                                <ajx:TabContainer ID="TCIdioma" runat="server" AutoPostBack="false" Visible="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td>
                                                <asp:Button ID="BCancelar" runat="server" Text="Cancelar" OnClick="BCancelar_Click" CssClass="Button_Normal" />
                                                <asp:Button ID="bAgregar" runat="server" Text="Grabar" ValidationGroup="Guardar" OnClick="bAgregar_Click" CssClass="Button_Normal" OnClientClick="return confirm('¿Esta seguro que desea realizar esta operación?');" />
                                                <asp:Button ID="bEliminar" runat="server" Text="Eliminar" CssClass="Button_Normal" OnClick="BEliminar_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar la Cláusula?');" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
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
        <asp:ObjectDataSource ID="oDSTipoClausula" runat="server" SelectMethod="Buscar" TypeName="Backend.Homes.TipoClausulaHome"></asp:ObjectDataSource>
        <uc1:SessionController ID="SessionController1" runat="server" />
    </div>
    </form>
</body>
</html>
