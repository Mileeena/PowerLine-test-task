namespace CarLibrary;

public class PassengerCar : Car
{
    /// <summary>
    /// Количество пассажирских мест
    /// </summary>
    public int PassengerNumber { get; set; }

    /// <summary>
    /// Конструктор класса PassengerCar (легковой автомобиль)
    /// </summary>
    /// <param name="averageFuelConsumption">Cредний расход топлива на 100км</param>
    /// <param name="fuelCapacity">Объем бака</param>
    /// <param name="maxSpeed">Максимальная скорость</param>
    /// <param name="passengerNumber">Количество пассажирских мест</param>
    public PassengerCar(double averageFuelConsumption, double fuelCapacity, double maxSpeed, int passengerNumber)
        : base(Car.CarType.Легковой, averageFuelConsumption, fuelCapacity, maxSpeed)
    {
        PassengerNumber = passengerNumber;
    }

    /// <summary>
    /// Расчет запаса хода с учетом количества пасажиров
    /// </summary>
    /// <param name="people">Количество пассажиров</param>
    /// <returns></returns>
    /// <exception cref="Exception">При нехватки пассажирских мест</exception>
    public double PowerReserve(int people)
    {
        if (people > PassengerNumber)
        {
            throw new Exception("Не хватает пассажирских мест в машине");
        }
        double reductionPeople = people * 0.06 + 1;
        return FuelCapacity / (AverageFuelConsumption / reductionPeople);
    }
}