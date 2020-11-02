using System;
using System.Collections.Generic;

namespace JSLTeste.Models
{
    public partial class Truck
    {
        public Truck()
        {
            TruckDriver = new HashSet<TruckDriver>();
        }

        public int TruckId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string License { get; set; }
        public int? Axle { get; set; }

        public virtual ICollection<TruckDriver> TruckDriver { get; set; }
    }
}
