<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Condiciones.Default" %>

<%@ Register src="Controles/SessionController.ascx" tagname="SessionController" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="./CSS/Main.css" type="text/css" />
    <title>Default</title>

    <script src="Js/Condiciones.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="PaginaPortal">
        <asp:SiteMapPath ID="SiteMap" runat="server" CssClass="Text_SiteMap" />
        <uc1:SessionController ID="SessionController1" runat="server" />
        <br />
        
        
        
        <br />
        
    </div>
    </form>
</body>
</html>