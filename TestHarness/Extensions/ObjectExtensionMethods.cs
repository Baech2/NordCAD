using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                    //switch til at håndterer når currenAttribute.ParentPropertyName stemmer over ens med en af disse cases.
                    switch (currentAttribute.ParentPropertyName)
                    {
                        //Gamle cases er at finde i codesnippets.
                        //Denne case bliver brugt til at komme ind i strukturen af parent for så at matchpropertiesfrom childpropertyInstance som er en instance af childproperty
                        
                        case "schDesignSymbolBodyRect":
                            TBA(parentProperties, parent, childProperty, self, currentAttribute);
                            break;
                        case "schDesignSymbolBodyArc":
                            TBA(parentProperties, parent, childProperty, self, currentAttribute);
                            break;
                        case "schDesignSymbolBodyLine":
                            TBA(parentProperties, parent, childProperty, self, currentAttribute);
                            break;
                        case "pp":
                            //parentPropertyValue(1)/(2) skal bruges senere til at gemme begge koordinatværdier i pp
                            foreach(var parentProperty in parentProperties)
                            {
                            //Det er nu muligt for mig at finde denne property ved hjælp af den overstående schDesign case. Så derfor er der ingen grund til at lave en masse foreach loops.
                            //Jeg kan ganske simplet behandle den property som stemmer over ens med currentAttribute.ParentPropertyName
                                    if (parentProperty.Name == currentAttribute.ParentPropertyName)
                                    {
                                        parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                        //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                        string[] results = parentPropertyValue.ToString().Split(' ');
                                        //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                        long NamedPartX1;
                                        long NamedPartY1;    

                                        bool NamedPartX1Success = Int64.TryParse(results[0], out NamedPartX1);
                                        if (NamedPartX1Success)
                                        {
                                            parentPropertyValue = NamedPartX1;
                                        }
                                        else
                                        {
                                            if (results[0] == null) results[0] = "";
                                            Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                        }
                                        bool NamedPartY1Success = Int64.TryParse(results[1], out NamedPartY1);
                                        foreach (var property in childProperties)
                                        {
                                            if (childProperty.Name == "y1")
                                            {
                                                if (NamedPartY1Success)
                                                {
                                                    parentPropertyValue2 = NamedPartY1;
                                                }
                                                else
                                                {
                                                    if (results[1] == null) results[1] = "";
                                                    Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                                }
                                            }
                                        } 
                                    }
                            }
                            break;
                        case "dxy":
                            //parentPropertyValue(1)/(2) skal bruges senere til at gemme begge koordinatværdier i pp
                            foreach(var parentProperty in parentProperties)
                            {
                            //Det er nu muligt for mig at finde denne property ved hjælp af den overstående schDesign case. Så derfor er der ingen grund til at lave en masse foreach loops. Jeg kan ganske simplet behandle den property som stemmer over ens med currentAttribute.ParentPropertyName
                                    if (parentProperty.Name == currentAttribute.ParentPropertyName)
                                    {
                                        parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                        //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                        string[] results = parentPropertyValue.ToString().Split(' ');
                                        //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                        long NamedPartX1;
                                        long NamedPartY1;    

                                        bool NamedPartX1Success = Int64.TryParse(results[0], out NamedPartX1);
                                        if (NamedPartX1Success)
                                        {
                                            parentPropertyValue = NamedPartX1;
                                        }
                                        else
                                        {
                                            if (results[0] == null) results[0] = "";
                                            Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                        }
                                        bool NamedPartY1Success = Int64.TryParse(results[1], out NamedPartY1);
                                            if (childProperty.Name == "y2")
                                            {
                                                if (NamedPartY1Success)
                                                {
                                                    parentPropertyValue2 = NamedPartY1;
                                                }
                                                else
                                                {
                                                    if (results[1] == null) results[1] = "";
                                                    Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                                }
                                            }
                                    }
                            }  
                            break;
                        case "pk":
                            foreach (var parentProperty in parentProperties)
                                {
                                    if (parentProperty.Name == currentAttribute.ParentPropertyName)
                                    {
                                        parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                        string[] results = parentPropertyValue.ToString().Split(' ');
                                        long NamedPartY2;
                                        bool NamedPartY2Success = Int64.TryParse(results[1], out NamedPartY2);
                                        if (NamedPartY2Success)
                                        {
                                            parentPropertyValue = NamedPartY2;
                                        }
                                        else
                                        {
                                            if(results[1] == null) results[1] = "";
                                            Console.WriteLine("Attempted conversion of '{1}' failed" );
                                        }
                                    }
                                }
                            break;
                        case "pk1":
                            foreach (var parentProperty in parentProperties)
                                {
                                //Det er nu muligt for mig at finde denne property ved hjælp af den overstående schDesign case. Så derfor er der ingen grund til at lave en masse foreach loops. Jeg kan ganske simplet behandle den property som stemmer over ens med currentAttribute.ParentPropertyName
                                    if (parentProperty.Name == currentAttribute.ParentPropertyName)
                                    {
                                        parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                        //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                        string[] results = parentPropertyValue.ToString().Split(' ');
                                        //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                        long NamedPartX2;

                                        bool NamedPartX2Success = Int64.TryParse(results[0], out NamedPartX2);
                                        if (NamedPartX2Success)
                                        {
                                            parentPropertyValue = NamedPartX2;
                                        }
                                        else
                                        {
                                            if (results[0] == null) results[0] = "";
                                            Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                        }

                                    }
                                }
                            break;
                    }

                    //Foreach fjernet herfra og tilføjet til codesnippets

                    //Tilføj value af parentPropertyValue til self.
                    try
                    {
                        childProperty.SetValue(self, parentPropertyValue);
                        //Her checker jeg om parentPropertyValue2 er null. Det gør jeg fordi der er nogen values fra CADint som skal fordeles ud over 2 properties i Orcad/capture. hvis den ikke er null så skal værdien gemmes til self. 
                        if(parentPropertyValue2 != null)
                        {
                            childProperty.SetValue(self, parentPropertyValue2);
                        }
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
    }

}
