using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Odontogram {

    [DataContract]
    public partial class OdontogramTreatmentVM {
        [DataMember]
        public int Id_Treatment { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Nullable<int> type { get; set; }
    }
}
