namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Appointment { get; set; }

        public int Id_patient { get; set; }

        public int Id_service { get; set; }

        public int Id_User { get; set; }

        public int Id_state { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Service Service { get; set; }

        public virtual StateAppointment StateAppointment { get; set; }

        public virtual User User { get; set; }
    }
}
