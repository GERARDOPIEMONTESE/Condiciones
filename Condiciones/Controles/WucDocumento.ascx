<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucDocumento.ascx.cs" Inherits="Condiciones.Controles.WucDocumento" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>

<asp:HiddenField ID="hfIdioma" runat="server"></asp:HiddenField>
<asp:GridView ID="GvDocumentos" runat="server" Width="100%"
    PagerStyle-CssClass="GridView_Pager_Normal" BorderWidth="0px" PageSize="10" 
    HeaderStyle-CssClass="GridView_Row_Header_Normal" AutoGenerateColumns="False"
    AllowPaging="True" AllowSorting="True" 
    RowStyle-CssClass="GridView_Row_Data_Normal" 
    onrowdatabound="GvDocumentos_RowDataBound">
    <Columns>
        <asp:BoundField HeaderText="Id" DataField="Id" ControlStyle-Width="50px" />
        <asp:BoundField HeaderText="Tipo" DataField="Nombre" ControlStyle-Width="80px" />
        <asp:TemplateField HeaderText="Adjunto">
            <ItemTemplate>
                <asp:DropDownList ID="DdlDocumento" runat="server" CssClass="DropDownList_XXX" 
					DataTextField="Nombre" DataValueField="Id" ondatabound="DdlDocumento_DataBound">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

<HeaderStyle CssClass="GridView_Row_Header_Normal"></HeaderStyle>

<PagerStyle CssClass="GridView_Pager_Normal"></PagerStyle>

<RowStyle CssClass="GridView_Row_Data_Normal"></RowStyle>
</asp:GridView>