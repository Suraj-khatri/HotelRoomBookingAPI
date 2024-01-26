using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BookingSystem.Localization
{
    public static class BookingSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BookingSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BookingSystemLocalizationConfigurer).GetAssembly(),
                        "BookingSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
