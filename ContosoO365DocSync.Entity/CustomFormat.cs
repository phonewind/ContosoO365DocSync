using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Entity
{
    public class CustomFormat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public int OrderBy { get; set; }

        public bool IsDeleted { get; set; }

        public string GroupName { get; set; }

        public int GroupOrderBy { get; set; }

        [JsonIgnore]
        public virtual ICollection<DestinationPoint> DestinationPoints { get; set; }
    }
}
