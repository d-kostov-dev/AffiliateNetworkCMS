namespace AffiliateNetwork.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Web.Areas.Administration.Controllers.Base;
    using AffiliateNewtork.Common;
    
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class SiteSettingsController : AdminBaseController
    {
        public SiteSettingsController(IDataProvider provider)
            : base(provider)
        {
        }

        public ActionResult Index()
        {
            this.ManagePageSizing();

            return this.View(this.Data.SiteSettings.All().OrderBy(x => x.Id).ToList());
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                this.Data.SiteSettings.Add(siteSetting);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(siteSetting);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SiteSetting siteSetting = this.Data.SiteSettings.Find(id);

            if (siteSetting == null)
            {
                return this.HttpNotFound();
            }

            return this.View(siteSetting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteSetting siteSetting)
        {
            if (ModelState.IsValid)
            {
                var currentSetting = this.Data.SiteSettings.Find(siteSetting.Id);

                currentSetting.Value = siteSetting.Value;
                currentSetting.Description = siteSetting.Description;

                this.Data.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(siteSetting);
        }
    }
}
