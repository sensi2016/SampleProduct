using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProduct.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

}
