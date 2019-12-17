using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomaineModel.Entities
{
    [Table("Booking")]
    public class Booking
    {
        #region Attributs
        private int bookingId;
        private DateTime created;
        private DateTime checkIn;
        private DateTime checkOut;
        private bool isPaid;
        private decimal price;
        #endregion
        #region Proprietes

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId
        {
            get { return bookingId; }
            set { bookingId = value; }
        }
        
        [Range(typeof(DateTime),"01/01/2019","31/12/2100")]
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        [Range(typeof(DateTime), "01/01/2019", "31/12/2100")]
        public DateTime CheckIn
        {
            get { return checkIn; }
            set { checkIn = value; }
        }

        [Range(typeof(DateTime), "01/01/2019", "31/12/2100")]
        public DateTime CheckOut
        {
            get { return checkOut; }
            set { checkOut = value; }
        }

        [Range(0.0,double.MaxValue)]
        [Required]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        [Required]
        public bool IsPaid
        {
            get { return isPaid; }
            set { isPaid = value; }
        }
        #endregion
        //Propriétés de navigation
        public virtual ICollection<BookingRoom> BookingRooms { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
