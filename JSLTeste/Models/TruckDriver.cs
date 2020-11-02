using System;
using System.Collections.Generic;

namespace JSLTeste.Models
{
    public partial class TruckDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TruckId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Truck Truck { get; set; }
    }
}
