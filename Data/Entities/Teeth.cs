namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teeth
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Teeth { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Odontogram { get; set; }

        public int? Cervical { get; set; }

        public int? Vestibular { get; set; }

        public int? Oclusal { get; set; }

        public int? Palatino { get; set; }

        public int? Distal { get; set; }

        public int? Mesial { get; set; }

        public virtual Odontogram Odontogram { get; set; }
    }
}
