namespace CarLibrary;

public class Car
{
    /// <summary>
    /// Тип автомобиля
    /// </summary>
    public readonly CarType Type;

    /// <summary>
    /// Cредний расход топлива на 100км
    /// </summary>
    public double AverageFuelConsumption { get; set; }

    /// <summary>
    /// Объем бака
    /// </summary>
    public double FuelCapacity { get; set; }

    /// <summary>
    /// Максимальная скорость
    /// </summary>
    public double MaxSpeed { get; set; }

    /// <summary>
    /// Конструктор класса Car
    /// </summary>
    /// <param name="type">Тип автомобиля</param>
    /// <param name="averageFuelConsumption">Cредний расход топлива на 100км</param>
    /// <param name="fuelCapacity">Объем бака</param>
    /// <param name="maxSpeed">Максимальная скорость</param>
    public Car(CarType type, double averageFuelConsumption, double fuelCapacity, double maxSpeed)
    {
        Type = type;
        AverageFuelConsumption = averageFuelConsumption;
        FuelCapacity = fuelCapacity;
        MaxSpeed = maxSpeed;
    }

    /// <summary>
    /// Расчет запаса хода, при полном баке
    /// </summary>
    /// <returns></returns>
    public virtual double MaximumRange()
    {
        return FuelCapacity / AverageFuelConsumption;
    }

    /// <summary>
    /// Расчет запаса хода, при остаточном запасе бака
    /// </summary>
    /// <param name="fuel">Количество топлива в баке</param>
    /// <returns></returns>
    public virtual double MaximumRange(double fuel)
    {
        return fuel / AverageFuelConsumption;
    }

    /// <summary>
    /// Расчет запаса хода с учетом количества пассажиров и веса груза 
    /// </summary>
    /// <param name="people">Количество пасажиров</param>
    /// <param name="loadWeight">Вес груза</param>
    /// <returns></returns>
    public virtual double PowerReserve(int people = 0, double loadWeight=0)
    {
        double reductionPeople = people * 0.01 + 1; //1.x
        double reductionWeight = loadWeight * 0.02 + 1; //1.y
        return FuelCapacity / (AverageFuelConsumption / reductionPeople / reductionWeight);
    }

    /// <summary>
    /// Расчет времени (минуты) в пути
    /// </summary>
    /// <param name="fuel">Количество топлива в баке</param>
    /// <param name="distance">Длина пути</param>
    /// <returns>Время в минутах</returns>
    /// <exception cref="Exception">При нехватки топлива</exception>
    public virtual double TravelTime(double fuel, double distance)
    {
        if (MaximumRange(fuel) < distance)
        {
            throw new Exception($"{fuel} литров топлива не хватит, чтобы проехать {distance}км");
        }

        return distance / MaxSpeed * 60;
    }

    /// <summary>
    /// Тип автомобиля
    /// </summary>
    public enum CarType
    {
        Грузовой,
        Легковой,
        Спортивный,
        Автобус
    }
}