using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    [Required]
    public int CategoryID { get; set; }
    [Required]
    [StringLength(35)]
    public string? CategoryName { get; set; }
    public virtual ICollection<Product>? Products { get; set; }

    public Category(int Id, string Name)
    {
        this.CategoryID = Id;
        this.CategoryName = Name;
    }
}

