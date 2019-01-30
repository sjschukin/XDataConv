using System.Collections.Generic;
using System.Linq;

namespace Schukin.XDataConv.Core.Csv
{
    public static class SourceMapInfo
    {
        public static IEnumerable<MemberMapInfo> GetInfo()
        {
            var sourceMap = new SourceMap();

            return sourceMap.MemberMaps
                .Where(item => item.Data.Names.Any()) // get map items with names only
                .Select(item => new MemberMapInfo
                {
                    PropertyName = item.Data.Member.Name,
                    FieldName = item.Data.Names.FirstOrDefault(),
                    MemberInfo = item.Data.Member
                }).ToArray();
        }
    }
}
