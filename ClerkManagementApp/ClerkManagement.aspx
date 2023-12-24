<%@ Page Title="Clerk Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClerkManagement.aspx.cs" Inherits="ClerkManagementApp.ClerkManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Manage Clerks</h1>
                            </div>
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtFirstName"><b>First Name</b></asp:Label><br />
                                        <asp:TextBox runat="server" ID="txtFirstName" class="form-control input-sm" placeholder="First Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtLastName"><b>Last Name</b></asp:Label><br />
                                        <asp:TextBox runat="server" ID="txtLastName" class="form-control input-sm" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtDateOfBirth"><b>Date of Birth</b></asp:Label><br />
                                        <asp:TextBox runat="server" ID="txtDateOfBirth" TextMode="Date" class="form-control input-sm" placeholder="Date of Birth"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Button Text="Save" ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-primary btn-lg" Width="220px" runat="server" />
                                        <asp:Button Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-primary btn-lg" Width="220px" runat="server" />
                                        <asp:Button Text="Delete" ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn btn-danger btn-lg" Width="220px" runat="server" />
                                        <asp:Label Text="" ForeColor="Green" Font-Bold="true" ID="lblMessage" CssClass="label label-success" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="form-group">
                                        <div class="table-responsive">
                                            <asp:GridView ID="gv" Width="100%" AutoGenerateColumns="false" OnSelectedIndexChanged="gv_SelectedIndexChanged" runat="server">
                                                <Columns>
                                                    <asp:BoundField DataField="ClerkId" HeaderText="Clerk ID" SortExpression="ClerkId" />
                                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                                    <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" SortExpression="DateOfBirth" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
