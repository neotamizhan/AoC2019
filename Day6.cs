using System;

namespace AdventOfCode {

  public class OrbitNode 
  {
    public string Node {get; set;}
    public List<string> DirectOrbits {get; set;}
    public List<string> IndirectOrbits {get; set;}  

    public OrbitNode(string Node) 
    {
      this.Node = Node;
    }        
  }
  
  public class Day6 {

    public void Process() {
      var map = File.ReadAllLines("input.txt");
      var uniqueNodes = GetUniqueNodes(map);

      var OrbitMap = uniqueNodes.ToDictionary(n=> n, n=> new OrbitNode(n));    

      foreach (var line in map) {
        
      }
    } 

    // return a unique list of all nodes
    private List<string> GetUniqueNodes(string[] map) {
      var nodes = new List<string>();
      
      foreach (var line in map) {
        var entries = line.Split(")");
        if (!nodes.Contains(entries[0]))
          nodes.Add(entries[0]);

        if (!nodes.Contains(entries[1]))
          nodes.Add(entries[1]);        
      }

      return nodes;
    }
  }
}