namespace CarLibrary;

public class Truck : Car
{
    /// <summary>
    /// Грузоподъемность
    /// </summary>
    public double MaxLoadWeight { get; set; }

    /// <summary>
    /// Конструктор класса Truck (грузовой автомобиль)
    /// </summary>
    /// <param name="averageFuelConsumption">Cредний расход топлива на 100км</param>
    /// <param name="fuelCapacity">Объем бака</param>
    /// <param name="maxSpeed">Максимальная скорость</param>
    /// <param name="maxLoadWeight">Грузоподъемность</para>
    public Truck(double averageFuelConsumption, double fuelCapacity, double maxSpeed, double maxLoadWeight) 
        : base(CarType.Грузовой, averageFuelConsumption, fuelCapacity, maxSpeed)
    {
        MaxLoadWeight = maxLoadWeight;
    }

    /// <summary>
    /// Расчет запаса хода с учетом веса груза 
    /// </summary>
    /// <param name="loadWeight">Вес груза</param>
    /// <returns></returns>
    /// <exception cref="Exception">При нехватки грузоподъемности</exception>
    public double PowerReserve(double loadWeight)
    {
        if (loadWeight > MaxLoadWeight)
        {
            throw new Exception("Не хватает грузоподъемности");
        }
        double reductionWeight = (int)(loadWeight / 200) * 0.04 + 1;
        return FuelCapacity / (AverageFuelConsumption / reductionWeight);
    }
}