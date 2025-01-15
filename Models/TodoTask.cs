using System.ComponentModel.DataAnnotations;

namespace ExerciceEfCore.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        public string Description { get; set; }
        public bool EstFini { get; set; }

        public TodoTask() { } // Constructeur par défaut
    }
}
