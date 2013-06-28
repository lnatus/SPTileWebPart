using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOne.SPTileWebPart.Tile
{
   public  class LocalizedWebCategoryAttribute : SPWebCategoryNameAttribute
    {
       private bool _isLocalized;

       public String ResourceFile { get; set; }

       public LocalizedWebCategoryAttribute(){ }

       public LocalizedWebCategoryAttribute(string categoryName) : this(categoryName, "core"){ }

       public LocalizedWebCategoryAttribute(string categoryName, string resourceFile): base(categoryName)
       {
           ResourceFile = resourceFile;
       }

       public override string CategoryName
       {
           get
           {
               if (!_isLocalized)
               {
                   this.CategoryNameValue = SPUtility.GetLocalizedString("$Resources:" + base.CategoryName, ResourceFile, (uint)CultureInfo.CurrentUICulture.LCID);
                   _isLocalized = true;
               }
               return base.CategoryName;
           }
       }
    }
}
