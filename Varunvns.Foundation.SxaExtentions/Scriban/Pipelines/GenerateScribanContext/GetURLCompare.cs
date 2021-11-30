using Scriban.Runtime;
using Sitecore.XA.Foundation.Abstractions;
using Sitecore.XA.Foundation.Scriban.Pipelines.GenerateScribanContext;
using Sitecore.Data.Items;

namespace Varunvns.Foundation.SxaExtentions.Scriban.Pipelines.GenerateScribanContext
{
    public class GetURLCompare : IGenerateScribanContextProcessor
    {
        private readonly IContext context;
        protected readonly IPageMode PageMode;
        private delegate bool Delegate(Item item, string URL);

        public GetURLCompare(IPageMode pageMode, IContext context)
        {
            PageMode = pageMode;
            this.context = context;
        }

        public void Process(GenerateScribanContextPipelineArgs args)
        {
            args.GlobalScriptObject.Import("sc_url_compare", new Delegate(GetURLCompareValue));
        }

        public bool GetURLCompareValue(Item item, string URL)
        {


            if (item != null && URL != null)
            {
                var itmURL = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item);
                var lnkURL = URL;

                if (itmURL.Contains(lnkURL) == true)
                {
                    return true;
                }
                return false;
            }

            return false;



        }
    }
}
