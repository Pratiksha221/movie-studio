<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Add a movie.aspx.cs" Inherits="PratikshaStudio.WebApp.Add_a_movie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-5">
            <br />
            <br />
            <table>
                <tr>
                    <td colspan="2">
                        <h4>Add Movie Details</h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMovieName" runat="server" Text="Enter Movie Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMovieDescription" runat="server" Text="Enter Description"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGenre" runat="server" Text="Genre"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlGenre" CssClass="form-control" runat="server" AppendDataBoundItems="True" ClientIDMode="Static">
                            <asp:ListItem Value=" ">--SELECT GENRE--</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblReleaseDate" runat="server" Text="Release Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDateOfRelease" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRating" runat="server" Text="Rating"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control" AppendDataBoundItems="True" ClientIDMode="Static">
                            <asp:ListItem Value=" ">--SELECT RATING--</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLength" runat="server" Text="Enter length (in mins)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtlength" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Enter movie Cast" ClientIDMode="Static"  OnClientClick=" return addDiv(event)" OnClick="btnAdd_Click" /></td>
                    <td>
                        <asp:Button ID="btnCancel" CssClass="btn btn-dark" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-1"></div>
        <div class="col-5" id="castDiv" <%--style="display: none;--%>">
            <br />
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Actor"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlActor" runat="server" CssClass="form-control" AppendDataBoundItems="True" ClientIDMode="Static">
                            <asp:ListItem Value=" ">--SELECT ACTOR--</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRole" runat="server" Text="Enter Role"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRole" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnEnter" CssClass="btn btn-outline-success" runat="server" Text="Enter" ClientIDMode="Static" OnClick="btnEnter_Click" /></td>
                    <td>
                        <asp:Button ID="btnDone" CssClass="btn btn btn-outline-dark" runat="server" Text="Done" OnClick="btnDone_Click" /></td>
                </tr>
            </table>
        </div>
    </div>

    <script>

        $(document).ready(function () {

            $("#txtDateOfRelease").datepicker({ dateFormat: 'dd-mm-yy' });
        
        });
        function addDiv(event) {
            document.getElementById('castDiv').style.display = "block";
            event.preventDefault();
            return false;
        }

    </script>
</asp:Content>
