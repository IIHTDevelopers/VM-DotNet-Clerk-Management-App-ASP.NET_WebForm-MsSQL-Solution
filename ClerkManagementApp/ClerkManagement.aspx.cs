using ClerkManagementApp.DAL;
using ClerkManagementApp.Model;
using System;
using System.Web.UI;

namespace ClerkManagementApp
{
    public partial class ClerkManagement : Page
    {
        private readonly datalayer _dataLayer;
        private readonly ClerkManagementApp.DAL.Interfaces.IClerkService _clerkService;

        public ClerkManagement()
        {
            _dataLayer = new datalayer();
            _clerkService = new DAL.Services.ClerkService(new DAL.Services.ClerkRepository(new ClerkManagementApp.DAL.ClerkDbContext()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            var clerks = _clerkService.GetAll();
            _dataLayer.fillgridView(clerks, gv);
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gv.SelectedRow.Cells[1].Text;
            // Retrieve the clerk details and populate the form
            var clerk = _clerkService.GetById(id);
            if (clerk != null)
            {
                txtFirstName.Text = clerk.FirstName;
                txtLastName.Text = clerk.LastName;
                txtDateOfBirth.Text = clerk.DateOfBirth.ToString("yyyy-MM-dd");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            var newClerk = new ClerkModel
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = DateTime.Parse(txtDateOfBirth.Text)
            };

            _clerkService.Add();
            BindGridView();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            var existingClerk = _clerkService.GetById(id);

            if (existingClerk != null)
            {
                existingClerk.LastName = txtLastName.Text;
                existingClerk.FirstName = txtFirstName.Text;
                existingClerk.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);

                _clerkService.Update();
                BindGridView();
            }
        }

        protected void btndlt_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            _clerkService.Delete();
            BindGridView();
        }
    }
}
