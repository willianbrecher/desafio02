using Desafio.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Desafio.EntityFramework.Common
{
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    [Index(nameof(IsDeleted))]
    public class AuditableEntity: CommonEntity, IAuditableEntity
    {
        [Required] public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        //[Required] public Guid CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        //public Guid? UpdatedBy { get; set; }

        public DateTimeOffset? IsDeleted { get; set; }
    }
}
