using System;
using System.Collections.Generic;

namespace EFCore_DBFirst_WinForm.Entities
{
    public partial class Yorumlar
    {
        public int Id { get; set; }
        public string Icerik { get; set; } = null!;
        public DateTime Tarih { get; set; }
        public string Yorumcu { get; set; } = null!;
        public int KonuId { get; set; }

        public virtual Konular Konu { get; set; } = null!;
    }
}
