using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Enums.Enums;

namespace Application.DTOs.Order.OrderDetailDTO;

public class OrderDetailDTO
{

    #region Properties

    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public string Title { get; set; }

    public string ItemType { get; set; }


    public int Price { get; set; }


    #endregion

}
