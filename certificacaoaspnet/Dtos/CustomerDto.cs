using certificacaoaspnet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace certificacaoaspnet.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente")]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}