namespace MVC_Week1_HK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();
            客戶資料 e= repo.Find(p => p.Id == this.客戶Id);
            if (e.客戶聯絡人.Any(p => p.Email == this.Email && p.Id!=this.Id))
            {
                yield return new ValidationResult("客戶聯絡人電子信箱重覆", new string[] { "Email" });
            }
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Required]
        public System.DateTime CreateDateTime { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
