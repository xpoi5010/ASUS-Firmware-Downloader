/*
 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASUS_Firmware_Downloader
{
    public struct ModelResults
    {
        public string Status;
        public Result Result;
        public string Message;
    }
    public struct Result
    {
        public string Count;
        public string WTBClassFlag;
        public ModelObj[] Obj;

    }
    public struct ModelObj
    {
        public string PDHashedId;
        public string PDMarketName;
        public string PDSlogan;
        public string BusinessPDSlogan;
        public string Url;
        public string ImageUrl;
        public string PDCompareCookieId;
        public string Size;
        public string SalePrice;
        public WTB WTB;
        public object[] Color;
    }
    public struct WTB
    {
        public string Name;
        public string Link;
        public string Price;
    }
    public struct DriverResults
    {
        public DriverResult Result;
        public string Status;
        public string Message;
    }
    public struct DriverResult
    {
        public int Count;
        public DriverObj[] Obj;
    }
    public struct DriverObj
    {
        public string Name;
        public int Count;
        public DriverFile[] Files;
    }
    public struct DriverFile
    {
        public string Id;
        public string Version;
        public string Title;
        public string Description;
        public string FileSize;
        public string IsRelease;
        public string ReleaseDate;
        public string PosType;
        public DriverDownloadUrl DownloadUrl;
    }
    public struct DriverDownloadUrl
    {
        public string Global;
        public string China;
    }
    public struct notshowProduct
    {
        public string HashId;
        public string imageUrl;
        public string Name;
        public string ProductUrl;
    }
    public struct UpdataInfo
    {
        public string ProductName;
        public string Version;
        public string DownloadUrl;
    }
}
