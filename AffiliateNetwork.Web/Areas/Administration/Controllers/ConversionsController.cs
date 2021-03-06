﻿namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNetwork.Web.Areas.Administration.Models.ViewModels;
    using AffiliateNewtork.Common;

    using AutoMapper.QueryableExtensions;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class ConversionsController : AdminBaseController
    {
        public ConversionsController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            var conversions = 
                this.Data.Conversions.All()
                .Project()
                .To<ConversionViewModels>();

            return this.View(conversions);
        }

        public ActionResult Delete(int id)
        {
            var item = this.Data.Conversions.Find(id);
            this.Data.Conversions.Delete(item);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
