<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>KPA Sign-off</title>

    <!-- Bootstrap CSS -->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Top Navbar -->
        <div class="navbar-custom d-flex justify-content-between align-items-center">
            <h5>KPA Sign-off</h5>
            <span class="fw-bold">ED K K Sign</span>
        </div>

        <!-- Main Container -->
        <div class="container my-4">

            <div class="d-flex justify-content-between align-items-center mb-3">
                <button class="btn btn-sm btn-outline-secondary me-2" type="button" data-bs-toggle="collapse" data-bs-target="#instructionInfo" aria-expanded="true" aria-controls="instructionInfo">
                    Hide / Show Instructions
                </button>
                <div>
                    <asp:Button ID="btnAddRole" runat="server" CssClass="btn btn-sm btn-primary" Text="Add Role" OnClick="btnAddRole_Click" />
                </div>
            </div>

            <!-- Instructions -->
            <div class="collapse show" id="instructionInfo">
                <div class="instructionInfo">
                    <h6 class="section-title">Instructions</h6>
                    <ul class="instructions-list">
                        <li>Review the roles and KPAs related to your subordinates.</li>
                        <li>Select a role to view its associated KPAs.</li>
                        <li>Choose the most relevant KPAs and mark importance level of each selected KPA.</li>
                    </ul>

                    <h6 class="section-title">Guardrails</h6>
                    <ul class="guardrails-list">
                        <li>Select at least <strong>5 KPAs</strong>, or the entire list if fewer than 5 are available.</li>
                        <li>Select no more than <strong>10 KPAs</strong>.</li>
                        <li>Include <strong>1–2 safety KPAs</strong>.</li>
                        <li>Select at least <strong>one KPA from each visible category</strong>.</li>
                    </ul>

                    <h6 class="section-title">Add New Roles</h6>
                    <p>
                        If you feel a role is missing, click the
                        <asp:Button ID="btnAddRole2" runat="server" CssClass="btn btn-sm btn-primary" Text="Add Role" OnClick="btnAddRole_Click" />
                        button (top right) to add it.
                    </p>

                    <h6 class="section-title">Review Access</h6>
                    <ul class="guardrails-list">
                        <li><strong>EDs</strong> can review Shop Head roles under their purview.</li>
                        <li><strong>Shop Heads</strong> can review Function Heads roles (e.g. Shop Ops Head, Shop Electrical Maintenance Head, etc.)</li>
                        <li><strong>Non-Works Department Heads</strong> can review all roles in their department.</li>
                        <li><strong>Function Heads (per shop)</strong> can review Shop Section Heads and Shift In-charges relevant to their function.</li>
                        <li><strong>DSO</strong> can review all safety roles across all shops.</li>
                    </ul>
                </div>
            </div>

            <!-- Search & Filters -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                        <asp:ListItem>Status (all)</asp:ListItem>
                        <asp:ListItem>Not started</asp:ListItem>
                        <asp:ListItem>Submitted</asp:ListItem>
                        <asp:ListItem>Manually added</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-5 d-flex align-items-center justify-content-end">
                    <h6 class="mb-0 text-end">Summary: Submitted 1 / 3</h6>
                </div>
            </div>

            <!-- Table -->
            <div class="table-responsive">
                <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered align-middle">
                    <Columns>
                        <asp:BoundField DataField="Shop" HeaderText="Shop" />
                        <asp:BoundField DataField="Section" HeaderText="Section" />
                        <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlAction" runat="server" NavigateUrl='<%# Eval("ActionUrl") %>' Text="Review" CssClass="btn btn-sm btn-primary"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" 
        integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" 
        crossorigin="anonymous"></script>

</body>
</html>
