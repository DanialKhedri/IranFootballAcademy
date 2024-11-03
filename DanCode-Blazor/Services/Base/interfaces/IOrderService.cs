namespace DanCode_Blazor.Services.Base.interfaces
{
    public interface IOrderService
    {

        public Task<Response<Cart>> GetCart(int UserId);

        public Task<Response<OrderDTO>> GetOrderByOrderId(int OrderId);

        public Task<Response<ICollection<OrderDetailDTO>>> GetOrderDetailsByOrderId(int OrderId);

        public Task<Response<ICollection<OrderDTO>>> GetAllFinalizedOrders();

        //Add Course To Cart
        public Task<Response<bool>> AddCourseToCart(int UserId, int CourseId);


        //Add Product To Cart
        public Task<Response<bool>> AddProductToCart(int UserId, int ProductId);


        //Remove OrdeDetail
        public Task<Response<bool>> RemoveOrderDetail(int OrderDetailId);

        public Task<Response<ICollection<OrderDTO>>> GetFinalizedOrderByUserId(int UserId);

        //Get All Finalized Orders
        public Task<Response<TotalSalesDTO>> GetTotlaSales();

        //Get Last Five Orders
        public Task<Response<ICollection<OrderDTO>>> GetLastFiveOrders();


    }

}
