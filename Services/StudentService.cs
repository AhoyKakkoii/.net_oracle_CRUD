using CoreCRUDwithOracle.Interface;
using CoreCRUDwithOracle.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace CoreCRUDwithOracle.Services
{
    public class StudentService : IStudentService
    {
        private readonly string _connectionString;
        public StudentService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> studentList = new List<Student>();
            OracleConnection con = new OracleConnection(_connectionString);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select ID, FirstName,LastName,EmailId,Mobile,Course from Student";
            OracleDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Student stu = new Student
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString(),
                    EmailId = rdr["EmailId"].ToString(),
                    Mobile = rdr["Mobile"].ToString(),
                    Course = rdr["Course"].ToString()
                };

                studentList.Add(stu);
            }
            return studentList;
        }

        public Student GetStudentById(int eid)
        {
            Student student = new Student();
            OracleConnection con = new OracleConnection(_connectionString);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from Student where Id=" + eid + "";
            OracleDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Student stu = new Student
                {
                    Id = Convert.ToInt32(rdr["Id"]),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString(),
                    EmailId = rdr["EmailId"].ToString(),
                    Mobile = rdr["Mobile"].ToString(),
                    Course = rdr["Course"].ToString()
                };
                student = stu;
            }
            return student;
        }

        public void AddStudent(Student student)
        {
            try
            {
                OracleConnection con = new OracleConnection(_connectionString);
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert into Student(Id, FirstName, LastName, EmailId, Mobile, Course)Values(" + student.Id + ",'" + student.FirstName + "','" + student.LastName + "','" + student.EmailId + "','" + student.Mobile + "','" + student.Course + "')";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void EditStudent(Student student)
        {
            try
            {
                OracleConnection con = new OracleConnection(_connectionString);
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update Student Set FirstName='" + student.FirstName + "', LastName='" + student.LastName + "', EmailId='" + student.EmailId + "', Mobile='" + student.Mobile + "', Course='" + student.Course + "' where Id=" + student.Id + "";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteStudent(Student student)
        {
            try
            {
                OracleConnection con = new OracleConnection(_connectionString);
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "Delete from Student where Id=" + student.Id + "";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
