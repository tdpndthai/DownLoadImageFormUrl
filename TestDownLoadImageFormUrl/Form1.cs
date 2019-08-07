using System;
using System.Windows.Forms;

namespace TestDownLoadImageFormUrl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Drawing.Image image = DownloadImageFromUrl(txtUrl.Text.Trim());
            string rootPath = @"C:\Test"; //đường dẫn phải có
            string fileName = System.IO.Path.Combine(rootPath, "test.png");
            image.Save(fileName);
        }
    }
}