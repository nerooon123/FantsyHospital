//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FantsyHospital.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Forms
    {
        public int IdForm { get; set; }
        public int Patient { get; set; }
        public string NameForm { get; set; }
        public string Pulse { get; set; }
        public string BloodPressure { get; set; }
        public string Temperature { get; set; }
        public string Breath { get; set; }
        public string Weight { get; set; }
        public string LiquidConsumed { get; set; }
        public string DailyAmountOfUrine { get; set; }
        public string Chair { get; set; }
        public string Bath { get; set; }
    
        public virtual Patients Patients { get; set; }
    }
}
