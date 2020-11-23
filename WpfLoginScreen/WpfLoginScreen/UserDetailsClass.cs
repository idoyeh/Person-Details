using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfLoginScreen
{
    public class UserDetailsClass
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        //public Button Buutton { get; set; }

        #region Select
        //public static DataTable Select()
        //{
        //    // Database Connection
        //    SqlConnection sqlCon = new SqlConnection(@"data source=LAPTOP-NSUOOFBL\SQLEXPRESS; initial catalog=LoginDB; integrated security=True;");
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        if (sqlCon.State == System.Data.ConnectionState.Closed)
        //        {
        //            sqlCon.Open();
        //        }

        //        // Writing SQL Query
        //        String query = "select *" +
        //            " from tbl_user_info" +
        //            " order by UserID, FirstName";

        //        // Creating sqlCmd using query and sqlCon
        //        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        //        // Creating SQL DataAdapter using sqlCmd
        //        SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

        //        adapter.Fill(dt);

        //        int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
        //        if (count != 1)
        //        {
        //            MessageBox.Show(".אין אנשים במערכת");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCon.Close();
        //    }
        //    return dt;
        //}
        #endregion

        public static DataTable Search(UserDetailsClass s)
        {
            //bool isSuccess = false;
            // Database Connection
            SqlConnection sqlCon = new SqlConnection(@"data source=LAPTOP-NSUOOFBL\SQLEXPRESS; initial catalog=LoginDB; integrated security=True;");
            DataTable dt = new DataTable();

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                String query = "select * from tbl_user_info ";
                Console.WriteLine("-----------------------");
                Console.WriteLine("-> FirstName:" + s.FirstName + ",LastName:" + s.LastName);

                if ((s.UserID == -1) && (s.FirstName == "" && s.LastName == "")) // all empty.
                {
                    //dt = Select();
                    //return dt;
                    // Writing SQL Query
                    query += "order by UserID, FirstName";
                }
                else if ((s.UserID != -1) && (s.FirstName == "" && s.LastName == "")) // UserID use.
                {
                    // Writing SQL Query
                    query += "where UserID=@UserID";
                }
                else if ((s.UserID == -1) && (s.FirstName != "-1" || s.FirstName != "") && s.LastName == "") // FirstName use.
                {
                    // Writing SQL Query
                    query += "where (FirstName=@FirstName or FirstName like @FirstName + '%')";
                }
                else if ((s.UserID != -1) && (s.FirstName != "-1" || s.FirstName != "") && s.LastName == "") // UserID and FirstName uses.
                {
                    // Writing SQL Query
                    query += "where UserID=@UserID and (FirstName=@FirstName or FirstName like @FirstName + '%')";
                }
                else if ((s.UserID == -1) && (s.FirstName != "-1" || s.FirstName != "") && (s.LastName != "-1" || s.LastName != "")) // UserID empty and FullName uses.
                {
                    // Writing SQL Query
                    query += "where (FirstName=@FirstName or FirstName like @FirstName + '%') and (LastName=@LastName or LastName like @LastName + '%')";
                }
                else
                {
                    // Writing SQL Query
                    query += "where UserID=@UserID and (FirstName=@FirstName or FirstName like @FirstName + '%') and (LastName=@LastName or LastName like @LastName + '%')";
                    #region complet select
                    //query = "select" +
                    //    " UserID as 'מזהה משתמש'," +
                    //    " FirstName as 'שם פרטי'," +
                    //    " LastName as 'שם משפחה'," +
                    //    " PhoneNumber as 'מספר טלפון'," +
                    //    " Address as 'כתובת'," +
                    //    " Gender as 'מין'" +
                    //    " from tbl_user_info" +
                    //    " where UserID=@UserID and (FirstName=@FirstName or FirstName like @FirstName + '%') and (LastName=@LastName or LastName like @LastName + '%')";
                    #endregion
                }

                // Creating sqlCmd using query and sqlCon
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                // Create Parameters to do search
                sqlCmd.Parameters.AddWithValue("@UserID", s.UserID);
                sqlCmd.Parameters.AddWithValue("@FirstName", s.FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", s.LastName);
                // Creating SQL DataAdapter using sqlCmd
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dt);
                
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    for (int b = 0; b < dt.Columns.Count; b++)
                    {
                        Console.WriteLine(dt.Rows[a].ItemArray[b]);
                    }
                    Console.WriteLine("--");
                }

                    foreach (DataRow row in dt.Rows)
                {
                    string value0 = row.ItemArray[0].ToString();
                    string value1 = row.ItemArray[1].ToString();
                    string value2 = row.ItemArray[2].ToString();
                    Console.WriteLine(value0 + " - " + value1 + " " + value2);

                    //...
                }

                #region comments


                //sqlReader.Close();
                //SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                //adapter.Fill(dt);
                //DataColumn newColumn = new DataColumn("הצגת פרטים", typeof(Button));
                //dt.Columns.Add(newColumn);

                //for (int a = 0; a < dt.Rows.Count; a++)
                //{
                //    dt.Rows[a].ItemArray[6] = MakeAButton();
                //}
                //adapter.Update(dt);



                //adapter.Fill(dt);
                //SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                //DataColumn newColumn0 = new DataColumn("מזהה משתמש", typeof(int));
                //DataColumn newColumn1 = new DataColumn("שם פרטי", typeof(string));
                //DataColumn newColumn2 = new DataColumn("שם משפחה", typeof(string));
                //DataColumn newColumn3 = new DataColumn("מספר טלפון", typeof(string));
                //DataColumn newColumn4 = new DataColumn("כתובת", typeof(string));
                //DataColumn newColumn5 = new DataColumn("מין", typeof(string));
                //DataColumn newColumn6 = new DataColumn("הצגת פרטים", typeof(Button));
                //dt.Columns.Add(newColumn0);
                //dt.Columns.Add(newColumn1);
                //dt.Columns.Add(newColumn2);
                //dt.Columns.Add(newColumn3);
                //dt.Columns.Add(newColumn4);
                //dt.Columns.Add(newColumn5);
                //dt.Columns.Add(newColumn6);

                //dt.Columns.Add("מזהה משתמש");
                //dt.Columns.Add("שם פרטי");
                //dt.Columns.Add("שם משפחה");
                //dt.Columns.Add("מספר טלפון");
                //dt.Columns.Add("כתובת");
                //dt.Columns.Add("מין");
                //dt.Columns.Add("הצגת פרטים");



                //while (sqlReader.Read())
                //{
                //    DataRow dataRow = dt.NewRow();

                //    Console.WriteLine(sqlReader["FirstName"].ToString() + " " + sqlReader["LastName"].ToString());

                //    dataRow["מזהה משתמש"] = Convert.ToInt32(sqlReader["UserID"]);
                //    dataRow["שם פרטי"] = sqlReader["FirstName"].ToString();
                //    dataRow["שם משפחה"] = sqlReader["LastName"].ToString();
                //    dataRow["מספר טלפון"] = sqlReader["PhoneNumber"].ToString();
                //    dataRow["כתובת"] = sqlReader["Address"].ToString();
                //    dataRow["מין"] = sqlReader["Gender"].ToString();
                //    dataRow["הצגת פרטים"] = MakeAButton();

                //    Console.WriteLine(dataRow["שם פרטי"].ToString() + " " + dataRow["שם משפחה"].ToString());

                //    dt.Rows.Add(dataRow);
                //}


                //foreach (DataRow row in schemaTable.Rows)
                //{
                //    for (int a = 0; a < schemaTable.Rows.Count; a++)
                //    {
                //        DataColumn newColumn1 = new DataColumn();
                //        Button btn = new Button();
                //        btn.Content = "הצג פרטים";
                //        btn.Name = "button" + a + "";
                //        btn.Click += BtnDelete_Click;

                //        //newColumn1.add = btn;
                //        //schemaTable.Columns.Add(btn);
                //            //dt.Columns.Add("הצגת פרטים", typeof(Button));
                //            //btn.Click += new EventHandler(this.BtnDelete_Click);
                //            //btn.Click += new RoutedEventHandler(this.BtnDelete_Click);
                //            //btnExitApp.Content = "Exit Application";
                //            //btnExitApp.Height = 25;
                //            //btnExitApp.Width = 100;

                //            //dt.Rows.Add(newColumn1);

                //    }
                //}

                //DataRow[] rows = dt.Select();
                //DataColumn newColumn = new DataColumn("הצגת פרטים", typeof(System.String));

                //DataColumn newColumn = new DataColumn("הצגת פרטים", typeof(Button));
                //dt.Columns.Add(newColumn);

                //adapter.Fill(dt);
                //int countNum = 0;
                //for(int i=0; i< dt.Rows.Count; i++)
                //{
                //    //DataColumn newColumn1 = new DataColumn();
                //    Button btn = new Button();
                //    btn.DataContext = "הצג פרטים";
                //    btn.Name = "button" + i + "";
                //    btn.Click += BtnDelete_Click;

                //    dt.Rows[i] = "button";
                //    //dt.Columns.Add("הצגת פרטים", typeof(Button));
                //    //btn.Click += new EventHandler(this.BtnDelete_Click);

                //    //dt.Rows.Add(newColumn1);
                //}


                //DataRow newRow = dt.NewRow();
                //Button btn1 = new Button();
                ////btn.DataContext = "הצג פרטים";
                //btn1.Name = "button1";
                //btn1.Content = "הצג פרטים";
                //btn1.Width = 10;
                //btn1.Height = 10;
                //btn1.ClickMode = ClickMode.Press;
                //btn1.Click += BtnDelete_Click;

                //newRow[0] = 10;
                //newRow[1] = "אורן";
                //newRow[2] = "ביטון";
                //newRow[3] = "חדרה";
                //newRow[4] = 098888888;
                //newRow[5] = "זכר";
                //newRow[6] = btn1;
                //dt.Rows.Add(newRow);

                //newRow["הצגת פרטים"] = new Button()
                //{
                //    //DataContext = "הצג פרטים",
                //    Name = "button1",
                //    Content = "הצג פרטים",
                //    Width = 10,
                //    Height = 10,
                //};
                //dt.Rows.Add(newRow);

                //for (int a = 0; a < dt.Rows.Count; a++)
                //{
                //    Button btn = new Button();
                //    //btn.DataContext = "הצג פרטים";
                //    btn.Name = "button" + a + "";
                //    btn.Content = "הצג פרטים";
                //    btn.Width = 10;
                //    btn.Height = 10;
                //    btn.Click += BtnDelete_Click;
                //    //btn.Click += new EventHandler(dt.Rows[a].ItemArray[6].BtnDelete_Click);
                //    //dt.Rows[a].GetChildRows(btn);
                //    Console.WriteLine(dt.Rows[a][6].GetType());
                //    //dt.Rows[a]["הצגת פרטים"] = btn;
                //    //dt.Rows[a].ItemArray[6] = btn;
                //    //dt.Rows.Add(dt.NewRow());
                //    adapter.Update(dt);

                //    for (int b = 0; b < dt.Columns.Count; b++)
                //    {
                //        Console.WriteLine(dt.Rows[a].ItemArray[b].ToString());
                //    }
                //    Console.WriteLine("----------");
                //    Console.WriteLine(dt.Rows[a].ItemArray[6].ToString());
                //    //dt.Rows[i].ItemArray[5] = new Button() {
                //    //    Name = "rowButton",
                //    //    DataContext = "Row Button Content",
                //    //    Width = 10,
                //    //    Height = 10,
                //    //};
                //    //Console.WriteLine(dt.Rows[i].ItemArray[5].ToString());
                //}


                //foreach (DataRow row in dt.Rows)
                //{
                //    Console.WriteLine("1 -------");
                //    row.BeginEdit();
                //    row["הצגת פרטים"] = new Button()
                //    {
                //        Name = "rowButton",
                //        DataContext = "Row Button Content",
                //        Width = 10,
                //        Height = 10,
                //    };
                //    dt.Rows.Add(row);
                //    //adapter.Fill(dt);
                //    row.EndEdit();
                //    //row.BeginEdit();
                //}

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    Console.WriteLine(i);
                //    //row.AcceptChanges();
                //    //row["הצגת פרטים"] = new Button()
                //    //{
                //    //    Name = "rowButton",
                //    //    DataContext = "Row Button Content",
                //    //    Width = 10,
                //    //    Height = 10,
                //    //};
                //    //dt.Rows.Add(row);
                //    //row.AcceptChanges();
                //    ////row.AcceptChanges();
                //    //dt.AcceptChanges();
                //}


                //row["הצגת פרטים"] = new Button
                //{
                //    Name = "rowButton",
                //    DataContext = "Row Button Content",
                //    Width = 10,
                //    Height = 10
                //};
                //dt.Rows.Add(row);
                //dt.RowChanged

                //DataColumn newColumn1 = new DataColumn();
                //Button btn = new Button();
                //btn.DataContext = "הצג פרטים";
                //btn.Name = "button" + countNum + "";
                //btn.Click += BtnDelete_Click;
                //btn.Click += new EventHandler(this.BtnDelete_Click);
                ////Console.WriteLine(" ***** ");
                //countNum++;

                //dt.Rows.Add(btn);

                //btn.Click += new EventHandler(BtnDelete_Click);

                //adapter.Fill(dt);

                //newColumn.DefaultValue = "הצג פרטים";
                //dt.Columns.Add(newColumn);
                //for (int i = 0; i < rows.Length; i++)
                //{
                //    //dt.Rows[i].add;
                //}

                //adapter.Fill(dt);



                //private static void BtnDelete_Click(object sender, RoutedEventArgs e)
                //{
                //    MessageBox.Show("הייתה לחיצה.");
                //}



                //int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                //if ((count == 0 || count != s.UserID) && s.FirstName == "")
                //{
                //    MessageBox.Show(".אין אנשים במערכת בעלי תעודת זהות כזו");
                //}
                //Console.WriteLine("------->" + count);

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            return dt;
        }

    }
}
