<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="BenefitsCalculation.ViewEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>View Employees</h1>
    </div>

    <asp:Panel runat="server" ID="aspTablePanel">
        <div class="row">
            <asp:Table runat="server" id="Table_EmployeeView" Visible="true" CssClass="col-lg-12">
                <asp:TableHeaderRow
                    TableSection="TableHeader">
                    <asp:TableHeaderCell ID="HeaderCell_ID" runat="server" Text="Employee ID" CssClass="col-sm-2" />
                    <asp:TableHeaderCell ID="HeaderCell_Last" runat="server" Text="Last Name" CssClass="col-sm-2" />
                    <asp:TableHeaderCell ID="HeaderCell_First" runat="server" Text="First Name" CssClass="col-sm-2" />
                    <asp:TableHeaderCell ID="HeaderCell_DepNum" runat="server" Text="Number of Dependents" CssClass="col-sm-2" />
                    <asp:TableHeaderCell ID="HeaderCell_CostPerYear" runat="server" Text="Benefits cost per year" CssClass="col-sm-2" />
                    <asp:TableHeaderCell ID="HeaderCell_PaycheckDeduction" runat="server" Text="Deduction per paycheck" CssClass="col-sm-4" />
                </asp:TableHeaderRow>
                <asp:TableRow TableSection="TableBody">
                    <asp:TableCell runat="server" ID="Cell_ID" CssClass="col-sm-2" />
                    <asp:TableCell runat="server" ID="Cell_Last" CssClass="col-sm-2" />
                    <asp:TableCell runat="server" ID="Cell_First" CssClass="col-sm-2" />
                    <asp:TableCell runat="server" ID="Cell_DepNum" CssClass="col-sm-2" />
                    <asp:TableCell runat="server" ID="Cell_CostPerYear" CssClass="col-sm-2" />
                    <asp:TableCell runat="server" ID="Cell_PaycheckDeduction" CssClass="col-sm-2" />
                </asp:TableRow>
            </asp:Table>
        </div>
    </asp:Panel>


    <asp:Panel runat="server" ID="Panel_EmployeesDisplay" Visible="false">
        <table runat="server" class="table">
            <thead id="head_employeeTable">
                <tr>
                    <th scope="col">Employee ID</th>
                    <th scope="col">Last</th>
                    <th scope="col">First</th>
                    <th scope="col">Number of Dependents</th>
                    <th scope="col">Cost of benefits</th>
                </tr>
            </thead>
            <tbody id="body_employeeTable">
                <tr>
                    <td id="td_EmployeeID"></td>
                    <td id="td_EmployeeLastName"></td>
                    <td id="td_EmployeeFirstName"></td>
                    <td id="td_HasDeps"></td>
                    <td id="td_BenefitsCost"></td>
                </tr>
            </tbody>
        </table>

    </asp:Panel>
</asp:Content>
