﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCAxis.Web.Core;
using PCAxis.Web.Controls.CommandBar.Plugin;
using System.Web.UI.WebControls;

namespace PCAxis.JsonStat2.Web.Controls
{
    public class JsonStat2FileTypeCodebehind : FileTypeControlBase<JsonStat2FileTypeCodebehind, JsonStat2FileType>
    {
        public JsonStat2FileTypeCodebehind()
        {
            this.Load += Json2Stat_Load;
        }


        /// <summary>
        /// Called when the user control is loaded
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        /// <remarks></remarks>
        private void Json2Stat_Load(object sender, System.EventArgs e)
        {
            OnFinished();
            Marker.SerializeAndStream();
        }
    }
}
