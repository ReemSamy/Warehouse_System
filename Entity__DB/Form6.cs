using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity__DB
{
    public partial class Form6 : Form
    {
        #region Used Data
        Entity__DB Ent = new Entity__DB();
        public Form6()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            
                foreach (Store store in Ent.Stores)
                {
                    comboBox1.Items.Add(store.Store_Name);
                }
                foreach (Supplier supplier_ in Ent.Suppliers)
                {
                    comboBox2.Items.Add(supplier_.Supplier_Name);
                }
                foreach (Item item_ in Ent.Items)
                {
                    comboBox3.Items.Add(item_.Item_Code);
                }
            
        }
        #endregion

        #region  Add Permission
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                int p_id = int.Parse(textBox2.Text);
                PermissionRequest request = Ent.PermissionRequests.Find(id);
                Permission_Item permission = Ent.Permission_Item.Find(p_id);
                string selectedStoreName = comboBox1.SelectedItem.ToString();
                string selectedSupplierName = comboBox2.SelectedItem.ToString();

                // Query the Store table for the StoreId of the selected store
                int selectedStoreId = Ent.Stores
                    .Where(s => s.Store_Name == selectedStoreName)
                    .Select(s => s.Store_Id)
                    .FirstOrDefault();
                int selectedSupplierId = Ent.Suppliers
                    .Where(s => s.Supplier_Name == selectedSupplierName)
                    .Select(s => s.Supplier_Id)
                    .FirstOrDefault();

                if (request == null && permission == null)
                {
                    PermissionRequest request_ = new PermissionRequest();

                    request_.Perm_Id = id;
                    request_.Store_Id = selectedStoreId;
                    request_.Sup_Id = selectedSupplierId;
                    if (radioButton1.Checked)
                    {
                        request_.Perm_Type = radioButton1.Text;
                    }
                    else
                    {
                        request_.Perm_Type = radioButton2.Text;
                    }
                    request_.Perm_Date = dateTimePicker1.Value;
                    Ent.PermissionRequests.Add(request_);

                    Permission_Item permission_ = new Permission_Item();
                    permission_.Perm_Id = id;
                    permission_.P_Id = p_id;
                    permission_.Item_count = int.Parse(textBox3.Text);
                    permission_.Item_Code = int.Parse(comboBox3.Text);
                    Ent.Permission_Item.Add(permission_);

                    // Query the Store_item table for the total count of the item in the store
                    Store_item storeItem = Ent.Store_item
                        .Where(si => si.Store_Id == selectedStoreId && si.Item_Code == permission_.Item_Code)
                        .FirstOrDefault();
                    if (storeItem != null)
                    {
                        if (radioButton2.Checked)
                        {
                            // Decrease the total count of the item if the permission type is "Export"
                            storeItem.Item_Total_Count -= permission_.Item_count;
                        }
                        else
                        {
                            // Increase the total count of the item if the permission type is "Import"
                           storeItem.Item_Total_Count += permission_.Item_count;
                        }
                    }

                    else
                    {
                        // Otherwise, insert a new row with the store id, item code, and total count
                        storeItem = new Store_item();
                        storeItem.Store_Id = selectedStoreId;
                        storeItem.Item_Code = permission_.Item_Code;
                       // storeItem.Item_Total_Count = permission_.Item_count;
                        Ent.Store_item.Add(storeItem);
                    }

                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                }
                else
                {
                    if (request != null)
                    {
                        MessageBox.Show("Permission with ID " + id + " already exists.");
                    }
                    else
                    {
                        MessageBox.Show("Permission_Item with ID " + p_id + " already exists.");
                    }
                }


            }
        }
        #endregion

        #region Update Permission
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                int p_id = int.Parse(textBox2.Text);
                PermissionRequest request = Ent.PermissionRequests.Find(id);
                Permission_Item permission = Ent.Permission_Item.Find(p_id);
                string selectedStoreName = comboBox1.SelectedItem.ToString();
                string selectedSupplierName = comboBox2.SelectedItem.ToString();
                
                int quantity = permission.Item_count;
                int newQuantity = int.Parse(textBox3.Text);
                string permType = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
               

                // Query the Store table for the StoreId of the selected store
                int selectedStoreId = Ent.Stores
                    .Where(s => s.Store_Name == selectedStoreName)
                    .Select(s => s.Store_Id)
                    .FirstOrDefault();
                int selectedSupplierId = Ent.Suppliers
                    .Where(s => s.Supplier_Name == selectedSupplierName)
                    .Select(s => s.Supplier_Id)
                    .FirstOrDefault();

                if (request != null && permission != null)
                {
                    // Update PermissionRequest data
                    request.Store_Id = selectedStoreId;
                    request.Sup_Id = selectedSupplierId;
                    request.Perm_Type = permType;
                    request.Perm_Date = dateTimePicker1.Value;

                    // Update Permission_Item data
                    permission.Item_count = newQuantity;
                    permission.Item_Code = int.Parse(comboBox3.Text);
                    // Query the Store_item table for the total count of the item in the store
                    Store_item storeItem = Ent.Store_item
                        .Where(si => si.Store_Id == selectedStoreId && si.Item_Code == permission.Item_Code)
                        .FirstOrDefault();
                    if (storeItem != null)
                    {
                        int countDiff = newQuantity - quantity;
                        if (permType == "Export")
                        {
                            // Decrease the total count of the item if the permission type is "Export"
                            storeItem.Item_Total_Count -= countDiff;
                        }
                        else if (permType == "Import")
                        {
                            // Increase the total count of the item if the permission type is "Import"
                            storeItem.Item_Total_Count += countDiff;
                        }
                    }
                    else
                    {
                        // Otherwise, insert a new row with the store id, item code, and total count
                        storeItem = new Store_item();
                        storeItem.Store_Id = selectedStoreId;
                        storeItem.Item_Code = permission.Item_Code;
                        storeItem.Item_Total_Count = newQuantity;
                        Ent.Store_item.Add(storeItem);
                    }


                    Ent.SaveChanges();
                    MessageBox.Show("Data has been updated successfully!");
                }
            }
        }
        #endregion

        #region Report TWo
        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
        #endregion

        #region Report Three
        private void button4_Click(object sender, EventArgs e)
        {
           Form9 form9 = new Form9();
            form9.Show();
        }
        #endregion
    }
}
