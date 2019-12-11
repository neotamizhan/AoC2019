using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
  class MainClass {
    public static void Main (string[] args) {
      /*Point a = new Point(3.0,2.0);
      Point b = new Point(3.0,6.0);
      Point c = new Point(5.0,3.0);
      Point d = new Point(2.0,3.0);

      var intersectPoint = Day3.lineLineIntersection(a,b,c,d);
      Point.displayPoint(intersectPoint);
      Console.WriteLine(Point.ManhattanDistance(new Point(0.0,0.0), intersectPoint));*/

      var route1 = Point.GetPointsFromRoute("R8,U5,L5,D3");
      var route2 = Point.GetPointsFromRoute("U7,R6,D4,L4");
      var result = route1.Intersect(route2).Select(c=> Math.Abs(c.x) + Math.Abs(c.y)).Min();
      Console.WriteLine("Result = {0}", result);
    }
  }
}