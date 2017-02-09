using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeCarotDAV
{
    class Config
    {
        public readonly static string[] CarotDAV_crypt_names = new string[]
        {
            "^_",
            ":D",
            ";)",
            "T-T",
            "orz",
            "ノシ",
            "（´・ω・）"
        };

        public static string CarotDAV_CryptNameHeader = CarotDAV_crypt_names[0];
    }
}
