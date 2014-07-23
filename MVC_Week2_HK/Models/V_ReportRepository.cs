using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_Week1_HK.Models
{   
	public  class V_ReportRepository : EFRepository<V_Report>, IV_ReportRepository
	{

	}

	public  interface IV_ReportRepository : IRepository<V_Report>
	{

	}
}