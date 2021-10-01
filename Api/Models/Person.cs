using System;
using System.Collections.Generic;

#nullable disable

namespace KarmaApi.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public float? Luck { get; set; }
        public float? Education { get; set; }
        public float? Health { get; set; }
        public float? Hunger { get; set; }
        public float? Security { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public DateTime? DestructionDate { get; set; }
        public string IdentificationTags { get; set; }
    }
}
