namespace PonsleAPI
{
    public interface IPlugin
    {
        PluginInfo pluginInfo { get; }
        void Init();
        void Exit();
    }
}
