using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace WinAppsLinker
{
    public partial class MainForm : Form
    {
        private class Application
        {
            public string ApplicationName { get; }
            public string ApplicationId { get; }
            public string ImagePath { get; }
            public int ImageIndex { get; }

            public Application(string name, string id, string imagePath, int imageIndex)
            {
                ApplicationName = name;
                ApplicationId = id;
                ImagePath = imagePath;
                ImageIndex = imageIndex;
            }
        }

        private IReadOnlyList<Application> _applications;

        public MainForm()
        {
            InitializeComponent();
        }

        private void PopulateApps()
        {
            var applications = new List<Application>();

            // GUID taken from https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid
            var FODLERID_AppsFolder = new Guid("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}");
            ShellObject appsFolder = (ShellObject)KnownFolderHelper.FromKnownFolderId(FODLERID_AppsFolder);

            foreach (var app in (IKnownFolder)appsFolder)
            {
                // The friendly app name
                string name = app.Name;
                // The ParsingName property is the AppUserModelID
                string appUserModelID = app.ParsingName; // or app.Properties.System.AppUserModel.ID
                                                         // You can even get the Jumbo icon in one shot

                imageList.Images.Add(appUserModelID, app.Thumbnail.Bitmap);
                var imageIndex = imageList.Images.Count - 1;

                var filePath = @"thumbs\" + Regex.Replace(name, @"[^\w]", "_") + ".png";
                try
                {
                    Directory.CreateDirectory(@"thumbs");
                    app.Thumbnail.Bitmap.Save(filePath);

                    if (File.Exists(filePath))
                        filePath = Path.GetFullPath(filePath);
                    else
                        filePath = null;
                }
                catch
                {
                    // do nothing yet, just erase the path for the image we haven’t created
                    filePath = null;
                }

                applications.Add(new Application(name, appUserModelID, filePath, imageIndex));
            }

            _applications = applications;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            imageList.Images.Add("appKey", SystemIcons.Application);

            PopulateApps();
            PopulateTreeApps(checkBoxMsApps.Checked);
        }

        private Regex _microsoftStoreIdPattern = new Regex(@"[\w\._\-]+![\w\._\-]+", RegexOptions.Compiled);

        private void PopulateTreeApps(bool showAllApps)
        {
            treeViewApps.Nodes.Clear();
            treeViewApps.Nodes.AddRange(
                _applications
                    .Where(a => showAllApps ? true : _microsoftStoreIdPattern.IsMatch(a.ApplicationId))
                    .OrderBy(a => a.ApplicationName)
                    .Select(CreateNodeFromApplication)
                    .ToArray());
        }

        private TreeNode CreateNodeFromApplication(Application app)
        {
            var node = new TreeNode(app.ApplicationName, app.ImageIndex, app.ImageIndex);

            var id = app.ApplicationId;
            if (_microsoftStoreIdPattern.IsMatch(id))
                id = @"shell:AppsFolder\" + id;

            var subNode = node.Nodes.Add("id", id);
            subNode.ImageIndex = 0;

            if (!string.IsNullOrEmpty(app.ImagePath))
            {
                subNode = node.Nodes.Add("img", app.ImagePath);
                subNode.ImageIndex = 0;
            }

            node.Collapse();

            return node;
        }

        /// <summary>
        /// Copy the selection text in the clipboard
        /// </summary>
        private void TreeViewApps_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null)
                return;

            Clipboard.SetText(e.Node.Text);
        }

        private void CheckBoxMsApps_CheckedChanged(object sender, EventArgs e)
        {
            PopulateTreeApps(checkBoxMsApps.Checked);
        }
    }
}
