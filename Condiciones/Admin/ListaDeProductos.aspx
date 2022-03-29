<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeProductos.aspx.cs" Inherits="Condiciones.Admin.ListaDeProductos" ValidateRequest="false" %>

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
                                <table border="0" cellpadding="1" cellspacing="1" width="50%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="LTipoGrupo" runat="server" Text="Tipo:" CssClass="Text_Normal" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlTipoGrupoClausula" runat="server" CssClass="DropDownList_M" AutoPostBack="true" EnableViewState="true" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="Text_Normal" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlPais" runat="server" CssClass="DropDownList_M" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="DdlPais_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator runat="server" ID="rfvDdlTIpoGrupoClausula" ControlToValidate="DdlTipoGrupoClausula" ErrorMessage="Seleccione un País" InitialValue="0"><img src="../IMG/error.gif" alt="Seleccione un País" title="Seleccione un País" /></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="btn-cntnr">
                                            <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="BBuscar_Click" CssClass="Button_Normal" CausesValidation="true" />
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
                                <br />
                                <asp:GridView ID="GvTarifas" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" Width="70%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False" AllowPaging="True"
                                    RowStyle-CssClass="GridView_Row_Data_Normal" PageSize="30" OnRowCommand="GvTarifas_RowCommand" Export="Yes" OnPageIndexChanging="GvTarifas_PageIndexChanging" OnRowDataBound="GvTarifas_RowDataBound">
                                    <RowStyle CssClass="GridView_Row_Data_Normal" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Id" DataField="Id" />
                                        <asp:BoundField HeaderText="CodigoPais" DataField="CodigoPais" />
                                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    </Columns>
                                    <PagerStyle CssClass="GridView_Pager_Normal" />
                                    <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="gvTarifas" />
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
