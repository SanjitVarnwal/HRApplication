﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessEntities;
using Common;

namespace DataAccessLayer
{
    public class ProjectDAL
    {
        SqlConnection objConn;
        SqlCommand objComm;
        SqlDataReader objDR;

        SqlParameter objSP_ProjID;
        SqlParameter objSP_ProjName;
        SqlParameter objSP_Description;
        SqlParameter objSP_Client;
        SqlParameter objSP_StartDate;
        SqlParameter objSP_EndDate;
        SqlParameter objSP_CreatedBy;
        SqlParameter objSP_CreatedDate;
        SqlParameter objSP_LastModifiedBy;
        SqlParameter objSP_LastModifiedDate;

        //void ConnectToDB()
        //{
        //    try
        //    {
        //        objConn = new SqlConnection(Database.ConnectionString);
        //        //objConn.Open();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //}

        public bool CreateProject(ProjectInfo project)
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.CreateProject, objConn);
            objComm.CommandType = CommandType.StoredProcedure;


            objSP_ProjName = new SqlParameter("@projName", SqlDbType.VarChar, 50);
            objSP_Description = new SqlParameter("@Description", SqlDbType.VarChar, 50);
            objSP_Client = new SqlParameter("@Client", SqlDbType.VarChar, 50);
            objSP_StartDate = new SqlParameter("@StartDate", SqlDbType.DateTime);
            objSP_EndDate = new SqlParameter("@EndDate", SqlDbType.DateTime);
            objSP_CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
            objSP_CreatedDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
            objSP_LastModifiedBy = new SqlParameter("@LastModifiedBy", SqlDbType.VarChar, 50);
            objSP_LastModifiedDate = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);

            objSP_ProjName.Direction = ParameterDirection.Input;
            objSP_Description.Direction = ParameterDirection.Input;
            objSP_Client.Direction = ParameterDirection.Input;
            objSP_StartDate.Direction = ParameterDirection.Input;
            objSP_EndDate.Direction = ParameterDirection.Input;
            objSP_CreatedBy.Direction = ParameterDirection.Input;
            objSP_CreatedDate.Direction = ParameterDirection.Input;
            objSP_LastModifiedBy.Direction = ParameterDirection.Input;
            objSP_LastModifiedDate.Direction = ParameterDirection.Input;

            objComm.Parameters.Add(objSP_ProjName);
            objComm.Parameters.Add(objSP_Description);
            objComm.Parameters.Add(objSP_Client);
            objComm.Parameters.Add(objSP_StartDate);
            objComm.Parameters.Add(objSP_EndDate);
            objComm.Parameters.Add(objSP_CreatedBy);
            objComm.Parameters.Add(objSP_CreatedDate);
            objComm.Parameters.Add(objSP_LastModifiedBy);
            objComm.Parameters.Add(objSP_LastModifiedDate);

            objSP_ProjName.Value = project.ProjName;
            objSP_Description.Value = project.Description;
            objSP_Client.Value = project.Client;
            objSP_StartDate.Value = project.StartDate;
            objSP_EndDate.Value = project.EndDate;
            objSP_CreatedBy.Value = project.CreatedBy;
            objSP_CreatedDate.Value = project.CreatedDate;
            objSP_LastModifiedBy.Value = project.LastModifiedBy;
            objSP_LastModifiedDate.Value = project.LastModifiedDate;


            try
            { 
                objConn.Open();

                int rowsAffected = objComm.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return true;
                else
                    return false;
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                objConn.Close();
            }

            //return false;
        }
        public DataTable ViewProject(int id)
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.ViewProject, objConn);
            objComm.CommandType = CommandType.StoredProcedure;
            objSP_ProjID = new SqlParameter("@projId", SqlDbType.Int);
            objSP_ProjID.Direction = ParameterDirection.Input;
            objComm.Parameters.Add(objSP_ProjID);
            objSP_ProjID.Value = id;



            try
            {
                objConn.Open();
                objDR = objComm.ExecuteReader();
                DataTable objDT = new DataTable();
                objDT.Load(objDR);

                return objDT;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                objConn.Close();
            }
            //return null;
        }
        public bool UpdateProject(ProjectInfo project)
        {

            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.UpdateProject, objConn);
            objComm.CommandType = CommandType.StoredProcedure;


            objSP_ProjID = new SqlParameter("@projId", SqlDbType.Int);
            objSP_ProjName = new SqlParameter("@projName", SqlDbType.VarChar, 50);
            objSP_Description = new SqlParameter("@Description", SqlDbType.VarChar, 50);
            objSP_Client = new SqlParameter("@Client", SqlDbType.VarChar, 50);
            objSP_StartDate = new SqlParameter("@StartDate", SqlDbType.DateTime);
            objSP_EndDate = new SqlParameter("@EndDate", SqlDbType.DateTime);
            objSP_LastModifiedBy = new SqlParameter("@LastModifiedBy", SqlDbType.VarChar, 50);
            objSP_LastModifiedDate = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);

            objSP_ProjID.Direction = ParameterDirection.Input;
            objSP_ProjName.Direction = ParameterDirection.Input;
            objSP_Description.Direction = ParameterDirection.Input;
            objSP_Client.Direction = ParameterDirection.Input;
            objSP_StartDate.Direction = ParameterDirection.Input;
            objSP_EndDate.Direction = ParameterDirection.Input;
            objSP_LastModifiedBy.Direction = ParameterDirection.Input;
            objSP_LastModifiedDate.Direction = ParameterDirection.Input;

            objComm.Parameters.Add(objSP_ProjID);
            objComm.Parameters.Add(objSP_ProjName);
            objComm.Parameters.Add(objSP_Description);
            objComm.Parameters.Add(objSP_Client);
            objComm.Parameters.Add(objSP_StartDate);
            objComm.Parameters.Add(objSP_EndDate);
            objComm.Parameters.Add(objSP_LastModifiedBy);
            objComm.Parameters.Add(objSP_LastModifiedDate);

            objSP_ProjID.Value = project.ProjId;
            objSP_ProjName.Value = project.ProjName;
            objSP_Description.Value = project.Description;
            objSP_Client.Value = project.Client;
            objSP_StartDate.Value = project.StartDate;
            objSP_EndDate.Value = project.EndDate;
            objSP_LastModifiedBy.Value = project.LastModifiedBy;
            objSP_LastModifiedDate.Value = project.LastModifiedDate;

            try
            {
                objConn.Open();
                int rowsEffected = objComm.ExecuteNonQuery();
                if (rowsEffected > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                objConn.Close();
            }
            //return false;
        }
        public DataTable SearchProjects()
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.SearchProjects, objConn);
            objComm.CommandType = CommandType.StoredProcedure;

            try
            {

                objConn.Open();
                objDR = objComm.ExecuteReader();
                DataTable objDT = new DataTable();
                objDT.Load(objDR);
                return objDT;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                objConn.Close();
            }
            //return null;
        }
        public DataTable GetProjectList()
        {
            objConn = new SqlConnection(Database.ConnectionString);
            objComm = new SqlCommand(Database.GetProjectList, objConn);
            objComm.CommandType = CommandType.StoredProcedure;
            try
            {

                objConn.Open();
                objDR = objComm.ExecuteReader();
                DataTable objDT = new DataTable();
                objDT.Load(objDR);
                return objDT;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                objConn.Close();
            }
            //return null;

        }
    }
}
