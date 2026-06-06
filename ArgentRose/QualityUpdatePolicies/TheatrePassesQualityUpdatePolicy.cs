namespace ArgentRose.QualityUpdatePolicies;

public class TheatrePassesQualityUpdatePolicy : QualityUpdatePolicy
{
    public Quality Update(Quality quality, int sellIn)
    {
        if (sellIn < 0)
        {
            return quality.DropToZero();
        }

        if (sellIn <= 5)
        {
            return quality.Increase(3);
        }

        return quality.Increase(1);
    }
}