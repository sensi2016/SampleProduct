﻿namespace SampleProduct.Domain.Entities;

public class UserRole : BaseAuditableEntity
{

    public Role Role { get; set; }
    public int RoleId { get; set; }    
    
    public User User { get; set; }
    public int UserId { get; set; }

}
