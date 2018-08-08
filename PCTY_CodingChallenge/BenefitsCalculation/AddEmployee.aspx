<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="BenefitsCalculation.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Add Employee</h1>
    </div>

    <asp:Panel runat="server" ID="Panel_AddEmployee">
        <asp:FormView>
        </asp:FormView>

    </asp:Panel>

</asp:Content>
