using System.Collections.Generic;

public class ABCClassifier
{
    // Represents an item with a name and annual usage value (e.g., cost * demand)
    public class InventoryItem
    {
        public string Name { get; set; }
        public double AnnualUsageValue { get; set; }

        public InventoryItem(string name, double annualUsageValue)
        {
            Name = name;
            AnnualUsageValue = annualUsageValue;
        }
    }

    private List<InventoryItem> items;

    // Constructor
    public ABCClassifier()
    {
        items = new List<InventoryItem>();
    }

    // Add inventory item
    public void AddItem(string name, double annualUsageValue)
    {
        // stub
    }

    // Perform classification into A/B/C groups
    public void ClassifyItems()
    {
        // stub
    }

    // Optionally get items by category
    public List<InventoryItem> GetCategoryAItems()
    {
        return new List<InventoryItem>(); // placeholder
    }

    public List<InventoryItem> GetCategoryBItems()
    {
        return new List<InventoryItem>(); // placeholder
    }

    public List<InventoryItem> GetCategoryCItems()
    {
        return new List<InventoryItem>(); // placeholder
    }
}
