namespace ArgentRose.QualityUpdatePolicies;

public class RegularProductQualityUpdatePolicy : QualityUpdatePolicy
{
    public Quality Update(Quality quality, int sellIn)
    {
        const int changeBeforeExpiry = 2;
        var decrease = sellIn <= -1 ? changeBeforeExpiry * 2 : changeBeforeExpiry;
        return quality.Decrease(decrease);
    }
}