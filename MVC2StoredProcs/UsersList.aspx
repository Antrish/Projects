<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="MVC2StoredProcs.UsersList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <h2>List of Users:</h2>
            <asp:GridView id="grdUserList" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>

