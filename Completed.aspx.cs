using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Completed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var shippingDate = PreviousPage.FindControl("txtTodaysDate") as TextBox;
        if (shippingDate != null)
        {
            lblCurrentDate.Text = "<b>Date:</b> " + shippingDate.Text;
        }
        var shipID = PreviousPage.FindControl("txtShipID") as TextBox;
        if (shipID != null)
        {
            lblShipID.Text = "<b>Ship #:</b> " + shipID.Text;
        }
        var shipType = PreviousPage.FindControl("rblBusinessPrivate") as RadioButtonList;
        if (shipType != null)
        {
            if (shipType.Text == "B")
            {
                lblShipType.Text = "<b>Ship Type:</b> Business";
            }
            else
            {
                lblShipType.Text = "<b>Ship Type:</b> Personal";
            }
        }
        lblInitiatingDepartment.Text = "<b>Initiating Department:</b> " + GetInitiatingDepartment();

        var fromName = PreviousPage.FindControl("txtFromName") as TextBox;
        if (fromName != null)
        {
            lblFromName.Text = "<b>FROM:</b> " + fromName.Text;
        }
        var fromPhone = PreviousPage.FindControl("txtFromPhone") as TextBox;
        if (fromPhone != null)
        {
           lblFromPhone.Text = "<b>Phone:</b> " + fromPhone.Text;
        }
        var fromEmail = PreviousPage.FindControl("txtEmailAddress") as TextBox;
        if (fromEmail != null)
        {
           lblFromEmail.Text = "<b>Email:</b> " + fromEmail.Text;
        }
        var toName = PreviousPage.FindControl("txtToName") as TextBox;
        if (toName != null)
        {
            lblToName.Text = "<b>TO:</b> " + toName.Text;
        }
        var toCountry = PreviousPage.FindControl("ddlCountries") as DropDownList;
        if (toCountry != null)
        {
           lblToCountry.Text = "<b>Country:</b> " + toCountry.Text;
        }
        var toCompany = PreviousPage.FindControl("txtToCompany") as TextBox;
        if (toCompany != null)
        {
           lblToCompany.Text = "<b>Company:</b> " + toCompany.Text;
        }
        var toAddressOne = PreviousPage.FindControl("txtToAddressOne") as TextBox;
        if (toAddressOne != null)
        {
           lblAddressOne.Text = "<b>Address One:</b> " + toAddressOne.Text;
        }
        var toAddressTwo = PreviousPage.FindControl("txtToAddressTwo") as TextBox;
        if (toAddressTwo != null)
        {
            lblAddressTwo.Text = "<b>Address Two:</b> " + toAddressTwo.Text;
        }
        var city = PreviousPage.FindControl("txtCity") as TextBox;
        if (city != null)
        {
          lblToCity.Text = "<b>City:</b> " + city.Text;
        }
        //CCalk 9/18/2012 If not US then do not display state
        var state = PreviousPage.FindControl("ddlStates") as DropDownList;

        if (toCountry.Text != "US") //The country is NOT US so do not show a state
        {
            lblToState.Text = "<b>State:</b> ";
        }
        else
        {
            if (state != null)
            {
                lblToState.Text = "<b>State:</b> " + state.Text;
            }
        }
        var postalCode = PreviousPage.FindControl("txtPostalCode") as TextBox;
        if (postalCode != null)
        {
           lblToPostalCode.Text = "<b>Postal Code:</b> " + postalCode.Text;
        }
        var phone = PreviousPage.FindControl("txtToPhone") as TextBox;
        if (phone != null)
        {
            lblToPhone.Text = "<b>Phone:</b> " + phone.Text;
        }
        //Shipping items list
        GetShippingItems(Convert.ToInt16(shipID.Text));

        var shipDate = PreviousPage.FindControl("calShipByDate") as Calendar;
        if (shipDate != null)
        {
            lblShipDate.Text = "<b>Date:</b> " + shipDate.SelectedDate.ToShortDateString();
        }
        var shipTime = PreviousPage.FindControl("ddlShipByTime") as DropDownList;
        if (shipTime != null)
        {
           lblShipTime.Text = "<b>Time:</b> " + shipTime.Text;
        }
        var comments = PreviousPage.FindControl("txtComments") as TextBox;
        if (comments != null)
        {
           lblComments.Text = "<b>Comments:</b> " + comments.Text;
        }
        var billToThirdParty = PreviousPage.FindControl("txtBillTo3rdParty") as TextBox;
        if (billToThirdParty != null)
        {
           lblBillToThirdParty.Text = "<b>Bill to 3rd Party:</b> " + billToThirdParty.Text;
        }
        var signatureRequired = PreviousPage.FindControl("cbSignatureRequired") as CheckBox;
        if (signatureRequired != null)
        {
           lblSignatureRequired.Text = "<b>Signature Required:</b> " + signatureRequired.Checked;
        }
    }
    private void GetShippingItems(int id)
    {
        //SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        //const string sql = "SELECT * FROM Test_Table";

        //SqlCommand myCommand = new SqlCommand(sql, myConnection);

        //DataSet myDataSet = new DataSet();

        //SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
        //myAdapter.Fill(myDataSet);

        ////Bind the DataSet to the GridView
        //gvItems.DataSource = myDataSet;
        //gvItems.DataBind();

        ////Close the connection
        //myConnection.Close();

        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OAI_ShippingRequest"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = String.Format(@"SELECT description, quantity FROM Shipping_Items WHERE ID = {0}", id);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = myConnection;

        DataSet myDataSet = new DataSet();

        SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
        myAdapter.Fill(myDataSet);

        //Bind the DataSet to the GridView
        gvItems.DataSource = myDataSet;
        gvItems.DataBind();

        //Close the connection
        myConnection.Close();
    }
    string GetInitiatingDepartment()
    {
        string initiatingDepartment = "";

        var initiatingDepartmentPrimary = PreviousPage.FindControl("ddlInitiatingDepartment") as DropDownList;
        var initiatingDepartmentSub = PreviousPage.FindControl("ddlSubDepartments") as DropDownList;
        var initiatingDepartmentOther = PreviousPage.FindControl("txtOtherInitiatingDepartment") as TextBox;

        string strInitiatingDepartmentPrimary = GetInitiatingDepartmentPrimary(Convert.ToInt16(initiatingDepartmentPrimary.Text));

        if (strInitiatingDepartmentPrimary == "Administration" || strInitiatingDepartmentPrimary == "MX" || strInitiatingDepartmentPrimary == "Operations")
            initiatingDepartment = GetInitiatingDepartmentSub(Convert.ToInt16(initiatingDepartmentSub.Text));
        else if (initiatingDepartmentPrimary.Text == "Other")
            initiatingDepartment = initiatingDepartmentOther.Text;
        else
            initiatingDepartment = strInitiatingDepartmentPrimary;

        return initiatingDepartment;
    }
    private string GetInitiatingDepartmentSub(int sd)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OAI_ShippingRequest"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        Object returnValue;

        cmd.CommandText = String.Format(@"SELECT Department_Name FROM Shipping_Department WHERE Department_ID = {0}", sd);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = myConnection;

        myConnection.Open();

        returnValue = cmd.ExecuteScalar();

        myConnection.Close();

        return returnValue.ToString();
    }
    private string GetInitiatingDepartmentPrimary(int pd)
    {
        //CCALK Pull initiating department from DB

        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["OAI_ShippingRequest"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        Object returnValue;

        cmd.CommandText = String.Format(@"SELECT Department_Name FROM Shipping_Department WHERE Department_ID = {0}", pd);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = myConnection;

        myConnection.Open();

        returnValue = cmd.ExecuteScalar();

        myConnection.Close();

        return returnValue.ToString();
    }
}