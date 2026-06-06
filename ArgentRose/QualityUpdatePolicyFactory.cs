using ArgentRose.QualityUpdatePolicies;

namespace ArgentRose;

using System;

public static class QualityUpdatePolicyFactory
{
    public static QualityUpdatePolicy CreateQualityUpdatePolicy(string description)
    {
        if (description.Equals("Theatre Passes", StringComparison.OrdinalIgnoreCase))
        {
            return new TheatrePassesQualityUpdatePolicy();
        }
        return new RegularProductQualityUpdatePolicy();
    }
}