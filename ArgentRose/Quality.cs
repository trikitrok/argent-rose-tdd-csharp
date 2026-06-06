using System;

namespace ArgentRose;

using System;

public class Quality
{
    private readonly int _quality;
    private const int MinQuality = 0;
    private const int MaxQuality = 50;
    
    public Quality(int quality)
    {
        _quality = quality;
    }

    public Quality Increase(int delta)
    {
        return CreateQuality(_quality + delta);
    }

    public Quality Decrease(int delta)
    {
        return CreateQuality(_quality - delta);
    }

    public Quality DropToZero()
    {
        return CreateQuality(MinQuality);
    }

    private static Quality CreateQuality(int newQuality)
    {
        return new Quality(Math.Clamp(newQuality, MinQuality, MaxQuality));
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Quality)obj);
    }

    protected bool Equals(Quality other)
    {
        return _quality == other._quality;
    }

    public override int GetHashCode()
    {
        return _quality;
    }

    public override string ToString()
    {
        return $"Quality[quality={_quality}]";
    }
}