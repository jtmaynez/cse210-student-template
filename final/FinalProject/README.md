<!-- @format -->

# Supply Chain Management System

## Overview

This C# console application helps users perform demand forecasting, calculate inventory levels, and classify inventory using the ABC method. It is designed using object-oriented programming (OOP) principles and follows a modular, extensible architecture.

## Features

### 1. Forecasting

Supports three forecasting models:

- Moving Average
- Weighted Average
- Exponential Smoothing

Forecasts can be calculated by:

- Year
- Quarter
- Month

Each forecast displays:

- Forecasted demand
- Mean Absolute Deviation (MAD)
- Mean Absolute Percentage Error (MAPE)

### 2. Inventory Calculations

Based on user inputs such as demand, holding cost, and standard deviation, the system calculates:

- Economic Order Quantity (EOQ)
- Average Inventory
- Holding Cost
- Safety Stock
- Total Order Quantity
- Cycle Time
- Reorder Point

### 3. ABC Classification

Users can input a list of inventory items and their annual usage values.
The system classifies items into:

- Category A: Top 70% of cumulative usage value
- Category B: Next 20%
- Category C: Remaining 10%

The classification results are displayed by group with item names and values.

## Object-Oriented Design

This project demonstrates clean implementation of OOP principles:

### Abstraction

- The abstract `Forecast` class defines a consistent interface for different forecasting techniques.
- Each forecasting class hides its specific logic from the rest of the application.

### Encapsulation

- All class variables are private and accessed through public methods.
- Each class manages its own data and behavior.

### Inheritance

- `MovingForecast`, `SmoothingForecast`, and `WeightedAverageForecast` inherit from the `Forecast` base class.

### Polymorphism

- Each forecasting class overrides the `Calculate` method.
- The program uses different forecast types interchangeably through polymorphic behavior.

## How to Run

1. Open the project in Visual Studio or run using `dotnet run`.
2. Follow the console menu prompts to:
   - Run a forecast
   - Perform inventory calculations
   - Classify inventory using the ABC method

## File Overview

| File Name            | Description                                |
| -------------------- | ------------------------------------------ |
| Program.cs           | Handles user interaction and program logic |
| Forecast.cs          | Abstract base class for forecasting        |
| MovingForecast.cs    | Implements moving average logic            |
| SmoothingForecast.cs | Implements exponential smoothing logic     |
| WeightedForecast.cs  | Implements weighted average logic          |
| InventoryCalc.cs     | Performs inventory-related calculations    |
| ABCClassifier.cs     | Classifies inventory into A/B/C categories |
| InventoryItem.cs     | Represents an inventory item               |
| DataHistory.cs       | Loads and manages historical sales data    |
| QtySold.csv          | CSV data file with monthly sales data      |
| Month.cs             | Enumeration for month names                |
| quarter.cs           | Enumeration for quarters                   |

## Status

The project meets all assignment criteria:

- Fully interactive console interface
- No runtime errors
- Well-structured object-oriented design
- Clear separation of concerns and functionality

## Author

Justin Maynes  
BYU–Idaho  
B.S. Supply Chain Management
