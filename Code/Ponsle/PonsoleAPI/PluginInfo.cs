
namespace PonsleAPI
{
    public class PluginInfo
    {
        private string _name;
        private float _version;
        private string[] _authors;
        private float _ponsleVersion;

        // Exports

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public PluginInfo(string name, float version, string[] authors, float ponsleVersion)
        {
            _name = name;
            _version = version;
            _authors = authors;
            _ponsleVersion = ponsleVersion;
        }
    }
}
