using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace RestfulAPITestDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            //
            //HttpWebRequestHelper.Get();

            //var text = HttpWebRequestHelper.Post();
            //this.richTextBox1.Text = text;


        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text =  HttpWebRequestHelper.HttpRequest("GET");
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            ChanPinDTO chanPin = new ChanPinDTO
            {
                Id = "739769244446625796",
                ChanPinMc = "api调用测试",
                WangGuanLj = "abc",
                GitFuWuQ = null,
                QunZuMc = "123",
                ChanPinBS = "api调用测试",
                GitYongHuM = null,
                GitMiMa = null,
                BeiZhu = null,
                ChanPinFZR = null,
                ChanPinFZRXM = null,
                KaiFaFZR = null,
                KaiFaFZRXM = null,
                TiYanFZR = null,
                TiYanFZRXM = null,
                CeShiFZR = null,
                CeShiFZRXM = null
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var data = serializer.Serialize(chanPin);
            HttpWebRequestHelper.Post(data);
        }

        private void buttonPut_Click(object sender, EventArgs e)
        {
            ChanPinDTO chanPin = new ChanPinDTO
            {
                Id = "739769244446625796",
                ChanPinMc = "api调用测试Put",
                WangGuanLj = "abc",
                GitFuWuQ = null,
                QunZuMc = "123",
                ChanPinBS = "api调用测试Put",
                GitYongHuM = null,
                GitMiMa = null,
                BeiZhu = null,
                ChanPinFZR = null,
                ChanPinFZRXM = null,
                KaiFaFZR = null,
                KaiFaFZRXM = null,
                TiYanFZR = null,
                TiYanFZRXM = null,
                CeShiFZR = null,
                CeShiFZRXM = null
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var data = serializer.Serialize(chanPin);
            HttpWebRequestHelper.Put(data);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            HttpWebRequestHelper.Delete();
        }

        /*{"Id":"739769244446625793","ChanPinMc":"api调用测试","WangGuanLj":"abc","GitFuWuQ":null,"QunZuMc":"123","ChanPinBS":"api调用测试","GitYongHuM":null,"GitMiMa":null,"BeiZhu":null,"ChanPinFZR":null,"ChanPinFZRXM":null,"KaiFaFZR":null,"KaiFaFZRXM":null,"TiYanFZR":null,"TiYanFZRXM":null,"CeShiFZR":null,"CeShiFZRXM":null}*/
    }
}
