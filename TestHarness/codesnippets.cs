using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
//Gamle cases som sidenhen er blevet lavet om til noget mere enkelt. Version 1.
switch (currentAttribute)
{
        case "pk":
            foreach (var parentProperty in parentProperties)
            {
                if (IsList(parentProperty.PropertyType))
                {
                    object parentPropertyInstance = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                    foreach (var parentPProperty in (IEnumerable) parentPropertyInstance)
                    {
                        var parentPProperties = parentProperty.GetType().GetProperties();
                        foreach (var parentPPProperty in parentPProperties)
                        {
                            object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);
                            if (parentPPPropertyValue != null)
                            {
                                var parentPPPProperties = parentPPPropertyValue.GetType().GetProperties();
                                foreach (var parentPPPProperty in parentPPPProperties)
                                {
                                    object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                    foreach (var objItem in (IEnumerable) parentPPPPInstance)
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
                    object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);
                    if (parentPPPropertyValue != null)
                    {
                        var parentPPPProperties = parentPPPropertyValue.GetType().GetProperties();
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
        case "pp":
            foreach (var parentProperty in parentProperties)
    {
        //parentPropertyValue skal bruges i loopet til et tjek, så derfor bliver den her sat til null i tilfælde af at dette ikke er tilfældet.
        parentPropertyValue = null;
        //Hjælp: er der en anden måde at lave dette check på? Der skal laves et check så det kun er muligt at komme ind i symbols. parentProperties[1] ? Det skal jo være rekrossivt og ikke hardcoded.
        if (parentProperty.Name == "Symbols")
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
                        if (!IsSimple(parentPPProperty.PropertyType))
                        {
                            //Find value for parentPPProperty for at få adgang til body fra schDesignSymbol eftersom det indeholder "items" som er hvad jeg er ude efter at lave foreach over for at nå helt ind til "pp".
                            object parentPPPropertyValue = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);
                            if (parentPPPropertyValue != null)
                            {
                                //Find properties for parentPPPProperty, som i dette tilfælde er et object array af "items".
                                var parentPPPProperties = parentPPPropertyValue.GetType().GetProperties();
                                foreach (var parentPPPProperty in parentPPPProperties)
                                {
                                    //Få fat på value af object item array
                                    object parentPPPPInstance = parentPPPropertyValue.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertyValue, null);
                                    //foreach over hvert item i object array.
                                    foreach (var objItem in (IEnumerable)parentPPPPInstance)
                                    {
                                        if (parentPropertyValue == null)
                                        {
                                            //Find properties for objItem.
                                            var objItemProperties = objItem.GetType().GetProperties();

                                            foreach (var objItemProperty in objItemProperties)
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
                                                    bool NamedPartYSuccess = Int64.TryParse(results[1], out NamedPartY);
                                                    if (NamedPartYSuccess)
                                                    {
                                                        parentPropertyValue2 = NamedPartY;
                                                        //Hjælp: Hvordan skal denne værdi gemmes og der kommer en exception her da det er type long og value er et decimal tal.
                                                    }
                                                    else
                                                    {
                                                        if (results[1] == null) results[1] = "";
                                                        Console.WriteLine("Attempted conversion of '{0}' failed", results[1]);
                                                    }
                                                    break;
                                                }
                                                //Hjælp: Her kan der os være en fejl eftersom der er flere instances som indeholder property "pp" og vil derfor overskrive den value som er i parentPropertyValue. På den måde ender alle "pp" properties med samme value, nemlig den sidste "pp" i items array'et
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    //break er sat her for ellers rammer den aldrig dxy. Har brug for input for at forstå hvorfor dette er tilfældet.
                    break;
                }
            }
        }
    }
        case "dxy":
            foreach (var parentProperty in parentProperties)
    {
        if (parentProperty.Name == "Symbols")
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
                        if (!IsSimple(parentPPProperty.PropertyType))
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
                                            //var attributesForObjProperty = objItemProperty.GetCustomAttributes(typeof(MatchParentAttribute), true);
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
                                                else
                                                {
                                                    if (results[0] == null) results[0] = "";
                                                    Console.WriteLine("Attempted conversion of '{0}' failed", results[0]);
                                                }
                                                bool NamedPartYSuccess = Int64.TryParse(results[1], out NamedPartY);
                                                if (NamedPartYSuccess)
                                                {
                                                    parentPropertyValue2 = NamedPartY;
                                                    //Hjælp: Dette skal også gemmes men til en anden property. how?
                                                }
                                                else
                                                {
                                                    if (results[1] == null) results[1] = "";
                                                    Console.WriteLine("Attempted conversion of '{0}' failed", results[1]);
                                                }
                                                break;
                                            }
                                        }
                                        //Hjælp: her skal der os sker noget for at komme ud af loopet. Ellers bliver den ved med at overskrive value på "self". x2 i dette tilfælde.
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }

}
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

    public static void FindItemsOfClass(object parentProperties, object parent, object childProperty)
    {
        foreach (var parentProperty in parentProperties)
        {
            if (IsList(parentProperty.PropertyType))
            {
                //Dette object skal bruges til at indeholde en liste af symbol fra CADint
                object parentPropertySymbolList = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                foreach (var parentPProperty in (IEnumerable)parentPropertySymbolList)
                {
                    //Finder properties for parentPProperty, hvilket er en liste som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                    //Denne variabel indeholder properties af parentPropertySymbolList
                    var parentPSLProperties = parentPProperty.GetType().GetProperties();

                    foreach (var parentPPProperty in parentPSLProperties)
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
                                    //Finder her det fulde navn (FullName). Dette fulde navn indeholder et "+" hvilket er hvor jeg vælger at dele det eftersom at det så er muligt at checke imod currentAttribute.ParentPropertyName.
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

//Version 2.
switch (currentAttribute)
{
    case "schDesignSymbolBodyRect":
        foreach (var parentProperty in parentProperties)
        {
            if (IsList(parentProperty.PropertyType))
            {
                //Dette object skal bruges til at indeholde en liste af symbol fra CADint
                object parentPropertySymbolList = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                foreach (var parentPProperty in (IEnumerable)parentPropertySymbolList)
                {
                    //Finder properties for parentPProperty, hvilket er en liste som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                    //Denne variabel indeholder properties af parentPropertySymbolList
                    var parentPSLProperties = parentPProperty.GetType().GetProperties();

                    foreach (var parentPPProperty in parentPSLProperties)
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
                                    //Finder her det fulde navn (FullName). Dette fulde navn indeholder et "+" hvilket er hvor jeg vælger at dele det eftersom at det så er muligt at checke imod currentAttribute.ParentPropertyName.
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
        break;
    case "schDesignSymbolBodyArc":
        foreach (var parentProperty in parentProperties)
        {
            if (IsList(parentProperty.PropertyType))
            {
                //En Instance af parentProperty. Som i dette tilfælde er en liste efter overstående if. Kører derefter en foreach over denne liste for at komme dybere ind i strukturen.
                //Dette object skal bruges til at indeholde en liste af symbol fra CADint
                object parentPropertySymbolList = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                foreach (var parentPProperty in (IEnumerable)parentPropertySymbolList)
                {
                    //Finder properties for parentPProperty, hvilket er en liste som bliver lavet foreach over, for igen at komme dybere ind i strukturen.
                    //Denne variabel indeholder properties af parentPropertySymbolList
                    var parentPSLProperties = parentPProperty.GetType().GetProperties();

                    foreach (var parentPPProperty in parentPSLProperties)
                    {
                        //Dette object indeholder value af SymbolBody(schDesignSymbolBody) fra CADint
                        object parentPPPropertySymbolBody = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);

                        if (parentPPPropertySymbolBody != null)
                        {
                            //Properties af parentPPPropertyValue som skal bruges i den næste foreach for igen at komme ind i strukturen/"træet".
                            //Dette object indeholder value af SymbolBody(schDesignSymbolBody) fra CADint
                            var parentPPPSBProperties = parentPPPropertySymbolBody.GetType().GetProperties();

                            foreach (var parentPPPProperty in parentPPPSBProperties)
                            {
                                //Dette object indeholde en liste af "Items" fra CADint. Items er Arc, Rect, Line, Text etc.
                                object parentPPPPItemsList = parentPPPropertySymbolBody.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertySymbolBody, null);

                                //Denne foreach går igennem alle Items og når et Item Name passer med currentAttribute.ParentPropertyName, går den ind i if.
                                foreach (var objItem in (IEnumerable)parentPPPPItemsList)
                                {
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
        break;
    case "schDesignSymbolBodyLine":
        foreach (var parentProperty in parentProperties)
        {
            if (IsList(parentProperty.PropertyType))
            {
                //Dette object skal bruges til at indeholde en liste af symbol fra CADint
                object parentPropertySymbolList = parent.GetType().GetProperty(parentProperty.Name).GetValue(parent, null);

                foreach (var parentPProperty in (IEnumerable)parentPropertySymbolList)
                {
                    //Denne variabel indeholder properties af parentPropertySymbolList
                    var parentPSLProperties = parentPProperty.GetType().GetProperties();

                    foreach (var parentPPProperty in parentPSLProperties)
                    {
                        //Dette object indeholder value af SymbolBody(schDesignSymbolBody) fra CADint
                        object parentPPPropertySymbolBody = parentPProperty.GetType().GetProperty(parentPPProperty.Name).GetValue(parentPProperty, null);

                        if (parentPPPropertySymbolBody != null)
                        {
                            //Denne variabel indeholder properties fra parentPPPropertySymbolBody
                            var parentPPPSBProperties = parentPPPropertySymbolBody.GetType().GetProperties();
                            foreach (var parentPPPProperty in parentPPPSBProperties)
                            {
                                //Dette object indeholde en liste af "Items" fra CADint. Items er Arc, Rect, Line, Text etc.
                                object parentPPPPItemsList = parentPPPropertySymbolBody.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPropertySymbolBody, null);

                                //object testerfyr = parentPPPPInstance.GetType().GetProperty(parentPPPProperty.Name).GetValue(parentPPPPInstance, null);
                                //Denne foreach går igennem alle Items og når et Item Name passer med currentAttribute.ParentPropertyName, går den ind i if.
                                foreach (var objItem in (IEnumerable)parentPPPPItemsList)
                                {
                                    var objItemFullName = objItem.GetType().FullName;
                                    string[] splitAtPlus = objItemFullName.ToString().Split('+');
                                    string objItemName = splitAtPlus[1];
                                    if (currentAttribute.ParentPropertyName.Equals(objItemName) == true)
                                    {
                                        //denne instance skal bruges i matchpropertiesfrom for at få adgang til de underliggende properties. pp, pk, pk1
                                        object childPropertyInstance = Activator.CreateInstance(Type.GetType(childProperty.PropertyType.FullName));
                                        childProperty.SetValue(self, childPropertyInstance);
                                        //matchPropertiesFrom ObjItem. Dette gøres så det er muligt at tjekke alle properties på "Line", om de indeholder min Custom Attribute.
                                        childPropertyInstance.MatchPropertiesFrom(objItem);
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
}