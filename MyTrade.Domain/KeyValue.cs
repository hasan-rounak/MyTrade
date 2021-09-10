using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrade.Domain
{
    public class KeyValue
    {
        public KeyValue()
        {
        }

        public KeyValue(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int Key { get; set; }

        public string Value { get; set; }
    }
}
