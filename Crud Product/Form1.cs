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
    public partial class ProductView : Form
    {
        public ProductView()
        {
            InitializeComponent();
        }

        static List<Product> products = new List<Product>();
        public BindingSource bs;

        private void Form1_Load(object sender, EventArgs e)
        {
            products.AddRange(new[] {
               new Product("P1", "Cowhead Pure milk 1L", 2.5), 
                new Product("P2", "Honda Dream 125cc", 2750), 
                new Product("P3", "Tiger Beer Cans 330ml", 16.7) 
            });

            bs = new BindingSource(products, null);
            dgvProductView.DataSource = bs;
            dgvProductView.AllowUserToAddRows = false;
            dgvProductView.ReadOnly = true;
            bs.ResetBindings(false);
            dgvProductView.Columns["Info"].Visible = false; 
            var tempVar = dgvProductView.Columns["ValidData"];
            tempVar.DisplayIndex = 0;
            tempVar.HeaderText = "Valid?";
            dgvProductView.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductView.Columns["Price"].DefaultCellStyle.Format = "#,0.00";
            txtInfo.DataBindings.Add("Text", bs, "Info");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddEditForm addProductForm = new AddEditForm();
            AddEditForm frmAdd = new AddEditForm("Adding Products", AddEditForm.Operation.OP_ADD, bs);
            frmAdd.ShowDialog(this);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bs.Current == null)
            {
                return;
            }
            AddEditForm frmEdit = new AddEditForm("Editing Product", AddEditForm.Operation.OP_EDIT, bs);
            frmEdit.Show();
        }
    }
}
