using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PratikshaStudio.BusinessEntities
{
    public class MovieRequestBE
    {
        public string Title { get; set; }
        public string GenreName { get; set; }
        public int GenreId { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public int RatingId { get; set; }
        public string RatingName { get; set; }
        public string Description { get; set; }
        public int? length { get; set; }
    }
}
