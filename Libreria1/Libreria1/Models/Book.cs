using System;
using System.Collections.Generic;

namespace Libreria1.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; } 

    public int? Chapters { get; set; }

    public int? Pages { get; set; }

    public int? Price { get; set; }

    public int? IdAuthor { get; set; }

    public virtual Author? IdAuthorNavigation { get; set; }
}
