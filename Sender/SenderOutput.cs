using System;
using System.Collections.Generic;

namespace Sender
{
    public interface ISenderOutput
    {
        void WriteOutput(IEnumerable<IEnumerable<String>> data);
    }

    public class ConsoleOutput : ISenderOutput
    {
        public void WriteOutput(IEnumerable<IEnumerable<String>> data)
        {
            int n_rows = GetNumberofRows(data);
            int n_columns = GetNumberofColumns(data);
            Console.WriteLine(n_rows);
            Console.WriteLine(n_columns);
            foreach (IEnumerable<String> row in data)
            {
                foreach (String value in row)
                {
                    Console.WriteLine(value);
                }
            }
        }

        public static int GetNumberofColumns(IEnumerable<IEnumerable<String>> data)
        {
            int col_count = 0;
            foreach (IEnumerable<String> row in data)
            {
                foreach (String value in row)
                {
                    col_count++;
                }
                break;
            }
            return col_count;
        }
        public static int GetNumberofRows(IEnumerable<IEnumerable<String>> data)
        {
            int row_count = 0;
            foreach (IEnumerable<String> row in data)
            {
                row_count++;
            }
            return row_count;
        }
    }
}
