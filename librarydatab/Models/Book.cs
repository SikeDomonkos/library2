using System;
using System.Collections.Generic;

namespace librarydatab.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime PublishDate { get; set; }

    public int AuthorId { get; set; }

    public int CategoryId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
