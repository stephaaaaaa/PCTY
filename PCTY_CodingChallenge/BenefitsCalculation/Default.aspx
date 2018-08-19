<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BenefitsCalculation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron custom-jumbo">
        <h1>Employee Benefits Calculator</h1>
        <p class="lead">
            Welcome to your employee benefits calculator. From this landing page, you can view, add,
            modify, or remove employees whose benefits packages you are keeping track of.
        </p>
    </div>

    <div class="row">
        <asp:Panel runat="server" ID="AddEmployee" CssClass="center-block">
            <div class="col-md-5" style="padding-left:200px;">
                <h2>Add an employee</h2>
                <p>Add your employee's information, along with information about any dependents.</p>
                <p>
                    <asp:LinkButton
                        runat="server"
                        CssClass="btn btn-default"
                        OnClick="Click_AddEmployee">
                    <i class="fa fa-plus" aria-hidden="true"></i>
                    Add
                    </asp:LinkButton>
                </p>
            </div>
        </asp:Panel>

        <asp:Panel ID="ViewEmployees" runat="server" CssClass="center-block">
            <div class="col-md-5 pull-right" style="padding-right:200px">
                <h2>View all employees</h2>
                <p>Get a birds-eye view of who you're keeping track of. Any modifications that come to mind can also be taken care of from here.</p>
                <p>
                    <asp:LinkButton
                        runat="server"
                        CssClass="btn btn-default"
                        OnClick="Click_ViewEmployees">
                    <i class="fa fa-address-card-o" aria-hidden="true"></i>
                    View
                    </asp:LinkButton>
                </p>
            </div>
        </asp:Panel>


<%--        <a onclick="document.location='https://www.paylocity.com/';return false;">
            <asp:ImageButton
                runat="server"
                class="center-block"
                ID="fruit"
                ImageUrl="Images/paylocity_fruit.png" />
        </a>--%>
    </div>

</asp:Content>
