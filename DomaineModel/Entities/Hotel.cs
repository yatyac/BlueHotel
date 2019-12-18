using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomaineModel.Entities
{
    [Table("Hotel")]
    public class Hotel
    {
        #region Variables
        private int hotelId;
        private string name;
        private int star;
        #endregion

        #region Proprietes scalaires
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int HotelId
		{
			get { return hotelId; }
			set { hotelId = value; }
		}
        [StringLength(30)]
        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [Required]
        public int Star
        {
            get { return star; }
            set { star = value; }
        }
        #endregion

        //Propriétés de navigation
        [Required]
        public virtual Address Address { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
