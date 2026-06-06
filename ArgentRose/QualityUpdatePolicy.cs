namespace ArgentRose;

public interface QualityUpdatePolicy
{
    Quality Update(Quality quality, int sellIn);
}