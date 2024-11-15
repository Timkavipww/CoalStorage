using CoalStorage.Core.Common.Extensions;
using CoalStorage.Core.Interfaces;

namespace CoalStorage.Core.Common.Responses
{
    public class StorageResponse
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IPicketRepository _picketRepository;

        public MainStorageDTO MainStorage { get; set; }
        public List<PicketDTO> Pickets { get; set; } = new List<PicketDTO>();
        public List<AreaDTO> Areas { get; set; } = new List<AreaDTO>();

        // Конструктор, принимающий IStorageRepository
        public StorageResponse(IStorageRepository storageRepository,
            IAreaRepository areaRepository,
            IPicketRepository picketRepository)
        {
            _storageRepository = storageRepository;
            _areaRepository = areaRepository;
            _picketRepository = picketRepository;
        }

        // Метод для получения данных о складе, пикетах и зонах по StorageId
        public async Task LoadStorageDataAsync(long storageId)
        {
            // Получаем данные о складе (MainStorage) по StorageId
            MainStorage = await _storageRepository.GetStorageByIdAsync(storageId);


            // Получаем список пикетов, принадлежащих данному складу
            Pickets = await _picketRepository.GetPicketsByStorageIdAsync(storageId);

            // Получаем список зон, принадлежащих данному складу
            Areas = await _areaRepository.GetAreasByStorageIdAsync(storageId);
        }
    }
}
