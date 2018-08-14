<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CloserDetails.aspx.cs" Inherits="BenefitsCalculation.CloserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="row">
            <asp:Panel runat="server" ID="CloserDetails_ForEmployee" CssClass="col-lg-6">
                <h2>Provider</h2>
                <div class="row">
                    <asp:Label runat="server"> Full name: </asp:Label>
                    <asp:Label runat="server" ID="LabelEmployeeFullName">
                    </asp:Label>
                </div>
                <div class="row">
                    <asp:Label runat="server"> Employee number: </asp:Label>
                    <asp:Label runat="server" ID="LabelEmployeeNumber"> </asp:Label>
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

            <asp:Panel runat="server" ID="CloserDetails_ForDependent" CssClass="col-lg-6" Visible="false">
                <h2>Dependents</h2>
            </asp:Panel>
        </div>
    </div>
    <br />
    <div class="row">
        <asp:Panel runat="server">
            <asp:Button runat="server" Text="Edit Employee" CssClass="btn" />
            <asp:Button runat="server" Text="Delete Employee" CssClass="btn btn-danger" />
        </asp:Panel>
    </div>


</asp:Content>
