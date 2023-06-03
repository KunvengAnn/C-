using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace botTelegram
{
    class HoiDataBase
    {   //nhu nay cung duoc Properties.Settings.Default.strCon;
        public string strCon = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True;";

        //tham khao cua Hieu
        // Cả class này sẽ chỉ thực hiện ExecuteScalar() mk sử lý database để trả về 1 chuỗi string để mk chỉ việc hiển thị.
        //public string baoMotHoaDon(string MA_KH, string action)//
        //{
        //    // Trả về kết quả 1 hóa đơn khi biết số hóa đơn
        //    string kq = "";
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(strCon))
        //        {
        //            cn.Open();
        //            using (SqlCommand cm = cn.CreateCommand())
        //            {
        //                cm.CommandText = "GetOrderDetails"; //GetOrderDetails 'KH01'
        //                cm.CommandType = CommandType.StoredProcedure;
        //                //cm.Parameters.Add("@MA_KH", SqlDbType.NVarChar, 30).Value = MA_KH;
        //                //cm.CommandType = CommandType.StoredProcedure;
        //               ///cm.Parameters.Add("@tenKH", SqlDbType.NVarChar, 50).Value = "%" + tenKH.Replace(" ", "%") + "%";
        //                //object obj = cm.ExecuteScalar(); //lấy col1 of row1
        //                //kq = (string)obj;
        //                cm.Parameters.Add("@action", SqlDbType.NVarChar, 10).Value = action;
        //                object obj = cm.ExecuteScalar(); //lấy col1 of row1
        //                if (obj != null)
        //                    kq = (string)obj;
        //                else
        //                   kq = $"không có dữ liệu về đơn hàng số có mã: {MA_KH}";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        kq += $"Error: {ex.Message}";
        //    }
        //    return kq;
        //}

        public string ShowAllKh()
        {
            string result = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(strCon))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "LISTALLKHACH";
                        cm.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string maKH = dr["MA_KH"].ToString();
                                string tenKH = dr["TEN_KH"].ToString();
                                string diaChi = dr["DIACHI_KH"].ToString();
                                string sdt = dr["SODT_KH"].ToString();

                                result += $"🤩🤩Mã khách hàng: {maKH}\n";
                                result += $"Tên khách hàng: {tenKH}\n";
                                result += $"Địa chỉ: {diaChi}\n";
                                result += $"Số điện thoại: {sdt}\n";
                                result += "-------------------------\n";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result += $"Error: {ex.Message}";
            }
            return result;
        }

        public string SearchKhachHangByTen(string tenKhachHang)
        {
            string result = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(strCon))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "searchKhachHangByTen";
                        cm.CommandType = CommandType.StoredProcedure;

                        cm.Parameters.AddWithValue("@tenKhachHang", tenKhachHang);

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string maKhachHang = dr["maKhachHang"].ToString();
                                string tenKhachHangResult = dr["tenKhachHang"].ToString();
                                string diaChi = dr["diaChi"].ToString();
                                string dienThoai = dr["dienThoai"].ToString();

                                result += $"Mã khách hàng: {maKhachHang}\n";
                                result += $"Tên khách hàng: {tenKhachHangResult}\n";
                                result += $"Địa chỉ: {diaChi}\n";
                                result += $"Điện thoại: {dienThoai}\n";
                                result += "-------------------------\n";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result += $"Error: {ex.Message}";
            }
            return result;
        }


    }
}
