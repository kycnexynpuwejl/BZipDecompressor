using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////   MAIN PROCESS   ////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////

Console.Title = "BZipDecompressor";

while (true)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n\nInsert string to decompress:\n");

        string stringToDecompess = Console.ReadLine();

        Console.WriteLine("\n\n" +
                          JValue.Parse(
                              Encoding.UTF8.GetString(
                                  DeCompress(
                                      stringToDecompess
                                  )
                              )).ToString(Formatting.Indented)
        );
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nERROR!\ninput is not a valid Base-64 string\n");
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////     FUNCTIONS    //////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////

static byte[] DeCompress(string zipText)
{
    using (MemoryStream mZipStreamIn = new MemoryStream(Convert.FromBase64String(zipText)))
    {
        using (MemoryStream mZipStreamOut = new MemoryStream())
        {
            BZip2.Decompress(mZipStreamIn, mZipStreamOut, false);
            return mZipStreamOut.ToArray();
        }
    }
}