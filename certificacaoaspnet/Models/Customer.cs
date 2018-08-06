using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace certificacaoaspnet.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente")]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}