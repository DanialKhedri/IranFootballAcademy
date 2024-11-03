#region
using Application.DTOs.Category;
using Application.DTOs.Drill.DrillAgeDTO;
using Application.DTOs.Drill.DrillType;
using Application.DTOs.Order.OrderDTO;
using Application.DTOs.Product.ProductDTO;
using Application.DTOs.User.UserLogInDTO;
using Application.DTOs.User.UserReadOnlyDTO;
using Application.DTOs.User.UserRegisterDTO;
using Application.Services.Implement.Drilll;
using AutoMapper;
using Domain.Entities.Drill.Ages;

using Domain.Entities.Drill.DrillType;
using Domain.Entities.Order;
using Domain.Entities.Product;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Course;
using Application.DTOs.Course;
using Domain.Entities;
using Application.DTOs.Order.OrderDetailDTO;
using Domain.Entities.Order.OrderDetail;
using Domain.Entities.Payment;
using Application.DTOs.Payment;
#endregion

namespace Application.Utilities.AutoMapper;

public class MapperConfig : Profile
{

    public MapperConfig()
    {

        CreateMap<UserRegisterDTO, User>().ReverseMap();
        CreateMap<UserLogInDTO, User>().ReverseMap();
        CreateMap<UserResultLogInDTO, User>().ReverseMap();
        CreateMap<UserReadonlyDTO, User>().ReverseMap();

        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<CreateProductDTO, Product>().ReverseMap();
        CreateMap<ProductReadOnlyDTO, Product>().ReverseMap();


        CreateMap<OrderDTO, Order>().ReverseMap();
        CreateMap<OrderDetailDTO, OrderDetail>().ReverseMap();




        //Drills




        //DrillType

        CreateMap<DrillType, AddDrillTypeDTO>().ReverseMap();
        CreateMap<DrillType, DrillTypeReadOnlyDTO>().ReverseMap();


        //DrillAge

        CreateMap<DrillAge, AddDrillAgeReadDTO>().ReverseMap();
        CreateMap<DrillAge, DrillAgeReadonlyDTO>().ReverseMap();


        //Course

        CreateMap<Course, CourseReadonlyDTO>().ReverseMap();
        CreateMap<Course, AddCourseDTO>().ReverseMap();
        CreateMap<Course, EditCourseDTO>().ReverseMap();

        //Payment

        CreateMap<Payment, PaymentDTO>().ReverseMap();
    }










}
