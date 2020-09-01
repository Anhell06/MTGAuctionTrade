using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AuctionerMTG.Model;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace AuctionerMTG.Controler
{
    class ParserWorker
    {
        private IParser _parser;
        private IParserSettings _parserSettings;
        private HtmlLoader _loader;
        private bool isActive;

        public IParser Parser { get { return _parser; } set { _parser = value; } }
        public IParserSettings Settings
        {
            get { return _parserSettings; }
            set
            {
                _parserSettings = value;
                _loader = new HtmlLoader(value);
            }
        }
        public bool IsActive { get { return isActive; } }

        public event Action<object, List<IAuction>> OnNewName;

        public event Action<object> OnComplited;

        public ParserWorker(IParser parser)
        {
            _parser = parser;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }
        public void Stop()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for (int i = _parserSettings.StartPoint; i < _parserSettings.EndPoint; i++)
            {
                if (isActive)
                {
                    string source = await _loader.GetSourseByPage(i);
                    HtmlParser docParser = new HtmlParser();
                    IHtmlDocument document = await docParser.ParseDocumentAsync(source);
                    OnNewName?.Invoke(this, _parser.Parse(document, DataType.auctionName));
                }
                

            }
            OnComplited?.Invoke(this);
            Stop();
            return;
        }


    }
}
