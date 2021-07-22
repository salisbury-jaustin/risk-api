using System;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using ExcelDataReader;

namespace Entities
{
    public class Reader
    {
        /* Internalize the location of the excel file. If we store as a field in our class
        we won't have to pass the file path as an arg every time we instantiate or call methods 
        */ 
        private string filePath;
		private FileStream stream;
		private IExcelDataReader reader;

		// Constructor
		public Reader(string table) {
            switch (table) 
            {
                case "dairyrpmaxes":
                    filePath = "..\\Data\\dairyrpmaxes.xlsx";
                    break;
            }
            stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            reader = ExcelReaderFactory.CreateReader(stream);
        } 

        // Private Methods 
        private DataSet getClasses() {
            var result = reader.AsDataSet(new ExcelDataSetConfiguration() 
            {
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    FilterRow = (rowReader) =>
                    {
                        return true;
                    },
                    FilterColumn = (rowReader, ColumnIndex) =>
                    {
                        return true;
                    }

                }
            });
            return result;
        }
        // Public Methods 
        public DataSet GetAllRows() {
            using (reader)
            {
                do
                {
                    // do this...
                } while (reader.Read());
				DataSet result = reader.AsDataSet();
                return result;
            }    
        }
    }
}
