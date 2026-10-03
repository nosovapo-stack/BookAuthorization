using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorization.Models;

public partial class Author
{
    [Key]
    [Column("AuthorID")]
    public int AuthorId { get; set; }

    public string FullName { get; set; } = null!;

    [Column(TypeName = "DATE")]
    public string BirthDate { get; set; } = null!;

    [ForeignKey("AuthorId")]
    [InverseProperty("Authors")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
