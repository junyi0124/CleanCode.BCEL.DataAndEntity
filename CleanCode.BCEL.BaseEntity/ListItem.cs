namespace CleanCode.BCEL.BaseEntity
{

    public class ListItem
    {
        public string Text { get; protected set; }
        public string Value { get; protected set; }

        public ListItem(string text, string value)
        {
            Text = text;
            Value = value;
        }
    }
}
