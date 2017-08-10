namespace ViewModels.Odontogram {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class OdontogramActionVM
    {
        [DataMember]
        public int Id_action { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [DataMember]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [DataMember]
        [Required]
        [StringLength(2)]
        public string shorcut { get; set; }
    }
}
