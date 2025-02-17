using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation: Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x=> new
            {
               FullName = x.GuideName + " " + x.GuideSurname,
               x.GuideId
            }).ToList();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "GuideId";
            comboBox1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(numericUpDown1.Value.ToString());
            location.City = txtName.Text;
            location.Country = txtSurname.Text;
            location.Price = decimal.Parse(textBox2.Text);
            location.DayNight = textBox3.Text;
            location.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Location Added");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue = db.Location.Find(id);
            db.Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Location Deleted");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.Capacity = byte.Parse(numericUpDown1.Value.ToString());
            updatedValue.City = txtName.Text;
            updatedValue.Country = txtSurname.Text;
            updatedValue.Price = decimal.Parse(textBox2.Text);
            updatedValue.DayNight = textBox3.Text;
            updatedValue.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Location Updated");
        }
    }
}
