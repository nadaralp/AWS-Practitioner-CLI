namespace AWS.Practicing.Domain.Models
{
    public class OptionsSchema
    {
        public string Key { get; set; }
        public string Description { get; set; }

        public OptionsSchema()
        {
        }

        public OptionsSchema(string key, string description)
        {
            Key = key;
            Description = description;
        }

        public OptionsSchema(char key, string description) : this(key.ToString(), description)
        {
        }
    }
}