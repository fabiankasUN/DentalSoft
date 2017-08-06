namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Odontogram = new HashSet<Odontogram>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_patient { get; set; }

        [Required]
        [StringLength(2)]
        public string DocumentType { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string SecondSurname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        public int? Age { get; set; }

        [StringLength(100)]
        public string Occupation { get; set; }

        [StringLength(1)]
        public string CivilState { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(20)]
        public string Cellphone { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(1)]
        public string SocialSecurity { get; set; }

        [StringLength(50)]
        public string Eps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odontogram> Odontogram { get; set; }
    }
}
