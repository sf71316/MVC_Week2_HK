using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Week1_HK.Models.viewModel
{
    public class BatchUpdateViewModel
    {
        public IEnumerable<BatchBankData> bank { get; set; }
        public IEnumerable<BatchContactData> contact { get; set; }
    }
    public class BatchBankData
    {
        public int Id { get; set; }
        public string 帳戶號碼 { get; set; }
    }
    public class BatchContactData
    {
        public int Id { get; set; }
        public string 電話 { get; set; }
    }
}