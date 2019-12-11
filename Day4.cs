using System;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
  public class Day4
  {
    static bool isTidy(int num) 
    { 
        // To store previous digit (Assigning 
        // initial value which is more than any 
        // digit) 
        int prev = 10; 
      
        // Traverse all digits from right to 
        // left and check if any digit is 
        // smaller than previous. 
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
    
    static bool hasRepeatingDigits(int num) 
    { 
        // To store previous digit (Assigning 
        // initial value which is more than any 
        // digit) 
        int prev = 10; 
        repeatedNum = 0;
        bool moreThanTwice = false; 
        // Traverse all digits from right to 
        // left and check if any digit is 
        // smaller than previous. 
        while (num > 0) 
        { 
            int rem = num % 10; 
            num /= 10; 
            if (rem == prev)
            { 
              if (moreThanTwice) {
                
              }
              return true; 
            }
            prev = rem; 
        } 
      
        return false; 
    } 

    public static bool CanBePassword(int lower, int upper, int number) 
    {
      return 
        (number >= lower && number <= upper) &&
        hasRepeatingDigits(number) &&
        isTidy(number);
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
