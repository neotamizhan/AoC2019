namespace AdventOfCode 
{
  public struct ModeInfo 
  {
    int opcode;
    int paramCount;
    int[] readModes;
  }

  public class Day5 
  {
    const int POS = 0;
    const int IMM = 1;

    int[] intStream;

    Dictionary<int,int> ParamCount = new Dictionary<int,int>(
                                          {1,3},
                                          {2,3},
                                          {3,1}
                                          );

    public void Part1(string vals)
    {
      intStream = vals.Split(",").Select(n=>int.Parse(n)).ToArray();
      Process(integers, 12, 2);
      Console.WriteLine(integers[0]);
    }

    private ModeInfo GetMode(int num) 
    {
      var mode = new ModeInfo();
      mode.opcode = num%100;
      num /= 100;
      mode.paramCount = ParamCount[opcode];
      for
    }

    private void Add(int i) 
    {
      var param1 = intStream[i+1];
      var param2 = intStream[i+2];
      var outputPos = intStream[i+3];
      intStream[outputPos] = intStream[param1] + intStream[param2]; 
    }

    private void Multiply(int i) 
    {
      var param1 = intStream[i+1];
      var param2 = intStream[i+2];
      var outputPos = intStream[i+3];
      intStream[outputPos] = intStream[param1] * intStream[param2]; 
    }

    private void Assign(int i) 
    {
      var param1 = intStream[i+1];            
      intStream[outputPos] = intStream[param1] + intStream[param2]; 
    }




    public void Process(int noun, int verb) 
    {
      //Console.WriteLine(string.Join(",",intStream));
      bool endOfStream = false; 
      intStream[1] = noun;
      intStream[2] = verb;
      int incrementor = 1;

      for (int i=0; i<intStream.Length; i=i+incrementor) {
        var opcode = intStream[i];
        int param1, param2, ouuputPos;

        switch (opcode) {
          case 1:
            Add(i);
            incrementor = i+4;
            break;
          case 2:
            Multiply(i);  
            incrementor = i+4;
            break;
          case 3:
            incrementor = i+2;
            param1 = incrementor[i+1];
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
  }
}