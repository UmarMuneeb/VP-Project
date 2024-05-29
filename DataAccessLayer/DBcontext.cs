using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ModelClassLibrary;


namespace DataAccessLayer
{
   
    public class DBcontext
    {
        public static void AddToCart(Cart cartItem)
        {
            Cart existingItem = GetCartProducts().FirstOrDefault(item => item.Id == cartItem.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
                UpdateCartItem(existingItem);
            }
            else
            {
                InsertCartItem(cartItem);
            }
        }

        private static void UpdateCartItem(Cart cartItem)
        {
            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand("UpdateItem", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", cartItem.Id);
            cmd.Parameters.AddWithValue("@Quantity", cartItem.Quantity);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private static void InsertCartItem(Cart cartItem)
        {
            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand("AddItem", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", cartItem.Id);
            cmd.Parameters.AddWithValue("@Title", cartItem.Title);
            cmd.Parameters.AddWithValue("@Image", cartItem.Image);
            cmd.Parameters.AddWithValue("@Price", cartItem.Price);
            cmd.Parameters.AddWithValue("@Quantity", cartItem.Quantity);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void DeleteFromCart(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static List<Cart> GetCartProducts()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Cart> CartList = new List<Cart>();
            while (reader.Read())
            {
                Cart cart = new Cart();
                cart.Id = Convert.ToInt32(reader["Id"]);

                cart.Quantity = Convert.ToInt32(reader["Quantity"]);
                cart.Price = Convert.ToDecimal(reader["Price"]);
                cart.Title = reader["Title"].ToString();
                cart.Image = reader["Image"].ToString();

                CartList.Add(cart);
            }
            con.Close();
            return CartList;
        }
    }
}