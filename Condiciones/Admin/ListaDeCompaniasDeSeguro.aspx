<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ListaDeCompaniasDeSeguro.aspx.cs" Inherits="Condiciones.Admin.CompaniasDeSeguro" ValidateRequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register Assembly="GridViewControl" Namespace="GridViewControl" TagPrefix="cc1" %>
<%@ Register src="../Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <asp:UpdatePanel ID="UpCompanias" runat="server">
            <ContentTemplate>
                <fieldset>
                    <asp:Panel runat="server" ID="pnl">
                    <table border="0" cellpadding="1" cellspacing="1" align="center" width="100%">
                        <tr style="background-color: #e5ebf7">
                            <td style="text-align: left;">
                                <table border="0" cellpadding="1" cellspacing="1" width="50%">
                                    <tr>
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
                                    <asp:GridView ID="GvCompaniasSeguro" runat="server" PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="1px" RowStyle-BorderStyle="Solid" Width="70%" HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
                                AllowPaging="False" RowStyle-CssClass="GridView_Row_Data_Normal" AllowSorting="True" OnRowCommand="GvCompaniasSeguro_RowCommand" OnRowDataBound="GvCompaniasSeguro_RowDataBound" OnPageIndexChanging="GvCompaniasSeguro_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />

                                    <asp:ButtonField ButtonType="Button" CommandName="Editar" ItemStyle-HorizontalAlign="Center">
                                            <ControlStyle CssClass="EditarGridButton" />
                                        </asp:ButtonField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="GridView_Row_Header_Normal" />
                                            <ItemTemplate>
                                                <asp:Button CssClass="EliminarGridButton" ID="BEliminar" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' ValidationGroup="Guardar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    <%--<asp:ButtonField ButtonType="Button" CommandName="Editar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center">
                                        <ControlStyle CssClass="EditarGridButton" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ID="BEliminar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center" OnClientClick="javascript:return confirm('Desea confirmar la operacion?');" runat="server" CommandName="Eliminar">
                                    <ControlStyle CssClass="EliminarGridButton" />
                                    </asp:ButtonField>--%>
                                    <%--<asp:ButtonField ButtonType="Button" CommandName="Eliminar" ItemStyle-Width="25" ItemStyle-HorizontalAlign="Center">
                                        <ControlStyle CssClass="EliminarGridButton" />
                                    </asp:ButtonField>--%>
                                </Columns>
                            </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="GvCompaniasSeguro" />
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
