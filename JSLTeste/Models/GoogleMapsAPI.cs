using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSLTeste.Models
{
    public class GoogleMapsAPI
    {
        static string googleApiKey = "AIzaSyC43OvPgcIqkx5N846tch-o-L3pxziLVCM";
        public string GetAddressCoordenates(string address) 
        {
            try
            {
                var locationService = new GoogleLocationService(googleApiKey);
                var point = locationService.GetLatLongFromAddress(address);
                return (point.Latitude.ToString(CultureInfo.InvariantCulture) + ", " + point.Longitude.ToString(CultureInfo.InvariantCulture));
            }catch(Exception ex)
            {
                return "Geolocation not found / API key invalid";
            }
        }
        public string GetAddressFromTruckDriverObject(TruckDriver truckDriver)
        {
            StringBuilder address = new StringBuilder(truckDriver.Address.Street);
            address.Append(",").Append(truckDriver.Address.Number).Append(" ").Append(truckDriver.Address.City);
            return address.ToString();
        }
    }
}
