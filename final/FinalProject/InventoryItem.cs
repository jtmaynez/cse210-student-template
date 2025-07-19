// this is an association with ABC it has a list of inventory items
public class InventoryItem
{
    public string _name { get; set; }
    public double _annualUsageValue { get; set; }

    public InventoryItem(string name, double annualUsageValue)
    {
        _name = name;
        _annualUsageValue = annualUsageValue;
    }
}
