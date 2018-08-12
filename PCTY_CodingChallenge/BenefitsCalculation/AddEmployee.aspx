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
                ID="Button_EditEmployeeName"
                CssClass="btn"
                OnClick="Button_EditEmployeeName_Click"
                CausesValidation="false"
                Text="Edit Employee Name"
                Visible="false" />
            <asp:Button
                runat="server"
                ID="Button_SubmitEmployeeWithNoDependents"
                CssClass="btn"
                OnClick="Button_SubmitEmployeeWithNoDependents_Click"
                Text="Submit" />
        </div>
        <br />
        <br />
        <br />
    </asp:Panel>

    <asp:Panel runat="server" ID="Panel_AddDependents" Visible="false">
        <div class="row col-lg-9">
            <asp:Label
                runat="server"
                CssClass="row col-lg-3"
                Text="Number of Dependents">
            </asp:Label>
            <asp:TextBox
                runat="server"
                ID="TextBoxNumberOfDependents"
                CssClass="form-control">
            </asp:TextBox>
        </div>
        <br />
        <br />
        <div >
            <asp:Button runat="server"
                ID="Button_GenerateDependentFields"
                CssClass=" btn"
                OnClick="Button_GenerateDependentFields_Click"
                Text="Generate dependent fields"></asp:Button>
        </div>
        <br />

        <div class="row">
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="TextBoxNumberOfDependents"
                ErrorMessage="*Please enter a number of dependents."
                ForeColor="#db1a32">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                runat="server"
                ControlToValidate="TextBoxNumberOfDependents"
                ValidationExpression="^\d+$"
                ErrorMessage="*Number of dependents must be a whole number"
                ForeColor="#db1a32">
            </asp:RegularExpressionValidator>
        </div>
    </asp:Panel>

    <br />
    <br />
    <br />
    <br />

    <div class="row col-lg-12">
        <asp:Panel runat="server" ID="Panel_DependentsFields" Visible="false">
        </asp:Panel>
    </div>

    <div class="row">
        <asp:Panel runat="server" ID="Panel_SubmitWithDependents" Visible="false">
            <div class="row col-lg-12">
                <asp:Button
                    runat="server"
                    CssClass="btn bottom "
                    Text="Submit"
                    ID="Button_SubmitWithDependents"
                    OnClick="Button_SubmitWithDependents_Click" />
            </div>
        </asp:Panel>
    </div>


</asp:Content>

