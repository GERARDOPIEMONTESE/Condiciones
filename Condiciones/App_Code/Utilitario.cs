using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using AjaxControlToolkit;
using System.Web.Configuration;
using System.Web.UI;

public class Utilitario
{
    public static string TextBoxValue(FormView pFormView, string Name)
    {
        return ((TextBox)pFormView.Row.FindControl(Name)).Text;
    }

    public static string DropDownListValue(FormView pFormView, string Name)
    {
        return ((DropDownList)pFormView.Row.FindControl(Name)).SelectedValue;
    }

    public static bool CheckBoxValue(FormView pFormView, string Name)
    {
        return ((CheckBox)pFormView.Row.FindControl(Name)).Checked;
    }

    public static FileUpload FileUpLoadControl(FormView pFormView, string Name)
    {
        return (FileUpload)pFormView.Row.FindControl(Name);
    }

    public static TreeView TreeView(Page pPage, string Name)
    {
        return (TreeView)pPage.FindControl(Name);
    }
 
}
