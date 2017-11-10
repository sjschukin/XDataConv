using System.Reflection;

namespace Schukin.XDataConv.Data
{
    public class MapInfo
    {
        public string PropertyName { get; set; }
        public string FieldName { get; set; }
        public MemberInfo MemberInfo { get; set; }
    }
}
