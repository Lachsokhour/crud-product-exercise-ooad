using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Product
{
    public partial class AddEditForm : Form
    {
        public AddEditForm()
        {
            InitializeComponent();
        }

        public enum Operation
        {
            OP_NONE = 0,
            OP_ADD = 1,
            OP_EDIT = 2,
        }

        private string title;
        private BindingSource bs; 
        private Operation op; 
        private BindingSource b; 
        private Product cur; 

        public AddEditForm(string title, Operation op, BindingSource bs) { 
            this.InitializeComponent(); 
            this.title = title;
            this.bs = bs; 
            if (bs == null) {
                this.Close(); 
            } 
            this.op = op; 
            if (this.op == Operation.OP_NONE) { 
                this.Close(); 
            } 
        }

        private void ValidateKeyPress(object sender, KeyPressEventArgs e) { 
            lblInfo.Text = ""; 
            if (e.KeyChar == Convert.ToChar(Keys.Escape)) { 
                (sender as TextBox).DataBindings["Text"].ReadValue(); 
            } 
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            this.Text = title; 
            lblInfo.Text = ""; 
            cur = new Product(); 
            if (op == Operation.OP_EDIT)
            {
                cur = (Product)bs.Current;
            }
            b = new BindingSource(cur, null); 
            txtId.DataBindings.Add("Text", b, "Id").DataSourceUpdateMode = DataSourceUpdateMode.Never; 
            txtName.DataBindings.Add("Text", b, "Name").DataSourceUpdateMode = DataSourceUpdateMode.Never; 
            txtPrice.DataBindings.Add("Text", b, "Price").DataSourceUpdateMode = DataSourceUpdateMode.Never; 
            b.ResetBindings(false);
            txtId.KeyPress += ValidateKeyPress; 
            txtName.KeyPress += ValidateKeyPress; 
            txtPrice.KeyPress += ValidateKeyPress;
        }

        private void btnCommit_Click(object sender, EventArgs e) { 
            b.RaiseListChangedEvents = false; txtName.DataBindings["Text"].WriteValue(); 
            txtId.DataBindings["Text"].WriteValue(); 
            txtPrice.DataBindings["Text"].WriteValue(); 
            b.RaiseListChangedEvents = true; 
            lblInfo.Text = "Entry was committed"; 
            if (op == Operation.OP_ADD) { 
                bs.Position = bs.List.Add(cur.Clone()); 
                cur.SetData("", "", 0); 
                b.CancelEdit(); 
            } bs.ResetBindings(false); 
        }

        private void btnCancel_Click(object sender, EventArgs e) { 
            b.CancelEdit(); 
            lblInfo.Text = "Entry was cancelled"; 
        }
    }
}
