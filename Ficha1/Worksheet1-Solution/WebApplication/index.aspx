<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 259px">
    <form id="form1" runat="server">
        <div>UC Name</div>
        <p>
            <asp:TextBox ID="TextBoxUCName" runat="server" style="margin-top: 12px"></asp:TextBox>
        </p>
        <p>
            School Year</p>
        <p>
            <asp:TextBox ID="TextBoxSchoolYear" runat="server" Height="22px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="buttonGetUCName" runat="server" Text="Get UC Name" Width="142px" />
        </p>
        <p>
            <asp:Button ID="buttonGetSchoolYear" runat="server" Text="Get School Year" Width="142px" />
        </p>
        <p style="height: 0px">
            &nbsp;</p>
    </form>
</body>
</html>
