using System;

namespace STX
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class Table : Attribute
    {
        public string TableName { get; set; }
        public string NomeSingular { get; set; }
        public string NomePlural { get; set; }
        public Table(string tableName, string nomeSingular, string nomePlural)
        {
            TableName = tableName;
        }
    }
    public class Field : Attribute
    {
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public SqlTypes FieldType { get; set; }
        public bool IsPrimaryAutoIncrement { get; set; }
        public bool IsNotNull { get; set; }
        public bool Visible { get; set; }
        public int ComponentWidth { get; set; }

        public Field(string fieldName, string displayName, SqlTypes fieldType, bool isPrimaryAutoIncrement = false, bool isNotNull = false, bool visible = true, int componentWidth = 200)
        {
            FieldName = fieldName;
            DisplayName = displayName;
            FieldType = fieldType;
            IsPrimaryAutoIncrement = isPrimaryAutoIncrement;
            IsNotNull = isNotNull;
            Visible = visible;
            ComponentWidth = componentWidth;
        }

    }
    public class ForeignKey : Attribute
    {
        public Type FkEntity { get; set; }
        public string ForeignKeyDisplayField { get; set; }
        public string ForeignKeyField { get; set; }
        public ForeignKey(Type fkEntity, string foreignKeyDisplayField, string foreignKeyField = "id")
        {
            FkEntity = fkEntity;
            ForeignKeyDisplayField = foreignKeyDisplayField;
            ForeignKeyField = foreignKeyField;
        }
    }
    public enum SqlTypes { varchar = 0, integer = 1, real = 2, boolean = 3, datetime = 4, longtext = 5, money = 6, foreignKey = 7 }
}
