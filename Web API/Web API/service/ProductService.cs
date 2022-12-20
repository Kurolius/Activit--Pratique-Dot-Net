
public interface ProductService
{
    Product Save(Product p);
    IEnumerable<Product> FindAll();
    IEnumerable<Product> FindByDesignation(string mc);
    Product GetOne(int ID);
    void Update(Product p);
    void Delete(int ID);
    Category GetCategorie(Product p);
}