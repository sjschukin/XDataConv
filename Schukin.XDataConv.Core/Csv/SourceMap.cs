using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Schukin.XDataConv.Core.Csv
{
    public sealed class SourceMap : ClassMap<DataItem>
    {
        public SourceMap()
        {
            // LDID;ADRID;FAMIL;IMJA;OTCH;DROG;POSEL;NASP;YLIC;NDOM;NKORP;NKW;NKOMN;ILCHET;ILCHET_NEW;VIDGF;OPL;OTPL;KOLZR;GKU;ORG;VIDTAR;TARIF;FAKT;SUMTAR;SUMDOLG;OPLDOLG;DATDOLG;MONTH;YEAR
            Map(m => m.LdId).Name("LDID");
            Map(m => m.AdrId).Name("ADRID");
            Map(m => m.Famil).Name("FAMIL").TypeConverterOption.NullValues("");
            Map(m => m.Imja).Name("IMJA").TypeConverterOption.NullValues("");
            Map(m => m.Otch).Name("OTCH").TypeConverterOption.NullValues("");
            Map(m => m.Drog).Name("DROG");
            Map(m => m.Posel).Name("POSEL").TypeConverterOption.NullValues("");
            Map(m => m.Nasp).Name("NASP").TypeConverterOption.NullValues("");
            Map(m => m.Ylic).Name("YLIC").TypeConverterOption.NullValues("");
            Map(m => m.Ndom).Name("NDOM").TypeConverterOption.NullValues("");
            Map(m => m.Nkorp).Name("NKORP").TypeConverterOption.NullValues("");
            Map(m => m.Nkw).Name("NKW").TypeConverterOption.NullValues("");
            Map(m => m.Nkomn).Name("NKOMN").TypeConverterOption.NullValues("");
            Map(m => m.IlChet).Name("ILCHET").TypeConverterOption.NullValues("");
            Map(m => m.IlChetNew).Name("ILCHET_NEW").TypeConverterOption.NullValues("");
            Map(m => m.VidGf).Name("VIDGF").TypeConverterOption.NullValues("");
            Map(m => m.Opl).Name("OPL").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US"));
            Map(m => m.Otpl).Name("OTPL").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US"));
            Map(m => m.KolZr).Name("KOLZR");
            Map(m => m.Gku).Name("GKU");
            Map(m => m.Org).Name("ORG");
            Map(m => m.VidTar).Name("VIDTAR");
            Map(m => m.Tarif).Name("TARIF").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US"));
            Map(m => m.Fakt).Name("FAKT").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US"));
            Map(m => m.SumTar).Name("SUMTAR").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US"));
            Map(m => m.SumDolg).Name("SUMDOLG").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US"));
            Map(m => m.OplDolg).Name("OPLDOLG").TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("en-US"));
            Map(m => m.DatDolg).Name("DATDOLG");
            Map(m => m.Month).Name("MONTH");
            Map(m => m.Year).Name("YEAR");
            Map(m => m.RowId).ConvertUsing(row => ((CsvReader) row).Parser.Context.Row);
        }
    }
}
