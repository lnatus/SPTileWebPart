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
    public class LocalizedWebDescriptionAttribute : WebDescriptionAttribute
    {
        private bool _isLocalized;
        public String ResourceFile { get; set; }

        public LocalizedWebDescriptionAttribute(){}

        public LocalizedWebDescriptionAttribute(string description): this(description, "core")
        {

        }

        public LocalizedWebDescriptionAttribute(string descriptions, string resourceFile)
        {
            ResourceFile = resourceFile;
        }

        public override string Description
        {
            get
            {
                if (!_isLocalized)
                {
                    this.DescriptionValue = SPUtility.GetLocalizedString("$Resources:" + base.Description, ResourceFile, (uint)CultureInfo.CurrentUICulture.LCID);
                    _isLocalized = true;
                }
                return base.Description;
            }
        }
    }
}
