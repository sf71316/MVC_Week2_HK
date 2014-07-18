using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Week1_HK.Models
{
    public class ReportRepository : EFRepository<V_Report>, IReportRepository
    {

    }
    public interface IReportRepository : IRepository<V_Report>
    {

    }
}