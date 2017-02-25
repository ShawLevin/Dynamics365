using Microsoft.Xrm.Sdk;
using System;
using Microsoft.Xrm.Sdk.Query;

namespace CRM.Accounts.Plugin
{
    public class QueryCounts : IPlugin
    {
        #region Secure/Unsecure Configuration Setup
        private string _secureConfig = null;
        private string _unsecureConfig = null;

        public QueryCounts(string unsecureConfig, string secureConfig)
        {
            _secureConfig = secureConfig;
            _unsecureConfig = unsecureConfig;
        }
        #endregion
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracer = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            try
            {
                Entity entity = (Entity)context.InputParameters["Target"];

                QueryByAttribute querybyexpression = new QueryByAttribute("contact");
                querybyexpression.ColumnSet = new ColumnSet("name", "address1_city");
  
                querybyexpression.Attributes.AddRange("address1_city");

                querybyexpression.Values.AddRange("Philadelphia");

                EntityCollection retrieved = service.RetrieveMultiple(querybyexpression);

                tracer.Trace(String.Concat("Entity Count: ", retrieved.Entities.Count));  
                
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.Message);
            }
        }
    }
}
