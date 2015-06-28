using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Math
{
	class GPS
	{
		/// <summary>
		/// Returns the distance in km between 2 GPS latitude / longitude points.
		/// </summary>
		/// <remarks>Based on http://www.codecodex.com/wiki/Calculate_Distance_Between_Two_Points_on_a_Globe#C.23 </remarks>
		public static double GpsDistance(double pos1Latitude, double pos1Longitude, double pos2Latitude, double pos2Longitude)
		{
			double R = 6371;    // radius of Earth in kilometer
								//Radian = (Math.PI / 180) *
			double dLat = (System.Math.PI / 180) * (pos2Latitude - pos1Latitude);
			double dLon = (System.Math.PI / 180) * (pos2Longitude - pos1Longitude);
			double a = System.Math.Sin(dLat / 2) * System.Math.Sin(dLat / 2) +
				 System.Math.Cos((System.Math.PI / 180) * (pos1Latitude)) * System.Math.Cos((System.Math.PI / 180) * (pos2Latitude)) *
				 System.Math.Sin(dLon / 2) * System.Math.Sin(dLon / 2);
			double c = 2 * System.Math.Asin(System.Math.Min(1, System.Math.Sqrt(a)));
			double d = R * c;
			return d;
		}
	}
}
