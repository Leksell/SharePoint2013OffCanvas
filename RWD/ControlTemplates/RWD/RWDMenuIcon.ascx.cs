using Microsoft.SharePoint;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace RWD.ControlTemplates.RWD
{
    public partial class RWDMenuIcon : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
{
    RWDIconControl.Controls.Add(new Literal
    {
        Text = string.Format("<a href='#' class='open-panel'><img src='{1}' style='height:24px;'/></a>",
        SPContext.Current.Site.Url,
        "/_layouts/15/images/RWD/menu-24.png",
        SPContext.Current.Site.RootWeb.Title)
    });
}
        }
}
