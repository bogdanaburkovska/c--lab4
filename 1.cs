using System;

class ProductionRecord
{
    public string Month { get; set; }
    public double PlannedProduction { get; set; }
    public double ActualProduction { get; set; }

    public double PercentageCompletion => (ActualProduction / PlannedProduction) * 100;
}

class Program
{
    static void Main()
    {
        try
        {
            ProductionRecord[] records = GenerateRecords();

            // Відсортувати за відсотком виконання плану
            Array.Sort(records, (x, y) => x.PercentageCompletion.CompareTo(y.PercentageCompletion));

            // Вивести таблицю
            Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-20}", "Місяць", "План", "Факт", "Відсоток виконання");
            foreach (var record in records)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-20:N2}%", record.Month, record.PlannedProduction, record.ActualProduction, record.PercentageCompletion);
            }

            // Знайти місяці з найбільшим та найменшим відсотком виконання плану
            string highestMonth = records[records.Length - 1].Month;
            string lowestMonth = records[0].Month;

            Console.WriteLine($"Місяць з найбільшим відсотком виконання плану: {highestMonth}");
            Console.WriteLine($"Місяць з найменшим відсотком виконання плану: {lowestMonth}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    static ProductionRecord[] GenerateRecords()
    {
        return new ProductionRecord[]
        {
            new ProductionRecord { Month = "Січень", PlannedProduction = 1000, ActualProduction = 950 },
            new ProductionRecord { Month = "Лютий", PlannedProduction = 1200, ActualProduction = 1100 },
            new ProductionRecord { Month = "Березень", PlannedProduction = 1500, ActualProduction = 1450 },
            new ProductionRecord { Month = "Квітень", PlannedProduction = 1100, ActualProduction = 1050 },
            new ProductionRecord { Month = "Травень", PlannedProduction = 1300, ActualProduction = 1200 },
            new ProductionRecord { Month = "Червень", PlannedProduction = 1400, ActualProduction = 1350 },
            new ProductionRecord { Month = "Липень", PlannedProduction = 1600, ActualProduction = 1550 },
            new ProductionRecord { Month = "Серпень", PlannedProduction = 1700, ActualProduction = 1600 },
            new ProductionRecord { Month = "Вересень", PlannedProduction = 1800, ActualProduction = 1750 },
            new ProductionRecord { Month = "Жовтень", PlannedProduction = 2000, ActualProduction = 1900 }
        };
    }
}
