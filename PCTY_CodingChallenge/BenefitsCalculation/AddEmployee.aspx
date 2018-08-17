<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="BenefitsCalculation.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron custom-jumbo">
        <h1>Add Employee</h1>
    </div>

    <asp:Panel runat="server" ID="Panel_AddSingleEmployee">
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
                ID="Button_AddDependent"
                CssClass="btn btn-default"
                OnClick="button_addNewDependent_Click"
                Text="Add Dependents" />
            <asp:Button
                runat="server"
                ID="Button_SubmitEmployeeWithNoDependents"
                CssClass="btn"
                OnClick="Button_SubmitEmployeeWithNoDependents_Click"
                Text="Submit" />
        </div>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />


    <asp:Panel runat="server" ID="Panel_AddDependents" Visible="false">

        <%--Test--%>

        <div class="form-group fieldGroup">
            <div class="input-group">
                <div class="">
                    <input type="text" name="name[]" class="form-control" placeholder="Enter first name" />
                </div>
                <br />
                <br />
                <div class="">
                    <input type="text" name="name[]" class="form-control" placeholder="Enter last name" />
                </div>
                <div class="input-group-addon">
                    <a
                        href="javascript:void(0)"
                        class="btn btn-success addMore">
                        <span
                            class="glyphicon glyphicon glyphicon-plus"
                            aria-hidden="true"></span>Add
                    </a>
                </div>
            </div>
        </div>

        <input type="submit" name="submit" class="btn btn-primary" value="SUBMIT" />

        <div class="form-group fieldGroupCopy" style="display: none;">
            <div class="input-group">
                <input type="text" name="name[]" class="form-control" placeholder="Enter first name" />
                <br/>
                <br/>
                <input type="text" name="name[]" class="form-control" placeholder="Enter last name" />
                <div class="input-group-addon">
                    <a href="javascript:void(0)" class="btn btn-danger remove"><span class="glyphicon glyphicon glyphicon-remove" aria-hidden="true"></span>Remove</a>
                </div>
            </div>
        </div>

        <%--End test--%>

        <div class="row">
            <asp:Panel runat="server" ID="panel_newDependentFields">
            </asp:Panel>
        </div>
        <div id="submissionButtons">
            <asp:Button runat="server"
                ID="button_addNewDependent"
                CssClass=" btn"
                OnClick="button_addNewDependent_Click"
                Text="Add dependent"></asp:Button>
            <asp:Button runat="server"
                ID="Button_CancelAddingDependents"
                CssClass=" btn"
                OnClick="Button_SubmitEmployeeWithNoDependents_Click"
                Text="Submit without dependents"></asp:Button>
            <asp:Button
                runat="server"
                CssClass="btn bottom "
                Text="Submit"
                ID="Button_SubmitWithDependents"
                OnClick="Button_SubmitWithDependents_Click" />
        </div>
        <br />
    </asp:Panel>


    <div class="row col-lg-12">
        <asp:Panel runat="server" ID="Panel_DependentsFields" Visible="false">
        </asp:Panel>
    </div>

    <div class="row">
        <asp:Panel runat="server" ID="Panel_SubmitWithDependents" Visible="false">
            <div class="row col-lg-12">
            </div>
        </asp:Panel>
    </div>

    <%--Scripts--%>

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Bootstrap js library -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            //group add limit
            var maxGroup = 10;

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


