using CoalStorage.Core.Common.Extensions;
using CoalStorage.Core.Interfaces;

namespace CoalStorage.Core.Common.Responses
{
    public class StorageResponse
    {

        public MainStorageDTO MainStorage { get; set; }
        public List<PicketDTO> Pickets { get; set; }
        public List<AreaDTO> Areas { get; set; } 

        
    }
}
