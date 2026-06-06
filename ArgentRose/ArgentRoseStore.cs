using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgentRose;

public class ArgentRoseStore
{
    private readonly List<Product> _inventory;

    public ArgentRoseStore(List<Product> inventory)
    {
        _inventory = new List<Product>(inventory);
    }

    public void Update()
    {
        foreach (var product in _inventory)
        {
            product.Update();
        }
    }

    public override int GetHashCode()
    {
        return _inventory.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        var that = (ArgentRoseStore)obj;
        return _inventory.SequenceEqual(that._inventory);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("ArgentRoseStore[");
        sb.Append("inventory=");
        sb.Append(string.Join(", \n", _inventory));
        sb.Append("]");
        return sb.ToString();
    }
}