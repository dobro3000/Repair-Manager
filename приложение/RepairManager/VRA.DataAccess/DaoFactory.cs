namespace VRA.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class DaoFactory
    {
        public static ICountryDao GetCountryDao()
        {
            return new CountryDao();
        }

        public static IReportItemDao GetReportProcess()
        {
            return new ReportDao();
        }

        public static IInfoRepairDao InfoRepairDao()
        {
            return new InfoRepairDao();
        }

        public static SettingsDao GetSettingsDao()
        {
            return new SettingsDao();
        }

        public static IEnterpriseDao GetEnterprisenDao()
        {
            return new EnterpriseDao();
        }

        public static IMachineDao GeMachineDao()
        {
            return new MachineDao();
        }

        public static IRepairDao GetRepairDao()
        {
            return new RepairDao();
        }

        public static ITypeMachineDao GetTypeMashineDao()
        {
            return new TypeMachineDao();
        }

        public static ITypeRepairDao GetTypeRepairDao()
        {
            return new TypeRepairDao();
        }

        public static INameRepairDao GetNameRepairDao()
        {
            return new NameRepairDao();
        }
    }
}
