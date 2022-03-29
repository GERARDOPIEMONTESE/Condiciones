<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDeAdministrador.aspx.cs" Inherits="Condiciones.Admin.ListaDeAdministrador" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Src="../Controles/SessionController.ascx" TagName="SessionController" TagPrefix="uc1" %>
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
    <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" />
    <asp:UpdatePanel runat="server" ID="UpDatos">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnl" DefaultButton="BBuscar">
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td style="text-align: left;">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="LTipoEntidad" runat="server" Text="Tipo:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlTipoEntidad" runat="server" DataTextField="Codigo" DataValueField="Clase" AutoPostBack="true" EnableViewState="true" CssClass="DropDownList_M" />
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
                            <asp:GridView ID="GvEntidades" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="1px" RowStyle-BorderStyle="Solid" Width="70%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                AllowPaging="False" RowStyle-CssClass="GridView_Row_Data_Normal" AllowSorting="True" OnRowDataBound="GvEntidades_RowDataBound">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                </Columns>
                            </asp:GridView>
                            <br />
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
    <uc1:SessionController ID="SessionController1" runat="server" />
    </form>
</body>
</html>
