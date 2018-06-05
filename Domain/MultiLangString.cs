using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;

namespace Domain
{
    public class MultiLangString
    {
        private static string _defaultLanguage = "en";

        public int MultiLangStringId { get; set; }

        [MaxLength(4096)]
        public string Value { get; set; }

        public virtual List<Translation> Translations { get; set; } = new List<Translation>();

        #region Constructors

        // default constructor just for EF and model binding
        public MultiLangString()
        {

        }

        public MultiLangString(string stringValue)
            : this(stringValue, Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
        {
        }

        public MultiLangString(string stringValue, string culture)
            : this(stringValue, culture, stringValue)
        {

        }

        public MultiLangString(string stringValue, string culture, string defaultStringValue)
        {
            // set the default
            if (string.IsNullOrWhiteSpace(Value) || culture == _defaultLanguage)
            {
                Value = defaultStringValue;
            }

            // TODO: if stringValue is in list of translations - update it else insert it
            SetTranslation(stringValue, culture);
        }
        #endregion
        public string Translate()
        {
            return Translate(Thread.CurrentThread.CurrentCulture.Name);
        }

        public string Translate(string culture)
        {
            var translation = FindExistingTranslation(culture);
            return translation == null ? Value + " (d)" : translation.Value;
        }


        public void SetTranslation(string stringValue)
        {
            SetTranslation(stringValue, Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
        }
        public void SetTranslation(string stringValue, string culture)
        {
            // do we have this language already among translations
            var translation = FindExistingTranslation(culture);

            // we tryd everything, its new
            if (translation == null)
            {
                Translations.Add(new Translation()
                {
                    Culture = culture,
                    Value = stringValue
                });
            }
            else
            {
                translation.Value = stringValue;
            }



        }

        private Translation FindExistingTranslation(string culture)
        {
            var translation = Translations.FirstOrDefault(a => a.Culture.ToUpper() == culture.ToUpper());
            // no direct match was found
            if (translation == null)
            {
                var language = culture.Split('-')[0];
                translation = Translations
                    .OrderBy(a => a.Culture)
                    .FirstOrDefault(a => a.Culture.ToUpper().StartsWith(language.ToUpper()));

            }

            return translation;
        }

        public override string ToString()
        {
            return Translate();
        }
    }
}
