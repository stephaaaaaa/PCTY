<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyEmployee.aspx.cs" Inherits="BenefitsCalculation.ModifyEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron custom-jumbo">
        <h1>Modify Employee</h1>
        <h2>Search your employee by their first or last name, to modify information about them or their dependents.</h2>
    </div>

    <div class="row">
        <asp:Panel runat="server" ID="Panel_ModifySearchBar">
            <asp:TextBox
                ID="TextBox_SearchField"
                runat="server"
                CssClass="form-control center-block">
            </asp:TextBox>
            <asp:Button
                ID="Button_SubmitSearch"
                runat="server"
                CssClass="btn center-block"
                Text="Search"
                OnClick="Button_SubmitSearch_Click" />
        </asp:Panel>
    </div>
</asp:Content>
