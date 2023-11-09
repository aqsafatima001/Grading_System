<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Contact.aspx.vb" Inherits="SemesterProject.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssFiles/contact.css" rel="stylesheet" />
    <link href="CssFiles/Navigation.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

		<nav>
            <ul>
                <li><a href="default.aspx">Home</a></li>
                <li><a href="About.aspx">About</a></li>
                <li><a href="Contact.aspx">Contact</a></li>
            </ul>
        </nav>

        <h1>Contact Us</h1>
	<div class="container">
		<div class="contact-info">
			<span>Phone:  +92 (51) 1111 PIEAS</span>
			<span>Email: controller@pieas.edu.pk</span>
			<span>Email: registrar@pieas.edu.pk</span>
			<span>Address: PIEAS, Lehtrar Road, Nilore, Islamabad</span>
		</div>
		<div class="map">
			<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d60202.773982585!2d-74.00594157803071!3d40.71277530350102!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89c24fa5d33f083b%3A0xf60010f1c7e4ef4d!2sNew%20York%2C%20NY%2C%20USA!5e0!3m2!1sen!2suk!4v1620662963221!5m2!1sen!2suk" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
		</div>
	</div>
    </form>
</body>
</html>
