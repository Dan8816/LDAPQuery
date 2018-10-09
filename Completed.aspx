<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Completed.aspx.cs" Inherits="Completed" %>
<%@ PreviousPageType VirtualPath="~/ShippingRequest.aspx" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Shipping Request Submitted</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
    <form class="form" id="form1" runat="server">
        <h3 style="color: Maroon">OAI Shipping Request</h3>
        <h5>The shipping request has been successfully submitted! Please print this page to send with your shipment.</h5>
        <hr>
            <asp:Label ID="lblCurrentDate" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblShipID" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblShipType" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblInitiatingDepartment" runat="server" Text=""></asp:Label><br /><br />
        <hr>
            <asp:Label ID="lblFromName" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblFromPhone" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblFromEmail" runat="server" Text=""></asp:Label><br /><br />
        <hr>
            <asp:Label ID="lblToName" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblToCountry" runat="server" Text=""></asp:Label><br />
     
            <asp:Label ID="lblToCompany" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblAddressOne" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblAddressTwo" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblToCity" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblToState" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblToPostalCode" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblToPhone" runat="server" Text=""></asp:Label><br /><br />
        <hr>
            <asp:GridView ID="gvItems" runat="server"></asp:GridView><br />
        <hr>
            <asp:Label ID="lblShipDate" runat="server" Text=""></asp:Label><br />

            <asp:Label ID="lblShipTime" runat="server" Text=""></asp:Label><br /><br />
        <hr>
            <asp:Label ID="lblComments" runat="server" Text=""></asp:Label><br /><br />

            <asp:Label ID="lblBillToThirdParty" runat="server" Text=""></asp:Label><br /><br />

            <asp:Label ID="lblSignatureRequired" runat="server" Text=""></asp:Label><br /><br />

            <asp:Label ID="Label1" runat="server" Text="Manager's Signature________________________________________________________________________________" Font-Bold="true"></asp:Label><br />

            <asp:Label ID="Label2" runat="server" Text="Note: Package will NOT ship without signature of immediate manager."></asp:Label><br /><br />

            <asp:hyperlink ID="Hyperlink1" runat="server" NavigateUrl="~/ShippingRequest.aspx">Return to Shipping Request page</asp:hyperlink>
        </form>
    </div>
</body>
</html>
