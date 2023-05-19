using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity__DB
{
    public partial class Form5 : Form
    {
        Entity__DB Ent = new Entity__DB();
        public Form5()
        {
            InitializeComponent();
        }
        #region Add Supplier
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                Supplier supplier = Ent.Suppliers.Find(id);

                if (supplier == null)
                {
                    Supplier supplier_ = new Supplier();
                    supplier_.Supplier_Id = id;
                    supplier_.Supplier_Name = textBox2.Text;
                    supplier_.Phone = textBox3.Text;
                    supplier_.Fax = textBox4.Text;
                    supplier_.Email = textBox5.Text;
                    supplier_.Website = textBox6.Text;
                    Ent.Suppliers.Add(supplier_);
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
                }
                else
                {
                    MessageBox.Show("Customer with ID " + id + " already exists.");
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
        }
        #endregion

        #region Update Supplier
        private void button2_Click(object sender, EventArgs e)
        {
            int supplierId = int.Parse(textBox1.Text);
            Supplier supplier = Ent.Suppliers.Find(supplierId);

            if (supplier != null)
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    supplier.Supplier_Name = textBox2.Text;
                    supplier.Phone = textBox3.Text;
                    supplier.Fax = textBox4.Text;
                    supplier.Email = textBox5.Text;
                    supplier.Website = textBox6.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
                    MessageBox.Show("Supplier details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Please enter a name for the supplier.");
                }
            }
            else
            {
                MessageBox.Show("Supplier not found in the database.");
            }
        }
        #endregion
    }
}
