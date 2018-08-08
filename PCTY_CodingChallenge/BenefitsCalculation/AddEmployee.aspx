<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="BenefitsCalculation.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Add Employee</h1>
    </div>

    <asp:Panel runat="server" ID="Panel_AddSingleEmployee">
        <div class="row">
            <asp:Label
                runat="server"
                CssClass="col-lg-2"> Employee First Name
            </asp:Label>
            <asp:TextBox runat="server" CssClass="form-control col-lg-1"></asp:TextBox>
        </div>
        <br />
        <div class="row">
            <asp:Label
                runat="server"
                CssClass="col-lg-2"> Employee Last Name
            </asp:Label>
            <asp:TextBox runat="server" CssClass="form-control col-lg-1"></asp:TextBox>
        </div>
        <br />
        <div class="row">
            <asp:Button
                runat="server" 
                ID="Button_AddDependent"
                CssClass="col-lg-2 btn"
                OnClick="Button_AddDependent_Click"
                Text="Add Dependents"/>
        </div>
        <br/>

    </asp:Panel>

    <asp:Panel
        runat="server"
        ID="Panel_AddDependents"
        Visible="false">

        <asp:Label 
            runat="server">
            
        </asp:Label>

    </asp:Panel>

</asp:Content>
