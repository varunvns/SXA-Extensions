namespace Varunvns.Foundation.SxaExtentions.Scriban.Model
{
    public class SiteInfoModel
    {
        public string name { get; set; }
        public string rootPath { get; set; }
        public string hostTargetSite { get; set; }
        public string hostName { get; set; }
        public string startItem { get; set; }
        public bool isActive { get; set; }
        public string domain { get; set; }
        public string contentStartItem { get; set; }
        public SiteInfoModel(Sitecore.Web.SiteInfo item)
        {
            name = item.Name;
            hostName = item.HostName;
            hostTargetSite = item.TargetHostName;
            rootPath = item.RootPath;
            startItem = item.StartItem;
            isActive = item.IsActive;
            domain = item.Domain;
            contentStartItem = item.ContentStartItem;

        }
    }
}
