﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PratikshaStudio.BusinessEntities
{
    public class MovieResponseBE
    {
        public string Title { get; set; }
        public string GenreName { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int MovieId { get; set; }
        public string RatingName { get; set; }

        public string Description { get; set; }
        public int length { get; set; }

    }
}
