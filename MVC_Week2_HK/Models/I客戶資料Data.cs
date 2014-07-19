using System;
namespace MVC_Week1_HK.Models
{
    interface I客戶資料Data
    {
        DateTime CreateDateTime { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        bool IsDelete { get; set; }
        DateTime? UpdateDateTime { get; set; }
        string 地址 { get; set; }
        string 客戶名稱 { get; set; }
        System.Collections.Generic.ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        System.Collections.Generic.ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
        string 統一編號 { get; set; }
        string 傳真 { get; set; }
        string 電話 { get; set; }
    }
}
