using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace DataOne.SPTileWebPart.Tile
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LocalizedWebDisplayNameAttribute : WebDisplayNameAttribute
    {
        private bool _isLocalized;
        public String ResourceFile { get; set; }

        public LocalizedWebDisplayNameAttribute(){}

        public LocalizedWebDisplayNameAttribute(string displayName) :  this (displayName,"core"){}

        public LocalizedWebDisplayNameAttribute(string displayName, string resourceFile)
            : base(displayName)
        {
            ResourceFile = resourceFile;
        }

        public override string DisplayName
        {
            get
            {
                if (!_isLocalized)
                {
                    this.DisplayNameValue = SPUtility.GetLocalizedString("$Resources:" + base.DisplayName, ResourceFile, (uint)CultureInfo.CurrentUICulture.LCID);
                    _isLocalized = true;
                }
                return base.DisplayName;
            }
        }
    }
}
