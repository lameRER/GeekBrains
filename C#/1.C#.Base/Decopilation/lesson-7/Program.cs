// Decompiled with JetBrains decompiler
// Type: lesson_7_1.Program
// Assembly: lesson-7-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9A3BD5C-87CF-4393-853E-0F796E6D1BBA
// Assembly location: C:\Users\Sasha\source\repos\HomeWork\lesson-7\bin\Debug\netcoreapp3.1\lesson-7-1.dll

using System;
using System.IO;

namespace lesson_7_1
{
  class Program
  {
    static void Main(string[] args)
    {
            Console.WriteLine("Decopilation");
      foreach (string directory in Directory.GetDirectories("C:\\"))
        Console.WriteLine(directory);
      Console.ReadLine();
    }
  }
}
