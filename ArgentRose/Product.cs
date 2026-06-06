using System;
using System.Text;

namespace ArgentRose;

public class Product
{
    private readonly string _description;
    private readonly QualityUpdatePolicy _qualityUpdatePolicy;
    private Quality _quality;
    private int _sellIn;

    public Product(string description, int sellIn, int quality)
    {
        _description = description;
        _sellIn = sellIn;
        _quality = new Quality(quality);
        _qualityUpdatePolicy = QualityUpdatePolicyFactory.CreateQualityUpdatePolicy(description);
    }

    public void Update()
    {
        DecreaseSellIn();
        UpdateQuality();
    }

    private void UpdateQuality()
    {
        _quality = _qualityUpdatePolicy.Update(_quality, _sellIn);
    }

    private void DecreaseSellIn()
    {
        _sellIn -= 1;
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Product)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_description, _quality, _sellIn);
    }

    protected bool Equals(Product other)
    {
        return _description == other._description && Equals(_quality, other._quality) && _sellIn == other._sellIn;
    }

    public override string ToString()
    {
        return new StringBuilder()
            .Append("Product[")
            .Append("description='").Append(_description).Append("', ")
            .Append("quality=").Append(_quality).Append(", ")
            .Append("sellIn=").Append(_sellIn)
            .Append("]")
            .ToString();
    }
}