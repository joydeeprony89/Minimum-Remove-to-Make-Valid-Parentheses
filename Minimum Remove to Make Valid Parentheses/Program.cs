using System;
using System.Linq;
using System.Text;

namespace Minimum_Remove_to_Make_Valid_Parentheses
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "((jay(deep)"; // lee(t(c)o)de)
      Program p = new Program();
      Console.WriteLine(p.MinRemoveToMakeValid(s));
    }

    public string MinRemoveToMakeValid(string s)
    {
      int openCounter = 0;
      StringBuilder sb = new StringBuilder();
      foreach (char c in s)
      {
        // when you see open , increament
        if (c == '(') openCounter++;
        else if (c == ')')
        {
          // when you see close, check is it already balanced i.e. count is 0, and we have found another close, so time to ignore this.
          if (openCounter == 0) continue;
          openCounter--;
        }
        sb.Append(c);
      }

      // if it is already balanced, return.
      if (openCounter == 0) return sb.ToString();
      else 
      {
        // when input is like with extra opening = (jaydeep)( or ((jay(deep)
        // we check for only opening '(', when found we check if the count is gt 0, i.e. we have found the extra opening one.
        StringBuilder result = new StringBuilder();
        s = sb.ToString();
        int len = s.Length;
        for (int i = len - 1; i >= 0; i--)
        {
          if(s[i] == '(' && openCounter > 0)
          {
            openCounter--;
            continue;
          }
          result.Append(s[i]);
        }

        s = result.ToString();
        return new string(s.Reverse().ToArray());
      }
    }
  }
}
