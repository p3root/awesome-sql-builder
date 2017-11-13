using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace Awesome.Data.Sql.Builder.Test.Unit.OData
{
    public static class ODataQueryOptionsHelper
    {
        public static ODataQueryOptions<T> Build<T>(string odataQueryString)
            where T : class
        {
            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder(new HttpConfiguration(), true);
            modelBuilder.EntitySet<T>("Set");
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/?" + odataQueryString);
            var model = modelBuilder.GetEdmModel();
            return new ODataQueryOptions<T>(new ODataQueryContext(model, typeof(T), new ODataPath()), request);
        }
    }
}
