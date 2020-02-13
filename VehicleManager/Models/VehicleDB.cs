using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using VehicleManager.Models;

namespace VehicleManager.VehicleDB
{
    public class VehicleData
    {
        private string ConnectionString = string.Empty;

        public VehicleData()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["VehicleContext"].ConnectionString;
        }

        public void SaveVehicle(Vehicle vehicle)
        {
            string createQuery = String.Format("Insert into Vehicle (Owner_First, Owner_Last, Owner_Phone, Owner_Unit, Owner_Apt, Make, Model, Color) Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');"
                + "Select @@Identity", vehicle.Owner_First.Trim(), vehicle.Owner_Last.Trim(), vehicle.Owner_Phone.Trim(), vehicle.Owner_Unit.Trim(), vehicle.Owner_Apt.Trim(), vehicle.Make.Trim(), vehicle.Model.Trim(), vehicle.Color.Trim());

            string updateQuery = String.Format("Update Vehicle SET Owner_First='{0}', Owner_Last = '{1}', Owner_Phone ='{2}', Owner_Unit = '{3}', Owner_Apt = '{4}', Make = '{5}', Model = '{6}', Color = '{7}' Where ID = '{8}';",
                vehicle.Owner_First.Trim(), vehicle.Owner_Last.Trim(), vehicle.Owner_Phone.Trim(), vehicle.Owner_Unit.Trim(), vehicle.Owner_Apt.Trim(), vehicle.Make.Trim(), vehicle.Model.Trim(), vehicle.Color.Trim(), vehicle.ID);

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = null;

            if (vehicle.ID != Guid.Empty)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            try
            {
                var oResult = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();

        }

        public Vehicle GetVehicleById(Guid vehicleId)
        {
            Vehicle result = new Vehicle();
            string sqlQuery = String.Format("select * from Vehicle where ID='{0}'", vehicleId);
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.ID = new Guid(dataReader["ID"].ToString());
                    result.Owner_First = dataReader["Owner_First"].ToString().Trim();
                    result.Owner_Last = dataReader["Owner_Last"].ToString().Trim();
                    result.Owner_Phone = dataReader["Owner_Phone"].ToString().Trim();
                    result.Owner_Unit = dataReader["Owner_Unit"].ToString().Trim();
                    result.Owner_Apt = dataReader["Owner_Apt"].ToString().Trim();
                    result.Make = dataReader["Make"].ToString().Trim();
                    result.Model = dataReader["Model"].ToString().Trim();
                    result.Color = dataReader["Color"].ToString().Trim();
                    result.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
                }
            }

            return result;
        }

        public List<Vehicle> SearchVehicle(string oSearch)
        {
            List<Vehicle> result = new List<Vehicle>();
            string sqlQuery = String.Format("select * from Vehicle where ID like '%{0}%'", oSearch);
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Vehicle oVehicle = new Vehicle();
                    oVehicle.ID = new Guid(dataReader["ID"].ToString());
                    oVehicle.Owner_First = dataReader["Owner_First"].ToString().Trim();
                    oVehicle.Owner_Last = dataReader["Owner_Last"].ToString().Trim();
                    oVehicle.Owner_Phone = dataReader["Owner_Phone"].ToString().Trim();
                    oVehicle.Owner_Unit = dataReader["Owner_Unit"].ToString().Trim();
                    oVehicle.Owner_Apt = dataReader["Owner_Apt"].ToString().Trim();
                    oVehicle.Make = dataReader["Make"].ToString().Trim();
                    oVehicle.Model = dataReader["Model"].ToString().Trim();
                    oVehicle.Color = dataReader["Color"].ToString().Trim();
                    oVehicle.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
                    result.Add(oVehicle);
                }
            }

            return result;
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> result = new List<Vehicle>();
            string sqlQuery = String.Format("select * from Vehicle");

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Vehicle oVehicle = new Vehicle();
                    oVehicle.ID = new Guid(dataReader["ID"].ToString());
                    oVehicle.Owner_First = dataReader["Owner_First"].ToString();
                    oVehicle.Owner_Last = dataReader["Owner_Last"].ToString();
                    oVehicle.Owner_Phone = dataReader["Owner_Phone"].ToString();
                    oVehicle.Owner_Unit = dataReader["Owner_Unit"].ToString();
                    oVehicle.Owner_Apt = dataReader["Owner_Apt"].ToString();
                    oVehicle.Make = dataReader["Make"].ToString();
                    oVehicle.Model = dataReader["Model"].ToString();
                    oVehicle.Color = dataReader["Color"].ToString();
                    oVehicle.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
                    result.Add(oVehicle);
                }
            }

            return result;

        }


    }
}