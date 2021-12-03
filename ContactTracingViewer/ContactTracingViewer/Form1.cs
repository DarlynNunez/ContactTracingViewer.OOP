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

namespace ContactTracingViewer
{
    public partial class Form1 : Form
    {
        static string filePathRecords = @"C:\Program Files (x86)\Microsoft";
        static string[] files = Directory.GetFiles(filePathRecords);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                filename = filename.Replace(".txt", "");
                listBox.Items.Add(filename);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            listBox.ClearSelected();
            listBox.Text = "";
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            labelSearchWarning.Text = "";
            if (listBox.Text != "")
            {
                string filePath = @"C:\Program Files (x86)\Microsoft" + listBox.Text + ".txt";

                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();

                MessageBox.Show(ListToString(lines), listBox.Text);
            } 
            else
            {
                labelSearchWarning.Location = new Point(159, 308);
                labelSearchWarning.Text = "Please select a name";
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyWord = txtBxSearch.Text;
            List<string> listOfNames = new List<string>();
            labelSearchWarning.Text = "";

            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                filename = filename.Replace(".txt", "");
                listOfNames.Add(filename);
            }

            String[] arrayOfNames = listOfNames.ToArray();

            if (keyWord.Length >= 3)
            {
                foreach (string x in arrayOfNames)
                {
                    if ((x.ToLower()).Contains(keyWord.ToLower()))
                    {
                        listBox.Text = x;
                    }
                }

                if (!((listBox.Text).ToLower()).Contains(keyWord.ToLower()))
                {
                    MessageBox.Show("Name not found", "Notification");
                }
            } 
            else
            {
                labelSearchWarning.Location = new Point(170, 106);
                labelSearchWarning.Text = "Please enter atleast three characters";
            }
        }

        private string ListToString(List<string> lines)
        {
            string x = "";

            foreach (string line in lines)
            {
                x = x + line + "\n";
            }

            return x;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
