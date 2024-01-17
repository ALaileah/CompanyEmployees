using Contracts;
using Entities.Models;


namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
 : base(repositoryContext)
        {
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) =>FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
        public void CreateCompany(Company company) => Create(company);
        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
 FindByCondition(x => ids.Contains(x.Id), trackChanges)
 .ToList();
        public void DeleteCompany(Company company) => Delete(company);


    }

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
 FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
 .OrderBy(e => e.Name).ToList();

        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
 FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id),
trackChanges)
 .SingleOrDefault();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);


    }


}
