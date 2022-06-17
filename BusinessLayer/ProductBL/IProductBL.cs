using BusinessLayer.DTO_s.Product;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.ProductBL
{
    public interface IProductBL
    {
        ProductReadDTO DeleteProduct(Guid id);
        ProductReadDTO GetById(Guid id);
        ActionResult<IEnumerable<ProductReadDTO>> GetProducts();
        ProductReadDTO Post(ProductWriteDTO _product);
    }
}