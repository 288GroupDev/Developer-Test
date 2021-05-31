using System;
using System.ComponentModel.DataAnnotations;

namespace _288Group.ECommerceShop.Persistence.Model
{
    public record DatedLongIdEntity
    {
        [Key]
        public long Id { get; init; }
        public DateTime DateCreatedUtc { get; init; } = DateTime.UtcNow;
    }
}
