namespace MVC_Week1_HK.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static V_ReportRepository GetV_ReportRepository()
		{
			var repository = new V_ReportRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static V_ReportRepository GetV_ReportRepository(IUnitOfWork unitOfWork)
		{
			var repository = new V_ReportRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶資料Repository Get客戶資料Repository()
		{
			var repository = new 客戶資料Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶資料Repository Get客戶資料Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶資料Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository()
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶聯絡人Repository Get客戶聯絡人Repository()
		{
			var repository = new 客戶聯絡人Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶聯絡人Repository Get客戶聯絡人Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶聯絡人Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}
        public static ReportRepository GetViewRepository()
        {
            var repository = new ReportRepository();
            repository.UnitOfWork = GetUnitOfWork();
            return repository;
        }
        public static ReportRepository GetViewRepository(IUnitOfWork unitOfWork)
        {
            var repository = new ReportRepository();
            repository.UnitOfWork = unitOfWork;
            return repository;
        }		
	}
}