using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewForm.HostObjects
{
    public class TestObject
    {
        private WebView2 wb;
        private Form form;
        public TestObject(WebView2 _wb, Form _form)
        {
            wb = _wb;
            form = _form;
        }
        public void SetFormText(string txt)
        {
            form.Text = txt;
        }
        public string GetWebViewSource() => wb.Source.AbsoluteUri.ToString();
        public string OpenTxt()
        {
            var fd = new OpenFileDialog
            {
                Title = "不敢相信",
                Filter = "文字檔|*.txt",
                Multiselect = false
            };
            fd.ShowDialog();
            var sr = new StreamReader(fd.FileName, Encoding.UTF8, false);
            var txt = sr.ReadToEnd();
            sr.Close();
            return txt;
        }
    }
}
