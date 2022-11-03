using System.Diagnostics;
using System.Xml;

int[] array = new int[100000];
Random rnd = new Random();

for (int i = 0; i < array.Length; i++)
{
    array[i] = rnd.Next(200000,5500000);
    //Console.WriteLine(array[i]);
}

String path = "C:\\Users\\Lenovo\\Desktop\\Egyetem\\C#\\file.xml";

// Create a new file in C:\\ dir

XmlTextWriter textWriter = new XmlTextWriter(path, null);
textWriter.WriteStartDocument();
Stopwatch clock = Stopwatch.StartNew();
clock.Start();
textWriter.WriteStartElement("Payments");
for(int i = 0; i < array.Length; i++)
{
    textWriter.WriteStartElement("Payment_" + (i+1));
    textWriter.WriteString(array[i].ToString());
    textWriter.WriteEndElement();
}
textWriter.WriteEndElement();
clock.Stop();
Console.WriteLine(clock.ElapsedMilliseconds);
textWriter.WriteEndDocument();
textWriter.Close();

//Read the xml file

XmlTextReader textReader = new XmlTextReader(path);
textReader.Read();

int[] array2 = new int[100000];
int idx = 0;
Stopwatch clock2 = Stopwatch.StartNew();
clock2.Start();
while (textReader.Read())
{
    int i = idx;
    if (textReader.Value != "")
    {
        array2[i] = Int32.Parse(textReader.Value);
        idx++;
    }
    
}
clock2.Stop();
textReader.Close();
Console.WriteLine(clock2.ElapsedMilliseconds);