
namespace Employee.Read.Domain.Redarbor.Entities
{
    public class EEmployee
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        public string Lastlogin { get; set; }
        public string Password { get; set; }
        public long PortalId { get; set; }
        public long RoleId { get; set; }
        public int StatusId { get; set; }
        public string Telephone { get; set; }
        public string Username { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
