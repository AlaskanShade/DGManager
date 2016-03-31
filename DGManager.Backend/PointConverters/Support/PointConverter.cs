using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.ComponentModel;

namespace DGManager.Backend
{
    public delegate void LogHandler(string message);
    public delegate void ProgressHandler(int progress);

    public static class PointConverter
    {
        private static Dictionary<string, IPointReader> readers = new Dictionary<string, IPointReader>();
        private static Dictionary<string, IPointWriter> writers = new Dictionary<string, IPointWriter>();
        public static string openFileFilter, saveFileFilter;

        private static List<string> openExts = new List<string>();
        private static List<string> saveExts = new List<string>();
        private static List<string> openFilters = new List<string>();
        private static List<string> saveFilters = new List<string>();

        static PointConverter()
        {
            //ScanAssembly(Assembly.GetExecutingAssembly());
            foreach (string file in Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll"))
            {
                if (file.Contains("exivsimple")) continue;
                try
                {
                    ScanAssembly(Assembly.LoadFile(file));
                }
                catch (BadImageFormatException)
                {
                    // Found a library that is not .Net.  Ignore it
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            openFileFilter = String.Format("All Supported Types|{0}|{1}", String.Join(";", openExts.ToArray()), String.Join("|", openFilters.ToArray()));
            saveFileFilter = String.Format("All Supported Types|{0}|{1}", String.Join(";", saveExts.ToArray()), String.Join("|", saveFilters.ToArray()));
        }

        private static void ScanAssembly(Assembly assembly)
        {
            PointConverterAttribute pointAttr;
            IPointReader reader;
            IPointWriter writer;

            Array.ForEach(assembly.GetTypes(), t => Array.ForEach(t.GetCustomAttributes(typeof(PointConverterAttribute), false), a =>
                                                    {
                                                        if ((pointAttr = a as PointConverterAttribute) != null)
                                                        {
                                                            object o = Assembly.GetExecutingAssembly().CreateInstance(t.FullName);
                                                            if ((reader = o as IPointReader) != null)
                                                            {
                                                                openFilters.Add(string.Format("{0}|*{1}", pointAttr.Description, String.Join(";*", pointAttr.Extensions.Split(','))));
                                                                Array.ForEach(pointAttr.Extensions.Split(','), ext =>
                                                                {
                                                                    openExts.Add(String.Format("*{0}", ext));
                                                                    readers.Add(ext, reader);
                                                                });
                                                            }
                                                            if ((writer = o as IPointWriter) != null)
                                                            {
                                                                saveFilters.Add(string.Format("{0}|*{1}", pointAttr.Description, String.Join(";*", pointAttr.Extensions.Split(','))));
                                                                Array.ForEach(pointAttr.Extensions.Split(','), ext =>
                                                                {
                                                                    saveExts.Add(String.Format("*{0}", ext));
                                                                    writers.Add(ext, writer);
                                                                });
                                                            }
                                                        }
                                                    }));
        }

        public static List<PointOfInterestList> ParseFiles(string[] filenames)
        {
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            PointReaderArgs args = new PointReaderArgs(filenames);
            Array.ForEach(filenames, filename =>
            {
                if (readers.ContainsKey(Path.GetExtension(filename).ToLower()))
                    tracks.AddRange(readers[Path.GetExtension(filename).ToLower()].ParseFile(filename, args));
            });
            return tracks;
        }

        public static void ParseFilesAsync(object sender, DoWorkEventArgs e)
        {
            PointReaderArgs args = e.Argument as PointReaderArgs;
            if (args == null) return;
            string[] filenames = args.Filenames;
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            int i = 1;
            Array.ForEach(filenames, filename =>
            {
                if (readers.ContainsKey(Path.GetExtension(filename).ToLower()))
                {
                    args.Log(String.Format("Reading file: {0}", Path.GetFileName(filename)));
                    tracks.AddRange(readers[Path.GetExtension(filename).ToLower()].ParseFile(filename, args));
                }
                args.ReportProgress(i);
                i++;
            });
            e.Result = tracks;
        }

        public static void SaveFile(PointWriterArgs args)
        {
            if (writers.ContainsKey(Path.GetExtension(args.Filename).ToLower()))
                writers[Path.GetExtension(args.Filename).ToLower()].WriteFile(args);
        }

        public static void SaveFileAsync(object sender, DoWorkEventArgs e)
        {
            PointWriterArgs args = e.Argument as PointWriterArgs;
            if (args == null) return;
            if (writers.ContainsKey(Path.GetExtension(args.Filename).ToLower()))
                writers[Path.GetExtension(args.Filename).ToLower()].WriteFile(args);
        }
    }
}
