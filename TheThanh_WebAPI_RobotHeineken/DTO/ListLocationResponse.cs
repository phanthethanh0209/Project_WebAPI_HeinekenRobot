namespace TheThanh_WebAPI_RobotHeineken.DTO
{
    public class ListLocationResponse
    {
        public int TotalLocations { get; set; }
        public int TotalLocationsWithCampaigns { get; set; }
        public int OperatingDeviceCount { get; set; }
        public List<LocationDTO>? LocationDTOs { get; set; }
    }
}
