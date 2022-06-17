using AutoMapper;
using BusinessLayer.DTO_s.Product;
using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.DataBaseModels;
using DataAccessLayer.Repositories.Product_Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProductBL
{
    public class ProductBL : IProductBL
    {
        private readonly IProduct_Repository _ptoductRepo;
        private readonly IMapper _mapper;

        public ProductBL(IProduct_Repository ptoductRepo, IMapper mapper, MyContext _context)
        {
            this._ptoductRepo = ptoductRepo;
            _mapper = mapper;
        }

        public ActionResult<IEnumerable<ProductReadDTO>> GetProducts()
        {
            var productFromDB = _ptoductRepo.GetAll();
            return _mapper.Map<List<ProductReadDTO>>(productFromDB);

        }

        public ProductReadDTO Post(ProductWriteDTO _product)
        {
            var productToAdd = _mapper.Map<Product>(_product);


            productToAdd.Id = Guid.NewGuid();

            _ptoductRepo.Add(productToAdd);
            _ptoductRepo.SaveChanges();


            return _mapper.Map<ProductReadDTO>(productToAdd);
        }


        public ProductReadDTO GetById(Guid id)
        {
            var productFromDB = _ptoductRepo.GetById(id);


            return _mapper.Map<ProductReadDTO>(productFromDB);
        }

        public ProductReadDTO DeleteProduct(Guid id)
        {
            var productDeleted = _ptoductRepo.GetById(id);


            _ptoductRepo.Delete(id);
            _ptoductRepo.SaveChanges();

            return _mapper.Map<ProductReadDTO>(productDeleted);

        }



    }
}
