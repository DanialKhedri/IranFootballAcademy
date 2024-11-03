#region Orderdetails
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Enums.Enums;
#endregion

namespace Domain.Entities.Order.OrderDetail;

public class OrderDetail
{

    #region Properties

    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public string Title { get; set; }

    public string ItemType { get; set; }


    public int Price { get; set; }


    #endregion


    #region Navigation Properties

    public Order Order { get; set; }


    #endregion

}
