using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestFull.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime PublishDate { get; set; }

    public int AuthorId { get; set; }

    public int CategoryId { get; set; }

}
