//time taken ~28 minutes
/* q1
input: two Z+
ouput: print(all i%2 ==0  between 2 and higher parameter value where it
  is divisible by smallest param)

approach: simple
lo = min(param1, param2)
hi = max(para1, param2)
  for loop 
    if 2i%lo == 0:
      
*/

using System;
class Program
{
  static void Main()
  {
    q1(17,4);
    Console.WriteLine();
    q1(21,7);
    Console.WriteLine();
    q1(5,20);
    Console.WriteLine();
    q1(3,10);
    Console.WriteLine();
    q1(2,2);
    Console.WriteLine();
  }
  public static void q1(int a, int b)
  {
    int lo = Math.Min(a,b);
    int hi = Math.Max(a,b);
  
    for(int i = 2; i <= hi; i+=2)
    {
      if(i % lo == 0) Console.Write(i+" ");
    }
    
    if(hi %2==0 && hi%lo == 0)
    {
      Console.Write(hi);
    }
  }
}

//abstract since vehicles are mostly the same
abstract class Vehicle
{
  public string make { get; set; }
  public string model { get; set; }
  public int wheels { get; set; }

  public double length { get; set; }
  public double weight { get; set; }
  public int maxPassengers { get; set; }

  protected Vehicles(string make, string model, int wheels, double length, double weight,
    int maxPassengers)
  {
    this.make = make;
    this.model = model;
    this.wheels = wheels;
    this.length = length;
    this.weight = weight;
    this.maxPassengers = maxPassengers;
  }
}

class Car : Vehicle
{
  public Car(string make, string model, double length, double weight, int maxPassengers): base(make, model, 4, length, weight, maxPassengers) { } //cars have 4 wheels
}

class Motorcycle : Vehicle
{
  public Car(string make, string model, double length, double weight, int maxPassengers): base(make, model, 2, length, weight, maxPassengers) { } //bikes have 2 wheels
}

class Bus : Vehicle
{
  public Car(string make, string model, double length, double weight, int maxPassengers): base(make, model, wheels, length, weight, maxPassengers) { } //busses' wheels can vary
}

abstract class ParkingLocation
{
  public int normalSpaces { get; set; }

  protected ParkingLocation(int normalSpaces)
  {
    this.normalSpaces = normalSpaces;
  }

  //each location has its own rules for parking
  public abstract string park(Vehicle v);
}

class ParkingLot : ParkingLocation
{
  public ParkingLot(int normalSpaces): base(normalSpaces) { }

  //lots accept any type of vehicle
  public override string park(Vehicle v)
  {
    if ( normalSpaces > 0)
    {
      normalSpaces -= 1;
      return v.make + " " + v.model + " parked in the lot";
    }
    else
    {
      return "Lot is full";
    }
  }
}

class ParkingGarage : ParkingLocation
{
  public int compactSpaces { get; set; }

  public ParkingGarage(int normalSpaces, int compactSpaces): base(normalSpaces)
  {
    this.compactSpaces = compactSpaces;
  }

  //only accept cars and motorcycles->use compact spaces first
  public override string park(Vehicle v)
  {
    if (v is Bus)
    {
      return "Buses can't park in the garage";
    }

    if (v.weight < 1500 && compactSpaces > 0)
    {
      compactSpaces -= 1;
      return v.make + " " + v.model + " parked in a compact space";
    }
    else if (normalSpaces > 0)
    {
      normalSpaces -= 1;
      return v.make + " " + v.model + " parked in a normal space";
    }
    else
    {
      return "Garage is full";
    }
  }
}