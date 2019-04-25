using System.ComponentModel.DataAnnotations;

namespace InDev.DbModels
{
    public class DalToDo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ToDo { get; set; }
        public bool Done { get; set; }
    }
}
