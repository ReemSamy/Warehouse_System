namespace Entity__DB
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Request_Permission = new System.Windows.Forms.Button();
            this.Supplier = new System.Windows.Forms.Button();
            this.Customer = new System.Windows.Forms.Button();
            this.Product = new System.Windows.Forms.Button();
            this.Store = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Request_Permission
            // 
            this.Request_Permission.Location = new System.Drawing.Point(30, 365);
            this.Request_Permission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Request_Permission.Name = "Request_Permission";
            this.Request_Permission.Size = new System.Drawing.Size(152, 27);
            this.Request_Permission.TabIndex = 17;
            this.Request_Permission.Text = "Request Permission";
            this.Request_Permission.UseVisualStyleBackColor = true;
            this.Request_Permission.Click += new System.EventHandler(this.Request_Permission_Click);
            // 
            // Supplier
            // 
            this.Supplier.Location = new System.Drawing.Point(30, 313);
            this.Supplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(152, 27);
            this.Supplier.TabIndex = 16;
            this.Supplier.Text = "Supplier";
            this.Supplier.UseVisualStyleBackColor = true;
            this.Supplier.Click += new System.EventHandler(this.Supplier_Click);
            // 
            // Customer
            // 
            this.Customer.Location = new System.Drawing.Point(30, 257);
            this.Customer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(152, 27);
            this.Customer.TabIndex = 15;
            this.Customer.Text = "Customer";
            this.Customer.UseVisualStyleBackColor = true;
            this.Customer.Click += new System.EventHandler(this.Customer_Click);
            // 
            // Product
            // 
            this.Product.Location = new System.Drawing.Point(30, 194);
            this.Product.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(152, 27);
            this.Product.TabIndex = 14;
            this.Product.Text = "Item";
            this.Product.UseVisualStyleBackColor = true;
            this.Product.Click += new System.EventHandler(this.Product_Click);
            // 
            // Store
            // 
            this.Store.Location = new System.Drawing.Point(30, 138);
            this.Store.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Store.Name = "Store";
            this.Store.Size = new System.Drawing.Size(152, 27);
            this.Store.TabIndex = 13;
            this.Store.Text = "Store";
            this.Store.UseVisualStyleBackColor = true;
            this.Store.Click += new System.EventHandler(this.Store_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = " WareHouse  Application";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(769, 504);
            this.Controls.Add(this.Request_Permission);
            this.Controls.Add(this.Supplier);
            this.Controls.Add(this.Customer);
            this.Controls.Add(this.Product);
            this.Controls.Add(this.Store);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Request_Permission;
        private System.Windows.Forms.Button Supplier;
        private System.Windows.Forms.Button Customer;
        private System.Windows.Forms.Button Product;
        private System.Windows.Forms.Button Store;
        private System.Windows.Forms.Label label1;
    }
}

