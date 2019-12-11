using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {  
  class Day2 {

    public void Part1(string vals) {
      int[] integers = vals.Split(",").Select(n=>int.Parse(n)).ToArray();
      Process(integers, 12, 2);
      Console.WriteLine(integers[0]);
    }

    public void Process(int[] intStream, int noun, int verb) {
      //Console.WriteLine(string.Join(",",intStream));
      bool endOfStream = false; 
      intStream[1] = noun;
      intStream[2] = verb;
      
      for (int i=0; i<intStream.Length; i=i+4) {
        var opcode = intStream[i];
        var param1 = intStream[i+1];
        var param2 = intStream[i+2];
        var outputPos = intStream[i+3];

        switch (opcode) {
          case 1:
            intStream[outputPos] = intStream[param1] + intStream[param2];  
            break;
          case 2:
            intStream[outputPos] = intStream[param1] * intStream[param2];  
            break;
          case 99:
            endOfStream = true;
            break;            
          default:
            break;
        }

        if (endOfStream) break;
      } 
      //Console.WriteLine(string.verboin(",",intStream));
    }

    public void Part2(string vals){
      int[] origIntegers = vals.Split(",").Select(n=>int.Parse(n)).ToArray();
      var newIntStream = new int[origIntegers.Length];
      var requiredOutput = 19690720;

      for (int noun = 0; noun<100; noun++) {
        for (int verb=0; verb <100; verb++) {
          origIntegers.CopyTo(newIntStream, 0);
          Process(newIntStream, noun, verb);
          if (newIntStream[0] == requiredOutput) {
            Console.WriteLine("Noun = {0}, Verb = {1}, Answer = {2}", noun, verb, (100 * noun) + verb);
            return;
          }
        }
      }

      Console.WriteLine("No values found");
    }
  }
}