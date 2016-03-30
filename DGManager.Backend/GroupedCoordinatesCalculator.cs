using System.Collections.Generic;

namespace DGManager.Backend
{
  public class GroupedCoordinatesCalculator
  {
    /// <summary>
    /// This static method calculates a list of locations surrounding a center location given the center location
    /// and the number of surrounding locations to calculate. This is particularly useful if you have a bunch of
    /// photos which were all taken at approximately the same location, but you dont want the thumbnails on a map
    /// showing these photos to lie exactly on top of each other. This way all photos will have a slight offset
    /// compared to each other.
    /// </summary>
    /// <param name="centerLocation">the center location to calculate surrounding locations around</param>
    /// <param name="noOfSurroundingLocations">total number of surrounding locations to calculate</param>
    /// <returns></returns>
    public static List<Location> CalculateSurroundingLocations(Location centerLocation, int noOfSurroundingLocations)
    {
      List<Location> result = new List<Location>();
      result.Add(centerLocation);//start by adding center as first item of resulting locations
      double latAdd = 0.0001;
      double lonAdd = 0.0001;
      int switchCounter = 1;
      for (int i = 1; i < noOfSurroundingLocations; i++)//loop only noOfSurroundingLocations - 1 times
      {
        Location location = new Location();

        switch (switchCounter)
        {
          case 1:
            { //1st quadrant
              location.Latitude = centerLocation.Latitude + latAdd;
              location.Longitude = centerLocation.Longitude + lonAdd;
              location.Altitude = centerLocation.Altitude;
              break;
            }
          case 2:
            { //2nd quadrant
              location.Latitude = centerLocation.Latitude - latAdd;
              location.Longitude = centerLocation.Longitude + lonAdd;
              location.Altitude = centerLocation.Altitude;
              break;
            }
          case 3:
            { //3rd quadrant
              location.Latitude = centerLocation.Latitude - latAdd;
              location.Longitude = centerLocation.Longitude - lonAdd;
              location.Altitude = centerLocation.Altitude;
              break;
            }
          case 4:
            { //4th quadrant
              location.Latitude = centerLocation.Latitude + latAdd;
              location.Longitude = centerLocation.Longitude - lonAdd;
              location.Altitude = centerLocation.Altitude;
              break;
            }
        }

        if (switchCounter == 4)
        {  //all 4 cases have been hit, increase added values and reset switch counter
          latAdd += 0.0001;
          lonAdd += 0.0001;
          switchCounter = 1;
        }
        else
          switchCounter++;

        result.Add(location);
      }

      return result;
    }
  }
}
