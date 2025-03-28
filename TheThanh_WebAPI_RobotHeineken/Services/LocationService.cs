﻿using AutoMapper;
using TheThanh_WebAPI_RobotHeineken.Data;
using TheThanh_WebAPI_RobotHeineken.DTO;
using TheThanh_WebAPI_RobotHeineken.Repository;
using TheThanh_WebAPI_RobotHeineken.Validation;

namespace TheThanh_WebAPI_RobotHeineken.Services
{
    public interface ILocationService
    {
        Task<ListLocationResponse> GetAllLocation(int page = 0);
        Task<LocationDetailsDTO> GetLocationById(int id);
        Task<(bool Success, string ErrorMessage)> CreateLocation(LocationDTO createDTO);
        Task<(bool Success, string ErrorMessage)> UpdateLocation(int id, LocationDTO updateLocationDTO);
        Task<(bool Success, string ErrorMessage)> DeleteLocation(int id);
    }
    public class LocationService : ILocationService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly CreateLocationValidator _createValidator;
        public LocationService(IRepositoryWrapper repository, IMapper mapper, CreateLocationValidator createValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
        }
        public async Task<ListLocationResponse> GetAllLocation(int page = 0)
        {
            // lấy các location
            IEnumerable<Location> locations = await _repository.Location.GetAllAsync();
            List<LocationDTO> locationDTOs = _mapper.Map<List<LocationDTO>>(locations);

            ListLocationResponse locationViewModel = new()
            {
                TotalLocations = locationDTOs.Count,
                //TotalLocationsWithCampaigns = 5,
                OperatingDeviceCount = _repository.RecyclingMachine.GetAllAsync(l => l.LocationID != null).Result.Count(),
                LocationDTOs = locationDTOs
            };

            return locationViewModel;
        }

        public async Task<(bool Success, string ErrorMessage)> CreateLocation(LocationDTO createDTO)
        {
            // Kiểm tra duy nhất của LocationName (đã tồn tại => true)
            bool isLocationNameUnique = await _repository.Location.AnyAsync(m => m.LocationName == createDTO.LocationName);
            if (isLocationNameUnique)
            {
                return (false, "Location name already exists");
            }

            FluentValidation.Results.ValidationResult validationResult = await _createValidator.ValidateAsync(createDTO);

            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            Location newLocation = _mapper.Map<Location>(createDTO);
            await _repository.Location.CreateAsync(newLocation);

            return (true, null);
        }

        public async Task<(bool Success, string ErrorMessage)> UpdateLocation(int id, LocationDTO updateDTO)
        {
            Location location = await _repository.Location.GetByIdAsync(m => m.LocationID == id);
            if (location == null)
            {
                return (false, "Location not found");
            }

            // Kiểm tra location name duy nhất
            bool isLocationNameUnique = await _repository.Location.AnyAsync(m => m.LocationName == updateDTO.LocationName
                                                                            && location.LocationName != updateDTO.LocationName);
            if (isLocationNameUnique)
            {
                return (false, "Location name already exists");
            }

            FluentValidation.Results.ValidationResult validationResult = await _createValidator.ValidateAsync(updateDTO);

            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            // Cập nhật các thuộc tính của đối tượng machine với các giá trị từ updateDTO.
            _mapper.Map(updateDTO, location);
            await _repository.Location.UpdateAsync(location);
            return (true, null);
        }

        public async Task<(bool Success, string ErrorMessage)> DeleteLocation(int id)
        {
            Location location = await _repository.Location.GetByIdAsync(m => m.LocationID == id);
            if (location == null) return (false, "Location not found");

            // ktra địa điểm có đang được vận hành
            bool isLocationOperation = await _repository.RecyclingMachine.AnyAsync(m => m.LocationID == id);
            if (isLocationOperation)
            {
                return (false, "Location is currently in operation and cannot be deleted");
            }

            await _repository.Location.DeleteAsync(location);
            return (true, null);
        }

        public async Task<LocationDetailsDTO> GetLocationById(int id)
        {
            // lấy các recycling machine thuộc địa điểm
            IEnumerable<RecyclingMachine> machines = await _repository.RecyclingMachine.GetAllAsync(m => m.LocationID == id);
            List<LocationMachineDTO> locationDTOs = _mapper.Map<List<LocationMachineDTO>>(machines);

            Location location = await _repository.Location.GetByIdAsync(m => m.LocationID == id);

            if (location == null) return null;

            LocationDetailsDTO locationDetails = new()
            {
                LocationName = location.LocationName,
                Area = location.City,
                District = location.District,
                Ward = location.Ward,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                MachineDTOs = locationDTOs
            };

            return locationDetails;
        }
    }
}
