using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.Entity.Abstract
{
    public abstract class EntityBase  //Abstract oluşturulma sebebi farklı sınıflarda değiştirilme ihtimali. Virtual yazılır. (override)
    {
        public virtual int Id  { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedName { get; set; } = "Admin";
        public virtual string EditedName { get; set; } =  "Admin";
        public virtual DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual DateTime EditDate { get; set; } = DateTime.Now;



    }
}
