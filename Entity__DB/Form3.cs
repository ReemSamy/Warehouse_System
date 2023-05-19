using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity__DB
{
    public partial class Form3 : Form
    {
        #region Used Data
        Entity__DB Ent = new Entity__DB();
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (Item store_ in Ent.Items)
            {
                comboBox1.Items.Add(store_.Item_Name);
            }
        }
        #endregion

        #region Add Item
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int code = int.Parse(textBox1.Text);
                Item item = Ent.Items.Find(code);
                Measurement measure = Ent.Measurements.Find(code);    


                if (item == null)
                {
                    Item item_ = new Item();
                    item_.Item_Code = code;
                    item_.Item_Name = textBox2.Text;
                    item_.Prod_Date = dateTimePicker1.Value;
                    item_.Validity_Period = dateTimePicker2.Value;
                    Measurement measure_ = new Measurement();
                    measure_.M_Id = code;
                    measure_.Item_Code = code;
                    measure_.measure_Name = textBox4.Text;
                    Ent.Measurements.Add(measure_);
                    Ent.Items.Add(item_);
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text =textBox4.Text= "";
                }

                else
                {
                    MessageBox.Show("Item with ID " + code + " already exists.");
                }

            }
            else
            {
                MessageBox.Show("Empty Data");
            }
        }
        #endregion

        #region Update Item

        private void button2_Click(object sender, EventArgs e)
        {
            Item item = Ent.Items.Find(int.Parse(textBox1.Text));
            Measurement measure = Ent.Measurements.Find(int.Parse(textBox1.Text)); ;

            if (item != null)
            {
                if (textBox2.Text != "")
                {
                    item.Item_Name = textBox2.Text;
                    item.Prod_Date = dateTimePicker1.Value;
                    item.Validity_Period = dateTimePicker2.Value;
                    measure.measure_Name = textBox4.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text =textBox4.Text= "";
                }
                else
                {
                    MessageBox.Show("No Name Available");
                }
            }
            else
            {
                MessageBox.Show("Item not found");
            }
        }

        #endregion

        #region Report 
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            string selectedstore = comboBox1.SelectedItem.ToString();
            int selectedstoreid = (from st in Ent.Items where st.Item_Name == selectedstore select st.Item_Code).FirstOrDefault();
            var stro = (from st in Ent.Items where st.Item_Name == selectedstore select st);  //Get all col in table

            var entryDatesAndValidities = from si in Ent.Store_item
                                          join pr in Ent.PermissionRequests on si.Store_Id equals pr.Store_Id
                                          join it in Ent.Items on si.Item_Code equals it.Item_Code
                                          where it.Item_Name == selectedstore && pr.Perm_Date >= dateTimePicker3.Value && pr.Perm_Date <= dateTimePicker4.Value
                                          select new
                                          {
                                              EntryDate = pr.Perm_Date,
                                              Validity = it.Validity_Period,
                                              it.Item_Code,
                                              it.Prod_Date,
                                              it.Item_Name
                                          };
            foreach (var entry in entryDatesAndValidities)
            {
                textBox3.Text = entry.Item_Code.ToString();
                listBox1.Items.Add(entry.Item_Name);
                listBox3.Items.Add(entry.Prod_Date);
                listBox4.Items.Add(entry.Validity);
            }
            foreach (var s in stro)
            {
                textBox3.Text = s.Item_Code.ToString();

            }

            var productdate = (from prdt in Ent.Measurements
                               where prdt.Item_Code == selectedstoreid
                               select prdt);



            foreach (var perm in productdate)
            {

                listBox2.Items.Add(perm.measure_Name);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 =new Form8();
            form8.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 form10 =new Form10();
            form10.Show();
        }
        #endregion
    }



}
