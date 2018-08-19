<%@ Page Title="Add New Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="BenefitsCalculation.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron custom-jumbo">
        <h1>Add People</h1>
        <h3>Add employees and/or their dependents</h3>
        <asp:Panel runat="server" ID="panel_IncomingEmployeeInfo"></asp:Panel>
    </div>

    <div style="padding-bottom: 30px;">
        <asp:Panel runat="server" ID="Panel_AddSingleEmployee" Visible="false">
            <div class="row">
                <asp:Label
                    runat="server"
                    CssClass="col-lg-2"> Employee First Name
                </asp:Label>
                <asp:TextBox runat="server" ID="TextBox_EmployeeFirstName" CssClass="form-control col-lg-1"></asp:TextBox>
                <%--Validators--%>
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
                <%--End validator--%>
            </div>
            <br />
            <div class="row">
                <asp:Label
                    runat="server"
                    CssClass="col-lg-2"> Employee Last Name
                </asp:Label>
                <asp:TextBox runat="server" ID="TextBox_EmployeeLastName" CssClass="form-control col-lg-1"></asp:TextBox>
                <%--Validator--%>
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
                <%--End validator--%>
            </div>
            <br />
            <div class="row col-lg-6">
                <asp:Button
                    runat="server"
                    ID="Button_addDependents"
                    CssClass="btn btn-default"
                    OnClick="button_addDependents_Click"
                    Text="Add Dependents" />
                <asp:Button
                    runat="server"
                    ID="Button_SubmitEmployeeWithNoDependents"
                    CssClass="btn"
                    OnClick="Button_SubmitEmployeeWithNoDependents_Click"
                    Text="Submit" />
                <asp:Button
                    runat="server"
                    ID="button_cancel"
                    CssClass="btn"
                    OnClick="button_cancel_Click"
                    Text="Cancel"
                    CausesValidation="false" />
            </div>
        </asp:Panel>
    </div>

    <asp:Panel runat="server" ID="Panel_AddDependents" Visible="true">
        <div class="form-group fieldGroup" style="padding-top: 20px;">
            <div class="">
                <div class="" style="padding-bottom: 5px;">
                    <asp:Label runat="server">Dependent First Name:</asp:Label>
                    <asp:TextBox runat="server" ID="dep_firstname" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        runat="server"
                        ControlToValidate="dep_firstname"
                        ForeColor="#db1a32"
                        ErrorMessage="* Please enter a first name.">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        runat="server"
                        ControlToValidate="dep_firstname"
                        ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                        ForeColor="#db1a32"
                        ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
                    </asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Label runat="server">Dependent Last Name:</asp:Label>
                    <asp:TextBox runat="server" ID="dep_lastname" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        runat="server"
                        ControlToValidate="dep_lastname"
                        ForeColor="#db1a32"
                        ErrorMessage="* Please enter a last name.">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        runat="server"
                        ControlToValidate="dep_lastname"
                        ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                        ForeColor="#db1a32"
                        ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
                    </asp:RegularExpressionValidator>
                </div>
            </div>
        </div>

        <div style="padding-top: 20px">
            <div style="padding-top: 10px; padding-bottom: 20px;">
                <a href="javascript:void(0)" class="btn btn-success addMore"><span class="glyphicon glyphicon glyphicon-plus" aria-hidden="true"></span>Add Dependent</a>
            </div>
            <asp:Button
                runat="server"
                ID="button_submitEmployeeWithDependent"
                CausesValidation="false"
                Text="Submit"
                CssClass="btn"
                OnClick="button_submitEmployeeWithDependent_Click"></asp:Button>
            <asp:Button
                runat="server"
                ID="button_cancelWithDependentsField"
                Text="Cancel"
                CssClass="btn"
                CausesValidation="false"
                OnClick="button_cancel_Click"></asp:Button>
        </div>

        <div class="form-group fieldGroupCopy col-lg-12" style="display: none;">
            <div style="padding-bottom: 5px;">
                <asp:Label runat="server">Dependent First Name:</asp:Label>
                <asp:TextBox runat="server" ID="dep_firstname1" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="dep_firstname1"
                    ForeColor="#db1a32"
                    ErrorMessage="* Please enter a first name.">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    runat="server"
                    ControlToValidate="dep_firstname1"
                    ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                    ForeColor="#db1a32"
                    ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
                </asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label runat="server">Dependent Last Name:</asp:Label>
                <asp:TextBox runat="server" ID="dep_lastname1" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="dep_lastname1"
                    ForeColor="#db1a32"
                    ErrorMessage="* Please enter a last name.">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    runat="server"
                    ControlToValidate="dep_lastname1"
                    ErrorMessage="Do not include symbols other than numerals, punctuation marks, or letters."
                    ForeColor="#db1a32"
                    ValidationExpression="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$">
                </asp:RegularExpressionValidator>
            </div>
            <div>
                <a href="javascript:void(0)" class="btn btn-danger remove"><span class="glyphicon glyphicon glyphicon-remove" aria-hidden="true"></span>Remove</a>
            </div>
        </div>
    </asp:Panel>


    <%--Scripts--%>

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Bootstrap js library -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            // who has more than 30 kids these days?
            var maxGroup = 30;

            //add more fields group
            $(".addMore").click(function () {
                if ($('body').find('.fieldGroup').length < maxGroup) {
                    var fieldHTML = '<div class="form-group fieldGroup">' + $(".fieldGroupCopy").html() + '</div>';
                    $('body').find('.fieldGroup:last').after(fieldHTML);
                } else {
                    alert('Maximum ' + maxGroup + ' groups are allowed.');
                }
            });

            //remove fields group
            $("body").on("click", ".remove", function () {
                $(this).parents(".fieldGroup").remove();
            });
        });
    </script>

    <%--End scripts--%>
</asp:Content>


