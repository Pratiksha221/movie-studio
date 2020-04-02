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
    public partial class DisplayMovieDetails : System.Web.UI.Page
    {
        private MovieResponseBE _movieResponseBE;
        private MovieBusinessAccess _movieBA;
        //private List<MovieCastBE> _movieCastBE;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Session["MovieId"] != null)
                {
                    //lblMovieId.Text=Session["MovieId"].ToString();
                    BindData();

                }
               
            }
           
        }
        private void BindData()
        {
            try
            {
                int MovieId = Convert.ToInt32(Session["MovieId"]);
                _movieResponseBE = new MovieResponseBE();

                _movieBA = new MovieBusinessAccess();
                _movieResponseBE = _movieBA.GetMovieById(MovieId);
                lblTitle.Text = "Title  :  " + _movieResponseBE.Title;
                lblGenre.Text = "Genre  :  " + _movieResponseBE.GenreName;
                lblDateOfRelease.Text = "Date Of Release  :  " + Convert.ToString(_movieResponseBE.DateOfRelease);
                lblRating.Text = "Rating  :  " + _movieResponseBE.RatingName;
                lblDesription.Text = "Description  :  " + _movieResponseBE.Description;
                lblLength.Text = "Duration (in mins)  :  " + _movieResponseBE.length;

                gvwMovieDetails.DataSource = _movieBA.GetCastDetails(MovieId);
                gvwMovieDetails.DataBind();

            }
            catch(Exception)
            {
                lblError.Text = "Error Retrieving movie Details";
            }
            


        }
    }
}