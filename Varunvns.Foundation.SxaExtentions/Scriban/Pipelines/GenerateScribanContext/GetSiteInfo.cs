using Sitecore.XA.Foundation.Abstractions;
using Sitecore.XA.Foundation.Scriban.Pipelines.GenerateScribanContext;
using Sitecore.Data.Items;
using Scriban.Runtime;

namespace Varunvns.Foundation.SxaExtentions.Scriban.Pipelines.GenerateScribanContext
{
    public class SiteExtensions : IGenerateScribanContextProcessor
    {
        protected readonly IPageMode PageMode;
        private readonly IContext context;

        private delegate Sitecore.Web.SiteInfo SiteInfoDelegate(Item item);

        public SiteExtensions(IPageMode pageMode, IContext context)
        {
            PageMode = pageMode;
            this.context = context;

        }

        public void Process(GenerateScribanContextPipelineArgs args)
        {
            var siteInfo = new SiteInfoDelegate(GetSiteInfo);
            args.GlobalScriptObject.Import("sc_site_info", siteInfo);
        }
        public Sitecore.Web.SiteInfo GetSiteInfo(Item item)
        {

            if (item == null)
            {
                return null;
            }
            Sitecore.Web.SiteInfo targetSite = Sitecore.Links.LinkManager.ResolveTargetSite(item);

            return targetSite;
        }
    }
}
