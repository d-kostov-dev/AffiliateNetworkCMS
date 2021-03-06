﻿namespace AffiliateNetwork.Web.Areas.Administration.Models.InputModels
{
    public class GridOptionsInputModel
    {
        public GridOptionsInputModel()
        {
            this.Sorting = "Id";
            this.PerPage = 5;
            this.Page = 1;
        }

        public string Sorting { get; set; }

        public int PerPage { get; set; }

        public int Page { get; set; }

        public string SearchFilter { get; set; }

        public string CurrentFilter { get; set; }
    }
}