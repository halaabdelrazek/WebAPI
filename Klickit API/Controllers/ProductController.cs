using BusinessLayer.DTO_s.Product;
using BusinessLayer.ProductBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Klickit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL productBL;

        public ProductController(IProductBL productBL)
        {
            this.productBL = productBL;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDTO>> GetProduct()
        {

            return productBL.GetProducts();

        }
        // POST: api/product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProductReadDTO> PostProduct(ProductWriteDTO product)
        {
            var productDTO = productBL.Post(product);
            return Created("Product Created", productDTO);
        }



        // DELETE: api/Product/id
        [HttpDelete("{id}")]
        public ActionResult<ProductReadDTO> DeleteProduct(Guid id)
        {
            var returnedProduct = productBL.DeleteProduct(id);

            return Ok(returnedProduct);
        }


        // GET: api/Product/id
        [HttpGet("{id}")]
        public ActionResult<ProductReadDTO> GetProduct(Guid id)
        {
          
            return productBL.GetById(id);
        }


    }
}
