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
    public partial class Form8 : Form
    {
        #region Used Data
        Entity__DB Ent = new Entity__DB();
        public Form8()
        {
            InitializeComponent();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            var productsincompany = from pr in Ent.Items select pr.Item_Name;
            foreach (var st in productsincompany)
            {

                comboBox1.Items.Add(st);
            }

            var moveid = (from id in Ent.Items
                          select id.Item_Code);

            foreach (int id in moveid)
            {
                comboBox2.Items.Add(id);
            }
        }
       

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            //listBox3.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";

            string selectedproduct = comboBox1.SelectedItem.ToString();
            int selectedproductid = (from st in Ent.Items where st.Item_Name == selectedproduct select st.Item_Code).FirstOrDefault();
            var pro = (from st in Ent.Items where st.Item_Name == selectedproduct select st);
            foreach (var s in pro)
            {
                textBox1.Text = s.Item_Code.ToString();
                textBox2.Text = s.Item_Name;
                textBox3.Text = s.Prod_Date.ToString();
                DateTime start = s.Prod_Date;
                DateTime end = s.Validity_Period;

                // Calculate the total number of days between the two dates
                int totalDays = (int)(end - start).TotalDays;

                // Calculate the number of months by dividing the total number of days by the average number of days in a month
                int months = (int)Math.Round(totalDays / (365.25 / 12));

                // Ensure that only a positive number is displayed in the textbox
                int positiveMonths = Math.Max(months, 0);
                textBox4.Text = positiveMonths.ToString();

            }

            var product = (from id in Ent.Store_item
                           where id.Item_Code == selectedproductid
                           select id);

            foreach (var id in product)
            {
                listBox1.Items.Add(id.Item_Code.ToString());
                listBox2.Items.Add(id.Item_Total_Count.ToString());
               
            }
        }
        #endregion

        #region Transfer

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int moveid = int.Parse(comboBox2.SelectedIndex.ToString());
            var movetable = (from id in Ent.Item_Transfer
                             where id.Item_Code == moveid
                             select id);

            var idproduct = (from id in Ent.Item_Transfer

                             where id.Item_Code == moveid
                             select id.Item_Code).FirstOrDefault();

            var productname = (from id in Ent.Items
                               where id.Item_Code == idproduct
                               select id.Item_Name).FirstOrDefault();

            var idsupp = (from id in Ent.Item_Transfer
                          where id.Item_Code == moveid
                          select id.Sup_Id).FirstOrDefault();

            var subbname = (from id in Ent.Suppliers
                            where id.Supplier_Id == idsupp
                            select id.Supplier_Name).FirstOrDefault();

            foreach (var item in movetable)
            {
                textBox5.Text = item.FromStore_Id.ToString();
                textBox6.Text = item.ToStore_Id.ToString();
                textBox7.Text = productname;
                textBox8.Text = item.Item_count.ToString();
                textBox9.Text = subbname;
                textBox10.Text = item.Prod_Date.ToString();
                textBox11.Text = item.Validity_Period.ToString();
                textBox12.Text = item.Transfer_Date.ToString();

            }
        }
        #endregion


    }
}