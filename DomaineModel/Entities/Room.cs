using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomaineModel.Entities
{
    [Table("Room")]
    public class Room
    {
        #region Attributs
        private int roomId;
        private string name;
        private int floor;
        private string category;
        #endregion
        #region Proprietes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        
        [StringLength(30)]
        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [Range(0,200)]
        [Required]
        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }
        [StringLength(50)]
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        #endregion
        //Propriétés de navigation
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<BookingRoom> BookingRooms { get; set; }
    }
}
