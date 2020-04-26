<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInformationForm.aspx.cs" Inherits="MVC2StoredProcs.UserInformationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><h3>User Registration</h3></div>
        <div>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label><br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label><br />
            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label><br />
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label><br />
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnSave" runat="server" Text="Save" onClick="btnSave_Click"/>
    </form>
</body>
</html>
