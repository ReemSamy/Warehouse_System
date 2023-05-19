using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity__DB
{
    public partial class Form7 : Form
    {
        #region Used Data 
        Entity__DB Ent = new Entity__DB();
        int storeid;
        List<Item> item1 = new List<Item>();
        Item product;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            foreach (var item in Ent.Stores)
            {
                comboBox1.Items.Add(item.Store_Name);
                comboBox2.Items.Add(item.Store_Name);
               
            }
            foreach (var item in Ent.Suppliers)
            {
                comboBox3.Items.Add(item.Supplier_Name);
            }
          
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            storeid = (from s in Ent.Stores where s.Store_Name == comboBox1.Text select s.Store_Id).FirstOrDefault();
            var itemsIds = from i in Ent.Store_item where i.Store_Id == storeid select i;

            foreach (var item in itemsIds)
            {
                string itemsNames = (from i in Ent.Items where i.Item_Code == item.Item_Code select i.Item_Name).FirstOrDefault();
                comboBox4.Items.Add(itemsNames);
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItemName = comboBox4.Text.Trim();

            if (!string.IsNullOrEmpty(selectedItemName))
            {
                product = (from pd in Ent.Items where pd.Item_Name == selectedItemName select pd).FirstOrDefault();

                if (product != null)
                {
                    textBox3.Text = product.Item_Name;

                    var count = (from c in Ent.Store_item where (c.Store_Id == storeid && c.Item_Code == product.Item_Code) select c).FirstOrDefault();
                    textBox2.Text = count.Item_Total_Count.ToString();
                }
                else
                {
                    MessageBox.Show("Item not found!");
                }
            }

        }
        #endregion

        #region Transfer

        private void button1_Click(object sender, EventArgs e)
        {
           
            Item_Transfer transfer = new Item_Transfer();
            int tCount = int.Parse(textBox2.Text);
            transfer.T_Id = int.Parse(textBox1.Text);
            transfer.FromStore_Id = storeid;
            transfer.ToStore_Id = (from t in Ent.Stores where t.Store_Name == comboBox2.Text select t.Store_Id).FirstOrDefault();
            transfer.Item_Code = product.Item_Code;
            transfer.Item_count = tCount;
            transfer.Sup_Id = (from s in Ent.Suppliers where s.Supplier_Name == comboBox3.Text select s.Supplier_Id).FirstOrDefault();
            transfer.Prod_Date = product.Prod_Date;
            transfer.Validity_Period = product.Validity_Period;
            transfer.Transfer_Date = DateTime.Now;
            

            var checktotalCount = (from ch in Ent.Store_item
                                   where (ch.Store_Id == storeid && ch.Item_Code == product.Item_Code)
                                   select ch).FirstOrDefault();


            var checkitemExit = (from ch in Ent.Store_item
                                 where (ch.Store_Id == transfer.ToStore_Id && ch.Item_Code == product.Item_Code)
                                 select ch).FirstOrDefault();
            if (checktotalCount.Item_Total_Count < tCount)
            {
                MessageBox.Show(" please enter smaller quantity");
            }
            else
            {
                if (checkitemExit != null)
                {
                    if (checktotalCount.Item_Total_Count == tCount)
                    {
                        checkitemExit.Item_Total_Count += tCount;
                        Ent.Store_item.Remove(checktotalCount);
                    }
                    else
                    {
                        checkitemExit.Item_Total_Count += tCount;
                        checktotalCount.Item_Total_Count -= tCount;
                    }
                }
                else
                {
                    if (checktotalCount.Item_Total_Count == tCount)
                    {
                        Store_item _Items = new Store_item();
                        _Items.Store_Id = transfer.ToStore_Id;
                        _Items.Item_Code = product.Item_Code;
                        _Items.Item_Total_Count = tCount;
                        Ent.Store_item.Add(_Items);
                        Ent.Store_item.Remove(checktotalCount);
                    }
                    else
                    {
                        checktotalCount.Item_Total_Count -= tCount;
                        Store_item _Items = new Store_item();
                        _Items.Store_Id = transfer.ToStore_Id;
                        _Items.Item_Code = product.Item_Code;
                        _Items.Item_Total_Count = tCount;
                      
                        Ent.Store_item.Add(_Items);
                    }
                }
                Ent.Item_Transfer.Add(transfer);
            }
            Ent.SaveChanges();
            MessageBox.Show("Transfered Successfully !");
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = "";
        }

        #endregion

        #region  Report 
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }
    }
    #endregion
}
