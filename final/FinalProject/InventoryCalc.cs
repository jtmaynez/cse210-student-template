public class InventoryCalculator
{

    private double _demand;
    private double _holdingCostPerUnit;
    private double _orderingCost;
    private double _leadTime;
    private double _stdDevDemand;
    private double _zScore;

    public InventoryCalculator(double demand, double holdingCost, double orderingCost, double leadTime, double stdDev, double zScore = 1.65)
    {
        _demand = demand;
        _holdingCostPerUnit = holdingCost;
        _orderingCost = orderingCost;
        _leadTime = leadTime;
        _stdDevDemand = stdDev;
        _zScore = zScore;
    }

   // EOQ = sqrt((2 * D * S) / H)
    public double CalculateEOQ()
    {
        return Math.Sqrt(2 * _demand * _orderingCost / _holdingCostPerUnit);
    }

    // Average Inventory = EOQ / 2
    public double CalculateAverageInventory()
    {
        return CalculateEOQ() / 2;
    }

    // Holding Cost = Average Inventory × Holding Cost Per Unit
    public double CalculateHoldingCost()
    {
        return CalculateAverageInventory() * _holdingCostPerUnit;
    }

    // Safety Stock = z × σ × sqrt(lead time)
    public double CalculateSafetyStock()
    {
        return _zScore * _stdDevDemand * Math.Sqrt(_leadTime);
    }

    // Total Order Quantity = EOQ + Safety Stock
    public double CalculateOrderQuantity()
    {
        return CalculateEOQ() + CalculateSafetyStock();
    }
    // Cycle Time = EOQ / daily demand
    public double CalculateCycleTime()
    {
        double dailyDemand = _demand / 365.0;
        return CalculateEOQ() / dailyDemand; // returns in days
    }

    // Reorder Point = (daily demand × lead time) + safety stock
    public double CalculateReorderPoint()
    {
        double dailyDemand = _demand / 365.0;
        return (dailyDemand * _leadTime) + CalculateSafetyStock();
    }
}
