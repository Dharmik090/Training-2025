using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureNotes.Domain
{
    public class CryptoFields
    {
        public string Ciphertext { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public string Nonce { get; set; } = String.Empty;
        public string Tag { get; set; } = String.Empty;

    }
}
