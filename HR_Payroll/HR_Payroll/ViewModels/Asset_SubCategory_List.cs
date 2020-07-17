using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_Payroll.Models;
using System.Data.Entity;

namespace HR_Payroll.ViewModels
{
    public class Asset_SubCategory_List
    {
        HR_PayrollEntities _db = new HR_PayrollEntities();
        List<AssetSubCategoryData> AsssubCatergoryList = new List<AssetSubCategoryData>();

        public List<AssetSubCategoryData> GetAssetSubCategoryData(int? Asset_Category_ID)
        {
            
            if (Asset_Category_ID == 0 || Asset_Category_ID == null)
            {
                var query = _db.Asset_Sub_Category.Include(m => m.Asset_Category).Where(m => m.Asset_Category_ID != null).ToList();
                AsssubCatergoryList = query.Select(i =>
                new AssetSubCategoryData
                {
                    Asset_Sub_Category_ID = i.Asset_Sub_Category_ID,
                    Sub_Category_Code = i.Sub_Category_Code,
                    Sub_Category_Name = i.Sub_Category_Name,
                    Asset_Category_ID = i.Asset_Category_ID,
                    Category_Name=i.Asset_Category.Category_Name,
                    SubAsset_Purchase_Date=i.SubAsset_Purchase_Date,
                    SubAsset_Warranty_Date=i.SubAsset_Warranty_Date,

                    SubAsset_Value=i.SubAsset_Value,
                    SubAsset_Recovery_Value=i.SubAsset_Recovery_Value,
                    SubAsset_ModelNo = i.SubAsset_ModelNo,
                    SubAsset_SerialNo=i.SubAsset_SerialNo
                }).ToList();
            }
            else
            {
                var query = _db.Asset_Sub_Category.Include(m => m.Asset_Category).Where(m => m.Asset_Category_ID == Asset_Category_ID).ToList();
                AsssubCatergoryList = query.Select(i =>
                new AssetSubCategoryData
                {
                    Asset_Sub_Category_ID = i.Asset_Sub_Category_ID,
                    Sub_Category_Code = i.Sub_Category_Code,
                    Sub_Category_Name = i.Sub_Category_Name,
                    Asset_Category_ID = i.Asset_Category_ID,
                    Category_Name = i.Asset_Category.Category_Name,
                    SubAsset_Purchase_Date = i.SubAsset_Purchase_Date,
                    SubAsset_Warranty_Date = i.SubAsset_Warranty_Date,
                    SubAsset_Value = i.SubAsset_Value,
                    SubAsset_Recovery_Value = i.SubAsset_Recovery_Value,
                    SubAsset_ModelNo = i.SubAsset_ModelNo,
                    SubAsset_SerialNo = i.SubAsset_SerialNo
                }).ToList();
            }

                return AsssubCatergoryList;
        }
    }

    public class AssetSubCategoryData
    {
        public int Asset_Sub_Category_ID { get; set; }
        public string Sub_Category_Code { get; set; }
        public string Sub_Category_Name { get; set; }
        public Nullable<int> Asset_Category_ID { get; set; }
        public string Category_Name { get; set; }
        public Nullable<System.DateTime> SubAsset_Purchase_Date { get; set; }
        public Nullable<System.DateTime> SubAsset_Warranty_Date { get; set; }
        public Nullable<decimal> SubAsset_Value { get; set; }
        public Nullable<decimal> SubAsset_Recovery_Value { get; set; }
        public string SubAsset_ModelNo { get; set; }
        public string SubAsset_SerialNo { get; set; }
    }
}