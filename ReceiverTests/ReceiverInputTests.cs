using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Receiver;
using Xunit;
namespace ReceiverTests
{
    public class MockConsoleInput : IReceiverInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            int n_rows, n_cols;
            n_rows = 3;
            n_cols = 3;
            var InputFromSender = new List<List<string>>();
            for (int i = 0; i < n_rows; i++)
            {
                var new_row = new List<string>();
                for (int j = 0; j < n_cols; j++)
                {
                    new_row.Add("sample" + i.ToString() + j.ToString());

                }
                InputFromSender.Add(new_row);
            }
            return InputFromSender;
        }
        public void InputExceptionHandler(IEnumerable<IEnumerable<string>> Input)
        {
            if (!Input.Any())
            {
                throw new InvalidDataException();
            }
        }
    }

    public class ReceiverInputTests
    {
        [Fact]
        public void TestExpectingAnIEnumerableWhenCalledWithNumRowsAndNumColsAndData()
        {

            MockConsoleInput mockObject = new MockConsoleInput();
            var ActualTestOutput = (List<List<string>>)mockObject.ReadInput();
            Assert.Equal("sample00", ActualTestOutput[0][0]);
        }
    }
}
