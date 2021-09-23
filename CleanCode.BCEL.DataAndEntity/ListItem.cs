using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public class ListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ListItem(string text, string value)
        {
            Text = text;
            Value = value;
        }
    }
}
