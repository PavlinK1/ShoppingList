namespace Shopping_List
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListBox lbHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtItem = new System.Windows.Forms.TextBox();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lvItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lbHistory = new System.Windows.Forms.ListBox();

            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.SuspendLayout();

            // txtItem
            this.txtItem.Location = new System.Drawing.Point(20, 20);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(150, 23);
            this.txtItem.Text = "Име на продукт";
            this.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // nudQty
            this.nudQty.Location = new System.Drawing.Point(190, 20);
            this.nudQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQty.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(60, 23);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Text = "Добави";
            this.btnAdd.UseVisualStyleBackColor = true;

            // btnRemove
            this.btnRemove.Location = new System.Drawing.Point(110, 60);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.Text = "Премахни";
            this.btnRemove.UseVisualStyleBackColor = true;

            // lvItems
            this.lvItems.Location = new System.Drawing.Point(20, 100);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(230, 150);
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.Columns.AddRange(new[] { this.columnHeader1, this.columnHeader2 });

            // columnHeader1
            this.columnHeader1.Text = "Продукт";
            this.columnHeader1.Width = 150;

            // columnHeader2
            this.columnHeader2.Text = "Количество";
            this.columnHeader2.Width = 70;

            // lbHistory
            this.lbHistory.Location = new System.Drawing.Point(270, 20);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(200, 230);

            // Form1
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtItem, this.nudQty,
                this.btnAdd, this.btnRemove,
                this.lvItems, this.lbHistory
            });
            this.Name = "Form1";
            this.Text = "Shopping List";

            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
