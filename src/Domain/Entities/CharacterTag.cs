using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Domain.Entities;
public class CharacterTag : BaseEntity
{
    public string CharacterId { get; set; } = string.Empty;
    public string TagId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Character Character { get; set; } = new Character();
    public virtual Tag Tag { get; set; } = new Tag();
}
