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
        static string Id;
        private void BindGridView()
        {
            var query = _clerkService.GetAll();
            _dataLayer.fillgridView(query, gv);
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Id = gv.SelectedRow.Cells[1].Text.ToString();
            txtFirstName.Text = gv.SelectedRow.Cells[2].Text.ToString();
            txtLastName.Text = gv.SelectedRow.Cells[3].Text.ToString();
            txtDateOfBirth.Text = gv.SelectedRow.Cells[4].Text.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var query = _clerkService.Add();
            string qry = query + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtDateOfBirth.Text + "')";
            lblMessage.Text = _dataLayer.insertUpdateCreateOrDelete(qry);
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDateOfBirth.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var query = _clerkService.Update();
            string qry = query + txtFirstName.Text + "',LastName='" + txtLastName.Text + "',DateOfBirth='" + txtDateOfBirth.Text + "'";
            lblMessage.Text = _dataLayer.insertUpdateCreateOrDelete(qry);
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDateOfBirth.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var query = _clerkService.Delete();
            string qry = query + Id + "'";
            lblMessage.Text = _dataLayer.insertUpdateCreateOrDelete(qry);
        }
    }
}
