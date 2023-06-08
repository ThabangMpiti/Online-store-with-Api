using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using store2.Models;
using System.Diagnostics;
using System.Data;

namespace store2.Controllers
{
    

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        string conString = "Data Source=.;Initial Catalog=Tman;Integrated Security=True";


        public payment payments = new payment();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeOrder()
        {
            return View();
        }

        

        [HttpGet]
        public IActionResult html2()
        {
            return View(new products());
        }


       


        [HttpPost]
        //post insert
        public ActionResult html2(products Products)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();

                string sqlQuery = "INSERT INTO ORDERS(PRODUCT_NAME,TOTAL_PRICE,QUANTITY,ORDER_STATUS) VALUES(@ProductName,@Price,@Quantity,@STATUS)";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@ProductName", Products.PRODUCT_NAME);
                cmd.Parameters.AddWithValue("@Price", Products.TOTAL_PRICE);
                cmd.Parameters.AddWithValue("@Quantity", Products.QUANTITY);
                cmd.Parameters.AddWithValue("@STATUS", "Pending");
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Payment");

        }
        
     



        public IActionResult Privacy()
        {
            return View();
        }



        [HttpGet]
        //Orders to pass my values to the database
        public ActionResult Orders()
        {

            List<products> GetProducts = new List<products>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM ORDERS";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products SetProducts = new products();

                            SetProducts.ORDER_ID = reader.GetInt32(0);
                            SetProducts.PRODUCT_NAME = reader.GetString(1);
                            SetProducts.TOTAL_PRICE = reader.GetDecimal(2);
                            SetProducts.QUANTITY = reader.GetInt32(3);
                            SetProducts.ORDER_STATUS = reader.GetString(4);
                            SetProducts.CREATED_DATE = reader.GetDateTime(5);
                            GetProducts.Add(SetProducts);


                        }

                    }
                }

            }
            return View(GetProducts);



        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult payment()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        //passing the ID so that i can get my maxi
        [HttpGet]
        public ActionResult Payment()
        {

            string id;
            id = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sqlQuery = "SELECT MAX(ORDER_ID) FROM ORDERS";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int getID = reader.GetInt32(0);
                            id = getID.ToString();



                        }

                    }

                }



                //getting my order Id,
                string sqlQueryTwo = "SELECT * FROM ORDERS WHERE ORDER_ID=" + id;



                using (SqlCommand cmd = new SqlCommand(sqlQueryTwo, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int ORDER_ID = reader.GetInt32(0);
                            string PRODUCT_NAME = reader.GetString(1);
                            decimal TOTAL_PRICE = reader.GetDecimal(2);
                            int QUANTITY = reader.GetInt32(3);
                            string ORDER_STATUS = reader.GetString(4);
                            DateTime CREATED_DATE = reader.GetDateTime(5);

                            ViewBag.ProdRef = ORDER_ID;
                            ViewBag.ProdAmount = TOTAL_PRICE;


                        }

                    }

                }

            }

            return View();
        }


        //Updating order table


        [HttpGet]
        public ActionResult PaymentSuccessful()
        {

            string id;
            id = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sqlQuery = "SELECT MAX(ORDER_ID) FROM ORDERS";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int getID = reader.GetInt32(0);
                            id = getID.ToString();





                        }

                    }

                }





                string sqlQueryPay = "UPDATE ORDERS  SET ORDER_STATUS='Successful' WHERE ORDER_ID=@BACKORDER";

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();


                    SqlCommand cmd = new SqlCommand(sqlQueryPay, conn);
                    cmd.Parameters.AddWithValue("@BACKORDER", id);
                    cmd.ExecuteNonQuery();

                }


            }

            return View();


        }



        [HttpGet]
        public ActionResult Cancel()
        {

            string id;
            id = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sqlQuery = "SELECT MAX(ORDER_ID) FROM ORDERS";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int getID = reader.GetInt32(0);
                            id = getID.ToString();





                        }

                    }

                }

                string sqlQueryPay = "UPDATE ORDERS  SET ORDER_STATUS='Cancelled' WHERE ORDER_ID=@BACKORDER";

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();


                    SqlCommand cmd = new SqlCommand(sqlQueryPay, conn);
                    cmd.Parameters.AddWithValue("@BACKORDER", id);
                    cmd.ExecuteNonQuery();

                }


            }

            return View();


        }


        [HttpGet]
        public ActionResult Decline()
        {

            string id;
            id = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string sqlQuery = "SELECT MAX(ORDER_ID) FROM ORDERS";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int getID = reader.GetInt32(0);
                            id = getID.ToString();

                        }

                    }

                }

                string sqlQueryPay = "UPDATE ORDERS  SET ORDER_STATUS='Decline' WHERE ORDER_ID=@BACKORDER";

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();


                    SqlCommand cmd = new SqlCommand(sqlQueryPay, conn);
                    cmd.Parameters.AddWithValue("@BACKORDER", id);
                    cmd.ExecuteNonQuery();

                }


            }

            return View();


        }


    }
        


}