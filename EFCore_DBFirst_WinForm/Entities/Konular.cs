using System;
using System.Collections.Generic;

namespace EFCore_DBFirst_WinForm.Entities
{
    public partial class Konular
    {
        public Konular()
        {
            Yorumlars = new HashSet<Yorumlar>();
        }

        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string? Aciklama { get; set; }
        public DateTime Tarih { get; set; }

        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
