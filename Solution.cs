using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the isValid function below.
    static string isValid(string s)
    {
        bool allSame = false;
        var result = s.GroupBy(c => c).Select(c => c.Count()).ToList();

        for(var i = 0;i <result.Count;i++)
        {
            if (!result.Select(item => item).Where(a => a != 0).Where(x => x != result.FirstOrDefault()).Distinct().Any())
                return "YES";
            result[i] -= 1;
            allSame = !result.Select(item => item).Where(a => a != 0).Where(x => x != result.FirstOrDefault()).Distinct().Any();
            if (allSame == true)
                return "YES";
            else
                result[i] += 1;
        }

        return "NO";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
