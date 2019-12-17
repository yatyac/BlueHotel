using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomaineModel.Entities
{
    [Table("Customer")]
    public class Customer
    {
        #region Attributs
        private int customerId;
        private string fullName;
        #endregion
        #region Proprietes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        [StringLength(255)]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        [Range(typeof(DateTime),"01/01/1900","31/12/2100")]
        public DateTime DateOfBirth { get; set; }
        #endregion
        //Propriétés de navigation
        public virtual Address Address { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
