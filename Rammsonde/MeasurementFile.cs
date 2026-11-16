using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rammsonde
{
    /// <summary>
    /// Lesen und Schreiben des Messdatenformats: eine Zeile pro Messpunkt,
    /// "&lt;Tiefe_cm&gt; &lt;Schläge_bzw_Sekunden&gt;", durch Leerzeichen getrennt.
    /// </summary>
    public static class MeasurementFile
    {
        public static SortedDictionary<int, int> Parse(IEnumerable<string> lines)
        {
            SortedDictionary<int, int> data = [];
            int lineNum = 0;
            foreach (string rawLine in lines)
            {
                lineNum++;
                string line = rawLine.Trim();
                if (line.Length == 0)
                    continue;

                string[] parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2 || !int.TryParse(parts[0], out int depth) || !int.TryParse(parts[1], out int value))
                    throw new FormatException($"Ungültiges Format in Zeile {lineNum}:\n\"{rawLine}\"");
                if (depth <= 0 || value < 0)
                    throw new FormatException($"Ungültiger Wert in Zeile {lineNum}:\n\"{rawLine}\"");

                data[depth] = value;
            }
            return data;
        }

        public static IEnumerable<string> Serialize(IEnumerable<KeyValuePair<int, int>> data) =>
            data.OrderBy(e => e.Key).Select(e => $"{e.Key} {e.Value}");

        public static SortedDictionary<int, int> Load(string path) => Parse(File.ReadLines(path));

        public static void Save(string path, IEnumerable<KeyValuePair<int, int>> data) =>
            File.WriteAllLines(path, Serialize(data));
    }
}
