using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestHarness.Extensions
{
    public static class ObjectExtensionMethods
    {
        public static void CopyPropertiesFrom(this object self, object parent)
        {
            var fromProperties = parent.GetType().GetProperties();
            var toProperties = self.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    if (fromProperty.Name == toProperty.Name && fromProperty.PropertyType == toProperty.PropertyType)
                    {
                        toProperty.SetValue(self, fromProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }

        public static void MatchPropertiesFrom(this object self, object parent)
        {
            //Få en liste af properties fra self/child.
            var childProperties = self.GetType().GetProperties();
            //foreach childproperties for at få fat på en enkelt property.
            foreach (var childProperty in childProperties)
            {
                //Få fat i CustomAttribute af type MatchParentAttribute. Hvilket vil sige at den får fat på den customAttribute som vi har lavet.
                var attributesForProperty = childProperty.GetCustomAttributes(typeof(MatchParentAttribute), true);
                // Boolean som bruges til tjek/if senere.
                var isOfTypeMatchParentAttribute = false;

                //instance af MatchParentAttribute som skal bruges til tjek/if, når der skal sammenlignes navne på properties.
                MatchParentAttribute currentAttribute = null;
                //foreach på attributesForProperty for at finde hver enkel attibute.
                foreach (var attribute in attributesForProperty)
                {
                    //Tjek om attribute type er MatchParentAttribute.
                    if (attribute.GetType() == typeof(MatchParentAttribute))
                    {
                        //Hvis attribute type er MatchParentAttribute skal isOfTypeMatchParentAttrbute sættes til true.
                        isOfTypeMatchParentAttribute = true;
                        //currentAttribute indeholder den nu værende attribute.
                        currentAttribute = (MatchParentAttribute)attribute;
                        //Hvis koden når her til skal dette foreach loop brudes.
                        break;
                    }
                }
                //Tjek om isOfTypeMatchParentAttribute er true. Altså om attributes er ens.
                if (isOfTypeMatchParentAttribute == true)
                {
                    //Liste af parentProperties som kan bruges i en foreach.
                    var parentProperties = parent.GetType().GetProperties();
                    //parentPropertyValue bruges til SetValue udenfor loop.
                    object parentPropertyValue = null;
                    //parentPropertyValue2 er lavet for at tage højde for koordinator som er placeret i samme property som f.eks pp og dxy.
                    object parentPropertyValue2 = null;
                    //Format bliver brugt til convert af en string til en double og derefter til en long. Det er ved hjælp af dette at value af long bliver afrundet.
                    //Her skal jeg læse mere op på hvad NumberFormatInfo benytter sig af for at afrunde den pågældende værdi.
                    var format = new NumberFormatInfo();
                    format.NumberDecimalSeparator = ".";
                    format.NegativeSign = "-";
                    //switch til at håndterer når currenAttribute.ParentPropertyName stemmer over ens med en af disse cases.
                    switch (currentAttribute.ParentPropertyName)
                    {
                        //Gamle cases er at finde i codesnippets.
                        //Denne case bliver brugt til at komme ind i strukturen af parent for så at matchpropertiesfrom childpropertyInstance som er en instance af childproperty
                        case "schDesignSymbolBody":
                            childProperty.TBA2(parentProperties, parent, self, currentAttribute);
                            break;
                        case "schDesignSymbolBodyRect":
                            childProperty.TBA2(parentProperties, parent, self, currentAttribute);
                            break;
                        case "schDesignSymbolBodyArc":
                            childProperty.TBA2(parentProperties, parent, self, currentAttribute);
                            break;
                        case "schDesignSymbolBodyLine":
                            TBA(parentProperties, parent, childProperty, self, currentAttribute);
                            break;
                        case "pp":
                            var longValueArrayPP = ConvertToLong(parent, parentProperties, currentAttribute, 2);
                            parentPropertyValue = longValueArrayPP[0];
                            foreach (var childPropertyY in childProperties)
                            {
                                if (childPropertyY.Name == "y1")
                                {
                                    parentPropertyValue2 = longValueArrayPP[1];
                                    childPropertyY.SetValue(self, parentPropertyValue2);
                                    break;
                                }
                            }
                            break;
                        case "dxy":
                            var longValueArrayDXY = ConvertToLong(parent, parentProperties, currentAttribute, 2);
                            parentPropertyValue = longValueArrayDXY[0];
                            foreach (var childPropertyY in childProperties)
                            {
                                if (childPropertyY.Name == "y2")
                                {
                                    parentPropertyValue2 = longValueArrayDXY[1];
                                    childPropertyY.SetValue(self, parentPropertyValue2);
                                    break;
                                }
                            }
                            break;
                        case "pk":
                            //Version 1.
                            #region
                            //foreach (var parentProperty in parentProperties)
                            //{
                                //if (parentProperty.Name == currentAttribute.ParentPropertyName)
                                //{
                                    
                                    //parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                    //string[] results = parentPropertyValue.ToString().Split(' ');
                                    //double parseStringToDoubleY2 = double.Parse(results[1], format);
                                    //long y2 = Convert.ToInt64(parseStringToDoubleY2, format);


                                    //break;

                                 //}
                            //}   
                            #endregion
                            //Version 2.
                            //ConvertToLongY er en metode som kan findes i bunden af dette dokument. Den håndtere convert fra string til long(først double, så long).
                            //1 er y i koodinatsættet pk. ALtså y er den som ikke er 0.
                            var parentPropertyValueY = ConvertToLong(parent, parentProperties, currentAttribute, 1); 
                            parentPropertyValue = parentPropertyValueY[1];
                            break;
                        case "pk1":
                            //0 er x koordinatsættet i pk1. Altså x er den som ikke er 0.
                            var parentPropertyValueX = ConvertToLong(parent, parentProperties, currentAttribute, 0);
                            parentPropertyValue = parentPropertyValueX[0];
                            break;
                    }

                    //Tilføj value af parentPropertyValue til self.
                    try
                    {
                        childProperty.SetValue(self, parentPropertyValue);
                        //parentPropertyValue2 bliver gems i casen.
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error when saving data(SetValue). Error massage: " + ex);
                        throw;
                    }
                }
                //Hvis ikke isOfTypeMatchParentAttribute er true skal strukturen af child objectet opbygges ved hjælp af rekrusiv kode.
                else
                {
                    //Hvis childproperty.propertyType ikke er simple dvs string, long, int eller lignede skal det gå ind i if'en
                    if (!IsSimple(childProperty.PropertyType))
                    {
                        //try/catch i tilfælde af der forekommer errors som skal håndteres.
                        try
                        {
                            //Hivs det er en liste.
                            if (IsList(childProperty.PropertyType))
                            {
                                //Lav array instance of childproperty, som udgangspunkt er der 7 pladser i arrayet.
                                object childPropertyInstance = Array.CreateInstance(childProperty.PropertyType.GetElementType(), 7);
                                //Gem det array på self/child objectet.
                                if(childProperty.PropertyType == typeof(object[]))
                                {
                                    
                                    var Items = self.GetType().GetProperty("Items");
                                    XmlElementAttribute[] attribs = (XmlElementAttribute[])Attribute.GetCustomAttributes(Items, typeof(XmlElementAttribute));
                                     
                                }
                                childProperty.SetValue(self, childPropertyInstance);
                            }
                            //Hvis det er en complex type. (Class)
                            else
                            {
                                //Lav object instance af childproperty baseret på det fulde navn af propertyType.
                                object childInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));
                                //Gem dette object på self/child objectet.
                                childProperty.SetValue(self, childInstance);
                                //MatchPropertiesFrom parent til childInstance i et forsøg på at få så mange values med som muligt.
                                childInstance.MatchPropertiesFrom(parent);
                            }
                        }
                        //Hvis der forekommer nogen errors i forsøget på at opbygge strukturen af objectet bliver den error udskrevet i console, så koden kan tilpasses som der er brug for.
                        catch (Exception ex)
                        {
                            Console.WriteLine("--------------Exception(" + childProperty.Name + ")--------------");
                            Console.WriteLine("Exception: " + ex);
                            Console.WriteLine("-------------------------------------");
                        }
                    }
                }
            }
        }
        //Metode for at fastslå om en Type er simple(String, int, long eller ligneden)
        public static bool IsSimple(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimple(typeInfo.GetGenericArguments()[0]);
            }
            return typeInfo.IsPrimitive
              || typeInfo.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(long))
              || type.Equals(typeof(int))
              || type.Equals(typeof(float))
              || type.Equals(typeof(double))
              || type.Equals(typeof(bool))
              || type.Equals(typeof(decimal));
        }
        //Metode for at fastslå om en Type er en liste
        public static bool IsList(Type type)
        {
            if (null == type)
                throw new ArgumentNullException("type");

            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                return true;
            foreach (var it in type.GetInterfaces())
                if (it.IsGenericType && typeof(IEnumerable<>) == it.GetGenericTypeDefinition())
                    return true;
            return false;
        }
        public static void TBA2(this PropertyInfo childPropertyself, PropertyInfo[] parentProperties, object parent, object captureSelf, MatchParentAttribute currentAttribute)
        {
            //Foreach af parentProperties som er sendt med fra MatchProprtiesFrom. Navnet er uændret.
            foreach (PropertyInfo parentProperty in  (IEnumerable)parentProperties)
            {
                //Hvis det ikke er null, fortsæt.
                if (parentProperty != null)
                {
                    //Finder value af parentProperty.
                    object valueOfParentProperty = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                    //hvis det ikke er null, fortsæt.
                    if (valueOfParentProperty != null)
                    {
                        //Hvis valueOfParentProperty er en liste, fortsæt.
                        if (IsList(valueOfParentProperty.GetType()))
                        {
                            //Foreach over hvert element i valueOfParentProperty. Eftersom jeg ved at det er en liste kan det castes som værende IEnumerabble.
                            foreach (var propertyOfvalue in (IEnumerable)valueOfParentProperty)
                            {
                                //Hvis det er en complex type, fortsæt.
                                if (!IsSimple(propertyOfvalue.GetType()))
                                {
                                    //hvis navnet på propertyOfValue er ens med currentAttribute.ParentPropertyName, fortsæt.
                                    if (currentAttribute.ParentPropertyName == propertyOfvalue.GetType().Name)
                                    {
                                        //Hjælp: dette skal bruges til at kunne gemme childinstance til items listen. Men de er forskellige types og kan ikke ikke se hvordan det skal ændres så det virker
                                        var Items = captureSelf.GetType().GetProperty("Items");
                                        XmlElementAttribute[] attribs = (XmlElementAttribute[])Attribute.GetCustomAttributes(Items, typeof(XmlElementAttribute));

                                        //Opret en instance af childpropertySelf, for at gemme den til captureself/self(fra MatchPropertiesFrom).
                                        object childInstance = Activator.CreateInstance(Type.GetType(childPropertyself.PropertyType.FullName));
                                        //SetValue.
                                        childPropertyself.SetValue(captureSelf, childInstance);
                                        //MatchPropertiesFrom propertyOfValue til childinstance. For hvis navnet er korrekt har det os nogle simple types på sig som skal matches til sin modstykke i CADint.
                                        childInstance.MatchPropertiesFrom(propertyOfvalue);
                                    
                                    }
                                //Hvis propertyOfValue's navn ikke er ens med ParentPropertyName skal der laves en liste af dens properties som bruges i ChildPropertySelf.TBA2().
                                PropertyInfo[] propertiesOfPropertyOfList = propertyOfvalue.GetType().GetProperties();
                                childPropertyself.TBA2(propertiesOfPropertyOfList, propertyOfvalue, captureSelf, currentAttribute);
                                
                                }
                            }
                            
                        }
                        //Hvis valueOfParentProperty ikke er en liste og hvis det er en complex type, fortsæt.
                        else if (!IsSimple(valueOfParentProperty.GetType()))
                        {
                            //Hvis valueOfParentProperty's navn er ens med ParentPropertyName fra currentAttribute, fortsæt.
                            if (currentAttribute.ParentPropertyName == valueOfParentProperty.GetType().Name)
                            {
                                //Opret en instance af childpropertyself som skal bruges til setvalue og MatchPropertiesFrom. Ligesom det er blevet gjort ovenover.
                                object childInstance = Activator.CreateInstance(Type.GetType(childPropertyself.PropertyType.FullName));
                                childPropertyself.SetValue(captureSelf, childInstance);
                                childInstance.MatchPropertiesFrom(parent);
                            }
                            PropertyInfo[] propertiesOfValueOfParentProperty = valueOfParentProperty.GetType().GetProperties();
                            foreach (var propertyVar in propertiesOfValueOfParentProperty)
                            {
                                if (IsList(propertyVar.PropertyType))
                                {
                                    childPropertyself.TBA2(propertiesOfValueOfParentProperty, valueOfParentProperty, captureSelf, currentAttribute);
                                }
                            }
                            
                        }
                        if (IsSimple(valueOfParentProperty.GetType()))
                        {
                            childPropertyself.MatchPropertiesFrom(valueOfParentProperty);
                        }
                    }
                }

            }
        }
        //Metode til at håndtere at gå ind i strukturen af parent(CADint).
        public static void TBA(PropertyInfo[] parentProperties, object parent, PropertyInfo childProperty, object self, MatchParentAttribute currentAttribute)
        {
            foreach (PropertyInfo parentProperty in (IEnumerable)parentProperties)
            {
                if (IsList(parentProperty.PropertyType))
                {
                    //Dette object skal bruges til at indeholde en liste af symbol fra CADint
                    object parentPropertySymbolList = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                    foreach (var parentPProperty in (IEnumerable)parentPropertySymbolList)
                    {
                        //Finder properties for parentPProperty, hvilket er en liste som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                        //Denne variabel indeholder properties af parentPropertySymbolList
                        var parentPSLItemProperties = parentPProperty.GetType().GetProperties();

                        foreach (var parentPPProperty in parentPSLItemProperties)
                        {
                            //Dette object indeholder value af SymbolBody(schDesignSymbolBody) fra CADint
                            object parentPPPropertySymbolBody = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);

                            if (parentPPPropertySymbolBody != null)
                            {
                                //Properties af parentPPPropertyValue som skal bruges i den næste foreach for igen at komme ind i strukturen/"træet".
                                //Dette object indeholder value af SymbolBody(schDesignSymbolBody) fra CADint
                                var parentPPPProperties = parentPPPropertySymbolBody.GetType().GetProperties();
                                foreach (var parentPPPProperty in parentPPPProperties)
                                {
                                    //Dette object indeholde en liste af "Items" fra CADint. Items er Arc, Rect, Line, Text etc.
                                    object parentPPPPItemsList = parentPPPropertySymbolBody.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertySymbolBody, null);

                                    //Denne foreach går igennem alle Items og når et Item Name passer med currentAttribute.ParentPropertyName, går den ind i if.
                                    foreach (var objItem in (IEnumerable)parentPPPPItemsList)
                                    {
                                        //Finder her det fulde navn (FullName). Dette fulde navn indeholder et "+" hvilket er hvor jeg vælger at dele det eftersom
                                        //at det så er muligt at checke imod currentAttribute.ParentPropertyName.
                                        var objItemFullName = objItem.GetType().FullName;
                                        string[] splitAtPlus = objItemFullName.ToString().Split('+');
                                        string objItemName = splitAtPlus[1];
                                        if (currentAttribute.ParentPropertyName.Equals(objItemName) == true)
                                        {
                                            //denne instance skal bruges i matchpropertiesfrom for at få adgang til de underliggende properties. pp, pk, pk1
                                            object childPropertyInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));
                                            childProperty.SetValue(self, childPropertyInstance);
                                            //matchPropertiesFrom ObjItem. Dette gøres så det er muligt at tjekke alle properties på "Arc", om de indeholder min Custom Attribute.
                                            childPropertyInstance.MatchPropertiesFrom(objItem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //Version1
        public static long ConvertToLongY(object parent, PropertyInfo[] parentProperties, MatchParentAttribute currentAttribute)
        {
            foreach (PropertyInfo parentProperty in (IEnumerable)parentProperties)
            {
                //Det er nu muligt for mig at finde denne property ved hjælp af den overstående schDesign case. Så derfor er der ingen grund til at lave en masse foreach loops. Jeg kan ganske simplet behandle den property som stemmer over ens med currentAttribute.ParentPropertyName
                if (parentProperty.Name == currentAttribute.ParentPropertyName)
                {
                    //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                    //X og Y i OrCad/Capture er type long, så derfor skal string results parses til en double for så at convert til long. Det er gjort på denne måde for at afrunde value af long variablen.
                    object parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                    if (parentPropertyValue != null)
                    {
                        try 
	                    {	        
		                    //format til double.Parse og Convert.ToInt64(). Her bliver "." og "-" defineret som værende separator og negativ/minus tegn.
                            var format = new NumberFormatInfo();
                            format.NumberDecimalSeparator = ".";
                            format.NegativeSign = "-";
                            //splitter value af parentPropertyValue som er et sæt koordinator.
                            string[] results = parentPropertyValue.ToString().Split(' ');
                            //Først laver jeg en double som kan indeholde hele den korrekte value. Derefter convert til long.
                            double parseStringToDoubleY = double.Parse(results[1], format);
                            long y = Convert.ToInt64(parseStringToDoubleY, format);
                            return y;
	                    }
	                    catch (Exception ex)
	                    {
                            Console.WriteLine("An exception has occurred in trying to convert string to long Y: " +ex);
		                    return 0;
	                    }
                    }
                    else { return 0; }
                }
            }
            return 0;
        }
        //Version2
        public static long[] ConvertToLong(object parent, PropertyInfo[] parentProperties, MatchParentAttribute currentAttribute, int X0orY1orBoth2)
        {
            long[] longarray = new long[2];
            long x = 0;
            long y = 0;
            //int XorYorBoth er tiltænkt at 0 er x, 1 er y og 2 er begge.
            foreach (PropertyInfo parentProperty in (IEnumerable)parentProperties)
            {
                if (parentProperty.Name == currentAttribute.ParentPropertyName)
                {
                    object parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue (parent, null);
                    if (parentPropertyValue != null)
                    {
                        try 
	                    {	        
		                    var format = new NumberFormatInfo();
                            format.NumberDecimalSeparator= ".";
                            format.NegativeSign= "-";
                            string[] results = parentPropertyValue.ToString().Split(' ');
                            if (X0orY1orBoth2 == 0 || X0orY1orBoth2 == 2)
                            {
                                double parseStringToDoubleX = double.Parse(results[0], format);
                                x = Convert.ToInt64(parseStringToDoubleX, format);
                                longarray[0] = x;
                            }
                            if (X0orY1orBoth2 == 1 || X0orY1orBoth2 == 2)
                            {
                                double parseStringToDoubleX = double.Parse(results[1], format);
                                y = Convert.ToInt64(parseStringToDoubleX, format);
                                longarray[1] = y;
                            }
                            return longarray;
	                    }
	                    catch (Exception ex)
	                    {
                            Console.WriteLine("An exception has occurred in trying to convert string to long X: " +ex);
		                    return null;
	                    }
                    }
                    else { return null; }
                }
            }
            return null;
        }
    }

}
