<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrupoClausulaSLA_Datos.aspx.cs" Inherits="Condiciones.GrupoClausulas.SLA.GrupoClausulaSLA_Datos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/Main.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/Espera.css" rel="stylesheet" type="text/css" />
    <script src="../../Js/Condiciones.js" type="text/javascript"></script>

    <script type="text/javascript">
        function Loading() {
            $find('behaivourCargando').show();
            return true;
        }


        function ValidateMe() {
            var ok = Page_ClientValidate("BuscaSucursales");
            if (ok) {
                $find('behaivourCargando').show();
                return true;
            }
            else
                return false;
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
                <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                    <tr style="background-color: #e5ebf7">
                        <td style="text-align: left;">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPais" runat="server" Text="País:" CssClass="Text_Normal" />
                                    </td>
                                    <td>
                                        <asp:ObjectDataSource ID="odsPais" runat="server" SelectMethod="Buscar" TypeName="Backend.Homes.PaisHome"></asp:ObjectDataSource>
                                        <asp:DropDownList ID="ddlPais" runat="server" DataSourceID="odsPais" CssClass="DropDownList_M" DataTextField="Nombre" DataValueField="Codigo">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblCodigoAgencia" Text="Código Agencia:" CssClass="Text_Normal"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCodigoAgencia" CssClass="TextBox_S"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblRazonSocial" Text="Razón Social:" CssClass="Text_Normal"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtRazonSocial" CssClass="TextBox_M"></asp:TextBox>
                                    </td>
                                    <td class="btn-cntnr">
                                        <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_OnClick" CssClass="Button_Normal" 
                                        ValidationGroup="BuscaSucursales" OnClientClick="if (!ValidateMe()) return false;" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvtxtCodigoAgencia" CssClass="TextError_Normal" ErrorMessage="* Ingrese Código Agencia"
                                         ControlToValidate="txtCodigoAgencia" Display="Dynamic" ValidationGroup="BuscaSucursales"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <br />
                            <table width="100%">
                                <tr>
                                    <td align="center" style="border-right: 1px; border-right-style: solid; vertical-align: top;">
                                        <asp:GridView ID="grvSucursales" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="17" Width="500" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                            AllowPaging="True" AllowSorting="True" OnRowDataBound="grvSucursales_OnRowDataBound" OnPageIndexChanging="grvSucursales_OnPageIndexChanging" RowStyle-CssClass="GridView_Row_Data_Normal">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chbGrupoClausula" EnableViewState="true" 
                                                        OnCheckedChanged="chbGrupoClausula_OnCkeckedChanged" AutoPostBack="true"  />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Id" DataField="Id" />
                                                <asp:BoundField HeaderText="Código Agencia" DataField="CodigoDeCuenta" />
                                                <asp:BoundField HeaderText="Nº Sucursal" DataField="NumeroSucursal" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Razón Social" DataField="RazonSocial" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <asp:Label runat="server" ID="lblEmptyRow" Text="No hay sucursales disponibles"></asp:Label>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                    <td align="center" style="vertical-align: top; border-left-width: 1px; border-left-style: solid;">
                                        <div style="width: 100%; max-height: 400px; overflow: auto;">
                                            <asp:GridView ID="grvSucursalesCheck" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" DataKeyNames="Id" Width="500" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                                AllowPaging="false" AllowSorting="True" OnRowDataBound="grvSucursalesCheck_OnRowDataBound" RowStyle-CssClass="GridView_Row_Data_Normal">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="chbGrupoClausula" EnableViewState="true" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                                    <asp:BoundField HeaderText="Código Agencia" DataField="CodigoDeCuenta" />
                                                    <asp:BoundField HeaderText="Nº Sucursal" DataField="NumeroSucursal" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Razón Social" DataField="RazonSocial" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label runat="server" ID="lblErrorSucursales" Visible="false" CssClass="Text_Error"></asp:Label>
                            <asp:CustomValidator ID="cmvSeleccionAgencia" runat="server" ErrorMessage="Seleccione por lo menos una sucursal" Text="Seleccione por lo menos una sucursal" 
                                Visible="false" CssClass="Text_Error">
                                     <img src="../../IMG/error.gif" alt="Seleccione por lo menos una sucursal" title="Seleccione por lo menos una sucursal" />
                            </asp:CustomValidator>
                        </td>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table border="0" cellpadding="1" cellspacing="1" align="center">
            <tr>
                <td class="btn-cntnr-large">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_OnClick" CssClass="Button_Normal" />
                    <asp:Button ID="btnContinue" runat="server" Text="Continuar" OnClick="btnContinue_OnClick" CssClass="Button_Normal" ValidationGroup="Validar" OnClientClick="Loading();" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdfCargando" />
        <ajx:ModalPopupExtender runat="server" ID="mpeCargando" BehaviorID="behaivourCargando" PopupControlID="UpEsperaAccion"
         TargetControlID="hdfCargando">
        </ajx:ModalPopupExtender>
        <asp:UpdateProgress ID="UpEsperaAccion" runat="server">
            <ProgressTemplate>
                <div class="ProgressBanner">
                    <img src="/IMG/loading.gif" alt="Cargando Página" />
                    <p>
                        Cargando Página ...
                    </p>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
