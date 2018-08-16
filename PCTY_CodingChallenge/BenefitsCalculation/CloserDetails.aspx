<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CloserDetails.aspx.cs" Inherits="BenefitsCalculation.CloserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-lg-12">

        <asp:Panel runat="server" ID="CloserDetails_ForEmployee" CssClass="col-lg-3">
            <h2>Provider</h2>
            <div class="row">
                <h4>
                    <asp:Label runat="server"> Full name: </asp:Label>
                    <asp:Label runat="server" ID="LabelEmployeeFullName">
                    </asp:Label>
                </h4>
            </div>
            <div class="row">
                <h4>
                    <asp:Label runat="server"> Employee number: </asp:Label>
                    <asp:Label runat="server" ID="LabelEmployeeNumber"> </asp:Label>
                </h4>
            </div>
            <br />
            <div class="row">
                <asp:Label runat="server"> Number of Dependents: </asp:Label>
                <asp:Label runat="server" ID="LabelNumOfDependents"></asp:Label>
            </div>
            <div class="row">
                <asp:Label runat="server">Employee Base Cost: </asp:Label>
                <asp:Label runat="server" ID="LabelEmployeeBaseCost"></asp:Label>
            </div>
            <div class="row">
                <asp:Label runat="server">Cost Accrued by Dependents: </asp:Label>
                <asp:Label runat="server" ID="LabelAmountIncreasedByDependents"></asp:Label>
            </div>
            <div class="row">
                <asp:Label runat="server">Total Benefits Cost:</asp:Label>
                <asp:Label runat="server" ID="LabelBenefitsCost"></asp:Label>
            </div>
            <br />
            <div class="row">
                <asp:Label runat="server">Paycheck Before Deductions: </asp:Label>
                <asp:Label runat="server" ID="LabelEmployeeSalary"></asp:Label>
            </div>
            <div class="row">
                <asp:Label runat="server">Deduction Per Paycheck: </asp:Label>
                <asp:Label runat="server" ID="LabelDeductionsPerPaycheck"></asp:Label>
            </div>
            <div class="row">
                <asp:Label runat="server">Paycheck After Deductions: </asp:Label>
                <asp:Label runat="server" ID="LabelAfterDeductions"></asp:Label>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="CloserDetails_ForDependent" CssClass="col-lg-6 col-lg-offset-1" Visible="false">
            <h2>Dependents</h2>
        </asp:Panel>
    </div>

    <asp:Panel runat="server">
            <asp:Panel runat="server">
                <asp:Button ID="button_EditEmployee" runat="server" Text="Edit Employee" CssClass="btn" OnClick="button_EditEmployee_Click" />
                <asp:Button ID="button_DeleteEmployee" runat="server" Text="Delete Employee" CssClass="btn btn-danger" OnClick="button_DeleteEmployee_Click" />
            </asp:Panel>
    </asp:Panel>

</asp:Content>
