<%@ Page Title="View Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="BenefitsCalculation.ViewEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron custom-jumbo">
        <h1>View Employees</h1>
    </div>

    <asp:Panel runat="server" ID="sortingButtonsPanel" Visible="false">
        <div>
            <asp:Label
                runat="server"
                CssClass="col-lg-1"
                Text="Sort by:">
            </asp:Label>
            <asp:DropDownList
                runat="server"
                ID="DropDown_SortingOptions"
                CssClass="form-control col-lg-1"
                AutoPostBack="true">
                <asp:ListItem Text="Newest"
                    Selected="True">
                </asp:ListItem>
                <asp:ListItem Text="Oldest">
                </asp:ListItem>
                <asp:ListItem Text="Last name">
                </asp:ListItem>
                <asp:ListItem Text="First name">
                </asp:ListItem>
                <asp:ListItem Text="Dependents (high to low)">
                </asp:ListItem>
                <asp:ListItem Text="Dependents (low to high)">
                </asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--Create search bar here?--%>
    </asp:Panel>

    <asp:Panel runat="server" ID="aspTablePanel">
        <asp:Table runat="server" ID="Table_EmployeeView" Visible="true" CssClass="table custom-table table-hover">
            <asp:TableHeaderRow TableSection="TableHeader">
                <asp:TableHeaderCell ID="HeaderCell_ID" runat="server" Text="Employee ID" />
                <asp:TableHeaderCell ID="HeaderCell_Last" runat="server" Text="Last Name" />
                <asp:TableHeaderCell ID="HeaderCell_First" runat="server" Text="First Name" />
                <asp:TableHeaderCell ID="HeaderCell_DepNum" runat="server" Text="Number of Dependents" />
                <asp:TableHeaderCell ID="HeaderCell_CostPerYear" runat="server" Text="Benefits cost per year" />
                <asp:TableHeaderCell ID="HeaderCell_PaycheckDeduction" runat="server" Text="Deduction per paycheck" />
                <asp:TableHeaderCell ID="HeaderCell_PaycheckRemaining" runat="server" Text="Paycheck after deductions" />
                <asp:TableHeaderCell runat="server" />

            </asp:TableHeaderRow>
            <asp:TableRow TableSection="TableBody" ID="EmployeeViewBody">
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>


</asp:Content>
