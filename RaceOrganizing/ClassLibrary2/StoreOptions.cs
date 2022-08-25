using System.ComponentModel.DataAnnotations;

namespace RaceOrganizing.Sql
{
    public sealed class StoreOptions
    {
        [Required]
        public string ConnectionString
        {
            get;
            set;
        }
    }
}
