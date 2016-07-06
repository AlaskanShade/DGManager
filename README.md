# DGManager
DGManager.NET is a management utility for the GlobalSat DG-100 GPS datalogger. It provides additional 
features such as allowing you to geocode / geotag photos. Requires the .NET Framework 4.5. NEW: It can 
now be used with any GPX file!  Migrated from: https://sourceforge.net/projects/dgmanager-net/

This program can also handle working with a number of different file formats of spatial data.  Most formats can also be written to.  It is also possible to create plugins with converters by putting a DLL in the same folder with a class that implements IPointReader and/or IPointWriter in the DGManager.Backend library.

| Type/Extension | Support | Sample | Notes |
| --- | --- | --- | --- |
| GPS Exchange Format (.gpx) | Read/Write | [20120607_West_Glacier.gpx](Samples/20120607_West_Glacier.gpx) |  |
| GlobalSat Data File (.gsd) | Read/Write | [20110713.gsd](Samples/20110713.gsd) |  |
| Google Earth (.kml) | Read/Write | [KML_Samples.kml](Samples/KML_Samples.kml) |  |
| Google Map (.htm,.html,.js) | Read/Write | [GoogleMaps.htm](Samples/GoogleMaps.htm) | HTML files generated by DGManager can be read back in. |
| TopoGrafix Data File (.loc) | Write |  | Not commonly used any longer.  Replaced by GPX. |
| NMEA Data (.log,.nmea) | Read/Write | [GPS_20121104_134730.log](Samples/GPS_20121104_134730.log) | Used by GPS loggers. |
| OziExplorer Track File (.plt) | Read/Write |  |  |
| OziExplorer Waypoint File (.wpt) | Write | [sample.wpt](Samples/sample.wpt) |  |
| OpenLayers File (.osm) | Read | [display-osm.osm](Samples/display-osm.osm) |  |
| Polish Map Format (.mp) | Read |  |  |
| POI File (.poi) | Write |  |  |
| TomTom POI File (.ov2) | Read/Write | [aplant.ov2](Samples/aplant.ov2) |  |
| MapExpert 2.0 (.ovl) | Read/Write | [sample.ovl](Samples/sample.ovl) |  |
| Comma Separated Values (.csv) | Read/Write | [2012-06-07.csv](Samples/2012-06-07.csv) | Works with these columns: Record Number,Date,Time,Latitude,Longitude,Speed(km/h),Altitude(meters) |
| Text File (.txt) | Write |  | Tab delimited data similar to the CSV format |
| Border Points Ascii (.asc) | Read | [bordpnts.asc](Samples/bordpnts.asc) | One-off format for reading in state borders from <http://www.econ.umn.edu/~holmes/data/BorderData.html> |

This project was originally created by Reuben Bluff and hosted on SourceForge here: https://sourceforge.net/projects/dgmanager-net/  
I hope by posting it here the code will be more accessible to make modifications and improvements.