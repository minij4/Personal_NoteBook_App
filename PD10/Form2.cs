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

namespace PD10 { 
    public partial class Form2 : Form
    {
        DataGridView dgv1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(DataGridView dgv)
        {
            InitializeComponent();

            dgv1 = dgv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Data atsiskaitymas;
                atsiskaitymas = new Data();

                atsiskaitymas.putModule(textBox1.Text);
                atsiskaitymas.putDescription(textBox2.Text);



                atsiskaitymas.putMonth(Convert.ToInt32(textBox3.Text));



                atsiskaitymas.putDay(Convert.ToInt32(textBox4.Text));


                atsiskaitymas.leftTime();
                string mod = atsiskaitymas.getModule();
                string des = atsiskaitymas.getDescription();
                string date = atsiskaitymas.getMonthName() + " " + atsiskaitymas.getDay() + " ";
                double leftDays = atsiskaitymas.getLeftDays();



                this.dgv1.Rows.Add(mod, des, date, leftDays);

                dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


                string fileName = "db.txt";
                StreamWriter sw = new StreamWriter(fileName, true);

                sw.WriteLine(atsiskaitymas.getModule() + "|" + atsiskaitymas.getDescription() + "|"
                    + atsiskaitymas.getMonthName() + " " + atsiskaitymas.getDay());

                sw.Close();
                Close();
            }
            catch
            {
                MessageBox.Show("Neteisingai įvestas mėnuo arba diena");
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
