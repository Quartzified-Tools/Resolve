using UnityEditor;

namespace Quartzified.Resolve.Editor
{
    public static class ResolveSettingsProvider
    {
        [SettingsProvider]
        static SettingsProvider SettingsProvider()
        {
            SettingsProvider provider = new SettingsProvider("Quartzified/Resolve", SettingsScope.User)
            {
                label = "Resolve",

                activateHandler = (searchContext, rootElement) =>
                {
                    ResolveEditorSettings settings = ResolveEditorSettings.GetAssets();
                }
            };

            return provider;
        }
    }
}

