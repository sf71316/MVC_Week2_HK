using System;
namespace MVC_Week1_HK.Models
{
    interface I客戶聯絡人Data
    {
        DateTime CreateDateTime { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        bool IsDelete { get; set; }
        DateTime? UpdateDateTime { get; set; }
        string 手機 { get; set; }
        string 姓名 { get; set; }
        int 客戶Id { get; set; }
        客戶資料 客戶資料 { get; set; }
        string 電話 { get; set; }
        string 職稱 { get; set; }
    }
}
