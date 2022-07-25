namespace CarLibrary;

public class SportsСar : Car
{
    /// <summary>
    /// Конструктор класса SportsСar (спортивный автомобиль)
    /// </summary>
    /// <param name="averageFuelConsumption">Cредний расход топлива на 100км</param>
    /// <param name="fuelCapacity">Объем бака</param>
    /// <param name="maxSpeed">Максимальная скорость</param>
    public SportsСar(double averageFuelConsumption, double fuelCapacity, double maxSpeed) 
        : base(CarType.Спортивный, averageFuelConsumption, fuelCapacity, maxSpeed)
    {
    }
}