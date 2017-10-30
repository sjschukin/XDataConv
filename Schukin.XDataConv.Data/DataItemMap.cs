using System.Globalization;
using CsvHelper.Configuration;

namespace Schukin.XDataConv.Data
{
    public sealed class DataItemMap : ClassMap<DataItem>
    {
        public DataItemMap()
        {
            // LDID;FAMIL;IMJA;OTCH;DROG;POSEL;NASP;YLIC;NDOM;NKORP;NKW;NKOMN;ILCHET;VIDGF;OPL;OTPL;KOLZR;GKU;ORG;VIDTAR;TARIF;FAKT;SUMTAR;SUMDOLG;OPLDOLG;DATDOLG;MONTH;YEAR
            Map(m => m.LdId).Name("LDID");
            Map(m => m.Famil).Name("FAMIL");
            Map(m => m.Imja).Name("IMJA");
            Map(m => m.Otch).Name("OTCH");
            Map(m => m.Drog).Name("DROG");
            Map(m => m.Posel).Name("POSEL");
            Map(m => m.Nasp).Name("NASP");
            Map(m => m.Ylic).Name("YLIC");
            Map(m => m.Ndom).Name("NDOM");
            Map(m => m.Nkorp).Name("NKORP");
            Map(m => m.Nkw).Name("NKW");
            Map(m => m.Nkomn).Name("NKOMN");
            Map(m => m.IlChet).Name("ILCHET");
            Map(m => m.VidGf).Name("VIDGF");
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
        }
    }
}
