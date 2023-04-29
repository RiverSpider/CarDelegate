using System;
using System.Collections.Generic;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }
}

public class Garage
{
    private List<Car> _cars = new List<Car>();

    public void AddCar(Car car)
    {
        _cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        _cars.Remove(car);
    }

    public void PrintAllCars()
    {
        Console.WriteLine("Cars in the garage:");
        foreach (Car car in _cars)
        {
            Console.WriteLine("{0} {1} ({2})", car.Brand, car.Model, car.Year);
        }
    }

    public delegate void CarWashDelegate(Car car);

    public void WashAllCars(CarWashDelegate washDelegate)
    {
        Console.WriteLine("Washing all cars in the garage...");
        foreach (Car car in _cars)
        {
            washDelegate(car);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Ford", "Mustang", 1969);
        Car car2 = new Car("Chevrolet", "Corvette", 2021);
        Car car3 = new Car("Dodge", "Challenger", 1970);

        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);
        garage.AddCar(car3);

        garage.PrintAllCars();

        Garage.CarWashDelegate carWashDelegate = WashCar;

        garage.WashAllCars(carWashDelegate);

        garage.RemoveCar(car1);

        garage.PrintAllCars();
    }

    private static void WashCar(Car car)
    {
        Console.WriteLine("Washing {0} {1} ({2})...", car.Brand, car.Model, car.Year);
    }
}