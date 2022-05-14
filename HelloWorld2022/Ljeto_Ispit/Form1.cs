using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ljeto_Ispit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitavanjePodatakaBP();
            UcitavanjePodatakaComboBox();
        }

        private void UcitavanjePodatakaComboBox()
        {
            cmbFilterBy.Items.Add("ProductID");
            cmbFilterBy.Items.Add("Name");
            cmbFilterBy.Items.Add("Product Number");

            cmbFilterBy.SelectedIndex = 0;
        }

        private void UcitavanjePodatakaBP()
        {
            using (var db = new entities())
            {
                var query = from x in db.Product
                            select x;
                var countAllLoading = (from x in db.Product
                             select x).Count();
                dgvProducts.DataSource = query.Select(x => new { ProductID = x.ProductID, Name = x.Name, ProductNumber = x.ProductNumber, 
                    StandardCost = x.StandardCost, ListPrice = x.ListPrice}).ToList();

                lblCountRows.Text = String.Format($"Showing {countAllLoading} out of {countAllLoading} records");
            }
        }

        public int UkupanBrojRedakaUTablici()
        {
            using (var db = new entities())
            {
                var countAllLoading = (from x in db.Product
                                       select x).Count();
                return countAllLoading;
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            using (var db = new entities())
            {
                var query = from x in db.Product
                            select x;

                dgvProducts.DataSource = query.Select(o => new {
                    ProductID = o.ProductID,
                    Name = o.Name,
                    ProductNumber = o.ProductNumber,
                    StandardCost = o.StandardCost,
                    ListPrice = o.ListPrice
                }).ToList();

                lblCountRows.Text = String.Format($"Showing {UkupanBrojRedakaUTablici()} out of {UkupanBrojRedakaUTablici()} records");
            }
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltiranjeTabliceComboBoxTextBox();
        }

        private void FiltiranjeTabliceComboBoxTextBox()
        {
            int odabir = cmbFilterBy.SelectedIndex;
            IzvrsavanjeOpcijeComboBoxa(odabir);
        }

        private void IzvrsavanjeOpcijeComboBoxa(int odabir)
        {
            switch (odabir)
            {
                case 0:
                    FiltarPoProductID();
                    break;
                case 1:
                    FiltarPoName();
                    break;
                case 2:
                    FiltarPoProductNumber();
                    break;
                default:
                    break;
            }
        }

        private void FiltarPoProductNumber()
        {
            using (var db = new entities())
            {
                string uneseniZnak = txtUnos.Text.Trim();
                var query = from x in db.Product
                            where x.ProductNumber.Contains(uneseniZnak)
                            select x;
                var brojRedaka = (from x in db.Product
                                  where x.ProductNumber.Contains(uneseniZnak)
                                  select x).Count();

                lblCountRows.Text = String.Format($"Showing {brojRedaka} out of {UkupanBrojRedakaUTablici()} records");

                dgvProducts.DataSource = query.Select(y => new { ProductID = y.ProductID, Name = y.Name, ProductNumber = y.ProductNumber, 
                StandardCost = y.StandardCost, ListPrice = y.ListPrice}).ToList();
            }
        }

        private void FiltarPoName()
        {
            using (var db = new entities())
            {
                string uneseniZnak = txtUnos.Text.Trim();
                var query = from x in db.Product
                            where x.Name.Contains(uneseniZnak)
                            select x;

                var brojRedaka = (from x in db.Product
                                  where x.Name.Contains(uneseniZnak)
                                  select x).Count();

                dgvProducts.DataSource = query.Select(y => new {
                    ProductID = y.ProductID,
                    Name = y.Name,
                    ProductNumber = y.ProductNumber,
                    StandardCost = y.StandardCost,
                    ListPrice = y.ListPrice
                }).ToList();

                lblCountRows.Text = String.Format($"Showing {brojRedaka} out of {UkupanBrojRedakaUTablici()} records");
            }
        }

        private void FiltarPoProductID()
        {
            using (var db = new entities())
            {
                string uneseniZnak = txtUnos.Text.Trim();
                var query = from x in db.Product
                            where (x.ProductID).ToString().Contains(uneseniZnak)
                            select x;
                var brojRedaka = (from x in db.Product
                                  where (x.ProductID).ToString().Contains(uneseniZnak)
                                  select x).Count();

                dgvProducts.DataSource = query.Select(y => new {
                    ProductID = y.ProductID,
                    Name = y.Name,
                    ProductNumber = y.ProductNumber,
                    StandardCost = y.StandardCost,
                    ListPrice = y.ListPrice
                }).ToList();

                lblCountRows.Text = String.Format($"Showing {brojRedaka} out of {UkupanBrojRedakaUTablici()} records");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FiltiranjeTabliceComboBoxTextBox();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
