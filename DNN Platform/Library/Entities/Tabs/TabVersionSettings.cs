﻿#region Copyright
// 
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2014
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Framework;

namespace DotNetNuke.Entities.Tabs
{
    public class TabVersionSettings: ServiceLocator<ITabVersionSettings, TabVersionSettings>, ITabVersionSettings
    {
        private int portalId = PortalSettings.Current.PortalId;
        public int MaximunNumberOfVersions
        {
            get { return PortalController.GetPortalSettingAsInteger("TabVersionsMaxNumber", portalId, 5); }
            set
            {
                PortalController.UpdatePortalSetting(portalId, "TabVersionsMaxNumber", value.ToString(CultureInfo.InvariantCulture));
            }
        }

        public bool VersioningEnabled
        {
            get { return Convert.ToBoolean(PortalController.GetPortalSetting("TabVersionsEnabled", portalId, Boolean.FalseString)); }
            set
            {
                PortalController.UpdatePortalSetting(portalId, "TabVersionsEnabled", value.ToString(CultureInfo.InvariantCulture));                
            }
        }

        protected override Func<ITabVersionSettings> GetFactory()
        {
            return () => new TabVersionSettings();
        }
    }
}