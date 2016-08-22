﻿using System.Threading.Tasks;
using System.Xml;

using DynamicTranslator.Constants;

namespace DynamicTranslator.Application.Yandex
{
    public class YandexMeanOrganizer : AbstractMeanOrganizer
    {
        public override TranslatorType TranslatorType => TranslatorType.Yandex;

        public override Task<Maybe<string>> OrganizeMean(string text, string fromLanguageExtension)
        {
            if (text == null)
                return Task.FromResult(new Maybe<string>());

            var doc = new XmlDocument();
            doc.LoadXml(text);
            var node = doc.SelectSingleNode("//Translation/text");
            var output = node?.InnerText ?? "!!! An error occurred";

            return Task.FromResult(new Maybe<string>(output.ToLower().Trim()));
        }
    }
}