using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness.CADintSch
{
    public class DisplayfSch
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class schDesign
        {

            private schDesignPcbRules pcbRulesField;

            private schDesignSymbol[] symbolsField;

            private schDesignPartRef[] partReferencesField;

            private schDesignPartNumber[] partNumbersField;

            private schDesignTopDesign topDesignField;

            private byte verField;

            private string nameField;

            /// <remarks/>
            public schDesignPcbRules pcbRules
            {
                get
                {
                    return this.pcbRulesField;
                }
                set
                {
                    this.pcbRulesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Symbol", IsNullable = false)]
            public schDesignSymbol[] Symbols
            {
                get
                {
                    return this.symbolsField;
                }
                set
                {
                    this.symbolsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("PartRef", IsNullable = false)]
            public schDesignPartRef[] partReferences
            {
                get
                {
                    return this.partReferencesField;
                }
                set
                {
                    this.partReferencesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("PartNumber", IsNullable = false)]
            public schDesignPartNumber[] partNumbers
            {
                get
                {
                    return this.partNumbersField;
                }
                set
                {
                    this.partNumbersField = value;
                }
            }

            /// <remarks/>
            public schDesignTopDesign topDesign
            {
                get
                {
                    return this.topDesignField;
                }
                set
                {
                    this.topDesignField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPcbRules
        {

            private schDesignPcbRulesGlobalRule globalRuleField;

            private schDesignPcbRulesSignalRule signalRuleField;

            /// <remarks/>
            public schDesignPcbRulesGlobalRule globalRule
            {
                get
                {
                    return this.globalRuleField;
                }
                set
                {
                    this.globalRuleField = value;
                }
            }

            /// <remarks/>
            public schDesignPcbRulesSignalRule signalRule
            {
                get
                {
                    return this.signalRuleField;
                }
                set
                {
                    this.signalRuleField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPcbRulesGlobalRule
        {

            private schDesignPcbRulesGlobalRuleGlobalRule globalRuleField;

            private object innerRuleField;

            private object topRuleField;

            private object bottomRuleField;

            private object linksField;

            private string nameField;

            /// <remarks/>
            public schDesignPcbRulesGlobalRuleGlobalRule globalRule
            {
                get
                {
                    return this.globalRuleField;
                }
                set
                {
                    this.globalRuleField = value;
                }
            }

            /// <remarks/>
            public object innerRule
            {
                get
                {
                    return this.innerRuleField;
                }
                set
                {
                    this.innerRuleField = value;
                }
            }

            /// <remarks/>
            public object topRule
            {
                get
                {
                    return this.topRuleField;
                }
                set
                {
                    this.topRuleField = value;
                }
            }

            /// <remarks/>
            public object bottomRule
            {
                get
                {
                    return this.bottomRuleField;
                }
                set
                {
                    this.bottomRuleField = value;
                }
            }

            /// <remarks/>
            public object Links
            {
                get
                {
                    return this.linksField;
                }
                set
                {
                    this.linksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPcbRulesGlobalRuleGlobalRule
        {

            private decimal clrField;

            /// <remarks/>
            public decimal clr
            {
                get
                {
                    return this.clrField;
                }
                set
                {
                    this.clrField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPcbRulesSignalRule
        {

            private object globalRuleField;

            private object innerRuleField;

            private object topRuleField;

            private object bottomRuleField;

            private object linksField;

            private string nameField;

            /// <remarks/>
            public object globalRule
            {
                get
                {
                    return this.globalRuleField;
                }
                set
                {
                    this.globalRuleField = value;
                }
            }

            /// <remarks/>
            public object innerRule
            {
                get
                {
                    return this.innerRuleField;
                }
                set
                {
                    this.innerRuleField = value;
                }
            }

            /// <remarks/>
            public object topRule
            {
                get
                {
                    return this.topRuleField;
                }
                set
                {
                    this.topRuleField = value;
                }
            }

            /// <remarks/>
            public object bottomRule
            {
                get
                {
                    return this.bottomRuleField;
                }
                set
                {
                    this.bottomRuleField = value;
                }
            }

            /// <remarks/>
            public object Links
            {
                get
                {
                    return this.linksField;
                }
                set
                {
                    this.linksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbol
        {

            private schDesignSymbolProperties propertiesField;

            private schDesignSymbolBody bodyField;

            private string nameField;

            private byte verField;

            /// <remarks/>
            public schDesignSymbolProperties Properties
            {
                get
                {
                    return this.propertiesField;
                }
                set
                {
                    this.propertiesField = value;
                }
            }

            /// <remarks/>
            public schDesignSymbolBody Body
            {
                get
                {
                    return this.bodyField;
                }
                set
                {
                    this.bodyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolProperties
        {

            private schDesignSymbolPropertiesA[] aField;

            private byte verField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("A")]
            public schDesignSymbolPropertiesA[] A
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolPropertiesA
        {

            private string keyField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBody
        {

            private object[] itemsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("arc", typeof(schDesignSymbolBodyArc))]
            [System.Xml.Serialization.XmlElementAttribute("circ", typeof(schDesignSymbolBodyCirc))]
            [System.Xml.Serialization.XmlElementAttribute("circW", typeof(schDesignSymbolBodyCircW))]
            [System.Xml.Serialization.XmlElementAttribute("e", typeof(schDesignSymbolBodyE))]
            [System.Xml.Serialization.XmlElementAttribute("line", typeof(schDesignSymbolBodyLine))]
            [System.Xml.Serialization.XmlElementAttribute("lineW", typeof(schDesignSymbolBodyLineW))]
            [System.Xml.Serialization.XmlElementAttribute("rect", typeof(schDesignSymbolBodyRect))]
            [System.Xml.Serialization.XmlElementAttribute("text", typeof(schDesignSymbolBodyText))]
            public object[] Items
            {
                get
                {
                    return this.itemsField;
                }
                set
                {
                    this.itemsField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyArc
        {

            private uint lField;

            private string ppField;

            private decimal rField;

            private decimal aField;

            private byte bField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal r
            {
                get
                {
                    return this.rField;
                }
                set
                {
                    this.rField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal a
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte b
            {
                get
                {
                    return this.bField;
                }
                set
                {
                    this.bField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyCirc
        {

            private uint lField;

            private string ppField;

            private decimal rField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal r
            {
                get
                {
                    return this.rField;
                }
                set
                {
                    this.rField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyCircW
        {

            private uint lField;

            private string ppField;

            private decimal rField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal r
            {
                get
                {
                    return this.rField;
                }
                set
                {
                    this.rField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyE
        {

            private schDesignSymbolBodyEChildren childrenField;

            private schDesignSymbolBodyEProperties propertiesField;

            private string nField;

            private string ppField;

            /// <remarks/>
            public schDesignSymbolBodyEChildren Children
            {
                get
                {
                    return this.childrenField;
                }
                set
                {
                    this.childrenField = value;
                }
            }

            /// <remarks/>
            public schDesignSymbolBodyEProperties Properties
            {
                get
                {
                    return this.propertiesField;
                }
                set
                {
                    this.propertiesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string n
            {
                get
                {
                    return this.nField;
                }
                set
                {
                    this.nField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyEChildren
        {

            private schDesignSymbolBodyEChildrenText textField;

            /// <remarks/>
            public schDesignSymbolBodyEChildrenText text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyEChildrenText
        {

            private uint lField;

            private string ppField;

            private string faceNameField;

            private decimal cellHeightField;

            private decimal cellWidthField;

            private decimal cellStrokeField;

            private byte axField;

            private bool axFieldSpecified;

            private byte res1Field;

            private bool res1FieldSpecified;

            private string tField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string faceName
            {
                get
                {
                    return this.faceNameField;
                }
                set
                {
                    this.faceNameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellHeight
            {
                get
                {
                    return this.cellHeightField;
                }
                set
                {
                    this.cellHeightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellWidth
            {
                get
                {
                    return this.cellWidthField;
                }
                set
                {
                    this.cellWidthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellStroke
            {
                get
                {
                    return this.cellStrokeField;
                }
                set
                {
                    this.cellStrokeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ax
            {
                get
                {
                    return this.axField;
                }
                set
                {
                    this.axField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool axSpecified
            {
                get
                {
                    return this.axFieldSpecified;
                }
                set
                {
                    this.axFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte res1
            {
                get
                {
                    return this.res1Field;
                }
                set
                {
                    this.res1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool res1Specified
            {
                get
                {
                    return this.res1FieldSpecified;
                }
                set
                {
                    this.res1FieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string T
            {
                get
                {
                    return this.tField;
                }
                set
                {
                    this.tField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyEProperties
        {

            private schDesignSymbolBodyEPropertiesA aField;

            private byte verField;

            /// <remarks/>
            public schDesignSymbolBodyEPropertiesA A
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyEPropertiesA
        {

            private string keyField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyLine
        {

            private uint lField;

            private string ppField;

            private string dxyField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string dxy
            {
                get
                {
                    return this.dxyField;
                }
                set
                {
                    this.dxyField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyLineW
        {

            private uint lField;

            private string ppField;

            private string dxyField;

            private decimal wField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string dxy
            {
                get
                {
                    return this.dxyField;
                }
                set
                {
                    this.dxyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal w
            {
                get
                {
                    return this.wField;
                }
                set
                {
                    this.wField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyRect
        {

            private uint lField;

            private string ppField;

            private string pkField;

            private string pk1Field;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pk
            {
                get
                {
                    return this.pkField;
                }
                set
                {
                    this.pkField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pk1
            {
                get
                {
                    return this.pk1Field;
                }
                set
                {
                    this.pk1Field = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignSymbolBodyText
        {

            private uint lField;

            private string ppField;

            private string faceNameField;

            private decimal cellHeightField;

            private decimal cellWidthField;

            private decimal cellStrokeField;

            private byte axField;

            private bool axFieldSpecified;

            private byte ayField;

            private bool ayFieldSpecified;

            private string tField;

            private byte aField;

            private bool aFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string faceName
            {
                get
                {
                    return this.faceNameField;
                }
                set
                {
                    this.faceNameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellHeight
            {
                get
                {
                    return this.cellHeightField;
                }
                set
                {
                    this.cellHeightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellWidth
            {
                get
                {
                    return this.cellWidthField;
                }
                set
                {
                    this.cellWidthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellStroke
            {
                get
                {
                    return this.cellStrokeField;
                }
                set
                {
                    this.cellStrokeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ax
            {
                get
                {
                    return this.axField;
                }
                set
                {
                    this.axField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool axSpecified
            {
                get
                {
                    return this.axFieldSpecified;
                }
                set
                {
                    this.axFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ay
            {
                get
                {
                    return this.ayField;
                }
                set
                {
                    this.ayField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool aySpecified
            {
                get
                {
                    return this.ayFieldSpecified;
                }
                set
                {
                    this.ayFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string T
            {
                get
                {
                    return this.tField;
                }
                set
                {
                    this.tField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte a
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool aSpecified
            {
                get
                {
                    return this.aFieldSpecified;
                }
                set
                {
                    this.aFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRef
        {

            private schDesignPartRefSymbol symbolField;

            private schDesignPartRefGate[] gateField;

            private schDesignPartRefPad[] padField;

            private schDesignPartRefPin[] pinField;

            private schDesignPartRefPower[] powerField;

            private schDesignPartRefProperties propertiesField;

            private string nameField;

            private byte verField;

            /// <remarks/>
            public schDesignPartRefSymbol Symbol
            {
                get
                {
                    return this.symbolField;
                }
                set
                {
                    this.symbolField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Gate")]
            public schDesignPartRefGate[] Gate
            {
                get
                {
                    return this.gateField;
                }
                set
                {
                    this.gateField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Pad")]
            public schDesignPartRefPad[] Pad
            {
                get
                {
                    return this.padField;
                }
                set
                {
                    this.padField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Pin")]
            public schDesignPartRefPin[] Pin
            {
                get
                {
                    return this.pinField;
                }
                set
                {
                    this.pinField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Power")]
            public schDesignPartRefPower[] Power
            {
                get
                {
                    return this.powerField;
                }
                set
                {
                    this.powerField = value;
                }
            }

            /// <remarks/>
            public schDesignPartRefProperties Properties
            {
                get
                {
                    return this.propertiesField;
                }
                set
                {
                    this.propertiesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRefSymbol
        {

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRefGate
        {

            private string nameField;

            private byte swapField;

            private byte indexField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Swap
            {
                get
                {
                    return this.swapField;
                }
                set
                {
                    this.swapField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Index
            {
                get
                {
                    return this.indexField;
                }
                set
                {
                    this.indexField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRefPad
        {

            private byte nameField;

            private byte netField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Net
            {
                get
                {
                    return this.netField;
                }
                set
                {
                    this.netField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRefPin
        {

            private string nameField;

            private byte netField;

            private byte swapField;

            private bool swapFieldSpecified;

            private byte pinSetField;

            private bool pinSetFieldSpecified;

            private byte pinMemberField;

            private bool pinMemberFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Net
            {
                get
                {
                    return this.netField;
                }
                set
                {
                    this.netField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Swap
            {
                get
                {
                    return this.swapField;
                }
                set
                {
                    this.swapField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool SwapSpecified
            {
                get
                {
                    return this.swapFieldSpecified;
                }
                set
                {
                    this.swapFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PinSet
            {
                get
                {
                    return this.pinSetField;
                }
                set
                {
                    this.pinSetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool PinSetSpecified
            {
                get
                {
                    return this.pinSetFieldSpecified;
                }
                set
                {
                    this.pinSetFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PinMember
            {
                get
                {
                    return this.pinMemberField;
                }
                set
                {
                    this.pinMemberField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool PinMemberSpecified
            {
                get
                {
                    return this.pinMemberFieldSpecified;
                }
                set
                {
                    this.pinMemberFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRefPower
        {

            private string nameField;

            private byte netField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Net
            {
                get
                {
                    return this.netField;
                }
                set
                {
                    this.netField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRefProperties
        {

            private schDesignPartRefPropertiesA[] aField;

            private byte verField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("A")]
            public schDesignPartRefPropertiesA[] A
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartRefPropertiesA
        {

            private string keyField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartNumber
        {

            private schDesignPartNumberProperties propertiesField;

            private string nameField;

            private byte verField;

            /// <remarks/>
            public schDesignPartNumberProperties Properties
            {
                get
                {
                    return this.propertiesField;
                }
                set
                {
                    this.propertiesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartNumberProperties
        {

            private schDesignPartNumberPropertiesA[] aField;

            private byte verField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("A")]
            public schDesignPartNumberPropertiesA[] A
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignPartNumberPropertiesA
        {

            private string keyField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesign
        {

            private schDesignTopDesignTopView topViewField;

            private schDesignTopDesignContainer containerField;

            private string idField;

            private uint hField;

            /// <remarks/>
            public schDesignTopDesignTopView topView
            {
                get
                {
                    return this.topViewField;
                }
                set
                {
                    this.topViewField = value;
                }
            }

            /// <remarks/>
            public schDesignTopDesignContainer container
            {
                get
                {
                    return this.containerField;
                }
                set
                {
                    this.containerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint h
            {
                get
                {
                    return this.hField;
                }
                set
                {
                    this.hField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignTopView
        {

            private schDesignTopDesignTopViewBody bodyField;

            private string nameField;

            private byte verField;

            /// <remarks/>
            public schDesignTopDesignTopViewBody Body
            {
                get
                {
                    return this.bodyField;
                }
                set
                {
                    this.bodyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignTopViewBody
        {

            private schDesignTopDesignTopViewBodyRect rectField;

            private schDesignTopDesignTopViewBodyText textField;

            /// <remarks/>
            public schDesignTopDesignTopViewBodyRect rect
            {
                get
                {
                    return this.rectField;
                }
                set
                {
                    this.rectField = value;
                }
            }

            /// <remarks/>
            public schDesignTopDesignTopViewBodyText text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignTopViewBodyRect
        {

            private uint lField;

            private string ppField;

            private string pkField;

            private string pk1Field;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pk
            {
                get
                {
                    return this.pkField;
                }
                set
                {
                    this.pkField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pk1
            {
                get
                {
                    return this.pk1Field;
                }
                set
                {
                    this.pk1Field = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignTopViewBodyText
        {

            private uint lField;

            private string ppField;

            private string faceNameField;

            private decimal cellHeightField;

            private decimal cellWidthField;

            private decimal cellStrokeField;

            private string tField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string faceName
            {
                get
                {
                    return this.faceNameField;
                }
                set
                {
                    this.faceNameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellHeight
            {
                get
                {
                    return this.cellHeightField;
                }
                set
                {
                    this.cellHeightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellWidth
            {
                get
                {
                    return this.cellWidthField;
                }
                set
                {
                    this.cellWidthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellStroke
            {
                get
                {
                    return this.cellStrokeField;
                }
                set
                {
                    this.cellStrokeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string T
            {
                get
                {
                    return this.tField;
                }
                set
                {
                    this.tField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainer
        {

            private schDesignTopDesignContainerProperties propertiesField;

            private schDesignTopDesignContainerChildren childrenField;

            /// <remarks/>
            public schDesignTopDesignContainerProperties Properties
            {
                get
                {
                    return this.propertiesField;
                }
                set
                {
                    this.propertiesField = value;
                }
            }

            /// <remarks/>
            public schDesignTopDesignContainerChildren Children
            {
                get
                {
                    return this.childrenField;
                }
                set
                {
                    this.childrenField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerProperties
        {

            private schDesignTopDesignContainerPropertiesA aField;

            private byte verField;

            /// <remarks/>
            public schDesignTopDesignContainerPropertiesA A
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerPropertiesA
        {

            private string keyField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildren
        {

            private object[] itemsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Bus", typeof(schDesignTopDesignContainerChildrenBus))]
            [System.Xml.Serialization.XmlElementAttribute("CompS", typeof(schDesignTopDesignContainerChildrenCompS))]
            [System.Xml.Serialization.XmlElementAttribute("Port", typeof(schDesignTopDesignContainerChildrenPort))]
            [System.Xml.Serialization.XmlElementAttribute("Wire", typeof(schDesignTopDesignContainerChildrenWire))]
            [System.Xml.Serialization.XmlElementAttribute("text", typeof(schDesignTopDesignContainerChildrenText))]
            public object[] Items
            {
                get
                {
                    return this.itemsField;
                }
                set
                {
                    this.itemsField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenBus
        {

            private schDesignTopDesignContainerChildrenBusE[] esField;

            private schDesignTopDesignContainerChildrenBusLP[] cnField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("e", IsNullable = false)]
            public schDesignTopDesignContainerChildrenBusE[] es
            {
                get
                {
                    return this.esField;
                }
                set
                {
                    this.esField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("lp", IsNullable = false)]
            public schDesignTopDesignContainerChildrenBusLP[] cn
            {
                get
                {
                    return this.cnField;
                }
                set
                {
                    this.cnField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenBusE
        {

            private uint hField;

            private byte iField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint h
            {
                get
                {
                    return this.hField;
                }
                set
                {
                    this.hField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte i
            {
                get
                {
                    return this.iField;
                }
                set
                {
                    this.iField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenBusLP
        {

            private string[] pField;

            private decimal wField;

            private byte tsField;

            private byte isField;

            private byte teField;

            private byte ieField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("p")]
            public string[] p
            {
                get
                {
                    return this.pField;
                }
                set
                {
                    this.pField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal w
            {
                get
                {
                    return this.wField;
                }
                set
                {
                    this.wField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ts
            {
                get
                {
                    return this.tsField;
                }
                set
                {
                    this.tsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte @is
            {
                get
                {
                    return this.isField;
                }
                set
                {
                    this.isField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte te
            {
                get
                {
                    return this.teField;
                }
                set
                {
                    this.teField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ie
            {
                get
                {
                    return this.ieField;
                }
                set
                {
                    this.ieField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenCompS
        {

            private schDesignTopDesignContainerChildrenCompSProperties propertiesField;

            private schDesignTopDesignContainerChildrenCompSE[] eField;

            private schDesignTopDesignContainerChildrenCompSAtext[] childrenField;

            private string nField;

            private uint hField;

            private string ppField;

            private string idField;

            private string symField;

            private string prField;

            private byte aField;

            private bool aFieldSpecified;

            /// <remarks/>
            public schDesignTopDesignContainerChildrenCompSProperties Properties
            {
                get
                {
                    return this.propertiesField;
                }
                set
                {
                    this.propertiesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("e")]
            public schDesignTopDesignContainerChildrenCompSE[] e
            {
                get
                {
                    return this.eField;
                }
                set
                {
                    this.eField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Atext", IsNullable = false)]
            public schDesignTopDesignContainerChildrenCompSAtext[] Children
            {
                get
                {
                    return this.childrenField;
                }
                set
                {
                    this.childrenField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string n
            {
                get
                {
                    return this.nField;
                }
                set
                {
                    this.nField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint h
            {
                get
                {
                    return this.hField;
                }
                set
                {
                    this.hField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sym
            {
                get
                {
                    return this.symField;
                }
                set
                {
                    this.symField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pr
            {
                get
                {
                    return this.prField;
                }
                set
                {
                    this.prField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte a
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool aSpecified
            {
                get
                {
                    return this.aFieldSpecified;
                }
                set
                {
                    this.aFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenCompSProperties
        {

            private schDesignTopDesignContainerChildrenCompSPropertiesA[] aField;

            private byte verField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("A")]
            public schDesignTopDesignContainerChildrenCompSPropertiesA[] A
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Ver
            {
                get
                {
                    return this.verField;
                }
                set
                {
                    this.verField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenCompSPropertiesA
        {

            private string keyField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenCompSE
        {

            private byte nField;

            private byte xField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte n
            {
                get
                {
                    return this.nField;
                }
                set
                {
                    this.nField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte x
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenCompSAtext
        {

            private uint lField;

            private string ppField;

            private string faceNameField;

            private decimal cellHeightField;

            private byte cellWidthField;

            private decimal cellStrokeField;

            private string tField;

            private string kField;

            private byte s1Field;

            private bool s1FieldSpecified;

            private byte s2Field;

            private bool s2FieldSpecified;

            private byte aField;

            private bool aFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string faceName
            {
                get
                {
                    return this.faceNameField;
                }
                set
                {
                    this.faceNameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellHeight
            {
                get
                {
                    return this.cellHeightField;
                }
                set
                {
                    this.cellHeightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte cellWidth
            {
                get
                {
                    return this.cellWidthField;
                }
                set
                {
                    this.cellWidthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellStroke
            {
                get
                {
                    return this.cellStrokeField;
                }
                set
                {
                    this.cellStrokeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string T
            {
                get
                {
                    return this.tField;
                }
                set
                {
                    this.tField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string K
            {
                get
                {
                    return this.kField;
                }
                set
                {
                    this.kField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte s1
            {
                get
                {
                    return this.s1Field;
                }
                set
                {
                    this.s1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool s1Specified
            {
                get
                {
                    return this.s1FieldSpecified;
                }
                set
                {
                    this.s1FieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte s2
            {
                get
                {
                    return this.s2Field;
                }
                set
                {
                    this.s2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool s2Specified
            {
                get
                {
                    return this.s2FieldSpecified;
                }
                set
                {
                    this.s2FieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte a
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool aSpecified
            {
                get
                {
                    return this.aFieldSpecified;
                }
                set
                {
                    this.aFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenPort
        {

            private schDesignTopDesignContainerChildrenPortChildren childrenField;

            private string nField;

            private uint hField;

            private string ppField;

            private byte aField;

            private bool aFieldSpecified;

            private string symField;

            /// <remarks/>
            public schDesignTopDesignContainerChildrenPortChildren Children
            {
                get
                {
                    return this.childrenField;
                }
                set
                {
                    this.childrenField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string n
            {
                get
                {
                    return this.nField;
                }
                set
                {
                    this.nField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint h
            {
                get
                {
                    return this.hField;
                }
                set
                {
                    this.hField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte a
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool aSpecified
            {
                get
                {
                    return this.aFieldSpecified;
                }
                set
                {
                    this.aFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sym
            {
                get
                {
                    return this.symField;
                }
                set
                {
                    this.symField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenPortChildren
        {

            private schDesignTopDesignContainerChildrenPortChildrenAtext atextField;

            /// <remarks/>
            public schDesignTopDesignContainerChildrenPortChildrenAtext Atext
            {
                get
                {
                    return this.atextField;
                }
                set
                {
                    this.atextField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenPortChildrenAtext
        {

            private uint lField;

            private string ppField;

            private string faceNameField;

            private decimal cellHeightField;

            private byte cellWidthField;

            private decimal cellStrokeField;

            private byte axField;

            private bool axFieldSpecified;

            private string tField;

            private string kField;

            private byte aField;

            private bool aFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string faceName
            {
                get
                {
                    return this.faceNameField;
                }
                set
                {
                    this.faceNameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellHeight
            {
                get
                {
                    return this.cellHeightField;
                }
                set
                {
                    this.cellHeightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte cellWidth
            {
                get
                {
                    return this.cellWidthField;
                }
                set
                {
                    this.cellWidthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellStroke
            {
                get
                {
                    return this.cellStrokeField;
                }
                set
                {
                    this.cellStrokeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ax
            {
                get
                {
                    return this.axField;
                }
                set
                {
                    this.axField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool axSpecified
            {
                get
                {
                    return this.axFieldSpecified;
                }
                set
                {
                    this.axFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string T
            {
                get
                {
                    return this.tField;
                }
                set
                {
                    this.tField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string K
            {
                get
                {
                    return this.kField;
                }
                set
                {
                    this.kField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte a
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool aSpecified
            {
                get
                {
                    return this.aFieldSpecified;
                }
                set
                {
                    this.aFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenWire
        {

            private schDesignTopDesignContainerChildrenWireE[] esField;

            private schDesignTopDesignContainerChildrenWireV[] vsField;

            private schDesignTopDesignContainerChildrenWireLP[] cnField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("e", IsNullable = false)]
            public schDesignTopDesignContainerChildrenWireE[] es
            {
                get
                {
                    return this.esField;
                }
                set
                {
                    this.esField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("v", IsNullable = false)]
            public schDesignTopDesignContainerChildrenWireV[] vs
            {
                get
                {
                    return this.vsField;
                }
                set
                {
                    this.vsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("lp", IsNullable = false)]
            public schDesignTopDesignContainerChildrenWireLP[] cn
            {
                get
                {
                    return this.cnField;
                }
                set
                {
                    this.cnField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenWireE
        {

            private uint hField;

            private byte iField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint h
            {
                get
                {
                    return this.hField;
                }
                set
                {
                    this.hField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte i
            {
                get
                {
                    return this.iField;
                }
                set
                {
                    this.iField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenWireV
        {

            private string ppField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenWireLP
        {

            private string[] pField;

            private decimal wField;

            private byte tsField;

            private byte isField;

            private byte teField;

            private byte ieField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("p")]
            public string[] p
            {
                get
                {
                    return this.pField;
                }
                set
                {
                    this.pField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal w
            {
                get
                {
                    return this.wField;
                }
                set
                {
                    this.wField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ts
            {
                get
                {
                    return this.tsField;
                }
                set
                {
                    this.tsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte @is
            {
                get
                {
                    return this.isField;
                }
                set
                {
                    this.isField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte te
            {
                get
                {
                    return this.teField;
                }
                set
                {
                    this.teField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ie
            {
                get
                {
                    return this.ieField;
                }
                set
                {
                    this.ieField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class schDesignTopDesignContainerChildrenText
        {

            private uint lField;

            private string ppField;

            private string faceNameField;

            private decimal cellHeightField;

            private decimal cellWidthField;

            private decimal cellStrokeField;

            private string tField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint L
            {
                get
                {
                    return this.lField;
                }
                set
                {
                    this.lField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pp
            {
                get
                {
                    return this.ppField;
                }
                set
                {
                    this.ppField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string faceName
            {
                get
                {
                    return this.faceNameField;
                }
                set
                {
                    this.faceNameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellHeight
            {
                get
                {
                    return this.cellHeightField;
                }
                set
                {
                    this.cellHeightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellWidth
            {
                get
                {
                    return this.cellWidthField;
                }
                set
                {
                    this.cellWidthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal cellStroke
            {
                get
                {
                    return this.cellStrokeField;
                }
                set
                {
                    this.cellStrokeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string T
            {
                get
                {
                    return this.tField;
                }
                set
                {
                    this.tField = value;
                }
            }
        }


    }
}
