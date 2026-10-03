using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorization.Models;

public partial class Genre
{
    [Key]
    [Column("GenreID")]
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    [InverseProperty("Genre")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
