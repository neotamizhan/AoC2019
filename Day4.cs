using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode
{
  public class Day4
  {
    static bool areDigitsAscending(int num) 
    { 
        // To store previous digit (Assigning 
        // initial value which is more than any 
        // digit) 
        int prev = 10; 
      
        // Traverse all digits from right to 
        // left and check if any digit is 
        // smaller than or equal to previous. 
        while (num > 0) 
        { 
            int rem = num % 10; 
            num /= 10; 
            if (rem > prev) 
              return false; 
            prev = rem; 
        } 
      
        return true; 
    } 
    
    static bool hasRepeatingDigits(int num, bool ensureDouble) 
    { 
        // To store previous digit (Assigning 
        // initial value which is more than any 
        // digit) 
        int prev = 10; 
        int repeatedNum = 0;
        Dictionary<int,int> counter = new Dictionary<int,int>();
        // Traverse all digits from right to 
        // left and check if any digit is 
        // smaller than previous. 
        while (num > 0) 
        { 
            int rem = num % 10; 
            num /= 10; 
            if (rem == prev)
            { 
              if (!counter.ContainsKey(rem)) {
                counter[rem] = 1;
              }
              counter[rem]++;
            }
            prev = rem; 
        } 
      
        return counter.Where(c=>c.Value == 2).Count() > 0;; 
    } 

    public static bool CanBePassword(int lower, int upper, int number) 
    {
      return 
        (number >= lower && number <= upper) &&
        hasRepeatingDigits(number, true) &&
        areDigitsAscending(number);
    }    

    public static void Process() {
      int lower = 347312; 
      int upper = 805915;
      int pwdCount = 0;

      for (int n = lower; n <= upper; n++) 
      {
        if (CanBePassword(lower, upper, n)) 
        {
          pwdCount++;
        }
      }

      Console.WriteLine(pwdCount);
    }
  }
}
