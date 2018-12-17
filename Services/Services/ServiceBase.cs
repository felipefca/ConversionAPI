namespace Services.Services
{
    public class ServiceBase
    {
        protected string UrlBase => "http://apilayer.net/api";
        protected string GetCoinsResource => "/list";
        protected string GetComparativeCurrencyResource => "/live";
        protected string KeyDescription => "access_key";
        protected string KeyValue => "13dbc02cf35aaedfdc08cf3c964b7a6b";
    }
}