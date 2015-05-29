using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
    {
    static void Main(string[] args)
        {
        WAUtils.fncPrintLine = AppendTextBox;

        // Configure server
        string authorization = "";
        string serverUrl = "";
        WABarcodeReader reader = new WABarcodeReader(serverUrl, authorization);

        // Configure test
        Test test = new Test();
        // test.showBarcodes = null;                    // suppress show barcodes
        reader.diagCallback = test.DiagCallback;        // Enable display processing status

/*  
            test.bTestDropBox = false;
            test.bTestBase64 = false;
            test.bTestSamplesLocal = false;
            test.bTestSamplesWeb = false;
            test.bTestUtf8 = false;
            test.bTestUtf8Names = false;
*/

        // Test asynchronous API
        test.Run(reader, true);   
        
        // Test synchronous API
        test.Run(reader, false);
        
        WAUtils.printLine("DONE!");
        Console.Write("Hit Enter> "); Console.ReadLine();
        }

    public static void AppendTextBox(string value)
        {
        Console.WriteLine(value);
        }
    }

