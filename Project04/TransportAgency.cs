//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project04
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransportAgency
    {
        public int id { get; set; }
        public string type { get; set; }
        public System.DateTime departureTime { get; set; }
        public System.DateTime arrivalTime { get; set; }
        public string destination { get; set; }
        public int distance { get; set; }
        public int seats { get; set; }
        public int ticketsSold { get; set; }
        public int cost { get; set; }
    }
}
