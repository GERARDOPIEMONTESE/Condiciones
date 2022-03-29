<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucContenidosClausula.ascx.cs" Inherits="Condiciones.Controles.WucContenidosClausula" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<%@ Register TagPrefix="wuc" TagName="ContenidoClausula" Src="~/Controles/WucContenidoClausula.ascx" %>

<asp:UpdatePanel runat="server" ID="UpContenidos">
<ContentTemplate>
<asp:HiddenField ID="hfCodigoPais" runat="server" />
    <table>
    <tr>
        <td align="left" class="btn-cntnr right-margined">
            <asp:ImageButton runat="server" ID="IbAgregarRango" 
                ImageUrl="~/IMG/btn_more.gif" OnClick="IbAgregarRango_Click"
                ToolTip="Agregar Nuevo Rango Edad" ValidationGroup="Guardar" /> &nbsp;
            <asp:ImageButton runat="server" ID="IbEliminarRango" 
                ImageUrl="~/IMG/btn_minus.gif" OnClick="IbEliminarRango_Click"
                ToolTip="Eliminar Rango Edad" ValidationGroup="Borrar"/>             
        </td>
    </tr>
    <tr>
        <td><br/></td>
    </tr>
    <tr>
        <td>
        <!-- VER ESTO MEJOR -->
            <ajx:TabContainer ID="TcContenidos" runat="server" Style="text-align: left" Width="380px">
                <ajx:TabPanel runat="server" ID="Tp1" HeaderText="#1" Visible="true">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula1" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp2" HeaderText="#2" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula2" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp3" HeaderText="#3" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula3" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp4" HeaderText="#4" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula4" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp5" HeaderText="#5" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula5" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp6" HeaderText="#6" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula6" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp7" HeaderText="#7" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula7" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp8" HeaderText="#8" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula8" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp9" HeaderText="#9" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula9" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp10" HeaderText="#10" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula10" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp11" HeaderText="#11" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula11" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp12" HeaderText="#12" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula12" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp13" HeaderText="#13" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula13" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp14" HeaderText="#14" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula14" />
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel runat="server" ID="Tp15" HeaderText="#15" Visible="false">
                    <ContentTemplate>
                        <wuc:ContenidoClausula runat="server" ID="ContenidoClausula15" />
                    </ContentTemplate>
                </ajx:TabPanel>
            </ajx:TabContainer>
        </td>
    </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>