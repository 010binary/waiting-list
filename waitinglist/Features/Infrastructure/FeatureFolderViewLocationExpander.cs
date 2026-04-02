using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace waitinglist.Features.Infrastructure;

public sealed class FeatureFolderViewLocationExpander : IViewLocationExpander
{
    private const string FeatureKey = "feature";

    public void PopulateValues(ViewLocationExpanderContext context)
    {
        if (context.ActionContext.ActionDescriptor is not ControllerActionDescriptor controllerActionDescriptor)
        {
            return;
        }

        var namespaceName = controllerActionDescriptor.ControllerTypeInfo.Namespace;
        var marker = ".Features.";
        var markerIndex = namespaceName?.LastIndexOf(marker, StringComparison.Ordinal);

        if (markerIndex is null or < 0)
        {
            return;
        }

        var featureName = namespaceName![(markerIndex.Value + marker.Length)..];
        if (!string.IsNullOrWhiteSpace(featureName))
        {
            context.Values[FeatureKey] = featureName;
        }
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        if (!context.Values.TryGetValue(FeatureKey, out var featureName))
        {
            return viewLocations;
        }

        return new[]
            {
                $"/Features/{featureName}/Views/{{1}}/{{0}}.cshtml",
                $"/Features/{featureName}/Views/Shared/{{0}}.cshtml",
                "/Features/Shared/{0}.cshtml",
                "/Views/Shared/{0}.cshtml"
            }
            .Concat(viewLocations);
    }
}

