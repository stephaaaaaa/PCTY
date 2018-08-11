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
            <asp:TextBox runat="server" ID="TextBox_EmployeeFirstName" CssClass="form-control col-lg-1"></asp:TextBox>
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="TextBox_EmployeeFirstName"
                ForeColor="#db1a32"
                ErrorMessage="*Please enter a first name.">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                runat="server"
                ControlToValidate="TextBox_EmployeeFirstName"
                ForeColor="#db1a32"
                ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
            </asp:RegularExpressionValidator>
        </div>
        <br />
        <div class="row">
            <asp:Label
                runat="server"
                CssClass="col-lg-2"> Employee Last Name
            </asp:Label>
            <asp:TextBox runat="server" ID="TextBox_EmployeeLastName" CssClass="form-control col-lg-1"></asp:TextBox>
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="TextBox_EmployeeLastName"
                ForeColor="#db1a32"
                ErrorMessage="*Please enter a last name.">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                runat="server"
                ControlToValidate="TextBox_EmployeeLastName"
                ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                ForeColor="#db1a32"
                ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
            </asp:RegularExpressionValidator>
        </div>
        <br />
        <div class="row col-lg-6">
            <asp:Button
                runat="server"
                ID="Button_AddDependent"
                CssClass="btn"
                OnClick="Button_AddDependent_Click"
                Text="Add Dependents" />
            <asp:Button
                runat="server"
                ID="Button_SubmitEmployeeWithNoDependents"
                CssClass="btn "
                OnClick="Button_SubmitEmployeeWithNoDependents_Click"
                Text="Submit" />
        </div>
        <br />
        <br />
        <br/>

    </asp:Panel>

    <asp:Panel runat="server" ID="Panel_AddDependents" Visible="false">

        <div class="row">
            <asp:Label
                runat="server"
                CssClass="col-lg-2">
                Number of dependents
            </asp:Label>
            <div class="col-sm-2">
                <asp:TextBox
                    runat="server"
                    ID="TextBoxNumberOfDependents"
                    CssClass="form-control">
                </asp:TextBox>
            </div>
            <asp:LinkButton runat="server"
                ID="Button_GenerateDependentFields"
                CssClass="btn btn-default"
                OnClick="Button_GenerateDependentFields_Click">
                    Generate dependent fields
            </asp:LinkButton>
        </div>
        <br />

        <div class="row">
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="TextBoxNumberOfDependents"
                ErrorMessage="*Please enter a number of dependents. 0 for no dependents."
                ForeColor="#db1a32">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                runat="server"
                ControlToValidate="TextBoxNumberOfDependents"
                ValidationExpression="^\d+$"
                ErrorMessage="*Number of dependents must be 0, or a whole number"
                ForeColor="#db1a32">
            </asp:RegularExpressionValidator>
        </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="Panel_DependentsFields" Visible="false">
    </asp:Panel>

</asp:Content>
