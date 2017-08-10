namespace ViewModels.Odontogram
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class OdontogramVM
    {
        [DataMember]
        public int Id_Odontogram { get; set; }
        [DataMember]
        public int Id_patient { get; set; }
        [DataMember]
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
        [DataMember]
        public bool? first { get; set; }

        [DataMember]
        public TeethVM[] upperTeeth { get; set; }
        [DataMember]
        public TeethVM[] upperTemporalTeeth { get; set; }
        [DataMember]
        public TeethVM[] lowerTemporalTeeth { get; set; }
        [DataMember]
        public TeethVM[] lowerTeeth { get; set; }

        [DataMember]
        public List<OdontogramActionVM> actions { get; set; }
    }
}
