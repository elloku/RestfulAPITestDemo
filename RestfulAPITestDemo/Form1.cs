using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            RestClient.HttpRequest("127.0.0.1", "31001", "/mcrp-prod-chanpinzx/api/ChanPin", RestClient.HttpType.GET);
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            RestClient.HttpRequest("127.0.0.1", "31001", "/mcrp-prod-chanpinzx/api/ChanPin", RestClient.HttpType.POST,);
        }

        private void buttonPut_Click(object sender, EventArgs e)
        {
            RestClient.HttpRequest("127.0.0.1", "31001", "/mcrp-prod-chanpinzx/api/ChanPin", RestClient.HttpType.PUT);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            RestClient.HttpRequest("127.0.0.1", "31001", "/mcrp-prod-chanpinzx/api/ChanPin", RestClient.HttpType.DELETE);
        }
    }
}
