using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Net;

namespace WCPars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }      
        public void WowheadGold()
        {
            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = website.Load("https://www.wowhead.com/");   
            var datalist3 = document.DocumentNode.SelectNodes("//span[@class='moneygold']").ToList();
            foreach (var content in datalist3)
            {
                richTextBox1.Text += content.InnerText +Environment.NewLine;
            }            
        }
        public void GetValuesPVE()
        {
            string modifiedString = string.Empty;
            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();     
            HtmlAgilityPack.HtmlDocument document2 = website.Load("https://www.wowmeta.com/shadowlands/dps-rankings");
            var datalist2 = document2.DocumentNode.SelectNodes("//*[@id='rankings-chart']/div[1]/div[1]").ToList();
            foreach (var content in datalist2)
            {
                richTextBox2.Text = content.InnerText;
            }
            foreach (string str in richTextBox2.Text.Split("\n"))
            {
                modifiedString += "        " + str;
                //"                     " +
            }
            richTextBox2.Text = modifiedString;
        }
        public void GetValuesPVP()
        {
            string modifiedString1 = string.Empty;
            HtmlAgilityPack.HtmlWeb website1 = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document3 = website1.Load("https://www.wowmeta.com/shadowlands/pvp-dps-rankings#2v2");
            var datalist3 = document3.DocumentNode.SelectNodes("/html/body/main/div/div/div[2]/div[2]/div[2]").ToList();
            foreach (var content1 in datalist3)
            {
                richTextBox3.Text = content1.InnerText;
            }
            foreach (string str in richTextBox3.Text.Split("\n"))
            {
                modifiedString1 += "                               " + str;
                //"                     " +
            }
            richTextBox3.Text = modifiedString1;
        }
        public void GetValuesPVEHeal()
        {
            string modifiedString2 = string.Empty;
            HtmlAgilityPack.HtmlWeb website2 = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document4 = website2.Load("https://www.wowmeta.com/shadowlands/healer-rankings");          
            var datalist4 = document4.DocumentNode.SelectNodes("/html/body/main/div/div[1]/div[3]/div[5]/div[1]/div[1]").ToList();
            foreach (var content2 in datalist4)
            {
                richTextBox4.Text = content2.InnerText;
            }
            foreach (string str3 in richTextBox4.Text.Split("\n"))
            {               
                modifiedString2 += "             " + str3;
                //"                     " +
            }
            richTextBox4.Text = modifiedString2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetValuesPVE();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            WowheadGold();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GetValuesPVEHeal();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            GetValuesPVP();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        //    richTextBox1.Clear();
        //    richTextBox2.Clear();
        //    richTextBox3.Clear();
        //    richTextBox4.Clear();
        }
    }
}


