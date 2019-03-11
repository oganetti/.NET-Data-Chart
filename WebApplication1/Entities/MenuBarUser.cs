using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OplogDataChartBackend.Entities
{
    public class MenuBarUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Guid MenuBarId { get; set; }

        public MenuBar MenuBar { get; set; }

        protected MenuBarUser() { }

        public MenuBarUser(Guid id, string userId, Guid menubarId)
        {
            this.Id = id;
            this.UserId = userId;
            this.MenuBarId = menubarId;
        }
    }
}
