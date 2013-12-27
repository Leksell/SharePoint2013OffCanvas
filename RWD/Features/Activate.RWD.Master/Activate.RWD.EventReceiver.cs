using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace RWD.Features.Activate.RWD.Master
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("c5fed656-5c1e-4e70-8c22-c09ddb4a9af9")]
    public class ActivateRWDEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Occurs after a Feature is activated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPFeatureReceiverProperties" /> object that represents the properties of the event.</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                SPWeb topLevelSite = site.RootWeb;

                // Calculate relative path to site from Web Application root.
                string webAppRelativePath = topLevelSite.ServerRelativeUrl;
                if (!webAppRelativePath.EndsWith("/"))
                {
                    webAppRelativePath += "/";
                }


                // Enumerate through each site and apply branding.
                foreach (SPWeb web in site.AllWebs)
                {
                    // Activate the publishing feature for all webs.
                    web.MasterUrl = webAppRelativePath + "_catalogs/masterpage/RWD.master";
                    web.CustomMasterUrl = webAppRelativePath + "_catalogs/masterpage/RWD.master";

                    // web.SiteLogoUrl = webAppRelativePath + "Style%20Library/ComapnyName/Images/logo.png";
                    web.Update();
                }
            }
        }

        /// <summary>
        /// Occurs when a Feature is deactivated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPFeatureReceiverProperties" /> object that represents the properties of the event.</param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite siteCollection = properties.Feature.Parent as SPSite;
            if (siteCollection != null)
            {
                SPWeb topLevelSite = siteCollection.RootWeb;

                // Calculate relative path to site from Web Application root.
                string webAppRelativePath = topLevelSite.ServerRelativeUrl;
                if (!webAppRelativePath.EndsWith("/"))
                {
                    webAppRelativePath += "/";
                }

                // Enumerate through each site and apply branding.
                foreach (SPWeb site in siteCollection.AllWebs)
                {
                    site.MasterUrl = webAppRelativePath + "_catalogs/masterpage/seattle.master";
                    site.CustomMasterUrl = webAppRelativePath + "_catalogs/masterpage/seattle.master";
                    site.SiteLogoUrl = string.Empty;
                    site.Update();
                }
            }
        }
    }
}
