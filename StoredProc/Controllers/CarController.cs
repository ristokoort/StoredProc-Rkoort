using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoredProc.Data;
using StoredProc.Models;
using System.Collections.Generic;
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
            public IActionResult DynamicSQL(string ModelName, string FuelType, string Transmission, int NumberOfWheeles)
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCars";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (ModelName != null)
                    {
                        SqlParameter param_fn = new SqlParameter("@ModelName", ModelName);
                        cmd.Parameters.Add(param_fn);
                    }
                    if (FuelType != null)
                    {
                        SqlParameter param_ln = new SqlParameter("@FuelType", FuelType);
                        cmd.Parameters.Add(param_ln);
                    }
                    if (Transmission != null)
                    {
                        SqlParameter param_g = new SqlParameter("@Transmission", Transmission);
                        cmd.Parameters.Add(param_g);
                    }
                    if (NumberOfWheeles != 0)
                    {
                        SqlParameter param_s = new SqlParameter("@NumberOfWheeles", NumberOfWheeles);
                        cmd.Parameters.Add(param_s);
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
            public IActionResult SearchWithDynamics(string ModelName, string FuelType, string Transmission, int NumberOfWheeles)
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCarsGoodDynamicSQL";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    StringBuilder stringBuilder = new StringBuilder("Select * from Employees where 1 = 1");

                    if (ModelName != null)
                    {
                        stringBuilder.Append(" AND ModelName=@ModelName");
                        SqlParameter param_fn = new SqlParameter("@ModelName", ModelName);
                        cmd.Parameters.Add(param_fn);
                    }
                    if (FuelType != null)
                    {
                        stringBuilder.Append(" AND FuelType=@FuelType");
                        SqlParameter param_ln = new SqlParameter("@FuelType", FuelType);
                        cmd.Parameters.Add(param_ln);
                    }
                    if (Transmission != null)
                    {
                        stringBuilder.Append(" AND Transmission=@Transmission");
                        SqlParameter param_g = new SqlParameter("@Transmission", Transmission);
                        cmd.Parameters.Add(param_g);
                    }
                    if (NumberOfWheeles != 0)
                    {
                        stringBuilder.Append(" AND NumberOfWheeles=@NumberOfWheeles");
                        SqlParameter param_s = new SqlParameter("@NumberOfWheeles", NumberOfWheeles);
                        cmd.Parameters.Add(param_s);
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
            public IActionResult DynamicSQLInStoredProcedure(string ModelName, string FuelType, string Transmission, int NumberOfWheeles)
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.spSearchCarsGoodDynamicSQL";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (ModelName != null)
                    {
                        SqlParameter param = new SqlParameter("@ModelName", ModelName);
                        cmd.Parameters.Add(param);
                    }
                    if (FuelType != null)
                    {
                        SqlParameter param = new SqlParameter("@FuelType", FuelType);
                        cmd.Parameters.Add(param);
                    }
                    if (Transmission != null)
                    {
                        SqlParameter param = new SqlParameter("@Transmission", Transmission);
                        cmd.Parameters.Add(param);
                    }
                    if (NumberOfWheeles != 0)
                    {
                        SqlParameter param = new SqlParameter("@NumberOfWheeles", NumberOfWheeles);
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
