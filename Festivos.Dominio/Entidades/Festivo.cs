using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Dominio.Entidades
{
    [Table("Festivo")]
    public class Festivo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre"), StringLength(100)]
        public string Nombre { get; set; }

        [Column("Dia")]
        public int Dia { get; set; }

        [Column("Mes")]
        public int Mes { get; set; }

        [Column("DiasPascua")]
        public int DiasPascua { get; set; }

        [Column("IdTipo")]
        public int IdTipo { get; set; }

        [ForeignKey("IdTipo")]
        public Tipo Tipo { get; set; }
    }
}
