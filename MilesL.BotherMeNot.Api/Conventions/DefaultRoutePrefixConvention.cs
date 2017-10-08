using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesL.BotherMeNot.Api.Conventions
{
    public class DefaultRoutePrefixConvention : IApplicationModelConvention
    {
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
