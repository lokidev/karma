using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaManagement.Decoraters
{
    public class PersonDecorator
    {
        public static Person setBirthDate(Person person)
        {
            person.BirthDate = DateTime.Now;
            return person;
        }

        public static Person setGender(Person person)
        {
            person.Gender = RandomBoolCalculator();
            return person;
        }

        public static Person setLuck(Person person)
        {
            person.Luck = RandomPercentCalculator();
            return person;
        }

        public static Person setHealth(Person person)
        {
            person.Health = RandomPercentCalculator();
            return person;
        }

        public static Person setHunger(Person person)
        {
            person.Hunger = RandomPercentCalculator();
            return person;
        }

        public static Person setSecurity(Person person)
        {
            person.Security = RandomPercentCalculator();
            return person;
        }

        public static float RandomPercentCalculator()
        {
            Random r = new Random();
            int rInt = r.Next(50, 100); //for ints
            return rInt;
        }

        public static bool RandomBoolCalculator()
        {
            Random r = new Random();
            return r.Next(2) == 0;
        }
    }
}
