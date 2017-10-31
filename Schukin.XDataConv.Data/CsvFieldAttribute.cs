using System;

namespace Schukin.XDataConv.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvFieldAttribute:Attribute
    {
        private string _name;

        public CsvFieldAttribute(string name)
        {
            _name = name;
        }
    }
}
