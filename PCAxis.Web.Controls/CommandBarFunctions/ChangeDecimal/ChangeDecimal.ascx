<%@ control  inherits="PCAxis.Web.Controls.ChangeDecimalCodebehind" %>
<%@ register assembly="PCAxis.Web.Controls" namespace="PCAxis.Web.Controls" tagprefix="pxc" %>

<div>
    <p><asp:Label runat="server" ID="TitleLabel" CssClass="commandbar_changedecimal_titletext" /></p>
        
    <asp:Panel runat="server" ID="SelectDecimalPanel" Visible="true">
        <p><asp:Label runat="server" ID="SelectNumberOfDecimalsLabel" CssClass="commandbar_changedecimal_selectvaluetitle" /></p>
            <p>
            <asp:Label runat="server" ID="NumberOfDecimalsLabel" CssClass="commandbar_changedecimal_selectvaluetext"/>
            <asp:TextBox runat="server" ID="NumberOfDecimalsTextBox"  CssClass="commandbar_changedecimal_selectvalue_textbox"/>
            <asp:Label runat="server" ID="RangeLabel" CssClass="commandbar_changedecimal_selectvaluetext"/>
            </p>
        <p class="commandbar_button_row">
            <asp:Button ID="ContinueButton" runat="server" CssClass="commandbar_continuebutton pxweb-btn primary-btn" />
            <asp:Button ID="CancelButton" runat="server" CssClass="commandbar_cancelbutton pxweb-btn primary-btn" />
        </p>
    </asp:Panel>
    <asp:RegularExpressionValidator ID="NumberOfDecimalsValidator" EnableClientScript="false"   runat="server" display="Dynamic" setfocusonerror="True"  ErrorMessage="0-6" ValidationExpression="^[0-6]$" ControlToValidate="NumberOfDecimalsTextBox" />
    <asp:RequiredFieldValidator ID="RequiredInputValidator" EnableClientScript="false"   runat="server" display="Dynamic" setfocusonerror="True"  ErrorMessage="Input required" ControlToValidate="NumberOfDecimalsTextBox" />

</div>


