using System.Collections.Generic;

namespace UfoObjectTree.Entities
{
    public class UfoType
    {
        public string Class { get; set; }
        public string Namespace { get; set; }
        public List<UfoFieldBase> UfoFields { get; set; }

        public string FullName
        {
            get { return string.Format("{0}.{1}", Namespace, Class); }
        }
    }

    public class UfoFieldBase
    {
        public string Name { get; set; }
        public string Comment { get; set; }
    }

    public class UfoEnum : UfoFieldBase
    {
        public string Value { get; set; }
    }

    public class UfoField : UfoFieldBase
    {
        public FieldType FieldType { get; set; }
        public string Type { get; set; }
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public UfoType LinkedType { get; set; }
        public string Icon
        {
            get
            {
                switch (this.FieldType)
                {
                    case FieldType.Field:
                        if (this.Type == "class")
                            return "TencentWeibo";
                        else if (this.Type == "enum")
                            return "InDent";
                        else if (this.Type == "array")
                            return "Bars";
                        else
                            return "Flash";
                    case FieldType.KeyRef:
                        return "ExternalLink";
                    case FieldType.PrimaryKey:
                        return "Key";                    
                }
                return "QuestionCircle";
            }
        }
    }

    public enum FieldType
    {
        Field,
        KeyRef,
        PrimaryKey
    }
}
