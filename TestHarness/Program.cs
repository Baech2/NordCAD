using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestHarness.Extensions;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Serializer ser = new Serializer();
            string path = string.Empty;
            string xmlInputData = string.Empty;
            string xmlOutputData = string.Empty;

            //Deserialization, Serialization, XmlDocument Create & Save
            #region

            //Console input. FileName og newFileName
            #region
            Console.WriteLine("Enter full filename(located in bin/debug/):");
            //string filename = Console.ReadLine();//The filename
            string filename = "CADintTestSch.schxml";
            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + filename))
            {
                Console.WriteLine("File exists.");
            }
            else
            {
                Console.WriteLine("File does not exist.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine("Enter the new full filename:");
            //string newFileName = Console.ReadLine();//The new filename
            string newFileName = "Test.xml";
            #endregion

            //Tjek om dokumentet kan deserialize.
            Stream fs = new FileStream(filename, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            //XmlSerializer serializer = new XmlSerializer(typeof(Xsd2.dsn.Design));
            XmlSerializer serializer = new XmlSerializer(typeof(CADintMaster.CADintMaster.schDesign));
            if (serializer.CanDeserialize(reader) == true)//Check doc. Can it deserialize
            {
                fs.Close();

                //Find den fulde sti som skal bruges plus fil navnet
                path = Directory.GetCurrentDirectory() + @"\" + filename;
                //find xml dokumentet baseret på stien ovenover.
                xmlInputData = File.ReadAllText(path);

                //Deserialize xml dokumentet/xmlInputData og gør det til Instance af dsn.design/CADintMaster (model)
                CADintMaster.CADintMaster.schDesign model = ser.Deserialize<CADintMaster.CADintMaster.schDesign>(xmlInputData);
                //Xsd2.dsn.Design model = ser.Deserialize<Xsd2.dsn.Design>(xmlInputData);

                //MatchProperties from deserialized xml.
                Xsd2.dsn.Design captureMaster = new Xsd2.dsn.Design();
                captureMaster.MatchPropertiesFrom(model);

                //Serialze model fra det overstående. Samme type som før.
                xmlOutputData = ser.Serialize<CADintMaster.CADintMaster.schDesign>(model); //Serialize the instance of  CADintMaster. Dette giver en CADint xml fil
                //xmlOutputData = ser.Serialize<Xsd2.dsn.Design>(model); //Dette skulle gerne give en OrCad/Capture fil. Undersøg nærmere.

                //xmloutputdata bliver indsat i et xml dokument i denne region.
                #region
                //Oprettelse af et nyt xml dokument.
                XmlDocument doc = new XmlDocument();
                //Tilføj xmlOutputData til det nye xml dokument.
                doc.LoadXml(xmlOutputData); 

                //Settings for xmlWriterSettings. Dette er nødvendigt for at sætte den korrekte UTF8 Encoding.
                XmlWriterSettings settings = new XmlWriterSettings();
                //Sæt encoding til UTF8. false betyder at dette er en encoding uden BOM.
                settings.Encoding = new UTF8Encoding(false); 
                //Denne setting gør blot sådan at det hele ikke bliver smidt ind på en enkelt linje(xml dokumentet).
                settings.Indent = true;
                //Anvendelse af XmlWriter. Create(path, settings).
                using (XmlWriter w = XmlWriter.Create(Directory.GetCurrentDirectory() + @"\" + newFileName, settings))
                {
                    try
                    {
                        //Gemmer det nye xml dokument med den tilføjet sti og settings.
                        doc.Save(w);
                    }
                    //Hvis der sker en exception vil den blive udskrive i console og i dette tilfælde smidt igen.
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error while saving the document:" + ex);
                        throw;
                    }
                }
                #endregion
                Console.WriteLine("Document complete");
                Console.ReadKey();
            }
            else
            {
                fs.Close();
                Console.WriteLine("Document cannot deserialize");
            }

            #endregion

            //Void Method calls
            #region
            //Program t = new Program();
            //CanDeserialize.
            //t.TestDocument("vco.xml", typeof(Xsd2.dsn.Design));

            //FileStream.
            //t.DeserializeObject("vco.xml");

            //XmlNodeReader.
            //XmlDocument doc = new XmlDocument();
            //doc.Load("vco.xml");
            //t.CreateObjectFromXMLDoc(doc);

            //StreamReader.
            //using (var sxmlReader = new StreamReader("vco.xml"))
            //{
            //    var serializer = new XmlSerializer(typeof(dsn2));
            //    dsn2 responseData = (dsn2)serializer.Deserialize(sxmlReader);
            //}
            #endregion


        }
        //void methods
        #region
        //Virker.
        private void DeserializeObject(string filename)
        {
            //instance of XmlSerializer specfing type.
            XmlSerializer serializer = new XmlSerializer(typeof(Xsd2.dsn.Design));

            //Create a TextReader to read the file.
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            TextReader reader = new StreamReader(fs);

            //obj of class
            Xsd2.dsn.Design model = new Xsd2.dsn.Design();
            //dsn2 model = new dsn2();

            //restore the obj
            model = (Xsd2.dsn.Design)serializer.Deserialize(reader);
            //model = (dsn2)serializer.Deserialize(reader);
            //Same error - XML (2,2)
            fs.Close();
        }
        //Virker.
        private void CreateObjectFromXMLDoc(XmlDocument doc)
        {
            var serializer = new XmlSerializer(typeof(Xsd2.dsn.Design));

            String xmlString = doc.OuterXml.ToString();
            XmlNodeReader reader = new XmlNodeReader(doc);

            using (reader)
            {
                Xsd2.dsn obj = (Xsd2.dsn)serializer.Deserialize(reader);
            }
        }
        //Virker.
        private void TestDocument(string filename, Type objType)
        {
            Stream fs = new FileStream(filename, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            XmlSerializer serializer = new XmlSerializer(objType);
            if (serializer.CanDeserialize(reader))
            {
                Object o = serializer.Deserialize(reader);
            }
            fs.Close();

        }
        #endregion

    }

}
