﻿namespace CoalStorage.Core.Entities.DTO;

public class PicketDTO
{
    public long Id { get; set; }
    public string PicketName => Convert.ToString(MainStorageId * 100 + Id);
    public double Load { get; set; }
    public long AreaId { get; set; }
    public long MainStorageId { get; set; }
}
