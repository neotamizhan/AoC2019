using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode 
{
  public class Day3 {
    
    public static void Process() {
      var paths = File.ReadAllLines("input.txt");
      var route1 = Point.GetPointsFromRoute(paths[0]);
      var route2 = Point.GetPointsFromRoute(paths[1]);
      var result = Point.GetIntersections(route1, route2);
      var pathsTill = result.Select(r=> Point.CalculateSteps(Point.GetPathTill(route1, r)) + Point.CalculateSteps(Point.GetPathTill(route2, r))).Min();

      Console.WriteLine(pathsTill);      
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

      public override string ToString() 
      {
        return  "(" + x + ", " + y + ")"; 
      }
    
      // Method used to display X and Y coordinates  
      // of a point  
      public static void displayPoint(Point p) 
      { 
          Console.WriteLine("(" + p.x + ", " + p.y + ")"); 
      } 

      public static double ManhattanDistance(Point A)
      {
          return Math.Abs(A.x) + Math.Abs(A.y);
      }

      public static double ManhattanDistance(Point A, Point B)
      {
          return Math.Abs(A.x - B.x) + Math.Abs(A.y - B.y);
      }

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

      public static List<Point> GetPointsFromRoute(string route) 
      {
        var routeArray = route.Split(",");
        var points = new List<Point>();
        points.Add(new Point(0.0,0.0));
        foreach (var leg in routeArray) 
        {
          var direction = leg.Substring(0,1);
          var moves = int.Parse(leg.Substring(1));

          var newPoint = new Point(points[points.Count - 1].x, points[points.Count - 1].y);

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
          //points.ForEach(p=>Console.Write(p + ","));
          //Console.WriteLine();
        }
       // points.ForEach(p=>Console.Write(p + ","));
        //Console.WriteLine();
        return points;
      }
      
      public static List<Point> GetIntersections(List<Point> path1, List<Point> path2) 
      {
        var intersections = new List<Point>();

        for (int i = 0; i < path1.Count -1; i++) 
        {
          var pointA = path1[i];
          var pointB = path1[i+1];

          for (int j = 0; j < path2.Count -1; j++) 
          {
            var pointC = path2[j];
            var pointD = path2[j+1];

            var intersect = Point.lineLineIntersection(pointA, pointB, pointC, pointD);

            if (    intersect.x != double.MaxValue 
                &&  (intersect.x != 0 && intersect.y != 0)
                &&  PointInLine(pointA, pointB, intersect) 
                &&  PointInLine(pointC, pointD, intersect)                
               ) 
            {
              //Console.WriteLine("[{0}, {1}] + [{2}, {3}] = {4}", pointA, pointB, pointC, pointD, intersect);
              intersections.Add(intersect);
            }
          }
        }

        return intersections;
      }

      public static List<Point> GetPathTill(List<Point> path, Point endPoint) 
      {
        var newPath = new List<Point>();

        for (int i = 0; i < path.Count -1; i++) 
        {
          var pointA = path[i];
          var pointB = path[i+1];
          
            if (!PointInLine(pointA, pointB, endPoint)) 
            { 
              if (!newPath.Contains(pointA))             
                newPath.Add(pointA);

              if (!newPath.Contains(pointB))                             
              newPath.Add(pointB);
            } else 
            {
                if (!newPath.Contains(pointA))             
                  newPath.Add(pointA);

              newPath.Add(endPoint);
              break;
            }
        }

        return newPath;
      }

      public static bool PointInLine(Point lineStart, Point lineEnd, Point p)
      {
        var xs = new double[] { lineStart.x, lineEnd.x};
        var ys = new double[] { lineStart.y, lineEnd.y};
        Array.Sort(xs);
        Array.Sort(ys);
        return ((p.x >= xs[0] && p.x <= xs[1]) && (p.y >= ys[0] && p.y <= ys[1]));
      }

      public static double CalculateSteps(List<Point> path)
      {
        var steps = 0.0;
        for (int i=1;i<path.Count;i++)
        {
          steps += Math.Abs(path[i-1].x - path[i].x) + Math.Abs(path[i-1].y - path[i].y); 
        }
        return steps;
      }
  }
  
   
}