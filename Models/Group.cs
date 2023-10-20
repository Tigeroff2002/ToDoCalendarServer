﻿using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Group
{
    [Key]
    public int Id { get; set; }

    public string GroupName { get; set; }

    public GroupType Type { get; set; }

    public virtual List<UserGroupMap> UserGroupMaps { get; set; }

    public Group() { }
}
