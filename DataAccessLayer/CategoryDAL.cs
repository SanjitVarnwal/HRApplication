﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common;
using BusinessEntities;
namespace DataAccessLayer
{
    public class CategoryDAL
    {
        SqlConnection objConn;
        SqlCommand objComm;
        SqlDataReader objDR;
        SqlParameter objSP_CategoryId;
        SqlParameter objSP_CategoryName;
        SqlParameter objSP_CategoryDescription;
        SqlParameter objSP_CreatedBy;
        SqlParameter objSP_CreatedDate;
        SqlParameter objSP_LastModifiedBy;
        SqlParameter objSP_LastModifiedDate;

        //void ConnectToDB()
        //{
        //    try
        //    {
        //        objConn = new SqlConnection(Database.ConnectionString);
        //        objConn.Open();
        //    } 
        //    catch (Exception e)
        //    {

        //    }
        //    objConn = new SqlConnection(Database.ConnectionString);
        //}

        public void CreateCategory( CategoryInfo Category )
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.CreateCategory, objConn);
            objComm.CommandType = CommandType.StoredProcedure;
            //Create Parameters
            objSP_CategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
            objSP_CategoryName = new SqlParameter("@CategoryName", SqlDbType.VarChar, 50);
            objSP_CategoryDescription = new SqlParameter("@CategoryDescription", SqlDbType.VarChar, 50);
            objSP_CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.Int);
            objSP_CreatedDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
            objSP_LastModifiedBy = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
            objSP_LastModifiedDate = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
            //Direction
            objSP_CategoryId.Direction = ParameterDirection.Input;
            objSP_CategoryName.Direction = ParameterDirection.Input;
            objSP_CategoryDescription.Direction = ParameterDirection.Input;
            objSP_CreatedBy.Direction = ParameterDirection.Input;
            objSP_CreatedDate.Direction = ParameterDirection.Input;
            objSP_LastModifiedBy.Direction = ParameterDirection.Input;
            objSP_LastModifiedDate.Direction = ParameterDirection.Input;
            //
            objComm.Parameters.Add(objSP_CategoryId);
            objComm.Parameters.Add(objSP_CategoryName);
            objComm.Parameters.Add(objSP_CategoryDescription);
            objComm.Parameters.Add(objSP_CreatedBy);
            objComm.Parameters.Add(objSP_CreatedDate);
            objComm.Parameters.Add(objSP_LastModifiedBy);
            objComm.Parameters.Add(objSP_LastModifiedDate);
            //Pass values
            objSP_CategoryId.Value = Category.CategoryId ;
            objSP_CategoryName.Value = Category.CategoryName ;
            objSP_CategoryDescription.Value = Category.CategoryDescription ;
            objSP_CreatedBy.Value = Category.CreatedBy ;
            objSP_CreatedDate.Value = Category.CreatedDate ;
            objSP_LastModifiedBy.Value = Category.LastModifiedBy ;
            objSP_LastModifiedDate.Value = Category.LastModifiedDate ;
            //
            objConn.Open();
            int noOfRowsEffected = objComm.ExecuteNonQuery();
            if (noOfRowsEffected > 0)
            {
                Console.WriteLine("Record inserted succesfully");
            }
            else
            {
                Console.WriteLine("Error occured while inserting the record");
            }
            objConn.Close();
        }
        public void UpdateCategory(CategoryInfo Category)
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.UpdateCategory, objConn);
            objComm.CommandType = CommandType.StoredProcedure;
            //Create Parameters
            objSP_CategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
            objSP_CategoryName = new SqlParameter("@CategoryName", SqlDbType.VarChar, 50);
            objSP_CategoryDescription = new SqlParameter("@CategoryDescription", SqlDbType.VarChar, 50);
            objSP_LastModifiedBy = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
            objSP_LastModifiedDate = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
            //Direction
            objSP_CategoryId.Direction = ParameterDirection.Input;
            objSP_CategoryName.Direction = ParameterDirection.Input;
            objSP_CategoryDescription.Direction = ParameterDirection.Input;
            objSP_LastModifiedBy.Direction = ParameterDirection.Input;
            objSP_LastModifiedDate.Direction = ParameterDirection.Input;
            //
            objComm.Parameters.Add(objSP_CategoryId);
            objComm.Parameters.Add(objSP_CategoryName);
            objComm.Parameters.Add(objSP_CategoryDescription);
            objComm.Parameters.Add(objSP_LastModifiedBy);
            objComm.Parameters.Add(objSP_LastModifiedDate);
            //Pass values
            objSP_CategoryId.Value = Category.CategoryId;
            objSP_CategoryName.Value = Category.CategoryName;
            objSP_CategoryDescription.Value = Category.CategoryDescription;
            objSP_LastModifiedBy.Value = Category.LastModifiedBy;
            objSP_LastModifiedDate.Value = Category.LastModifiedDate;
            //
            objConn.Open();
            int noOfRowsEffected = objComm.ExecuteNonQuery();
            if (noOfRowsEffected > 0)
            {
                Console.WriteLine("Record Updated succesfully");
            }
            else
            {
                Console.WriteLine("Error occured while Updating the record");
            }
            objConn.Close();
        }
        public DataTable SearchCategories()
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.SearchCategories , objConn);
            objComm.CommandType = CommandType.StoredProcedure;
            //
            try
            {
                objConn.Open();
                objDR = objComm.ExecuteReader();
                DataTable objDT = new DataTable();
                objDT.Load(objDR);
                objConn.Close();
                return objDT;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public DataTable ViewCategory( int id )
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.ViewCategory, objConn);
            objComm.CommandType = CommandType.StoredProcedure;
            //Create Parameters
            objSP_CategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
            //Direction
            objSP_CategoryId.Direction = ParameterDirection.Input;
            //
            objComm.Parameters.Add(objSP_CategoryId);
           //Pass values
            objSP_CategoryId.Value = id;
            //
            try
            {
                objConn.Open();
                objDR = objComm.ExecuteReader();
                DataTable objDT = new DataTable();
                objDT.Load(objDR);
                objConn.Close();
                return objDT;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        public DataTable GetCategoryList()
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.GetCategoryList, objConn);
            objComm.CommandType = CommandType.StoredProcedure;
            //
            try
            {
                objConn.Open();
                objDR = objComm.ExecuteReader();
                DataTable objDT = new DataTable();
                objDT.Load(objDR);
                objConn.Close();
                return objDT;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }



    }
}
