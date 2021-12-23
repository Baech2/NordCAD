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
                    //parentPropertyValue2 er lavet for at tage højde for koordinator som er placeret i samme property som f.eks pp og dxy.
                    object parentPropertyValue2 = null;

                    //switch til at håndterer når currenAttribute.ParentPropertyName stemmer over ens med en af disse cases.
                    switch (currentAttribute.ParentPropertyName)
                    {
                        case "pp":
                            SplitStringValueFromCurrentAttribute1(parentProperties, currentAttribute);
                            //Det nedenunder skal kommenteres ud.
                            foreach (var parentProperty in parentProperties)
	                        {
                                //Hvis navne og propertytypes er ens skal pp dele op ved mellemrum og derefter fordeles på 2 variabler på parent(CADint input)
                                if (parentProperty.Name == currentAttribute.ParentPropertyName)
                                {
                                    //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                    string[] results = parentProperty.ToString().Split(' ');
                                    //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                    long NamedPartX;
                                    long NamedPartY;

                                    NamedPartX = long.Parse(results[0]);
                                    NamedPartY = long.Parse(results[1]);
                                                                   
                                    parentPropertyValue = NamedPartX;
                                    //Her opstår et problem da den value som kommer fra CADint er .25 hvilket ikke er et korrekt format for long.
                                    //Hvordan skal det løses? type skal være long og kan derfor ikke tage imod decimal tal.
                                    parentPropertyValue2 = NamedPartY;                                
                                }
                                else
                                {
                                    if (IsList(parentProperty.PropertyType))
	                                {
                                        //En Instance af parentProperty. Som i dette tilfælde er en liste efter overstående if. Kører derefter en foreach over denne liste for at komme dybere ind i strukturen.
                                        //Instance er det samme som value eftersom den benytter sig af getvalue.
                                        object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                        //parentPProperty == parent Property Property etc.
                                        foreach (var parentPProperty in (IEnumerable)parentPropertyInstance)
	                                    {
                                            //Finder properties for parentPProperty, hvilket er en liste som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                                            var parentPPProperties = parentPProperty.GetType().GetProperties();
                                            foreach (var parentPPProperty in parentPPProperties)
	                                        {
                                                //Find value for parentPPProperty for at få adgang til body fra schDesignSymbol eftersom det indeholder "items" som er hvad jeg er ude efter at lave foreach over for at nå helt ind til "pp".
                                                object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);
                                                if (parentPPPropertyValue != null)
                                                {
                                                    //Find properties for parentPPPProperty, som i dette tilfælde er et object array af "items".
                                                    var parentPPPProperties = parentPPPropertyValue.GetType().GetProperties();
                                                    foreach(var parentPPPProperty in parentPPPProperties)
                                                    {
                                                        //Få fat på value af object item array
                                                        object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                                        //foreach over hvert item i object array.
                                                        foreach(var objItem in (IEnumerable)parentPPPPInstance)
                                                        {
                                                            //Find properties for objItem.
                                                            var objItemProperties = objItem.GetType().GetProperties();

                                                            foreach(var objItemProperty in objItemProperties)
                                                            {
                                                                //Hvis objItemProperty.Name er == "pp".
                                                                if (objItemProperty.Name == currentAttribute.ParentPropertyName)
                                                                {
                                                                    //Få fat i Value af item(pp)
                                                                    object objItemPropertyValue = objItem.GetType().GetProperty(objItemProperty.Name).GetValue(objItem, null);
                                                                    //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                                                    string[] results = objItemPropertyValue.ToString().Split(' ');
                                                                    //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                                                    long NamedPartX;
                                                                    long NamedPartY;
                                                                    //Forsøg at parse string[0] til NamedPartX typeof long.
                                                                    bool NamedPartXSuccess = Int64.TryParse(results[0], out NamedPartX);
                                                                    if (NamedPartXSuccess)
                                                                    {
                                                                        parentPropertyValue = NamedPartX;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (results[0] == null) results[0] = "";
                                                                        Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                                                    }
                                                                    //Forsøg at parse string[1] til NamedPartY typeof long.
                                                                    bool NamedPartYSuccess = Int64.TryParse(results[1],out NamedPartY);
                                                                    if (NamedPartYSuccess)
                                                                    {
                                                                        parentPropertyValue2 = NamedPartY;
                                                                    }
                                                                    else
                                                                    {
                                                                        if(results[1] == null) results[1] = "";
                                                                        Console.WriteLine ("Attempted conversion of '{0}'", results[1]);
                                                                    }
                                                                    break;
                                                                }
                                                                
                                                            }
                                                            
                                                        }
                                                        
                                                    }
                                                    
                                                }
                                                
	                                        }
                                            //break er sat her for ellers rammer den aldrig dxy. Har brug for input for at forstå hvorfor dette er tilfældet.
                                            break;
	                                    }
                                        
	                                }
                                    
                                }
                               
	                        }
                            break;
                        case "dxy":
                            SplitStringValueFromCurrentAttribute2(parentProperties, currentAttribute);
                            foreach(var parentProperty in parentProperties)
                            {
                                if (IsList(parentProperty.PropertyType))
	                            {
                                    //En Instance af parentProperty. Som i dette tilfælde er en liste efter overstående if. Kører derefter en foreach over denne liste for at komme dybere ind i strukturen.
                                    object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                    //parentPProperty == parent property property etc.
                                    foreach (var parentPProperty in (IEnumerable)parentPropertyInstance) 
                                    { 
                                        //Find properties for parentPProperty, hvilket er en list som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                                        var parentPProperties = parentPProperty.GetType().GetProperties();
                                        foreach (var parentPPProperty in parentPProperties)
                                        {
                                            //Find value for parentPPProperty for at få adgang til body fra schDesignSymbol eftersom det indeholder "items" som er hvad jeg er ude efter at lave en foreach over for at nå helt ind til "dxy".
                                            object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);
                                            if (parentPPPropertyValue != null)
	                                        {
                                                //Find properties for parentPPPProperty, som i dette tilfælde er et object array af "items".
                                                var parentPPPProperties = parentPPPropertyValue.GetType().GetProperties();
                                                foreach (var parentPPPProperty in parentPPPProperties)
                                                {
                                                    //Få fat på value af object item array
                                                    object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                                    //foreach over hvert item i object array
                                                    foreach (var objItem in (IEnumerable)parentPPPPInstance)
                                                    {
                                                        //Find properties for objItem.
                                                        var objItemProperties = objItem.GetType().GetRuntimeProperties();
                                                        foreach (var objItemProperty in objItemProperties)
                                                        {
                                                            if (objItemProperty.Name == currentAttribute.ParentPropertyName)
	                                                        {
                                                                //Få fat i Value af item(pp)
                                                                object objItemPropertyValue = objItem.GetType().GetProperty(objItemProperty.Name).GetValue(objItem, null);
                                                                //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                                                string[] results = objItemPropertyValue.ToString().Split(' ');
                                                                //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                                                long NamedPartX;
                                                                long NamedPartY;

                                                                bool NamedPartXSuccess = Int64.TryParse(results[0], out NamedPartX);
                                                                if (NamedPartXSuccess)
                                                                {
                                                                    parentPropertyValue = NamedPartX;
                                                                }
                                                                else
                                                                {
                                                                    if (results[0] == null) results[0] = "";
                                                                    Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                                                }
                                                                bool NamedPartYSuccess = Int64.TryParse(results[1],out NamedPartY);
                                                                if (NamedPartYSuccess)
                                                                {
                                                                    parentPropertyValue2 = NamedPartY;
                                                                }
                                                                else
                                                                {
                                                                    if(results[1] == null) results[1] = "";
                                                                    Console.WriteLine ("Attempted conversion of '{0}'", results[1]);
                                                                }
                                                            break;
	                                                        }
                                                        }
                                                    }
                                                }
	                                        }
                                        }
                                    }

	                            }
                            }
                            break;
                        case "pk":
                            foreach (var parentProperty in parentProperties)
                            {
                                if (IsList(parentProperty.PropertyType))
                                {
                                    object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                                    foreach (var parentPProperty in (IEnumerable)parentPropertyInstance)
                                    {
                                        var parentPProperties = parentProperty.GetType().GetProperties();
                                        foreach (var parentPPProperty in parentPProperties)
                                        {
                                            object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPProperty.Name).GetValue(parentPProperty, null);
                                            if (parentPPPropertyValue != null)
                                            {
                                                var parentPPPProperties = parentPPPropoertyValue.GetType().GetProperties();
                                                foreach (var parentPPPProperty in parentPPPProperties)
                                                {
                                                    object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                                    foreach (var objItem in (IEnumerable)parentPPPPInstance)
                                                    {
                                                        var objItemProperties = objItem.GetType().GetProperties();
                                                        foreach (var objItemProperty in objItemProperties)
                                                        {
                                                            if (objItemProperty.Name == currentAttribute.ParentPropertyName)
                                                            {
                                                                //Do stuff.
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "pk1":
                            foreach (var parentProperty in parentProperties)
                            {
                                if (IsList(parentProperty.PropertyType))
                                {
                                    object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                                    foreach (var parentPProperty in (IEnumerable)parentPropertyInstance)
                                    {
                                        var parentPProperties = parentProperty.GetType().GetProperties();
                                        foreach (var parentPPProperty in parentPProperties)
                                        {
                                            object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPProperty.Name).GetValue(parentPProperty, null);
                                            if (parentPPPropertyValue != null)
                                            {
                                                var parentPPPProperties = parentPPPropoertyValue.GetType().GetProperties();
                                                foreach (var parentPPPProperty in parentPPPProperties)
                                                {
                                                    object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                                    foreach (var objItem in (IEnumerable)parentPPPPInstance)
                                                    {
                                                        var objItemProperties = objItem.GetType().GetProperties();
                                                        foreach (var objItemProperty in objItemProperties)
                                                        {
                                                            if (objItemProperty.Name == currentAttribute.ParentPropertyName)
                                                            {
                                                                //Do stuff.
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }

                    //Denne foreach er fra den simple version af koden. Dvs før Switchen blev lavet til at tage sig af specifikke properties.
                    foreach (var parentProperty in parentProperties)
	                {
                    
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
                                //parentPropertyInstance bruges til at holde listen som kommer fra parent.
                                object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                //childPropertyInstance bruges til at indeholde listen fra child/self.
                                Object childPropertyInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));

                                //Her laves der en instance af child/self listen.
                                Object childListInstance = Activator.CreateInstance(childPropertyInstance.GetType());
                                //Oprettelse af liste som bruges til at tilføje Instances til, samt gemmes til i SetValue, efter tilføjelse til parentPropertyValue.
                                IList list = (IList)childListInstance;

                                //foreach over companyParent for at få fat i hver genstand på listen. Hold øje med hvorvidt IList er optimal for det enlige projekt.
                                foreach (var parentPropertyItem in (IEnumerable)parentPropertyInstance)
                                {
                                    //Dette giver en liste af "type". Hvilket skal findes for at kunne oprette en instance af list item.
                                    var TFromList = childPropertyInstance.GetType().GetGenericArguments();
                                    //Oprette en instance af hvad der er på listen.
                                    Object ChildTFromListInstance = Activator.CreateInstance(TFromList[0]);

                                    //Kør MatchPropertiesFrom med compparentItem som er en instance af en genstand på parent listen.
                                    //orgChildInstance er en instance af child/self list item. Hvilket betyder at det er her list items bliver matched.
                                    ChildTFromListInstance.MatchPropertiesFrom(parentPropertyItem);
                                    //Tilføjelse af det matched orgChildInstance til list(instance af child/self list)
                                    list.Add(ChildTFromListInstance);
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
                    //Tilføj value af parentPropertyValue til self.
                    try
                    {
                        childProperty.SetValue(self, parentPropertyValue);
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
                                Object childPropertyInstance = Array.CreateInstance(childProperty.PropertyType.GetElementType(), 7);
                                //Gem det array på self/child objectet.
                                childProperty.SetValue(self, childPropertyInstance);
                                //Skriv følgende besked i console.
                                Console.WriteLine(childProperty.Name + " do not contain a Custom Attribute of the type 'MatchParentAttribute'. " + childProperty.Name + " was created");
                            }
                            //Hvis det er en complex type. (Class)
                            else
                            {
                                //Lav object instance af childproperty baseret på det fulde navn af propertyType.
                                Object childInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));
                                //Gem dette object på self/child objectet.
                                childProperty.SetValue(self, childInstance);
                                //MatchPropertiesFrom parent til childInstance i et forsøg på at få så mange values med som muligt.
                                childInstance.MatchPropertiesFrom(parent);
                                //Skriv følgende besked i console.
                                Console.WriteLine(childProperty.Name + " do not contain a Custom Attribute of the type 'MatchParentAttribute'. " + childProperty.Name + " was created");
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
        //Disse to metoder bliver brugt til at hente og splitte string af blandt andet pp og dxy.
        public static void SplitStringValueFromCurrentAttribute1(object parentProperties, object currentAttribute)
        {
            foreach (var parentProperty in parentProperties)
	        {
                                    if (IsList(parentProperty.PropertyType))
	                                {
                                        //En Instance af parentProperty. Som i dette tilfælde er en liste efter overstående if. Kører derefter en foreach over denne liste for at komme dybere ind i strukturen.
                                        //Instance er det samme som value eftersom den benytter sig af getvalue.
                                        object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                        //parentPProperty == parent Property Property etc.
                                        foreach (var parentPProperty in (IEnumerable)parentPropertyInstance)
	                                    {
                                            //Finder properties for parentPProperty, hvilket er en liste som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                                            var parentPPProperties = parentPProperty.GetType().GetProperties();
                                            foreach (var parentPPProperty in parentPPProperties)
	                                        {
                                                //Find value for parentPPProperty for at få adgang til body fra schDesignSymbol eftersom det indeholder "items" som er hvad jeg er ude efter at lave foreach over for at nå helt ind til "pp".
                                                object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);
                                                if (parentPPPropertyValue != null)
                                                {
                                                    //Find properties for parentPPPProperty, som i dette tilfælde er et object array af "items".
                                                    var parentPPPProperties = parentPPPropertyValue.GetType().GetProperties();
                                                    foreach(var parentPPPProperty in parentPPPProperties)
                                                    {
                                                        //Få fat på value af object item array
                                                        object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                                        //foreach over hvert item i object array.
                                                        foreach(var objItem in (IEnumerable)parentPPPPInstance)
                                                        {
                                                            //Find properties for objItem.
                                                            var objItemProperties = objItem.GetType().GetProperties();

                                                            foreach(var objItemProperty in objItemProperties)
                                                            {
                                                                //Hvis objItemProperty.Name er == "pp".
                                                                if (objItemProperty.Name == currentAttribute.ParentPropertyName)
                                                                {
                                                                    //Få fat i Value af item(pp)
                                                                    object objItemPropertyValue = objItem.GetType().GetProperty(objItemProperty.Name).GetValue(objItem, null);
                                                                    //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                                                    string[] results = objItemPropertyValue.ToString().Split(' ');
                                                                    //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                                                    long NamedPartX;
                                                                    long NamedPartY;
                                                                    //Forsøg at parse string[0] til NamedPartX typeof long.
                                                                    bool NamedPartXSuccess = Int64.TryParse(results[0], out NamedPartX);
                                                                    if (NamedPartXSuccess)
                                                                    {
                                                                        parentPropertyValue = NamedPartX;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (results[0] == null) results[0] = "";
                                                                        Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                                                    }
                                                                    break;
                                                                }
                                                                
                                                            }
                                                            
                                                        }
                                                        
                                                    }
                                                    
                                                }
                                                
	                                        }
                                            //break er sat her for ellers rammer den aldrig dxy. Har brug for input for at forstå hvorfor dette er tilfældet.
                                            break;
	                                    }
                                        
	                                }
                                    
                                
                               
	        }
        }
        public static void SplitStringValueFromCurrentAttribute2(object parentProperties, object currentAttribute)
        {
            foreach (var parentProperty in parentProperties)
	        {
                                    if (IsList(parentProperty.PropertyType))
	                                {
                                        //En Instance af parentProperty. Som i dette tilfælde er en liste efter overstående if. Kører derefter en foreach over denne liste for at komme dybere ind i strukturen.
                                        //Instance er det samme som value eftersom den benytter sig af getvalue.
                                        object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);
                                        //parentPProperty == parent Property Property etc.
                                        foreach (var parentPProperty in (IEnumerable)parentPropertyInstance)
	                                    {
                                            //Finder properties for parentPProperty, hvilket er en liste som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                                            var parentPPProperties = parentPProperty.GetType().GetProperties();
                                            foreach (var parentPPProperty in parentPPProperties)
	                                        {
                                                //Find value for parentPPProperty for at få adgang til body fra schDesignSymbol eftersom det indeholder "items" som er hvad jeg er ude efter at lave foreach over for at nå helt ind til "pp".
                                                object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);
                                                if (parentPPPropertyValue != null)
                                                {
                                                    //Find properties for parentPPPProperty, som i dette tilfælde er et object array af "items".
                                                    var parentPPPProperties = parentPPPropertyValue.GetType().GetProperties();
                                                    foreach(var parentPPPProperty in parentPPPProperties)
                                                    {
                                                        //Få fat på value af object item array
                                                        object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                                        //foreach over hvert item i object array.
                                                        foreach(var objItem in (IEnumerable)parentPPPPInstance)
                                                        {
                                                            //Find properties for objItem.
                                                            var objItemProperties = objItem.GetType().GetProperties();

                                                            foreach(var objItemProperty in objItemProperties)
                                                            {
                                                                //Hvis objItemProperty.Name er == "pp".
                                                                if (objItemProperty.Name == currentAttribute.ParentPropertyName)
                                                                {
                                                                    //Få fat i Value af item(pp)
                                                                    object objItemPropertyValue = objItem.GetType().GetProperty(objItemProperty.Name).GetValue(objItem, null);
                                                                    //eftersom pp er string af x og y koordinater, skal pp splittes. Hvilket gøres her og tilføjet til et string array.
                                                                    string[] results = objItemPropertyValue.ToString().Split(' ');
                                                                    //X og Y i OrCad/Capture er type long, så derfor skal string results parses til long.
                                                                    long NamedPartX;
                                                                    long NamedPartY;
                                                                    //Forsøg at parse string[0] til NamedPartX typeof long.
                                                                    bool NamedPartYSuccess = Int64.TryParse(results[1],out NamedPartY);
                                                                    if (NamedPartYSuccess)
                                                                    {
                                                                        parentPropertyValue2 = NamedPartY;
                                                                    }
                                                                    else
                                                                    {
                                                                        if(results[1] == null) results[1] = "";
                                                                        Console.WriteLine ("Attempted conversion of '{0}'", results[1]);
                                                                    }
                                                                    break;
                                                                }
                                                                
                                                            }
                                                            
                                                        }
                                                        
                                                    }
                                                    
                                                }
                                                
	                                        }
                                            //break er sat her for ellers rammer den aldrig de andre MatchParentAttribute.
                                            break;
	                                    }
                                        
	                                }                 
	        }
        }
    }

}
