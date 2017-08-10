namespace ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [DataContract]
    public partial class UserVM
    {
        [DataMember]
        public int Id_user { get; set; }

        [DataMember]
        [Required]
        [StringLength(128)]
        public string Id_AspNetUser { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [DataMember]
        public int State { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Firstname { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Lastname { get; set; }

        [DataMember]
        [StringLength(1)]
        public string Gender { get; set; }
        [DataMember]

        [StringLength(100)]
        public string Mail { get; set; }
        [DataMember]
        [StringLength(100)]
        public string Occupation { get; set; }
        [DataMember]
        [StringLength(50)]
        public string phone { get; set; }
    }
}
