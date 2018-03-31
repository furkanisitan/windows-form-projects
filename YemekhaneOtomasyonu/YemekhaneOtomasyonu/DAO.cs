using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    class DAO
    {
        static String connectionString = "Data Source=ASUS-X555LN;Initial Catalog=YemekhaneVeritabani;Integrated Security=True";

        public SqlConnection sqlConnect()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception error) { MessageBox.Show("Veritabanı Bağlantı Hatası!\n" + error.ToString()); }
            return null;
        }

        /////////////       KATEGORİ İŞLEMLERİ      /////////////

        public void kategoriEkle(String kategori)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("yemek_kategori_ekle", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@kategori_ad", SqlDbType.VarChar, 50).Value = kategori;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Kategori Eklendi");
                        }
                    }
                    catch (SqlException error)
                    {
                        switch (error.Number)
                        {
                            case 2627:
                                MessageBox.Show($"{kategori} adında kayıt zaten mevcut");
                                break;
                            case 8152:
                                MessageBox.Show("Daha kısa bir kategori adı deneyin");
                                break;
                        }
                    }
                }
            }
            catch (Exception) { } // Bağlantı hatası sqlConnect() metodunda yazdırılıyor
        }

        public void kategoriSil(int id)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("yemek_kategori_sil", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.");
                        }
                    }
                    catch (Exception error) { MessageBox.Show("Silme işlemi yapılamadı\n" + error.Message); }
                }
            }
            catch (Exception) { }
        }

        public void kategoriGuncelle(int id, string kategori)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("yemek_kategori_guncelle", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            command.Parameters.Add("@kategori_ad", SqlDbType.VarChar, 50).Value = kategori;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Kategori Güncellendi");
                        }
                    }
                    catch (SqlException error)
                    {
                        switch (error.Number)
                        {
                            case 2627:
                                MessageBox.Show($"{kategori} adında kayıt zaten mevcut");
                                break;
                            case 8152:
                                MessageBox.Show("Daha kısa bir kategori adı deneyin");
                                break;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public DataTable kategoriGetir()
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    DataTable dataTable = new DataTable();
                    using (var dataAdapter = new SqlDataAdapter("yemek_kategori_getir", new DAO().sqlConnect()))
                    {
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception) { }
            return null;
        }

        /////////////       YEMEK İŞLEMLERİ      /////////////

        public void yemekEkle(String yemek, int kalori, int kategori_id)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("yemek_ekle", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@yemek_ad", SqlDbType.VarChar, 50).Value = yemek;
                            command.Parameters.Add("@kalori", SqlDbType.Int).Value = kalori;
                            command.Parameters.Add("@kategori_id", SqlDbType.Int).Value = kategori_id;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Yemek Eklendi");
                        }
                    }
                    catch (SqlException error)
                    {
                        switch (error.Number)
                        {
                            case 2627:
                                MessageBox.Show($"{yemek} adında kayıt zaten mevcut");
                                break;
                            case 8152:
                                MessageBox.Show("Veritipi boyut aşımı!\n" + error.Message);
                                break;
                        }
                    }
                }
            }
            catch (Exception) { } // Bağlantı hatası sqlConnect() metodunda yazdırılıyor
        }

        public void yemekSil(int id)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("yemek_sil", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.");
                        }
                    }
                    catch (Exception error) { MessageBox.Show("Silme işlemi yapılamadı\n" + error.Message); }
                }
            }
            catch (Exception) { }
        }

        public void yemekSilKategori(int kategori_id)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("yemek_sil_kategoriId", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@kategori_id", SqlDbType.Int).Value = kategori_id;
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
        }

        public void yemekGuncelle(int id, String yemek, int kalori, int kategori_id)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("yemek_guncelle", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            command.Parameters.Add("@yemek_ad", SqlDbType.VarChar, 50).Value = yemek;
                            command.Parameters.Add("@kalori", SqlDbType.Int).Value = kalori;
                            command.Parameters.Add("@kategori_id", SqlDbType.Int).Value = kategori_id;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Yemek Güncellendi");
                        }
                    }
                    catch (SqlException error)
                    {
                        switch (error.Number)
                        {
                            case 2627:
                                MessageBox.Show($"{yemek} adında kayıt zaten mevcut");
                                break;
                            case 8152:
                                MessageBox.Show("Daha kısa bir yemek adı deneyin");
                                break;
                        }
                    }
                }
            }
            catch (Exception) { } // Bağlantı hatası sqlConnect() metodunda yazdırılıyor
        }

        public DataTable yemekGetir()
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    DataTable dataTable = new DataTable();
                    using (var dataAdapter = new SqlDataAdapter("yemek_getir", new DAO().sqlConnect()))
                    {
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception) { }
            return null;
        }

        public DataTable yemekGetir(int kategori_id)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    DataTable dataTable = new DataTable();
                    using (var dataAdapter = new SqlDataAdapter("yemek_getir_kategoriden", new DAO().sqlConnect()))
                    {
                        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        dataAdapter.SelectCommand.Parameters.Add("@kategori_id", SqlDbType.Int).Value = kategori_id;
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception) { }
            return null;
        }

        /////////////       MENÜ İŞLEMLERİ      /////////////

        public void menuEkle(DateTime date, String menu)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("menu_ekle", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@tarih", SqlDbType.Date).Value = date;
                            command.Parameters.Add("@icerik", SqlDbType.VarChar, 255).Value = menu;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Menu Eklendi");
                        }
                    }
                    catch (SqlException error)
                    {
                        switch (error.Number)
                        {
                            case 2627:
                                MessageBox.Show($"{date.ToString("dd/MM/yyyy")} tarihli kayıt zaten mevcut");
                                break;
                            case 8152:
                                MessageBox.Show("Daha kısa bir menu deneyin");
                                break;
                        }
                    }

                }
            }
            catch (Exception) { } // Bağlantı hatası sqlConnect() metodunda yazdırılıyor
        }

        public void menuSil(DateTime date)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("menu_sil", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@tarih", SqlDbType.Date).Value = date;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.");
                        }
                    }
                    catch (Exception error) { MessageBox.Show("Silme işlemi yapılamadı\n" + error.Message); }
                }
            }
            catch (Exception) { }
        }

        public void menuGuncelle(DateTime date, string menu)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("menu_guncelle", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@tarih", SqlDbType.Date).Value = date;
                            command.Parameters.Add("@icerik", SqlDbType.VarChar, 255).Value = menu;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Menu Güncellendi");
                        }
                    }
                    catch (Exception error) { MessageBox.Show("Güncelleme yapılamadı\n" + error.Message); }
                }
            }
            catch (Exception) { }
        }

        public DataTable menuGetir(DateTime date)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    DataTable dataTable = new DataTable();
                    using (var dataAdapter = new SqlDataAdapter("menu_getir", new DAO().sqlConnect()))
                    {
                        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        dataAdapter.SelectCommand.Parameters.Add("@tarih", SqlDbType.Date).Value = date;
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception) { }
            return null;
        }

        /////////////       GÖRÜŞ İŞLEMLERİ      /////////////

        public void gorusEkle(DateTime date, String icerik)
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("gorus_ekle", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@tarih", SqlDbType.Date).Value = date;
                            command.Parameters.Add("@icerik", SqlDbType.VarChar, 255).Value = icerik;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Görüşünüz alındı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException error)
                    {
                        switch (error.Number)
                        {
                            case 8152:
                                MessageBox.Show("Daha kısa bir icerik deneyin");
                                break;
                        }
                    }

                }
            }
            catch (Exception) { }
        }

        public DataTable gorusGetir()
        {
            try
            {
                using (var connection = sqlConnect())
                {
                    DataTable dataTable = new DataTable();
                    using (var dataAdapter = new SqlDataAdapter("gorus_getir", new DAO().sqlConnect()))
                    {
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception) { }
            return null;
        }

        /////////////       BAKİYE İŞLEMLERİ      /////////////

        public void bakiyeDusur(String TC)
        {

            try
            {
                using (var connection = sqlConnect())
                {
                    try
                    {
                        using (var command = new SqlCommand("bakiye_dusur", new DAO().sqlConnect()))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@TC", SqlDbType.Char, 11).Value = TC;
                            command.Parameters.Add("@bakiye", SqlDbType.Float).Direction = ParameterDirection.Output;
                            command.ExecuteNonQuery();
                            if (command.Parameters["@bakiye"].Value.ToString() != "")
                                MessageBox.Show("Yemek Alındı\nKalan Bakiye :" + command.Parameters["@bakiye"].Value, "Satın Alma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Hatalı TC");
                        }
                    }
                    catch (SqlException error)
                    {
                        switch (error.Number)
                        {
                            case 547:
                                MessageBox.Show("Bakiye Yetersiz");
                                break;
                        }
                    }

                }
            }
            catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable personelleriGoster()
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("personelleriGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }

            finally
            {
                con.Close();
            }
        }

        public DataTable personelBilgisiniGoster(string tc)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("personelBilgisiniGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt;
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public void personelEkle(string tc, string ad, string soyad, float maas, string sifre, int unvan_id, int sube_id)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("personelEkle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@maas", maas);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                cmd.Parameters.AddWithValue("@unvan_id", unvan_id);
                cmd.Parameters.AddWithValue("@sube_id", sube_id);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                MessageBox.Show("Bu TC zaten kayıtlı.");
            }
            finally
            {
                con.Close();
            }
        }

        public int personelGuncelle(int personel_id, string tc, string ad, string soyad, float maas, string sifre, int unvan_id, int sube_id)
        {
            int sonuc = 0;
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("personelGuncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@personel_id", personel_id);
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@maas", maas);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                cmd.Parameters.AddWithValue("@unvan_id", unvan_id);
                cmd.Parameters.AddWithValue("@sube_id", sube_id);
                cmd.ExecuteNonQuery();

                sonuc = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return sonuc;
        }

        public int personelSil(string tc)
        {
            int sonuc = 0;
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("personelSil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.ExecuteNonQuery();

                sonuc = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return sonuc;
        }

        public DataTable unvanlariGoster()
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("unvanlariGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return null;

        }

        public DataTable subeleriGoster()
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("subeleriGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return null;

        }

        public void unvanEkle(string ad)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("unvanEkle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad", ad);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void unvanSil(int unvan_id)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("unvanSil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unvan_id", unvan_id);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                MessageBox.Show("Bu Ünvana Sahip Personel Var!");
            }
            finally
            {
                con.Close();
            }
        }

        public void unvanGuncelle(int unvan_id, string ad)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("unvanGuncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unvan_id", unvan_id);
                cmd.Parameters.AddWithValue("@ad", ad);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void subeEkle(string ad)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("subeEkle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad", ad);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void subeSil(int sube_id)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("subeSil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sube_id", sube_id);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                MessageBox.Show("Bu Şubede Çalışan Personel Var!");
            }
            finally
            {
                con.Close();
            }
        }

        public void subeGuncelle(int sube_id, string ad)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("subeGuncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sube_id", sube_id);
                cmd.Parameters.AddWithValue("@ad", ad);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }



        public DataTable kullanicilariGoster()
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullanicilariGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }

            finally
            {
                con.Close();
            }
        }

        public DataTable kullaniciBilgisiniGoster(string tc)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciBilgisiniGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public void kullaniciEkle(string tc, string ad, string soyad, float bakiye, int kullanici_turu_id)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciEkle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@bakiye", bakiye);
                cmd.Parameters.AddWithValue("@kullanici_turu_id", kullanici_turu_id);

                cmd.ExecuteNonQuery();

            }
            catch (Exception er)
            {
                MessageBox.Show("Hata " + er.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public int kullaniciGuncelle(int kullanici_id, string tc, string ad, string soyad, float bakiye, int kullanici_turu_id)
        {
            SqlConnection con = new DAO().sqlConnect();
            int sonuc = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciGuncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kullanici_id", kullanici_id);
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@bakiye", bakiye);
                cmd.Parameters.AddWithValue("@kullanici_turu_id", kullanici_turu_id);
                cmd.ExecuteNonQuery();

                sonuc = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return sonuc;
        }

        public int kullaniciSil(string tc)
        {
            int sonuc = 0;
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciSil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.ExecuteNonQuery();

                sonuc = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return sonuc;
        }

        public DataTable kullaniciTuruGoster()
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciTuruGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return null;

        }

        public void kullaniciTuruEkle(string ad, float alinacak_ucret)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciTuruEkle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@alinacak_ucret", alinacak_ucret);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void kullaniciTuruSil(int kullanici_turu_id)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciTuruSil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kullanici_turu_id", kullanici_turu_id);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                MessageBox.Show("Bu Ünvana Sahip Personel Var!");
            }
            finally
            {
                con.Close();
            }
        }

        public void kullaniciTuruGuncelle(int kullanici_turu_id, string ad, float alinacak_ucret)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("kullaniciTuruGuncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kullanici_turu_id", kullanici_turu_id);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@alinacak_ucret", alinacak_ucret);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public string alinacakFiyatGoster(int kullanici_turu_id)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("alinacakFiyatGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kullanici_turu_id", kullanici_turu_id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr["alinacak_ucret"].ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return null;

        }


        public string bakiyeSorgula(string tc)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("bakiyeSorgula", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr["bakiye"].ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return null;

        }

        public void bakiyeGuncelle(string tc, float bakiye)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {

                SqlCommand cmd = new SqlCommand("bakiyeGuncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@bakiye", bakiye);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void sifreGuncelle(string tc, string sifre)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("sifreGuncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public string unvanGoster(string tc)
        {
            SqlConnection con = new DAO().sqlConnect();
            try
            {
                ;
                SqlCommand cmd = new SqlCommand("unvanGoster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tc", tc);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["ad"].ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return null;

        }
    }
}

