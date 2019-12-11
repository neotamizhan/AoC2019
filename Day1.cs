using System;

namespace AdventOfCode {
  class Day1 {
    public static decimal GetFuel(decimal mass) {
        var fuel = Math.Floor(mass/3) -2;
        return (fuel < 0) ? 0 : fuel;
      }

      public static decimal GetFuelUntilZero(decimal mass) {
        decimal completeFuel = 0;
        decimal fuel = 0;
        decimal newMass = mass;
        do {
          fuel = GetFuel(newMass);
          completeFuel += fuel;
          newMass = fuel;
        } while (fuel > 0);

        return completeFuel;
      }    
  }
}