using Microsoft.Extensions.Localization;
using System.Reflection;

namespace ProjectES.Models
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(ShareResource);
            var assamblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assamblyName.Name);
        }
        public LocalizedString Getkey(string key)
        {
            return _localizer[key];
        }
    }
}
