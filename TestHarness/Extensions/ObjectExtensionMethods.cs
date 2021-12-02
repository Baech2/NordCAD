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
                var attributesForProperty = childProperty.GetCustomAttributes(typeof(MatchParentAttibute), true);
                // Boolean som bruges til tjek/if senere.
                var isOfTypeMatchParentAttribute = false;

                //instance af MatchParentAttribute som skal bruges til tjek/if, når der skal sammenlignes navne på properties.
                MatchParentAttibute currentAttribute = null;
                //foreach på attributesForProperty for at finde hver enkel attibute.
                foreach (var attribute in attributesForProperty)
                {
                    //Tjek om attribute type er MatchParentAttribute.
                    if (attribute.GetType() == typeof(MatchParentAttibute))
                    {
                        //Hvis attribute type er MatchParentAttibute skal isOfTypeMatchParentAttrbute sættes til true.
                        isOfTypeMatchParentAttribute = true;
                        //currentAttribute indeholder den nu værende attribute.
                        currentAttribute = (MatchParentAttibute)attribute;
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

                    //Få fat i hver enkelt Property fra parentProperties.
                    foreach (var parentProperty in parentProperties)
                    {

                        switch (currentAttribute.ParentPropertyName)
                        {
                            case "pp":
                                if (parentProperty.Name == currentAttribute.ParentPropertyName)
                                {
                                    //Tjek om PropertyType er ens.
                                    if (parentProperty.PropertyType == childProperty.PropertyType)
                                    {
                                        //hvis både Name og PropertyType er ens skal value tilføjes til parentPropertyValue som bruges til SetValue udenfor Loop.
                                        parentPropertyValue = parentProperty.GetValue(parent);
                                        //Her bliver pp splittet ved mellemrummet i property value. 
                                        MySplitter ppArray = new MySplitter((string)parentPropertyValue);
                                        //Derefter skal de 2 koordinater deles mellem StartX og StartY. Type på CADint class er "string" og "long" i capture class/dsn Hvilket betyder at value skal castes til "long".
                                        var ppX = ppArray.NamedPartX;
                                        var ppY = ppArray.NamedPartY;
                                        //Både X og Y skal gemmes til startX og startY. but how??
                                    }
                                }
                                else
                                {
                                    //parentPropertyValue indeholder value fra parentProperty. Skal bruges til MatchPropertiesFrom.
                                    parentPropertyValue = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                    //MatchPropertiesFrom companyParent til orginstance.
                                    self.MatchPropertiesFrom(parentPropertyValue);
                                }
                                break;
                            case "dxy":
                                object dxyToSplit = parentProperty.GetValue(parent);
                                //Her bliver dxy splittet ved mellemrummet i property value. dxy er deltaX og deltaY. Den skal os deles ud over 2 properties.
                                MySplitter dxyArray = new MySplitter((string)dxyToSplit);
                                //object testcase2 = parentProperty.GetValue(parent);
                                //string[] testsubs2 = testcase2.ToString().Split(' ');
                                var deltaX = dxyArray.NamedPartX;
                                var deltaY = dxyArray.NamedPartY;
                                //Både X og Y skal gemmes på child/self. (Dsn object)
                                break;
                        }

                        //Tjek om parentProperty.Name stemmer overens med currentAttibute.ParentPropertyName. Så hvis parentProperty.Name stemmer overens med det navn der er sat i vores CustomAttibute skal der laves tjek på PropertyType.
                        if (parentProperty.Name == currentAttribute.ParentPropertyName)
                        {
                            //Tjek om PropertyType er ens.
                            if (parentProperty.PropertyType == childProperty.PropertyType)
                            {
                                //hvis både Name og PropertyType er ens skal value tilføjes til parentPropertyValue som bruges til SetValue udenfor Loop.
                                parentPropertyValue = parentProperty.GetValue(parent);
                            }
                            //Tjekker om det er en liste vi har med at gøre.
                            else if (IsList(parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null).GetType()))
                            {
                                //companyParent bruges til at holde listen som kommer fra parent.
                                object companyParent = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                //orgInstance bruges til at indeholde listen fra child/self.
                                Object orgInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));

                                //Her laves der en instance af child/self listen.
                                Object instance = Activator.CreateInstance(orgInstance.GetType());
                                //Oprettelse af liste som bruges til at tilføje Instances til, samt gemmes til i SetValue, efter tilføjelse til parentPropertyValue.
                                IList list = (IList)instance;

                                //foreach over companyParent for at få fat i hver genstand på listen. Hold øje med hvorvidt IList er optimal for det enlige projekt.
                                foreach (var compparentItem in (IEnumerable)companyParent)
                                {
                                    //Dette giver en liste af "type". Hvilket skal findes for at kunne oprette en instance af list item.
                                    var TFromList = orgInstance.GetType().GetGenericArguments();
                                    //Oprette en instance af hvad der er på listen.
                                    Object orgChildInstance = Activator.CreateInstance(TFromList[0]);

                                    //Kør MatchPropertiesFrom med compparentItem som er en instance af en genstand på parent listen.
                                    //orgChildInstance er en instance af child/self list item. Hvilket betyder at det er her list items bliver matched.
                                    orgChildInstance.MatchPropertiesFrom(compparentItem);
                                    //Tilføjelse af det matched orgChildInstance til list(instance af child/self list)
                                    list.Add(orgChildInstance);
                                }
                                //Tilføjelse til parentPropertyValue som bruges til setvalue udenfor loop.
                                parentPropertyValue = list;
                            }
                            else
                            {
                                //companyParent indeholder value fra parentProperty. Skal bruges til MatchPropertiesFrom.
                                var companyParent = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                //orgInstance er en instance af chdilproperty. Skal bruge til MatchPropertiesFrom.
                                Object orgInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));
                                //MatchPropertiesFrom companyParent til orginstance.
                                orgInstance.MatchPropertiesFrom(companyParent);
                                //parentPropertyValue sættes lige med det "nye" orgInstance. 
                                parentPropertyValue = orgInstance;
                                break;
                            }
                        }
                    }
                    try
                    {
                        //Tilføj value af parentPropertyValue til self.
                        childProperty.SetValue(self, parentPropertyValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error when saving data(SetValue). Error massage: " + ex);
                        throw;
                    }
                }
                else
                {
                    if (!IsSimple(childProperty.PropertyType))
                    {
                        try
                        {
                            if (IsList(childProperty.PropertyType))
                            {
                                //Do stuff
                                Object childPropertyInstance = Array.CreateInstance(childProperty.PropertyType.GetElementType(), 7);
                                childProperty.SetValue(self, childPropertyInstance);
                                Console.WriteLine(childProperty.Name + " do not contain a Custom Attribute of the type 'MatchParentAttribute'. " + childProperty.Name + " was created");
                            }
                            else
                            {
                                Object childInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));
                                childProperty.SetValue(self, childInstance);
                                childInstance.MatchPropertiesFrom(parent);
                                Console.WriteLine(childProperty.Name + " do not contain a Custom Attribute of the type 'MatchParentAttribute'. " + childProperty.Name + " was created");
                            }
                        }
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
              || type.Equals(typeof(decimal));
        }

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

        public static Type GetCollectionElementType(Type type)
        {
            if (null == type)
                throw new ArgumentNullException("type");

            // first try the generic way
            // this is easy, just query the IEnumerable<T> interface for its generic parameter
            var etype = typeof(IEnumerable<>);
            foreach (var bt in type.GetInterfaces())
                if (bt.IsGenericType && bt.GetGenericTypeDefinition() == etype)
                    return bt.GetGenericArguments()[0];

            // now try the non-generic way

            // if it's a dictionary we always return DictionaryEntry
            if (typeof(System.Collections.IDictionary).IsAssignableFrom(type))
                return typeof(System.Collections.DictionaryEntry);

            // if it's a list we look for an Item property with an int index parameter
            // where the property type is anything but object
            if (typeof(System.Collections.IList).IsAssignableFrom(type))
            {
                foreach (var prop in type.GetProperties())
                {
                    if ("Item" == prop.Name && typeof(object) != prop.PropertyType)
                    {
                        var ipa = prop.GetIndexParameters();
                        if (1 == ipa.Length && typeof(int) == ipa[0].ParameterType)
                        {
                            return prop.PropertyType;
                        }
                    }
                }
            }

            // if it's a collection we look for an Add() method whose parameter is 
            // anything but object
            if (typeof(System.Collections.ICollection).IsAssignableFrom(type))
            {
                foreach (var meth in type.GetMethods())
                {
                    if ("Add" == meth.Name)
                    {
                        var pa = meth.GetParameters();
                        if (1 == pa.Length && typeof(object) != pa[0].ParameterType)
                            return pa[0].ParameterType;
                    }
                }
            }
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                return typeof(object);
            return null;
        }
    }

}
