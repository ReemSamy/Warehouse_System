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

namespace Entity__DB
{
    public partial class Form2 : Form
    {
        Entity__DB Ent = new Entity__DB();
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load_1(object sender, EventArgs e)
        {
            foreach (Store store in Ent.Stores)
            {
                comboBox1.Items.Add(store.Store_Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                Store store = Ent.Stores.Find(id);

                if (store == null)
                {
                    store = new Store();
                    store.Store_Id = id;
                    store.Store_Name = textBox2.Text;
                    store.Store_Address = textBox3.Text;
                    store.Manager_Name = textBox4.Text;
                    Ent.Stores.Add(store);
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Store with ID " + id + " already exists.");
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Store store = Ent.Stores.Find(int.Parse(textBox1.Text));

            if (store != null)
            {
                if (textBox2.Text != "")
                {
                    store.Store_Name = textBox2.Text;
                    store.Store_Address = textBox3.Text;
                    store.Manager_Name = textBox4.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("No Name Available");
                }
            }
            else
            {
                MessageBox.Show("Not Available Department");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            string selectedstore = comboBox1.SelectedItem.ToString();
            int selectedstoreid = (from st in Ent.Stores where st.Store_Name == selectedstore select st.Store_Id).FirstOrDefault();
            var stro = (from st in Ent.Stores where st.Store_Name == selectedstore select st);  //Get all col in table

            foreach (var s in stro)
            {
                textBox5.Text = s.Store_Address;
                textBox6.Text = s.Manager_Name;
            }

            var permissiondate = (from prdt in Ent.Item_Transfer
                                  where prdt.FromStore_Id == selectedstoreid
                                  select prdt);



            foreach (var perm in permissiondate)
            {
               
                listBox1.Items.Add(perm.Item_count);
                listBox2.Items.Add(perm.Item_count);
                listBox3.Items.Add(perm.Prod_Date);
            }


            var product = (from id in Ent.Store_item
                           where id.Store_Id == selectedstoreid
                           select id);

            foreach (var id in product)
            {           
                listBox4.Items.Add(id.Item_Total_Count);
            }
        }
    }
}
