using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Collections.Generic;
using Microsoft.SharePoint.Utilities;


namespace DataOne.SPTileWebPart.Tile
{
    public class Tile : TilesViewWebPart
    {
        [WebBrowsable]
        [Personalizable(PersonalizationScope.Shared)]
        [LocalizedWebDisplayName ("TileTitle","SPTileResource")]
        [LocalizedWebDescription ("TileTitleDescription", "SPTileResource")]
        [LocalizedWebCategory("TileCategory", "SPTileResource")]
        public String TileTitel { get; set; }

        [WebBrowsable]
        [Personalizable(PersonalizationScope.Shared)]
        [LocalizedWebDisplayName("TileDescription", "SPTileResource")]
        [LocalizedWebDescription("TileDescriptionDescription", "SPTileResource")]
        [LocalizedWebCategory("TileCategory", "SPTileResource")]
        public String TileDescription { get; set; }

        [WebBrowsable]
        [Personalizable(PersonalizationScope.Shared)]
        [LocalizedWebDisplayName("TileLaunchBehavior", "SPTileResource")]
        [LocalizedWebDescription("TileLaunchBehaviorDescription", "SPTileResource")]
        [LocalizedWebCategory("TileCategory", "SPTileResource")]
        public TileLaunchBehavior TileLaunchBehavior { get; set; }

        [WebBrowsable]
        [Personalizable(PersonalizationScope.Shared)]
        [LocalizedWebDisplayName("TileLink", "SPTileResource")]
        [LocalizedWebDescription("TileLinkDescription", "SPTileResource")]
        [LocalizedWebCategory("TileCategory", "SPTileResource")]
        public String TileLink { get; set; }

        [WebBrowsable]
        [Personalizable(PersonalizationScope.Shared)]
        [LocalizedWebDisplayName("TileBackgroundImageLocation", "SPTileResource")]
        [LocalizedWebDescription("TileImageLocationDescription", "SPTileResource")]
        [LocalizedWebCategory("TileCategory", "SPTileResource")]
        public String TileBackgroundImageLocation { get; set; }

        public Tile()
        {
            BaseViewID = ((int)TilesBaseViewID.TileView).ToString();
        }

        protected override TileData[] GetTiles()
        {
            SPUtility.GetLocalizedString("$Resources:SPTile_Properties", "SPTileResource", (uint)SPContext.Current.Web.Locale.LCID);

            var tiles = new List<TileData>();
            tiles.Add(new TileData
            {
                Title = TileTitel,
                Description = TileDescription,
                LaunchBehavior = TileLaunchBehavior,
                LinkLocation = TileLink,
                BackgroundImageLocation = TileBackgroundImageLocation,
                TileOrder = 0
            });
            return tiles.ToArray();
        }

        protected override string ViewTitle
        {
            get { return ""; }
        }
    }
}
