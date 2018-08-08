<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BenefitsCalculation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Employee Benefits Calculator</h1>
        <p class="lead">Welcome to your employee benefits calculator. From this landing page, you can view, add,
            modify, or remove employees whose benefits packages you are keeping track of, or view all your employees.
        </p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>View Employees</h2>
            <p>
                Get an birds-eye view of who you're keeping track of. Any modifications that come to mind, can
                also be taken care of, from here.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Modify an employee's information</h2>
            <p>
                Have someone in mind? Search your employee via their first or last name, or their employee ID. From
                there, you'll see information regarding their benefits cost. You can add or remove dependents for them,
                or remove the employee.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Add an employee</h2>
            <p>
                Add your employee's information, along with information about any dependents.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
