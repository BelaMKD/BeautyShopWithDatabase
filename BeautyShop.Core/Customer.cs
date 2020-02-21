
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeautyShop.Core
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, Display(Name = "Full Name")]
        public string Name { get; set; }
        public bool IsMember 
        {
            get 
            {
                return Membership != null;
            }
            
        }
        [Display(Name = "Choose Membership Type")]
        public int? MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
