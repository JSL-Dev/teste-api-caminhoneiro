using System;
using System.Collections.Generic;

namespace JSLTeste.Models
{
    public partial class Address
    {
        public Address()
        {
            TruckDriver = new HashSet<TruckDriver>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Coordenates { get; set; }
        public int? Number { get; set; }
        public string City { get; set; }

        public virtual ICollection<TruckDriver> TruckDriver { get; set; }
    }
}
