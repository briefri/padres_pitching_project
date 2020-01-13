using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace PitchingStatsProject
{
    public partial class _Default : Page
    {
        private string connectionString = "Server=aatzxgybimsbf0.c0im6ybaclfz.us-east-2.rds.amazonaws.com;Database=pitching_data;User Id=dbUser;Password=1qaz2wsx;";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            loadChart1();
            loadChart2();
            loadChart3();
            loadChart4();
            loadChart5();
            loadChart6();

        }
        private void loadChart1()
        {
            //This is for avg rel speed
            string sqlQuery = "SELECT pitcher, avg(relspeed) as avgRelSpeed FROM [dbo].[pitchData] group by pitcher order by pitcher asc;";
            DataTable ChartData = SqlQueryExecute(sqlQuery);

            //binding chart control  
            Chart1.Series[0].XValueMember = "pitcher";
            Chart1.Series[0].YValueMembers = "avgRelSpeed";
            Chart1.DataSource = ChartData;
            Chart1.DataBind();


            //Setting width of line  
            Chart1.Series[0].BorderWidth = 10;
            //setting Chart type   
            Chart1.Series[0].ChartType = SeriesChartType.Bar;

            //Enabled 3D  
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
        }
        private void loadChart2()
        {
            //chart 2
            //This is for pitch type
            string sqlQuery2 = (@"SELECT *
                                FROM
                                (
                                    SELECT[pitchno],
                                           [pitcher],
                                           [pitchtype]
                                    FROM[dbo].[pitchData]
                                    --ORDER BY pitcher ASC
                                ) AS SourceTable PIVOT(COUNT([pitchno]) FOR[pitchtype] IN([Splitter],
                                                                                         [Fastball],
                                                                                         [Sinker],
                                                                                         [ChangeUp],
														                                 [Cutter],
														                                 [Curveball],
														                                 [Slider])) AS PivotTable ORDER BY pitcher ASC;");
            DataTable ChartData2 = SqlQueryExecute(sqlQuery2);


            DataView dv = new DataView(ChartData2);
            Chart2.DataSource = dv;
            Chart2.DataBind();

            foreach (Series cs in Chart2.Series)
            {
                cs.Enabled = false;
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.StackedColumn;
                foreach (DataPoint point in cs.Points)
                {
                    if ((double)point.YValues.GetValue(0) != 0)
                    {
                        Debug.WriteLine("not empty");
                        cs.Enabled = true;
                    }
                }
            }
            

            //Setting width of line  
            Chart2.Series[0].BorderWidth = 10;
  
        }

        private void loadChart3()
        {
            //chart 3
            string sqlQuery3 = (@"SELECT *
                                FROM
                                (
                                    SELECT[pitchno],
                                           [pitcher],
                                           [pitcherset]
                                    FROM[dbo].[pitchData]
                                    WHERE pitchtype = 'Fastball'
                                ) AS SourceTable PIVOT(COUNT([pitchno]) FOR [pitcherset] IN ([Stretch], [Windup])) AS PivotTable;");

            DataTable ChartData3 = SqlQueryExecute(sqlQuery3);


            DataView dv = new DataView(ChartData3);
            Chart3.DataSource = dv;
            Chart3.DataBind();

            foreach (Series cs in Chart3.Series)
            {
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.StackedColumn;
            }

            //Setting width of line  
            Chart3.Series[0].BorderWidth = 10;
        }

        private void loadChart4()
        {
            string queryString = (@"SELECT *
                                    FROM
                                (
                                    SELECT[pitchno],
                                           [pitcher],
                                           [pitchtype]
                                    FROM[dbo].[pitchData]
                                    WHERE playresult = 'HomeRun'
                                    ) AS SourceTable PIVOT(COUNT([pitchno]) FOR [pitchtype] IN([Splitter],
                                                                                                [Fastball],
                                                                                                [Sinker],
                                                                                                [ChangeUp],
														                                        [Cutter],
														                                        [Other],
														                                        [Curveball],
														                                        [Slider])) AS PivotTable;");

            DataTable ChartData4 = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataAdapter sqlQueryAdapter = new SqlDataAdapter(queryString, connection))
                {
                    sqlQueryAdapter.SelectCommand.CommandTimeout = 120;
                    DataSet dataSet = new DataSet();

                    sqlQueryAdapter.Fill(dataSet);
                    connection.Close();
                    ChartData4 = dataSet.Tables[0];
                }
            }

            DataView dv = new DataView(ChartData4);
            Chart4.DataSource = dv;
            Chart4.DataBind();

            foreach (Series cs in Chart4.Series)
            {
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.StackedColumn;
            }

            //Setting width of line  
            Chart4.Series[0].BorderWidth = 10;
        }

        private void loadChart5()
        {
            string queryString = (@"SELECT *
                                    FROM
                                (
                                    SELECT[pitchno],
                                           [pitcher],
                                           [pitchtype]
                                    FROM[dbo].[pitchData]
                                    WHERE pitchcall = 'StrikeCalled'
                                    ) AS SourceTable PIVOT(COUNT([pitchno]) FOR [pitchtype] IN([Splitter],
                                                                                                [Fastball],
                                                                                                [Sinker],
                                                                                                [ChangeUp],
														                                        [Cutter],
														                                        [Curveball],
														                                        [Slider])) AS PivotTable;");

            DataTable ChartData5 = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataAdapter sqlQueryAdapter = new SqlDataAdapter(queryString, connection))
                {
                    sqlQueryAdapter.SelectCommand.CommandTimeout = 120;
                    DataSet dataSet = new DataSet();

                    sqlQueryAdapter.Fill(dataSet);
                    connection.Close();
                    ChartData5 = dataSet.Tables[0];
                }
            }

            DataView dv = new DataView(ChartData5);
            Chart5.DataSource = dv;
            Chart5.DataBind();

            foreach (Series cs in Chart5.Series)
            {
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.StackedColumn;
            }

            //Setting width of line  
            Chart5.Series[0].BorderWidth = 10;

        }

        private void loadChart6()
        {
            //chart 6
            string queryString = (@"SELECT *
                                 FROM
                                (
                                    SELECT[spinrate],
                                            [pitcher],
                                            [pitchtype]
                                    FROM[dbo].[pitchData]
                                    --WHERE spinrate >= 2416.54
                                ) AS SourceTable PIVOT(avg([spinrate]) FOR[pitchtype] IN([Splitter],
                                                                                            [Fastball],
                                                                                            [Sinker],
                                                                                            [ChangeUp],
														                                    [Cutter],
														                                    [Curveball],
														                                    [Slider])) AS PivotTable ORDER BY pitcher ASC;");
        DataTable ChartData6 = SqlQueryExecute(queryString);


            DataView dv = new DataView(ChartData6);
            Chart6.DataSource = dv;
            Chart6.DataBind();

            foreach (Series cs in Chart6.Series)
            {
                cs.Enabled = false;
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.Point;
                foreach (DataPoint point in cs.Points)
                {
                    if ((double)point.YValues.GetValue(0) != 0)
                    {
                        Debug.WriteLine("not empty");
                        cs.Enabled = true;
                    }
                }
            }

            //Setting width of line  
            Chart6.Series[0].BorderWidth = 10;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT *  FROM  [dbo].[pitchData] WHERE pitchtype = \'Slider\'";

            //Assign the results 
            GridView1.DataSource = SqlQueryExecute(queryString);

            //Bind the data
            GridView1.DataBind();

        }


        private DataTable SqlQueryExecute(string queryString)
        {
            Debug.WriteLine(queryString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataAdapter sqlQueryAdapter = new SqlDataAdapter(queryString, connection))
                {
                    sqlQueryAdapter.SelectCommand.CommandTimeout = 120;
                    DataSet dataSet = new DataSet();

                    sqlQueryAdapter.Fill(dataSet);
                    connection.Close();
                    return dataSet.Tables[0];
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chart 3
            string pitchType = DropDownList1.SelectedValue.ToString();
            Debug.WriteLine(pitchType);

            string queryString = (@"SELECT *
                                FROM
                                (
                                    SELECT[pitchno],
                                           [pitcher],
                                           [pitcherset]
                                    FROM[dbo].[pitchData]
                                    WHERE pitchtype = @pitchType) AS SourceTable PIVOT(COUNT([pitchno]) FOR [pitcherset] IN ([Stretch], [Windup])) AS PivotTable;");

            //DataTable ChartData3 = SqlQueryExecute(sqlQuery3);
            DataTable ChartData3 = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataAdapter sqlQueryAdapter = new SqlDataAdapter(queryString, connection))
                {
                    sqlQueryAdapter.SelectCommand.Parameters.AddWithValue("@pitchType", pitchType);
                    sqlQueryAdapter.SelectCommand.CommandTimeout = 120;
                    DataSet dataSet = new DataSet();

                    sqlQueryAdapter.Fill(dataSet);
                    connection.Close();
                    ChartData3 = dataSet.Tables[0];
                }
            }

            DataView dv = new DataView(ChartData3);
            Chart3.DataSource = dv;
            Chart3.DataBind();

            foreach (Series cs in Chart3.Series)
            {
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.StackedColumn;
            }

            //Setting width of line  
            Chart3.Series[0].BorderWidth = 10;
            
        }

        //drop down 2
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chart 4
            string playresult = DropDownList2.SelectedValue.ToString();
            Debug.WriteLine(playresult);

            string queryString = (@"SELECT *
                                FROM
                                (
                                    SELECT[pitchno],
                                           [pitcher],
                                           [pitchtype]
                                    FROM[dbo].[pitchData]
                                    WHERE playresult = @playresult) AS SourceTable PIVOT(COUNT([pitchno]) FOR [pitchtype] IN([Splitter],
                                                                                                                             [Fastball],
                                                                                                                             [Sinker],
                                                                                                                             [ChangeUp],
														                                                                     [Cutter],
														                                                                     [Other],
														                                                                     [Curveball],
														                                                                     [Slider])) AS PivotTable;");

            DataTable ChartData4 = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataAdapter sqlQueryAdapter = new SqlDataAdapter(queryString, connection))
                {
                    sqlQueryAdapter.SelectCommand.Parameters.AddWithValue("@playresult", playresult);
                    sqlQueryAdapter.SelectCommand.CommandTimeout = 120;
                    DataSet dataSet = new DataSet();

                    sqlQueryAdapter.Fill(dataSet);
                    connection.Close();
                    ChartData4 = dataSet.Tables[0];
                }
            }

            DataView dv = new DataView(ChartData4);
            Chart4.DataSource = dv;
            Chart4.DataBind();

            foreach (Series cs in Chart4.Series)
            {
                cs.Enabled = false;
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.StackedColumn;
                foreach (DataPoint point in cs.Points)
                {
                    Debug.WriteLine("pitcher: " + (double)point.YValues.GetValue(0));
                    if ((double)point.YValues.GetValue(0) != 0)
                    {
                        Debug.WriteLine("not empty");
                        cs.Enabled = true;
                    }
                }

            }

            //Setting width of line  
            Chart4.Series[0].BorderWidth = 10;

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chart 5
            string pitchcall = DropDownList3.SelectedValue.ToString();
            Debug.WriteLine(pitchcall);

            string queryString = (@"SELECT *
                                    FROM
                                (
                                    SELECT[pitchno],
                                           [pitcher],
                                           [pitchtype]
                                    FROM[dbo].[pitchData]
                                     WHERE pitchcall = @pitchcall
                                    ) AS SourceTable PIVOT(COUNT([pitchno]) FOR [pitchtype] IN([Splitter],
                                                                                                [Fastball],
                                                                                                [Sinker],
                                                                                                [ChangeUp],
														                                        [Cutter],
														                                        [Curveball],
														                                        [Slider])) AS PivotTable;");

            DataTable ChartData5 = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlDataAdapter sqlQueryAdapter = new SqlDataAdapter(queryString, connection))
                {
                    sqlQueryAdapter.SelectCommand.Parameters.AddWithValue("@pitchcall", pitchcall);
                    sqlQueryAdapter.SelectCommand.CommandTimeout = 120;
                    DataSet dataSet = new DataSet();

                    sqlQueryAdapter.Fill(dataSet);
                    connection.Close();
                    ChartData5 = dataSet.Tables[0];
                }
            }

            DataView dv = new DataView(ChartData5);
            Chart5.DataSource = dv;
            Chart5.DataBind();

            foreach (Series cs in Chart5.Series)
            {
                cs.Enabled = false;
                Debug.WriteLine(cs.Name);
                cs.ChartType = SeriesChartType.StackedColumn;
                foreach (DataPoint point in cs.Points)
                {
                    Debug.WriteLine("pitcher: " + (double)point.YValues.GetValue(0));
                    if ((double)point.YValues.GetValue(0) != 0)
                    {
                        Debug.WriteLine("not empty");
                        cs.Enabled = true;
                    }
                }

            }

            //Setting width of line  
            Chart5.Series[0].BorderWidth = 10;
        }
    }
}