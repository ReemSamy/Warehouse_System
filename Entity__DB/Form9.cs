using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity__DB
{
    public partial class Form9 : Form
    {
        #region Report  Four
        Entity__DB Ent = new Entity__DB();
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            var products = from pro in Ent.Item_Transfer select pro;
            foreach (var i in products)
            {
                comboBox1.Items.Add(i.T_Id);
            }

          
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id;
            if (comboBox1.SelectedItem != null && int.TryParse(comboBox1.SelectedItem.ToString(), out id))
            {
                var products = (from pro in Ent.Item_Transfer
                                where pro.T_Id == id
                                select pro).FirstOrDefault();

                if (products != null)
                {
                    dateTimePicker1.Value = products.Prod_Date;
                    dateTimePicker2.Value = products.Validity_Period;
                    dateTimePicker3.Value = products.Transfer_Date;

                    DateTime Dateofproduction = products.Prod_Date;
                    DateTime Dateofexpired = products.Validity_Period;
                    var DatesDifferences = Dateofexpired - Dateofproduction;
                    var month = (DatesDifferences.Days) / (365 / 12);
                    textBox4.Text = month.ToString();
                }
                else
                {
                    // Handle the case where no product is found with the selected T_Id
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                    dateTimePicker3.Value = DateTime.Now;
                    textBox4.Text = string.Empty;
                }

            }

        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if (comboBox1.SelectedItem != null && int.TryParse(comboBox1.SelectedItem.ToString(), out id))
            {
                var productstore = from prosto in Ent.Store_item
                                   where prosto.Item_Code == id
                                   select prosto;

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (var i in productstore)
                {
                    listBox1.Items.Add(i.Item_Code.ToString());
                    listBox2.Items.Add(i.Store_Id.ToString());
                }

                var CountTransfer = from prosto in Ent.Item_Transfer
                                    where prosto.T_Id == id
                                    select prosto;

                listBox3.Items.Clear();
                foreach (var item in CountTransfer)
                {
                    listBox3.Items.Add(item.Item_count.ToString());
                }
            }
        }
        #endregion
    }
}
