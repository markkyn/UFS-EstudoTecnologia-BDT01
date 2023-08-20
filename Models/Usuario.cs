using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;


namespace SistemaOcorrencias.Models
{

    public class Usuario
    {
        [Key]
        [Required]
        public UInt64  cpf { get; set; }

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required]
        public DateTime data_nascimento { get; set; }
    }
}
