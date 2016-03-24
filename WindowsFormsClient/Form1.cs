using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsClient;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        ServiceReference1.IgetdataClient proxy = new ServiceReference1.IgetdataClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = proxy.AllData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.myData d = new ServiceReference1.myData
            {
                //id = Int32.Parse(textBox1.Text),
                name = textBox2.Text,
                image = textBox3.Text
            };

            proxy.Create(d);
            dataGridView1.DataSource = proxy.AllData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(txtSearch.Text);
           ServiceReference1.myData d = proxy.searchData(x);
           if (d != null)
           {
               textBox2.Text = d.name;
               textBox3.Text = d.image;
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                ServiceReference1.myData d = new ServiceReference1.myData
                {
                    id = Int32.Parse(txtSearch.Text),
                    name = textBox2.Text,
                    image = textBox3.Text
                    };


                proxy.update(d);
                MessageBox.Show("Data Updated Successfully");
                dataGridView1.DataSource = proxy.AllData();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
            }
        }
    }
}
