using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TityoAttendance.Localization
{
    public static class TityoAttendanceLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TityoAttendanceConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TityoAttendanceLocalizationConfigurer).GetAssembly(),
                        "TityoAttendance.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
