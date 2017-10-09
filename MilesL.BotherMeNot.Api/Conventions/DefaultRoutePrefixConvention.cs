using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MilesL.BotherMeNot.Api.Conventions
{
    /// <summary>
    /// Covention to allow for access to the Api without a valid version in the url
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention" />
    public class DefaultRoutePrefixConvention : IApplicationModelConvention
    {
        /// <summary>
        /// Applies convention ensuring version segment is required in the url
        /// </summary>
        /// <param name="application">The <see cref="T:Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel" />.</param>
        public void Apply(ApplicationModel application)
        {
            foreach (var applicationController in application.Controllers)
            {
                applicationController.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = "api/[controller]"
                    }
                });
            }
        }
    }
}
