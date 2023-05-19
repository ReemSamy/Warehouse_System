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
    public partial class Form4 : Form
    {
        Entity__DB Ent = new Entity__DB();
        public Form4()
        {
            InitializeComponent();
        }
        #region Add Customer
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                Customer customer = Ent.Customers.Find(id);

                if (customer == null)
                {
                    Customer customer_ = new Customer();
                    customer_.Customer_Id = id;
                    customer_.Customer_Name = textBox2.Text;
                    customer_.Phone = textBox3.Text;
                    customer_.Fax = textBox4.Text;
                    customer_.Email = textBox5.Text;
                    customer_.Website = textBox6.Text;
                    Ent.Customers.Add(customer_);
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

        #region Update Customer

        private void button2_Click(object sender, EventArgs e)
        {
            int customerId = int.Parse(textBox1.Text);
            Customer customer = Ent.Customers.Find(customerId);

            if (customer != null)
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    customer.Customer_Name = textBox2.Text;
                    customer.Phone = textBox3.Text;
                    customer.Fax = textBox4.Text;
                    customer.Email = textBox5.Text;
                    customer.Website = textBox6.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
                    MessageBox.Show("Customer details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Please enter a name for the customer.");
                }
            }
            else
            {
                MessageBox.Show("Customer not found in the database.");
            }
        }
        #endregion
    }
}
