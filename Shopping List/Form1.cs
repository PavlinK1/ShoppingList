using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Shopping_List
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> items = new();
        private List<string> history = new();
        private const string PH = "Име на продукт";

        public Form1()
        {
            InitializeComponent();

            txtItem.ForeColor = Color.Gray;
            txtItem.Text = PH;
            txtItem.Enter += TxtItem_Enter;
            txtItem.Leave += TxtItem_Leave;
            txtItem.KeyDown += TxtItem_KeyDown;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            lvItems.SelectedIndexChanged += LvItems_SelectedIndexChanged;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            btnRemove.Enabled = false;
            RefreshUI();
        }

        private void TxtItem_Enter(object sender, EventArgs e)
        {
            if (txtItem.Text == PH)
            {
                txtItem.Text = "";
                txtItem.ForeColor = Color.Black;
            }
        }

        private void TxtItem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItem.Text))
            {
                txtItem.Text = PH;
                txtItem.ForeColor = Color.Gray;
            }
        }

        private void TxtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnAdd_Click(sender, e);
        }

        private void LvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = lvItems.SelectedItems.Count > 0;
        }

        private void RefreshUI()
        {
            lvItems.Items.Clear();
            foreach (var kv in items)
            {
                var it = new ListViewItem(kv.Key);
                it.SubItems.Add(kv.Value.ToString());
                lvItems.Items.Add(it);
            }

            lbHistory.Items.Clear();
            foreach (var h in history)
                lbHistory.Items.Add(h);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var name = txtItem.Text.Trim();
            if (string.IsNullOrEmpty(name) || name == PH) return;

            int qty = (int)nudQty.Value;
            if (items.ContainsKey(name)) items[name] += qty;
            else items[name] = qty;

            history.Add($"{DateTime.Now:HH:mm} + {name} x{qty}");
            RefreshUI();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count == 0) return;
            var name = lvItems.SelectedItems[0].Text;
            if (items.Remove(name))
                history.Add($"{DateTime.Now:HH:mm} - {name}");
            RefreshUI();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) ExportCsv();
            else if (e.Control && e.KeyCode == Keys.O) ImportCsv();
        }

        private void ExportCsv()
        {
            using var dlg = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv" };
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            using var w = new StreamWriter(dlg.FileName);
            w.WriteLine("Product,Quantity");
            foreach (var kv in items)
                w.WriteLine($"{kv.Key},{kv.Value}");

            history.Add($"{DateTime.Now:HH:mm} CSV exported");
            RefreshUI();
        }

        private void ImportCsv()
        {
            using var dlg = new OpenFileDialog { Filter = "CSV files (*.csv)|*.csv" };
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            foreach (var line in File.ReadAllLines(dlg.FileName).Skip(1))
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out var q))
                {
                    var key = parts[0];
                    if (items.ContainsKey(key)) items[key] += q;
                    else items[key] = q;
                }
            }

            history.Add($"{DateTime.Now:HH:mm} CSV imported");
            RefreshUI();
        }
    }
}
