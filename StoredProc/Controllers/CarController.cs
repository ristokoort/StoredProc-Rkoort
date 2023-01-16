using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoredProc.Data;
using StoredProc.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace StoredProc.Controllers
{
    public class CarController : Controller
    {
        public class CarsController : Controller
        {
            private readonly StoredProcDbContext _context;
            public IConfiguration _config { get; }

            public CarsController
                (
                StoredProcDbContext context,
                IConfiguration config
                )
            {
                _context = context;
                _config = config;

            }


            public IActionResult Index()
            {
                return View();
            }

            public IEnumerable<Car> SearchResult()
            {
                var result = _context.Car
                    .FromSqlRaw<Car>("dbo.spSearchCars")
                    .ToList();

                return result;
            }


            [HttpGet]
            public IActionResult DynamicSQL()
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCars";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    List<Car> model = new List<Car>();
                    while (sdr.Read())
                    {
                        var details = new Car();
                        details.Brand = sdr["Brand"].ToString();
                        details.Type = sdr["Type"].ToString();
                        details.Color = sdr["Color"].ToString();
                        details.Price = 10000;
                        model.Add(details);
                    }
                    return View(model);
                }
            }


            /// <returns></returns>
            [HttpPost]
            public IActionResult DynamicSQL(string Brand, string Type, string Color, int Price)
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCars";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (Brand != null)
                    {
                        SqlParameter param = new SqlParameter("@Brand", Brand);
                        cmd.Parameters.Add(param);
                    }
                    if (Type != null)
                    {
                        SqlParameter param = new SqlParameter("@Type", Type);
                        cmd.Parameters.Add(param);
                    }
                    if (Color != null)
                    {
                        SqlParameter param = new SqlParameter("@Color", Color);
                        cmd.Parameters.Add(param);
                    }
                    if (Price != 0)
                    {
                        SqlParameter param = new SqlParameter("@Price", Price);
                        cmd.Parameters.Add(param);
                    }
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    List<Car> model = new List<Car>();
                    while (sdr.Read())
                    {
                        var details = new Car();
                        details.Brand = sdr["Brand"].ToString();
                        details.Type = sdr["Type"].ToString();
                        details.Color = sdr["Color"].ToString();
                        details.Price = 10000;
                        model.Add(details);
                    }
                    return View(model);
                }
            }

            [HttpGet]
            public IActionResult SearchWithDynamics()
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCarsGoodDynamicSQL";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    List<Car> model = new List<Car>();
                    while (sdr.Read())
                    {
                        var details = new Car();
                        details.Brand = sdr["Brand"].ToString();
                        details.Type = sdr["Type"].ToString();
                        details.Color = sdr["Color"].ToString();
                        details.Price = 10000;
                        model.Add(details);
                    }
                    return View(model);
                }
            }

            [HttpPost]
            public IActionResult SearchWithDynamics(string Brand, string Type, string Color, int Price)
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCarsGoodDynamicSQL";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (Brand != null)
                    {
                        SqlParameter param = new SqlParameter("@Brand", Brand);
                        cmd.Parameters.Add(param);
                    }
                    if (Type != null)
                    {
                        SqlParameter param = new SqlParameter("@Type", Type);
                        cmd.Parameters.Add(param);
                    }
                    if (Color != null)
                    {
                        SqlParameter param = new SqlParameter("@Color", Color);
                        cmd.Parameters.Add(param);
                    }
                    if (Price != 0)
                    {
                        SqlParameter param = new SqlParameter("@Price", Price);
                        cmd.Parameters.Add(param);
                    }
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    List<Car> model = new List<Car>();
                    while (sdr.Read())
                    {
                        var details = new Car();
                        details.Brand = sdr["Brand"].ToString();
                        details.Type = sdr["Type"].ToString();
                        details.Color = sdr["Color"].ToString();
                        details.Price = 10000;
                        model.Add(details);
                    }
                    return View(model);
                }
            }

            [HttpGet]
            public IActionResult DynamicSQLInStoredProcedure()
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCarsGoodDynamicSQL";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    List<Car> model = new List<Car>();
                    while (sdr.Read())
                    {
                        var details = new Car();
                        details.Brand = sdr["Brand"].ToString();
                        details.Type = sdr["Type"].ToString();
                        details.Color = sdr["Color"].ToString();
                        details.Price = 10000;
                        model.Add(details);
                    }
                    return View(model);
                }
            }

            [HttpPost]
            public IActionResult DynamicSQLInStoredProcedure(string Brand, string Type, string Color, int Price)
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCarsGoodDynamicSQL";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (Brand != null)
                    {
                        SqlParameter param = new SqlParameter("@Brand", Brand);
                        cmd.Parameters.Add(param);
                    }
                    if (Type != null)
                    {
                        SqlParameter param = new SqlParameter("@Type", Type);
                        cmd.Parameters.Add(param);
                    }
                    if (Color != null)
                    {
                        SqlParameter param = new SqlParameter("@Color", Color);
                        cmd.Parameters.Add(param);
                    }
                    if (Price != 0)
                    {
                        SqlParameter param = new SqlParameter("@Price", Price);
                        cmd.Parameters.Add(param);
                    }
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    List<Car> model = new List<Car>();
                    while (sdr.Read())
                    {
                        var details = new Car();
                        details.Brand = sdr["Brand"].ToString();
                        details.Type = sdr["Type"].ToString();
                        details.Color = sdr["Color"].ToString();
                        details.Price = 10000;
                        model.Add(details);
                    }
                    return View(model);
                }
            }
        }
    }

}
