using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;

namespace NP5lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            using (HttpRequestMessage message = new HttpRequestMessage())
            {
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
                HttpResponseMessage resp = await client.SendAsync(message);
                textBox2.Text = "";
                textBox2.AppendText($"Status code:{resp.StatusCode}");
                textBox2.AppendText("Headers: ");
                foreach (var item in resp.Headers)
                {
                    textBox2.AppendText($"{item.Key}");
                }
                string body = await resp.Content.ReadAsStringAsync();
                textBox1.Text = body;
                List<Currency> items = JsonSerializer.Deserialize<List<Currency>>(body);
                listBox1.DataSource = null;
                listBox1.DataSource = items;
                listBox1.DisplayMember = "Description";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            using (HttpRequestMessage message = new HttpRequestMessage())
            {
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri("https://api.privatbank.ua/p24api/pboffice?json&city=%D0%9A%D1%80%D0%B8%D0%B2%D0%BE%D0%B9%20%D0%A0%D0%BE%D0%B3&address=");
                HttpResponseMessage resp = await client.SendAsync(message);
                string body = await resp.Content.ReadAsStringAsync();
                List<Department> items = JsonSerializer.Deserialize<List<Department>>(body);
                comboBox1.DataSource = null;
                comboBox1.DataSource = items;
                comboBox1.DisplayMember = "AddressList";

            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            using (HttpRequestMessage message = new HttpRequestMessage())
            {
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri("https://api.privatbank.ua/p24api/pboffice?json&city=%D0%9A%D1%80%D0%B8%D0%B2%D0%BE%D0%B9%20%D0%A0%D0%BE%D0%B3&address=");
                HttpResponseMessage resp = await client.SendAsync(message);
                string body = await resp.Content.ReadAsStringAsync();
                List<Department> items = JsonSerializer.Deserialize<List<Department>>(body);
            
            try
            {
                foreach (Department item in items)
                {
                    if (comboBox1.Text == item.Address)
                    {
                        textBox3.Lines = item.Info();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }
    }
}
