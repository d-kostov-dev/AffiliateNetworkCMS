using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace AffiliateNetwork.Web.Infrastructure.Filters
{
    public class SortAndPageAttribute : ActionFilterAttribute
    {
        private string sortName;
        private int currentPage;
        private const int pageSize = 1;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var parameters = filterContext.ActionParameters;

            if(parameters.ContainsKey("sort") && parameters.ContainsKey("page"))
            {
                sortName = parameters["sort"].ToString();
                currentPage = int.Parse(parameters["page"].ToString());
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as IQueryable;
            //var viewResult = filterContext.Result as ViewResultBase;

            if (viewResult != null)
            {
                viewResult = viewResult
                .OrderBy(sortName)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);
            }

 	         base.OnResultExecuted(filterContext);
        }
    }
}