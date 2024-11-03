namespace DanCode_Blazor.Services.Base.interfaces
{
    public interface IProductService
    {

        public Task<Response<bool>> AddProduct(CreateProductDTO dto);



        public Task<Response<bool>> EditProduct(ProductDTO dto);


        public Task<Response<bool>> RemoveProduct(int ProductId);


        public Task<Response<bool>> ProductIsBuyed(int UserId, int ProductId);


        public Task<Response<List<ProductReadOnlyDTO>>> GetBuyedProductsByUserId(int UserId);



    }


}
