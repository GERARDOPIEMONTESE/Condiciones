<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucTabsDocumentos.ascx.cs" Inherits="Condiciones.Controles.WucTabsDocumentos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>

<%@ Register src="WucDocumento.ascx" tagname="WucDocumento" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<asp:UpdatePanel runat="server" ID="UpDocumentos">
<ContentTemplate>
        <ajx:TabContainer ID="TcDocumentos" runat="server" Style="text-align: left; padding-left:10px;" Width="450px">
            
        </ajx:TabContainer>
</ContentTemplate>
</asp:UpdatePanel>
