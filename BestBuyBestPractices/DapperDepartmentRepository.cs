﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments");
        }
        public void InsertDepartment(string name)
        {
            _conn.Execute("INSERT INTO departments (NAME) VALUES (@name)",
                new {name = name});
        }

        public void DeleteDepartment(int depoID)
        {
            _conn.Execute("DELETE FROM departments WHERE (NAME) VALUES (@departmentID)",
                new { name = depoID });
        }
    }
}
