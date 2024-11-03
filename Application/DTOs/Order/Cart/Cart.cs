using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Order.Cart;

public class Cart
{

    public OrderDTO.OrderDTO Order { get; set; }

    public List<OrderDetailDTO.OrderDetailDTO> OrderDetailDTOs { get; set; } = new List<OrderDetailDTO.OrderDetailDTO>();

}
