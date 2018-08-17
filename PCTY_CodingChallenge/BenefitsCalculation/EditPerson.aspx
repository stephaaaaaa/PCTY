<%@ Page Title="Edit Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPerson.aspx.cs" Inherits="BenefitsCalculation.EditPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="panel_editEmployee" Visible="false">
        <div class="jumbotron custom-jumbo">
            <h1>Edit Employee</h1>

            <asp:Label runat="server" ID="label_employeeBeingEdited"></asp:Label>
        </div>

        <asp:Panel runat="server" ID="panel_editEmployeeFields">
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
                <asp:Button runat="server" Text="Submit Changes" ID="button_SubmitChanges" CssClass="btn btn-default" OnClick="button_SubmitChanges_Click"></asp:Button>
                <asp:Button runat="server" Text="Cancel Changes" ID="button_CancelChanges" CssClass="btn btn-default" OnClick="button_CancelChanges_Click"></asp:Button>
            </div>
        </asp:Panel>
    </asp:Panel>

    <asp:Panel runat="server" ID="panel_editDependent" Visible="false">

        <div class="jumbotron custom-jumbo">
            <h1>Edit Dependent</h1>
            <asp:Label runat="server" ID="label_dependentBeingEdited"></asp:Label>
        </div>

        <asp:Panel runat="server" ID="panel_editDependentFields">
            <div class="row">
                <asp:Label
                    runat="server"
                    CssClass="col-lg-2"> Dependent First Name
                </asp:Label>
                <asp:TextBox runat="server" ID="textBox_dependentFName" CssClass="form-control col-lg-1"></asp:TextBox>
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="textBox_dependentFName"
                    ForeColor="#db1a32"
                    ErrorMessage="*Please enter a first name.">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    runat="server"
                    ControlToValidate="textBox_dependentFName"
                    ForeColor="#db1a32"
                    ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                    ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
                </asp:RegularExpressionValidator>
            </div>
            <br />
            <div class="row">
                <asp:Label
                    runat="server"
                    CssClass="col-lg-2"> Dependent Last Name
                </asp:Label>
                <asp:TextBox runat="server" ID="textBox_dependentLName" CssClass="form-control col-lg-1"></asp:TextBox>
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="textBox_DependentLName"
                    ForeColor="#db1a32"
                    ErrorMessage="*Please enter a last name.">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    runat="server"
                    ControlToValidate="textBox_DependentLName"
                    ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                    ForeColor="#db1a32"
                    ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
                </asp:RegularExpressionValidator>
            </div>
            <br />
            <div class="row col-lg-6">
                <asp:Button runat="server" Text="Submit Changes" ID="button_depSubmitChanges" CssClass="btn btn-default" OnClick="button_SubmitChanges_Click"></asp:Button>
                <asp:Button runat="server" Text="Cancel Changes" ID="button_depCancelChanges" CssClass="btn btn-default" OnClick="button_CancelChanges_Click"></asp:Button>
            </div>
        </asp:Panel>

    </asp:Panel>
    <br />
    <br />

</asp:Content>
