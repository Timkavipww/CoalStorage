namespace CoalStorage.Core.Entities
{
    public class PicketArea : BaseEntity
    {
        public int PicketID { get; set; }
        public Picket Picket { get; set; } 

        public int AreaID { get; set; }    
        public Area Area { get; set; }   
    }
}
