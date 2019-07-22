namespace Epam.NetMentoring.ConfigurationMapper.Model
{
    public class ConfigParameter
    {
        public ConfigParameter()
        {
        }
        public ConfigParameter(string classNameWithNamespace,string parameter,string value)
        {
            ClassNameWithNamespace = classNameWithNamespace;
            Parameter = parameter;
            Value = value;
        }

        public string ClassNameWithNamespace { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
    }
}
