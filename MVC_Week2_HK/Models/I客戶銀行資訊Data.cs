using System;
namespace MVC_Week1_HK.Models
{
    interface I客戶銀行資訊Data
    {
        DateTime CreateDateTime { get; set; }
        int Id { get; set; }
        bool IsDelete { get; set; }
        DateTime? UpdateDateTime { get; set; }
        int? 分行代碼 { get; set; }
        int 客戶Id { get; set; }
        客戶資料 客戶資料 { get; set; }
        string 帳戶名稱 { get; set; }
        string 帳戶號碼 { get; set; }
        int 銀行代碼 { get; set; }
        string 銀行名稱 { get; set; }
    }
}
