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
    public partial class Form10 : Form
    {
        #region Report
        Entity__DB Ent = new Entity__DB();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            var items = from item in Ent.Items select item;
            foreach (var item in items)
            {
                comboBox1.Items.Add(item.Item_Name);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string itemName = comboBox1.SelectedItem.ToString();
            var item = (from i in Ent.Items
                        where i.Item_Name == itemName
                        select i).FirstOrDefault();
            if (item != null)
            {
                int itemId = item.Item_Code;

                // Get the entry dates and validities for the selected item
                var entryDatesAndValidities = from si in Ent.Store_item
                                              join pr in Ent.PermissionRequests on si.Store_Id equals pr.Store_Id
                                              join it in Ent.Items on si.Item_Code equals it.Item_Code
                                              where si.Item_Code == itemId
                                              select new { EntryDate = pr.Perm_Date, Validity = it.Validity_Period };

                // Clear the list boxes and add the entry dates and number of days left
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                foreach (var entryDateAndValidity in entryDatesAndValidities)
                {
                    listBox3.Items.Add(entryDateAndValidity.EntryDate);
                    DateTime expiryDate = entryDateAndValidity.EntryDate.AddDays(entryDateAndValidity.Validity.Day);
                    int daysLeft = (int)(expiryDate - DateTime.Now).TotalDays;
                    listBox4.Items.Add(daysLeft);
                }


                // Get the store and duration information for the selected item
                var storeItems = from si in Ent.Store_item
                                 where si.Item_Code == itemId
                                 select si;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (var si in storeItems)
                {
                    listBox1.Items.Add(si.Item_Code);
                    listBox2.Items.Add(si.Store_Id);
                }




            }
        }
        #endregion
    }

}
    

