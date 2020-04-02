using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PratikshaStudio.BusinessAccess;
using PratikshaStudio.BusinessEntities;

namespace PratikshaStudio.WebApp
{
    public partial class SearchMovie : System.Web.UI.Page
    {
        private CommonBusinessAccess _commonBA= new CommonBusinessAccess();
        private CommonBE commonBE= new CommonBE();
        private MovieRequestBE _movieRequestBE;
        private MovieBusinessAccess _movieBA = new MovieBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGenre();
                BindRating();
            }
            
        }
        public void BindGenre()
        {
            _commonBA = new CommonBusinessAccess();
            try
            {
                ddlGenre.DataSource = _commonBA.GetAllGenreId();
                ddlGenre.DataValueField = "GenreId";
                ddlGenre.DataTextField = "GenreName";
                ddlGenre.DataBind();

            }
            catch (Exception e)
            {
                lblError.Text = e.Message+e.StackTrace;
            }
        }
        public void BindRating()
        {
            _commonBA = new CommonBusinessAccess();
            try
            {
                ddlRating.DataSource = _commonBA.GetAllRatingId();
                ddlRating.DataValueField = "RatingId";
                ddlRating.DataTextField = "RatingName";
                ddlRating.DataBind();

            }
            catch (Exception e)
            {
                lblError.Text = e.Message + e.StackTrace;
            }
        }
        public void BindGrid()
        {
            _movieRequestBE = new MovieRequestBE();
           
                try
            {
                if (txtTitle.Text.Length != 0)
                {
                    _movieRequestBE.Title = Convert.ToString(txtTitle.Text.Trim());
                }

                if (txtDateOfRelease.Text.Length != 0)
                {
                    _movieRequestBE.DateOfRelease = Convert.ToDateTime(txtDateOfRelease.Text.Trim());
                }

                if (ddlGenre.SelectedIndex > 0)
                {
                    _movieRequestBE.GenreId = Convert.ToInt32(ddlGenre.SelectedValue);
                }
                if (ddlRating.SelectedIndex > 0)
                {
                    _movieRequestBE.RatingId = Convert.ToInt32(ddlRating.SelectedValue);
                }

                gvwMovie.DataSource = _movieBA.GetAllGenreId(_movieRequestBE);

                gvwMovie.DataBind();
            }
            catch (Exception e)
            {
                lblError.Text = e.Message + e.StackTrace;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvwMovie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwMovie.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvwMovie_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int MovieId = Convert.ToInt32(gvwMovie.DataKeys[e.NewSelectedIndex].Value);

            Session["MovieId"] = MovieId;
            Server.Transfer("DisplayMovieDetails.aspx");
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
    
}