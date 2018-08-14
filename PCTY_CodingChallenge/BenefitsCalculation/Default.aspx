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
            <div class="col-md-4">
                <h2>Add an employee</h2>
                <p>
                    Add your employee's information, along with information about any dependents.
                </p>
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
            <div class="col-md-4">
                <h2>View employees</h2>
                <p>
                    Get an birds-eye view of who you're keeping track of. Any modifications that come to mind, can
                also be taken care of from here.
                </p>
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

        <asp:Panel runat="server" Visible="false">
            <div class="col-md-4">
                <h2>Modify an employee's information</h2>
                <p>
                    Have someone in mind? Search your employee via their first or last name. From
                there, you'll see information regarding their benefits cost. You can add or remove dependents for them,
                or remove the employee from your records.
                </p>
                <p>
                    <asp:LinkButton
                        runat="server"
                        CssClass="btn btn-default"
                        OnClick="Click_ModifyEmployees">
                    <i class="fa fa-pencil-square-o" aria-hidden="true"></i>                   
                    Modify
                    </asp:LinkButton>
                </p>
            </div>
        </asp:Panel>
        <asp:ImageButton runat="server" class="center-block" ID="fruit" ImageUrl="Images/paylocity_fruit.png" OnClick="fruit_Click" />
    </div>

</asp:Content>
