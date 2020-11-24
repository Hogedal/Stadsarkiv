using Stadsarkiv.Domain;
using Stadsarkiv.Utils;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Stadsarkiv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til data type validering");
            string filePath;
            while (true)
            {
                Console.WriteLine("Indtast venligst filsti til arkiveringsversionen du ønsker analyseret");
                filePath = Console.ReadLine();
                if(CheckPath(filePath))
                {
                    break;
                }
                Console.WriteLine("Ugyldig filsti...");
            }
            var TableIndex = LoadTableIndex(filePath);

            foreach (var table in TableIndex.Tables)
            {
                Console.WriteLine($"Påbegynder validerings a tabel {table.Name}");
                ValidateTable(table,filePath);
            }
            Console.WriteLine("Validering færdig. Tryk en vilkærlig tast for at afslutte...");
            Console.ReadKey();

        }

        private static bool CheckPath(string filePath)
        {
            if (!Directory.Exists(filePath))
                return false;
            //TODO: Verify that folder structure matches expectation
            return true;
        }
        private static TableIndex LoadTableIndex(string filePath)
        {
            var indexPath = $"{filePath}\\Indices\\tableIndex.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(TableIndex));

            TableIndex index;

            using (Stream reader = new FileStream(indexPath, FileMode.Open))
            {
                index = (TableIndex)serializer.Deserialize(reader);
            }

            return index;
        }
        private static void ValidateTable(Table table, string filePath)
        {
            var tablePath = $"{filePath}\\Tables\\{table.Folder}\\{table.Folder}.xml";
            var xDoc = XDocument.Load(tablePath);
            int rowCount = 1;
            int erCount = 0;
            var rows = xDoc.Root.Elements();
            foreach (var row in rows)
            {
                foreach (var column in table.Columns)
                {
                    var columnValue = (string)row.Elements().First(x => x.Name.LocalName == column.ColumnID);
                    if (!DatatypeValidator.Validate(columnValue, column.Type))
                    {
                        Console.WriteLine($"Table {table.Name}: Column {column.ColumnID} of row {rowCount} does not conform to type {column.Type}");
                        erCount++;
                    }
                }
                rowCount++;
            }
            Console.WriteLine($"Færdig, {erCount} validerings fejl fundet i {rowCount} rækker");
        }
    }
}
