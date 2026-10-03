using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorization.Models;

[Index("Isbn", IsUnique = true)]
public partial class Book
{
    [Key]
    [Column("BookID")]
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    [Column("ISBN")]
    public string Isbn { get; set; } = null!;

    public int PublishedYear { get; set; }

    [Column("GenreID")]
    public int GenreId { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("Books")]
    public virtual Genre Genre { get; set; } = null!;

    [InverseProperty("Book")]
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    [ForeignKey("BookId")]
    [InverseProperty("Books")]
    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
