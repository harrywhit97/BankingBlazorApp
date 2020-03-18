using System.ComponentModel.DataAnnotations;

namespace Domain.Abstract
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }        
    }
}
