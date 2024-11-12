#region Usings
using Domain.Entities.Order.OrderDetail;
using Domain.Entities.Order;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Drill;
using Domain.Entities.Drill.Ages;
using Domain.Entities.Drill.DrillType;
using Domain.Entities.Drill.DrillType;
using Domain.Entities.Course;
using Domain.Entities;
using Domain.Entities.Payment;
using Domain.Entities.Article;
#endregion

namespace Infrastructure.Data;

public class DataContext : DbContext
{


    #region Ctor

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {


    }

    #endregion


    #region Db Sets

    public DbSet<User> Users { get; set; }


    #region Drills
    public DbSet<Drill> Drills { get; set; }



    public DbSet<DrillAge> DrillAges { get; set; }
    public DbSet<SelectedAge> SelectedAges { get; set; }


    public DbSet<DrillType> DrillTypes { get; set; }
    public DbSet<SelectedDrillType> SelectedDrillTypes { get; set; }

    #endregion


    #region product

    public DbSet<Product> Products { get; set; }
   
    public DbSet<BuyedProduct> BuyedProducts { get; set; } 

    #endregion



    #region Order
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }


    #endregion



    #region Course

    public DbSet<Course> Courses { get; set; }

    public DbSet<Video> Videos { get; set; }

    public DbSet<BuyedCourse> BuyedCourses { get; set; }



    #endregion


    #region Payment

    public DbSet<Payment> Payments { get; set; }


    #endregion


    #region  Article

    public DbSet<Article> Articles { get; set; }

    #endregion


    #endregion

}
