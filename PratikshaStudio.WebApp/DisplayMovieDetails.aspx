<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DisplayMovieDetails.aspx.cs" Inherits="PratikshaStudio.WebApp.DisplayMovieDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMovieId" runat="server" Text=" "></asp:Label>
    <br />
    <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
    <br />
    <asp:Label ID="lblDesription" runat="server" Text="Description"></asp:Label>
    <br />
    <asp:Label ID="lblDateOfRelease" runat="server" Text="Date Of Release"></asp:Label>
    <br />
    <asp:Label ID="lblGenre" runat="server" Text="Genre"></asp:Label>
    <br />
    <asp:Label ID="lblRating" runat="server" Text="Rating"></asp:Label>
    <br />
    <asp:Label ID="lblLength" runat="server" Text="Length"></asp:Label>
    <br /><br />

    <asp:GridView ID="gvwMovieDetails" runat="server" CssClass="table table-hover table-bordered" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

</asp:Content>
