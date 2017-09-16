using System.Collections.Generic;
using VRA.DataAccess;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class DtoConvert
    {

        #region Country

        public static CountryDto Convert(Country country)
        {
            if (country == null) return null;
            CountryDto countryDto = new CountryDto();
            countryDto.IDCountry = country.IDCountry;
            countryDto.NameCountry = country.NameCountry;
            return countryDto;
        }

        public static Country Convert(CountryDto countryDto)
        {
            if (countryDto == null) return null;
            Country country = new Country();
            country.IDCountry = countryDto.IDCountry;
            country.NameCountry = countryDto.NameCountry;
            return country;
        }

        internal static IList<CountryDto> Convert(IList<Country> country)
        {
            var countryss = new List<CountryDto>();
            foreach (var con in country)
            {
                countryss.Add(Convert(con));
            }
            return countryss;
        }

        #endregion

        #region Enterprise

        public static EnterpriseDto Convert(Enterprise enterprise)
        {
            if (enterprise == null) return null;
            EnterpriseDto enterpriseDto = new EnterpriseDto();
            enterpriseDto.IDEnterprise = enterprise.IDEnterprise;
            enterpriseDto.NameEnterprise = enterprise.NameEnterprise;
            return enterpriseDto;
        }

        public static Enterprise Convert(EnterpriseDto enterpriseDto)
        {
            if (enterpriseDto == null) return null;
            Enterprise enterprise = new Enterprise();
            enterprise.IDEnterprise = enterpriseDto.IDEnterprise;
            enterprise.NameEnterprise = enterpriseDto.NameEnterprise;
            return enterprise;
        }

        internal static IList<EnterpriseDto> Convert(IList<Enterprise> country)
        {
            var countryss = new List<EnterpriseDto>();
            foreach (var con in country)
            {
                countryss.Add(Convert(con));
            }
            return countryss;
        }

        #endregion

        #region Repair

        public static RepairDto Convert(Repair repair)
        {
            if (repair == null) return null;
            RepairDto repairDto = new RepairDto();
            repairDto.CodeMachine = repair.CodeMachine;
            repairDto.IDRepair = Convert(DaoFactory.GetNameRepairDao().Get( repair.IDRepair));

            repairDto.Note = repair.Note;
            repairDto.StartDate = repair.StartDate;

            return repairDto;
        }

        public static Repair Convert(RepairDto repairDto)
        {
            if (repairDto == null) return null;
            Repair repair = new Repair();
            repair.CodeMachine = repairDto.CodeMachine;
            repair.IDRepair = repairDto.IDRepair.IDRepair;
            repair.Note = repairDto.Note;
            repair.StartDate = repairDto.StartDate;
            return repair;
        }

        public static IList<RepairDto> Convert(IList<Repair> country)
        {
            if (country == null) return null;
            IList<RepairDto> countryss = new List<RepairDto>();
            foreach (var con in country)
            {
                countryss.Add(Convert(con));
            }
            return countryss;
        }

        #endregion

        #region Machine

        public static MachineDto Convert(Machine machine)
        {
            if (machine == null) return null;
            MachineDto machineDto = new MachineDto();
            machineDto.CodeMashine = machine.CodeMashine;
            machineDto.IDCountry = Convert(DaoFactory.GetCountryDao().Get(machine.IDCountry));

            machineDto.IDEnterprise = Convert(DaoFactory.GetEnterprisenDao().Get(machine.IDEnterprise));
            machineDto.NumberOfRepair = machine.NumberOfRepair;

            return machineDto;
        }

        public static Machine Convert(MachineDto machineDto)
        {
            if (machineDto == null) return null;
            Machine machine = new Machine();
            machine.CodeMashine = machineDto.CodeMashine;
            machine.IDCountry = machineDto.IDCountry.IDCountry;
            machine.IDEnterprise = machineDto.IDEnterprise.IDEnterprise;
            machine.NumberOfRepair = machineDto.NumberOfRepair;
            return machine;
        }

        public static IList<MachineDto> Convert(IList<Machine> machine)
        {
            if (machine == null) return null;
            IList<MachineDto> Machined = new List<MachineDto>();
            foreach (var con in machine)
            {
                Machined.Add(Convert(con));
            }
            return Machined;
        }

        #endregion

        #region TypeMachine

        public static TypeMachineDto Convert(TypeMachine typeMachine)
        {
            if (typeMachine == null) return null;
            TypeMachineDto typeMachineDto = new TypeMachineDto();
            typeMachineDto.CodeMachine = typeMachine.CodeMachine;
            typeMachineDto.Mark = typeMachine.Mark;

            typeMachineDto.YearOfIssue = typeMachine.YearOfIssue;

            return typeMachineDto;
        }

        public static TypeMachine Convert(TypeMachineDto typeMachine)
        {
            if (typeMachine == null) return null;
            TypeMachine machine = new TypeMachine();
            machine.CodeMachine = typeMachine.CodeMachine;
            machine.Mark = typeMachine.Mark;
            machine.YearOfIssue = typeMachine.YearOfIssue;
            return machine;
        }

        public static IList<TypeMachineDto> Convert(IList<TypeMachine> machine)
        {
            if (machine == null) return null;
            IList<TypeMachineDto> Machined = new List<TypeMachineDto>();
            foreach (var con in machine)
            {
                Machined.Add(Convert(con));
            }
            return Machined;
        }

        #endregion

        #region Type Repair

        public static TypeRepairDto Convert(TypeRepair repair)
        {
            if (repair == null) return null;
            TypeRepairDto repairDto = new TypeRepairDto();
            repairDto.Cost = repair.Cost;
            repairDto.IDRepair = repair.IDRepair;
            repairDto.Note = repair.Note;
            repairDto.Lenght = repair.Lenght;
            repairDto.NameRepair = repair.NameRepair;

            return repairDto;
        }

        public static TypeRepair Convert(TypeRepairDto repairDto)
        {
            if (repairDto == null) return null;
            TypeRepair repair = new TypeRepair();
            repair.Cost = repairDto.Cost;
            repair.IDRepair = repairDto.IDRepair;
            repair.Lenght = repairDto.Lenght;
            repair.NameRepair = repairDto.NameRepair;
            repair.Note = repairDto.Note;
            return repair;
        }

        public static IList<TypeRepairDto> Convert(IList<TypeRepair> machine)
        {
            if (machine == null) return null;
            IList<TypeRepairDto> Machined = new List<TypeRepairDto>();
            foreach (var con in machine)
            {
                Machined.Add(Convert(con));
            }
            return Machined;
        }

        #endregion

        #region InfoRepair

        public static InfoRepairDto Convert(InfoRepair country)
        {
            if (country == null) return null;
            InfoRepairDto countryDto = new InfoRepairDto();
            countryDto.Cost = country.Cost;
            countryDto.Length = country.Length;
            countryDto.NameRepairs = country.NameRepairs;
            countryDto.Note = country.Note;
            countryDto.StartDate = country.StartDate;
            return countryDto;
        }

        public static InfoRepair Convert(InfoRepairDto countryDto)
        {
            if (countryDto == null) return null;
            InfoRepair country = new InfoRepair();
            country.Cost = countryDto.Cost;
            country.Length = countryDto.Length;
            country.NameRepairs = countryDto.NameRepairs;
            country.Note = countryDto.Note;
            country.StartDate = countryDto.StartDate;
            return country;
        }

        internal static IList<InfoRepairDto> Convert(IList<InfoRepair> country)
        {
            var countryss = new List<InfoRepairDto>();
            foreach (var con in country)
            {
                countryss.Add(Convert(con));
            }
            return countryss;
        }


        #endregion


        private static ReportItemDto Convert(Report report)
        {
            if (report == null) { return null; }
            ReportItemDto reportdto = new ReportItemDto
            {
                date = report.date.ToString(),
                count =
                    report.count,
                price = report.price
            };
            return reportdto;
        }

        public static IList<ReportItemDto> Convert(IEnumerable<Report> reports)
        {
            if (reports == null) { return null; }
            IList<ReportItemDto> ReportsDto = new List<ReportItemDto>();
            foreach (var r in reports)
            {
                ReportsDto.Add(Convert(r));
            }
            return ReportsDto;
        }


        public static NameRepairDto Convert(NameRepair country)
        {
            if (country == null) return null;
            NameRepairDto countryDto = new NameRepairDto();
            countryDto.IDRepair = country.IDRepair;
            countryDto.NameTypeRepair = country.NameTypeRepair;
            return countryDto;
        }

        public static NameRepair Convert(NameRepairDto countryDto)
        {
            if (countryDto == null) return null;
            NameRepair country = new NameRepair();
            country.IDRepair = countryDto.IDRepair;
            country.NameTypeRepair = countryDto.NameTypeRepair;
            return country;
        }

        internal static IList<NameRepairDto> Convert(IList<NameRepair> country)
        {
            var countryss = new List<NameRepairDto>();
            foreach (var con in country)
            {
                countryss.Add(Convert(con));
            }
            return countryss;
        }

    }
}
