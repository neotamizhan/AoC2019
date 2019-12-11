using System;
using System.Collections.Generic;

namespace AdventOfCode 
{
  public class Day3 {
    
    public static Point lineLineIntersection(Point A, Point B, Point C, Point D) 
    { 
        // Line AB represented as a1x + b1y = c1  
        double a1 = B.y - A.y; 
        double b1 = A.x - B.x; 
        double c1 = a1 * (A.x) + b1 * (A.y); 
  
        // Line CD represented as a2x + b2y = c2  
        double a2 = D.y - C.y; 
        double b2 = C.x - D.x; 
        double c2 = a2 * (C.x) + b2 * (C.y); 
  
        double determinant = a1 * b2 - a2 * b1; 
  
        if (determinant == 0) 
        { 
            // The lines are parallel. This is simplified  
            // by returning a pair of FLT_MAX  
            return new Point(double.MaxValue, double.MaxValue); 
        } 
        else
        { 
            double x = (b2 * c1 - b1 * c2) / determinant; 
            double y = (a1 * c2 - a2 * c1) / determinant; 
            return new Point(x, y); 
        } 
    }      
  }

  public class Point 
  { 
      public double x, y; 
    
      public Point(double x, double y) 
      { 
          this.x = x; 
          this.y = y; 
      } 
    
      // Method used to display X and Y coordinates  
      // of a point  
      public static void displayPoint(Point p) 
      { 
          Console.WriteLine("(" + p.x + ", " + p.y + ")"); 
      } 

      public static double ManhattanDistance(Point A, Point B)
      {
          return Math.Abs(A.x - B.x) + Math.Abs(A.y - B.y);
      }

      public static List<Point> GetPointsFromRoute(string route) 
      {
        var routeArray = route.Split(",");
        var points = new List<Point>();
        points.Add(new Point(0.0,0.0));
        foreach (var leg in routeArray) 
        {
          var direction = leg.Substring(0,1);
          var moves = int.Parse(leg.Substring(1));

          var newPoint = points[points.Count - 1];

          switch (direction) {
            case "R":
              newPoint.y = newPoint.y + moves;
              break;
            case "L":
              newPoint.y = newPoint.y - moves;
              break;
            case "U":
              newPoint.x = newPoint.x + moves;
              break;
            case "D":
              newPoint.x = newPoint.x - moves;
              break;
            default:
              break;
          }

          points.Add(new Point(newPoint.x, newPoint.y));
        }

        return points;
      }
  }
  
   
}