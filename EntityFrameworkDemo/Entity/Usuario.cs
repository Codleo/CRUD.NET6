using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo
{
    public class Usuario
    {
        [Required]
        public Guid ID { get; private set; } // private set para o usuario não conseguir setar o Id
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(8)]
        public string Senha { get; set; }

        public Usuario()
        {
            ArgumentNullException.ThrowIfNull(nameof(ID));
            ArgumentNullException.ThrowIfNull(nameof(Nome));
            ArgumentNullException.ThrowIfNull(nameof(Email));
            ArgumentNullException.ThrowIfNull(nameof(Telefone));
            ArgumentNullException.ThrowIfNull(nameof(Senha));
            ID = Guid.NewGuid();
        }
    }
}
