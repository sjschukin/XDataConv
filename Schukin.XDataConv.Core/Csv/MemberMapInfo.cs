using System.Reflection;

namespace Schukin.XDataConv.Core.Csv
{
    public class MemberMapInfo
    {
        public string PropertyName { get; set; }
        public string FieldName { get; set; }
        public MemberInfo MemberInfo { get; set; }
    }
}
