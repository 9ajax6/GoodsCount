using AstoreLibrary.Models.Master;
using AstoreLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstoreLibrary.DataLayer.Master
{
    internal class AccountGroupDL
    {
        
        private DataContext _context;
        public AccountGroupDL()
        {
            _context = new DataContext();
        }
        // Get List
        internal ResultType GetAcGroupList()
        {
            ResultType result = new ResultType();
            List<AccountGroup> lstObjects = new List<AccountGroup>();
            string sqlQuery = @"select Ac_GrpCode,Ac_Desc,Ac_Type,BP_Type FROM Account_Group";
            var dbConnection = _context.Database.Connection;
            using (SqlConnection conn = new SqlConnection(dbConnection.ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandTimeout = conn.ConnectionTimeout;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sqlQuery;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                lstObjects.Add(new AccountGroup()
                                {
                                    Ac_GrpCode = (string)reader["Ac_GrpCode"],
                                    Ac_Desc = (string)reader["Ac_Desc"],
                                    Ac_Type = (string)reader["Ac_Type"],                                    
                                });
                            }
                            result.Data = lstObjects;
                        }
                    }
                }
            }
            return result;
        }

//        internal ProductList GetPagingList(int pageIndex, int pageSize,string search="")
//        {
//            ProductList prodList = new ProductList();
//            string sqlQuery = @"Select ProductId,ProductName,UnitPrice,UnitInStock,CategoryId,Discontinue
//                                  From Products where (cast(ProductId as varchar)=@search or ProductName Like @search +'%') order by ProductId desc 
//                                offset @Pagesize*(@Pageindex-1) Rows Fetch next @Pagesize rows only
//                                select Count(*) totalcount from Products where (cast(ProductId as varchar)=@search or ProductName Like @search +'%')";
//            var dbConnection = _context.Database.Connection;
//            using (SqlConnection conn = new SqlConnection(dbConnection.ConnectionString))
//            {
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    conn.Open();
//                    cmd.CommandTimeout = conn.ConnectionTimeout;
//                    cmd.CommandType = System.Data.CommandType.Text;
//                    cmd.CommandText = sqlQuery;
//                    cmd.Parameters.Add("@Pageindex", SqlDbType.Int).Value = pageIndex;
//                    cmd.Parameters.Add("@Pagesize", SqlDbType.Int).Value = pageSize;
//                    cmd.Parameters.Add("@search", SqlDbType.VarChar).Value = search == null ? "" : search;
//                    SqlDataReader dr = cmd.ExecuteReader();
//                    List<Product> lstObjects = new List<Product>();
//                    while (dr.Read())
//                    {
                      
//                            lstObjects.Add(new Product()
//                            {
//                                ProductId = (int)dr["ProductId"],
//                                ProductName = (string)dr["ProductName"],
//                                UnitInStock = (int)dr["UnitInStock"],
//                                UnitPrice = (decimal)dr["UnitPrice"],
//                                CategoryId = (int)dr["CategoryId"]
//                            });
                        

//                    }
//                    dr.NextResult();
//                    while (dr.Read())
//                    {
//                        prodList.totalcount = Convert.ToInt32(dr["totalcount"]);
//                    }
//                    prodList.dataList = lstObjects;
//                }
//            }
//            return prodList;
//        }
//        // Get Category with product list

//        // insert
//        internal async Task<string> Insert(Product obj)
//        {
//            string msg = string.Empty;
//            string qry = @"insert";
//            var dbConnection = _context.Database.Connection;
//            using (SqlConnection conn = new SqlConnection(dbConnection.ConnectionString))
//            {
//                using (var dbTransaction = conn.BeginTransaction())
//                {
//                    try
//                    {
//                        using (SqlCommand cmd = new SqlCommand(qry, conn))
//                        {
//                            cmd.Connection = conn;
//                            cmd.CommandText = qry;
//                            cmd.CommandType = CommandType.Text;
//                            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = obj.CategoryId;
//                            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = obj.ProductId;
//                            await cmd.ExecuteNonQueryAsync();
//                            dbTransaction.Commit();
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        dbTransaction.Rollback();
//                        throw;
//                    }
//                }
//            }
//            return msg;
//        }

//        // Update
//        internal async Task<string> Update(Product obj)
//        {
//            string msg = string.Empty;
//            string qry = @"Update";
//            var dbConnection = _context.Database.Connection;
//            using (SqlConnection conn = new SqlConnection(dbConnection.ConnectionString))
//            {
//                using (var dbTransaction = conn.BeginTransaction())
//                {
//                    try
//                    {
//                        using (SqlCommand cmd = new SqlCommand(qry, conn))
//                        {
//                            cmd.Connection = conn;
//                            cmd.CommandText = qry;
//                            cmd.CommandType = CommandType.Text;
//                            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = obj.CategoryId;
//                            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = obj.ProductId;
//                            await cmd.ExecuteNonQueryAsync();
//                            msg = "Updated";
//                            dbTransaction.Commit();
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        dbTransaction.Rollback();
//                        throw;
//                    }
//                }
//            }
//            return msg;
//        }

//        // Delete
//        internal async Task<string> Delete(int? id)
//        {
//            string msg = string.Empty;
//            string qry = @"Delete";
//            var dbConnection = _context.Database.Connection;
//            using (SqlConnection conn = new SqlConnection(dbConnection.ConnectionString))
//            {
//                using (var dbTransaction = conn.BeginTransaction())
//                {
//                    try
//                    {
//                        using (SqlCommand cmd = new SqlCommand(qry, conn))
//                        {
//                            cmd.Connection = conn;
//                            cmd.CommandText = qry;
//                            cmd.CommandType = CommandType.Text;
//                            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;
//                            await cmd.ExecuteNonQueryAsync();
//                            msg = "Deleted";
//                            dbTransaction.Commit();
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        dbTransaction.Rollback();
//                        throw;
//                    }
//                }
//            }
//            return msg;
//        }
        //public bool InsertImage(string Name, int size, byte[] bytes, out int newId)
        //{
        //    bool success = false;
        //    string qry = "spUploadImage";
        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FoodMandu"].ConnectionString))
        //    {
        //        try
        //        {
        //            using (SqlCommand cmd = new SqlCommand(qry, conn))
        //            {
        //                cmd.Connection = conn;
        //                cmd.CommandText = "spUploadImage";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
        //                cmd.Parameters.Add("@Size", SqlDbType.Int).Value = size;
        //                cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = bytes;
        //                // cmd.Parameters.Add("@NewId", SqlDbType.Int).Value = -1;
        //                SqlParameter paramNewId = new SqlParameter()
        //                {
        //                    ParameterName = "@NewId",
        //                    Value = -1,
        //                    Direction = ParameterDirection.Output
        //                };
        //                cmd.Parameters.Add(paramNewId);
        //                conn.Open();
        //                cmd.ExecuteNonQuery();
        //                newId = Convert.ToInt32(cmd.Parameters["@NewId"].Value);
        //                success = true;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    return success;
        //}
    }
}
