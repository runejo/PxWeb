﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using PXWeb.Database;
using System.Xml;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using Px.Rdf;

namespace PXWeb.Admin
{
    public partial class Tools_XMLGenerator : System.Web.UI.Page
    {

        protected void clearDropDown(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.DataBind();
            ddl.ClearSelection();
        }
        protected void fillPxDatabases(DropDownList ddl)
        {
            clearDropDown(ddl);
            foreach (var db in PXWeb.Settings.Current.General.Databases.AllPxDatabases)
            {
                ddl.Items.Add(new ListItem(db.Id, db.Id));
            }
        }

        protected void fillCNMMDatabases(DropDownList ddl)
        {
            clearDropDown(ddl);
            foreach (var db in PXWeb.Settings.Current.General.Databases.AllCnmmDatabases)
            {
                ddl.Items.Add(new ListItem(db.Id, db.Id));
            }
        }
        protected void cboSelectDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectDbType.SelectedItem.Value == "PX") fillPxDatabases(cboSelectDb);
            else fillCNMMDatabases(cboSelectDb);

            ReadSettings(cboSelectDb.Text);
        }

        protected void cboSelectDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadSettings(cboSelectDb.Text);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.EnableSave(new EventHandler(MasterSave_Click));
            if (!IsPostBack)
            {
                fillPxDatabases(cboSelectDb);
                ReadSettings(cboSelectDb.Text);
            }

        }
        protected void imgSelectDb_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectDb", "PxWebAdminToolsXMLGeneratorSelectDbInfo");
        }

        protected void imgSelectDbType_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectDbType", "PxWebAdminToolsXMLGeneratorSelectDbTypeInfo");
        }

        protected void imgSelectPreferredLanguage_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectPreferredLanguage", "PxWebAdminToolsXMLGeneratorSelectPreferredLanguageInfo");
        }

        protected void imgSelectBaseURI_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectBaseURI", "PxWebAdminToolsXMLGeneratorSelectBaseURIInfo");
        }
        protected void imgSelectCatalogTitle_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectCatalogTitle", "PxWebAdminToolsXMLGeneratorSelectCatalogTitleInfo");
        }

        protected void imgSelectCatalogDesc_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectCatalogDesc", "PxWebAdminToolsXMLGeneratorSelectCatalogDescInfo");
        }
        protected void imgSelectLicense_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectLicense", "PxWebAdminToolsXMLGeneratorSelectLicenseInfo");
        }

        protected void imgSelectLandingPageURL_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectLandingPageURL", "PxWebAdminToolsXMLGeneratorSelectLandingPageURLInfo");
        }

        protected void imgSelectApiURL_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectApiURL", "PxWebAdminToolsXMLGeneratorSelectApiURLInfo");
        }
        
        protected void imgSelectPublisher_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorSelectPublisher", "PxWebAdminToolsXMLGeneratorSelectPublisherInfo");
        }

        protected void imgStatus_Click(object sender, ImageClickEventArgs e)
        {
            Master.ShowInfoDialog("PxWebAdminToolsXMLGeneratorStatus", "PxWebAdminToolsXMLGeneratorStatusInfo");
        }

        private void ReadSettings(string database)
        {
            PXWeb.DatabaseSettings db = (PXWeb.DatabaseSettings)PXWeb.Settings.Current.GetDatabase(database);
            PXWeb.DcatSettings dcatSettings = (PXWeb.DcatSettings)db.Dcat;

            textBoxSelectBaseURI.Text = dcatSettings.BaseURI;
            textBoxSelectApiURL.Text = dcatSettings.BaseApiUrl;
            textBoxSelectLandingPageURL.Text = dcatSettings.LandingPageUrl;
            textBoxSelectPublisher.Text = dcatSettings.Publisher;
            textBoxSelectCatalogTitle.Text = dcatSettings.CatalogTitle;
            textBoxSelectCatalogDesc.Text = dcatSettings.CatalogDescription;
            textBoxSelectLicense.Text = dcatSettings.License;
            updateStatusLabel(dcatSettings);

            if (dcatSettings.FileStatus == DcatStatusType.Creating || dcatSettings.FileStatus == DcatStatusType.WaitingCreate) {
                btnGenerateXML.Enabled = false;
            }
            else
            {
                btnGenerateXML.Enabled = true;
            }
        }

        private void updateStatusLabel(DcatSettings dcatSettings)
        {
            lblStatusValue.Text = dcatSettings.FileStatus.ToString();
            if (dcatSettings.FileStatus == DcatStatusType.Created)
            {
                lblStatusValue.Text += " " + dcatSettings.FileUpdated.ToString();
            }
        }

        private void saveCurrentSettings()
        {
            PXWeb.DatabaseSettings db = (PXWeb.DatabaseSettings)PXWeb.Settings.Current.GetDatabase(cboSelectDb.Text);
            PXWeb.DcatSettings dcats = (PXWeb.DcatSettings)db.Dcat;

            dcats.BaseURI = textBoxSelectBaseURI.Text;
            dcats.BaseApiUrl = textBoxSelectApiURL.Text;
            dcats.LandingPageUrl = textBoxSelectLandingPageURL.Text;
            dcats.Publisher = textBoxSelectPublisher.Text;
            dcats.CatalogTitle = textBoxSelectCatalogTitle.Text;
            dcats.CatalogDescription = textBoxSelectCatalogDesc.Text;
            dcats.License = textBoxSelectLicense.Text;
            dcats.Database = cboSelectDb.Text;
            dcats.DatabaseType = cboSelectDbType.Text;

            db.Save();
        }

        protected void MasterSave_Click(object sender, EventArgs e) {
            saveCurrentSettings();
        }
        protected void btnGenerateXML_Click(object sender, EventArgs e)
        {
            string dbid = cboSelectDb.Text;

            saveCurrentSettings();

            PXWeb.DatabaseSettings db = (PXWeb.DatabaseSettings)PXWeb.Settings.Current.GetDatabase(dbid);
            PXWeb.DcatSettings dcatSettings = (PXWeb.DcatSettings)db.Dcat;

            // Check that the status has not been changed by another system before updating it
            if (dcatSettings.FileStatus != DcatStatusType.Creating)
            {
                dcatSettings.FileStatus = DcatStatusType.WaitingCreate;
                db.Save();
                updateStatusLabel(dcatSettings);
                btnGenerateXML.Enabled = false;

                if (PXWeb.Settings.Current.Features.General.BackgroundWorkerEnabled)
                {
                    // Wake up the background worker if it is asleep
                    BackgroundWorker.PxWebBackgroundWorker.WakeUp();
                }
            }
        }
    }
}
