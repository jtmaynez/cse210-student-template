public class ABCClassifier
{
    private List<InventoryItem> items;
    private List<InventoryItem> categoryA = new();
    private List<InventoryItem> categoryB = new();
    private List<InventoryItem> categoryC = new();

    public ABCClassifier()
    {
        items = new List<InventoryItem>();
    }

    public void AddItem(string name, double annualUsageValue)
    {
        items.Add(new InventoryItem(name, annualUsageValue));
    }

    public void ClassifyItems()
    {
        categoryA.Clear();
        categoryB.Clear();
        categoryC.Clear();

        var sortedItems = items.OrderByDescending(i => i._annualUsageValue).ToList();
        double totalValue = sortedItems.Sum(i => i._annualUsageValue);
        double cumulative = 0;

        foreach (var item in sortedItems)
        {
            cumulative += item._annualUsageValue;
            double percent = cumulative / totalValue;

            if (percent <= 0.7)
                categoryA.Add(item);
            else if (percent <= 0.9)
                categoryB.Add(item);
            else
                categoryC.Add(item);
        }
    }

    public List<InventoryItem> GetCategoryAItems() => categoryA;
    public List<InventoryItem> GetCategoryBItems() => categoryB;
    public List<InventoryItem> GetCategoryCItems() => categoryC;
}
