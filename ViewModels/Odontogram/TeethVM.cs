namespace ViewModels.Odontogram 
    {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class TeethVM
    {
        [DataMember]
        public int Id_Teeth { get; set; }

        [DataMember]
        public int Id_Odontogram { get; set; }
        [DataMember]
        public int? UpperCervical { get; set; }
        [DataMember]
        public int? Vestibular { get; set; }
        [DataMember]
        public int? Oclusal { get; set; }
        [DataMember]
        public int? Palatino { get; set; }
        [DataMember]
        public int? Distal { get; set; }
        [DataMember]
        public int? Mesial { get; set; }
        [DataMember]
        public int? LowerServical { get; set; }
        [DataMember]
        public int? General { get; set; }

    }
}
