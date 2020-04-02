<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchMovie.aspx.cs" Inherits="PratikshaStudio.WebApp.SearchMovie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        
        <div class="col-5">
            <br /> <br />
    <table>
        <tr>
            <td colspan="2"><h4>Search Movie</h4></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblMovieName" runat="server" Text="Movie Name"></asp:Label> </td>
            <td><asp:TextBox ID="txtTitle" runat="server" cssClass="form-control" ClientIDMode="Static"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblGenre" runat="server" Text="Genre"></asp:Label></td>
            <td><asp:DropDownList ID="ddlGenre" cssClass="form-control"  runat="server" AppendDataBoundItems="True" ClientIDMode="Static">
                <asp:ListItem Value=" ">--SELECT GENRE--</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblReleaseDate" runat="server" Text="Release Date"></asp:Label></td>
            <td><asp:TextBox ID="txtDateOfRelease"  cssClass="form-control"  runat="server" ClientIDMode="Static"></asp:TextBox></td>

        </tr>
        <tr>
            <td><asp:Label ID="lblRating" runat="server" Text="Rating"></asp:Label></td>
            <td><asp:DropDownList ID="ddlRating" runat="server" cssClass="form-control"  AppendDataBoundItems="True" ClientIDMode="Static">
                <asp:ListItem Value=" ">--SELECT RATING--</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnSearch" CssClass="btn btn-success" runat="server" Text="Search" OnClick="btnSearch_Click" ClientIDMode="Static" /></td>
            <td><asp:Button ID="btnCancel" CssClass="btn btn-dark" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>

    </table>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
        <div class="col-7">
            <br /><br />
            <asp:GridView ID="gvwMovie" runat="server" CssClass="table table-hover table-bordered" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="MovieId" OnPageIndexChanging="gvwMovie_PageIndexChanging" OnSelectedIndexChanging="gvwMovie_SelectedIndexChanging" PageSize="2">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="GenreName" HeaderText="Genre" />
                    <asp:BoundField DataField="DateOfRelease" DataFormatString="{0:dd/MMM/yyyy} " HeaderText="Date Of Release" />
                    <asp:BoundField DataField="RatingName" HeaderText="Rating" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
     <script>

        $(document).ready(function () {
            $("#txtDateOfRelease").datepicker();

            $("#btnSearch").click(function (e) {
                var title = $("#txtTitle").val().trim();
                var genre = $("#ddlGenre").val().trim();
                var rating= $("#ddlRating").val().trim();
                var release_date = $("#txtDateOfRelease").val().trim();
                //console.log(title, genre, rating, release_date);
                if (!title && !genre && !rating && !release_date) {
                    alert("Enter atleast one value");
                    e.preventDefault();
                }
            })
        })

    </script>
</asp:Content>
