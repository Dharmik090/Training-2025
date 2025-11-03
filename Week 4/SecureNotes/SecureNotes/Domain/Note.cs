using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureNotes.Domain
{
    internal class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public CryptoFields CryptoFields { get; set; } = new CryptoFields();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
