using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD10
{
   
    public partial class Form1 : Form
    {
        public void Printing_All_txt_file()
        {
            const string fileName = "db.txt";

            StreamReader sr = new StreamReader(fileName);

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] data = line.Split('|');
                    
                    
                    
                    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    line = "";

                    string time = data[2];
                    string[] times = time.Split(' ');
                    int month = 0;
                    string day = times[1];

                    switch (times[0])
                    {
                        case "Sausio": month = 1; break;
                        case "Vasario": month = 2; break;
                        case "Kovo": month = 3; break;
                        case "Balandžio": month = 4; break;
                        case "Gegužės": month = 5; break;
                        case "Birželio": month = 6; break;
                        case "Liepos": month = 7; break;
                        case "Rugpjūčio": month = 8; break;
                        case "Rugsėjo": month = 9; break;
                        case "Spalio": month = 10; break;
                        case "Lapkričio": month = 11; break;
                        case "Gruodžio": month = 12; break;
                    }

                    
                    DateTime dt = new DateTime(DateTime.Today.Year, month, Convert.ToInt32(day));
                    double leftDays = dt.Subtract(DateTime.Today).TotalDays;

                    List<string> ls = new List<string>();
                    ls.Add(data[0]);
                    ls.Add(data[1]);
                    ls.Add(data[2]);
                    ls.Add(leftDays.ToString());

                    data = ls.ToArray();

                    dataGridView1.Rows.Add(data);
                }
            }

            sr.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Printing_All_txt_file();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(dataGridView1);
            f2.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {

                int line_to_delete = e.RowIndex+1;
                string line = null;
                int line_number = 0;
                
                const string fileName = "db.txt";
                const string temporaryTxtFile = "dbt.txt";

                FileStream fs = File.Create(temporaryTxtFile);
                fs.Close();


                using (StreamReader reader = new StreamReader(fileName))
                {
                    using (StreamWriter writer = new StreamWriter(temporaryTxtFile))
                    {
                        while ((line = reader.ReadLine()) != null && line != "")
                        {
                            line_number++;
                            if (line_number == line_to_delete)
                            {
                                continue;
                            }
                            writer.WriteLine(line);
                            
                        }
                    }
                   
                }

                File.Delete(fileName);
                File.Copy(temporaryTxtFile, fileName);
                File.Delete(temporaryTxtFile);

                dataGridView1.Rows.Clear();

                Printing_All_txt_file();

                //deleting empty lines
                var lines = File.ReadAllLines(fileName).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fileName, lines);
            }
        }
    }
}
