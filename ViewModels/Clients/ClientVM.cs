namespace ViewModels.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class ClientVM
    {
        

        [DataMember]
        public int Id_Client { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Code { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember]
        public bool Active { get; set; }

    }
}
