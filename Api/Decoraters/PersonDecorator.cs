using KarmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karma.Decoraters
{
  public class PersonDecorator
  {
    public static Person setLuck(Person person)
    {
      person.Luck = RandomPercentCalculator();
      return person;
    }

    public static float RandomPercentCalculator()
    {
            Random r = new Random();
            int rInt = r.Next(50, 100); //for ints
            return rInt;
    }
  }
}
