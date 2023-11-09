<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegTeacher.aspx.vb" Inherits="SemesterProject.RegTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssFiles/Registration.css" rel="stylesheet" />
    <link href="CssFiles/Navigation.css" rel="stylesheet" />
    <title></title>
</head>
<body>

	<nav>
            <ul>
                <li><a href="default.aspx">Home</a></li>
                <li><a href="About.aspx">About</a></li>
                <li><a href="Contact.aspx">Contact</a></li>
            </ul>
        </nav>

     <div class="containerr">
		<h1>Register Teacher</h1>
		<form id="form1" class="C_form" runat="server">

			<label class="C_label" for="customer_id" runat="server">Username:</label>
			<asp:TextBox ID="username" Class="textbox" runat="server" required="true"></asp:TextBox>
			
			<label class="C_label" for="password" runat="server">Password:</label>
			<asp:TextBox ID="password" Class="textbox" runat="server" TextMode="Password"></asp:TextBox>
	
			<label class="C_label" for="ConfirmPassword" runat="server">Type Password Again:</label>
			<asp:TextBox ID="ConfirmPassord" Class="textbox" runat="server" TextMode="Password"></asp:TextBox>
	
			<asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
			 <asp:Label runat="server" ID="Results" Text="Label"><h1></h1></asp:Label>

		</form>
	</div>
</body>
</html>
