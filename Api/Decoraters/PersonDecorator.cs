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
      var t = new Random(100);
      return t.Next();
    }
  }
}
