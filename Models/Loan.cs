using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorization.Models;

public partial class Loan
{
    [Key]
    [Column("LoanID")]
    public int LoanId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("BookID")]
    public int BookId { get; set; }

    [Column(TypeName = "DATE")]
    public DateOnly DateLoans { get; set; }

    public int Rating { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Loans")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Loans")]
    public virtual User User { get; set; } = null!;
}
