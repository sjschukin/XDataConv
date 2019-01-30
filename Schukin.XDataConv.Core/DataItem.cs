using System;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core
{
    public class DataItem : IDataItem
    {
        public int RowId { get; set; }
        public string LdId { get; set; }
        public string AdrId { get; set; }
        public string Famil { get; set; }
        public string Imja { get; set; }
        public string Otch { get; set; }
        public DateTime? Drog { get; set; }
        public string Posel { get; set; }
        public string Nasp { get; set; }
        public string Ylic { get; set; }
        public string Ndom { get; set; }
        public string Nkorp { get; set; }
        public string Nkw { get; set; }
        public string Nkomn { get; set; }
        public string IlChet { get; set; }
        public string IlChetNew { get; set; }
        public string VidGf { get; set; }
        public decimal? Opl { get; set; }
        public decimal? Otpl { get; set; }
        public int? KolZr { get; set; }
        public string Gku { get; set; }
        public string Org { get; set; }
        public int? VidTar { get; set; }
        public decimal? Tarif { get; set; }
        public decimal? Fakt { get; set; }
        public decimal? SumTar { get; set; }
        public decimal? SumDolg { get; set; }
        public decimal? OplDolg { get; set; }
        public DateTime? DatDolg { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
