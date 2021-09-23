using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public class ListItemModel
    {
        public string Text { get; protected set; }
        public string Value { get; protected set; }

        public ListItemModel(string text, string value)
        {
            Text = text;
            Value = value;
        }
    }
}
