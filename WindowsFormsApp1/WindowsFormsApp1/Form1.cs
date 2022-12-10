using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        List<Crime> crimes = new List<Crime>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String path = "C:\\Users\\Lenovo\\Desktop\\Egyetem\\C#\\221117\\crime.json";

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                crimes = JsonConvert.DeserializeObject<List<Crime>>(json);
            }

            label1.Text = crimes.Count().ToString() + "db bűntett történt!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach(var crime in crimes)
            {
                if (crime.type.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    counter++;
                }
            }

            label3.Text = counter.ToString() + "db keresett bűntett van!";
        }
    }
}
