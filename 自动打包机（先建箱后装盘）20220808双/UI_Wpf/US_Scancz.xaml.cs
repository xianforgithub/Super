using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using LWDBJ;
using Visifire.Charts;

namespace LWDBJ_自建_.UI_Wpf
{
    /// <summary>
    /// US_Scancz.xaml 的交互逻辑
    /// </summary>
    public partial class US_Scancz : Window
    {
        public US_Scancz()
        {
            InitializeComponent();
        }

        DataTable historyTable;
        int historyCount;
        string SatrtTime;
        string EndTime;
        bool flagOKResult ;
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Readsqltoshow();
            if(flagOKResult )
            {
                cancz.Children.Clear();
                GetMonthChart();
            }
        }

        #region 方法
        private void  Readsqltoshow()
        {
            try
            {
                flagOKResult = false;
                if (datePicker1.Text.Trim() == "" || datePicker2.Text.Trim() == "")
                {
                    MessageBox.Show("请选择查询时间！");
                    return  ;
                }
                SatrtTime = datePicker1.Text.ToString() + " 00:00:00";
                EndTime = datePicker2.Text.ToString() + " 23:59:59";
                historyCount = 0;

                historyTable = SqlHelper.GetAllSQLDataAsDataTable("select * from scancz01 where time between'" + SatrtTime + "'and '" + EndTime + "' order by time asc ", out historyCount);
                dataGrid1.ItemsSource = historyTable.DefaultView;
                dataGrid1.ScrollIntoView(dataGrid1.Items[dataGrid1.Items.Count - 1]);
                this.textBoxCount.Text = historyCount.ToString();
                flagOKResult = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        #region 柱状图
        public void GetMonthChart()
        {
            string name = SatrtTime.Split(' ')[0];
            name = name.Split('/')[0];
            int time = Convert.ToInt16(SatrtTime.Split(' ')[0].Split('/')[1]);//2022/06/02 00:00:00
            List<string> ls_date = new List<string>();
            List<string> ls_value = new List<string>();
            //if (time == 2)
            //{
            //    for (int i = 1; i < 29; i++)
            //    {
            //        ls_date.Add(i.ToString());
            //    }
            //}
            //else if (time == 2 || time == 4 || time == 6 || time == 9 || time == 11)
            //{
            //    for (int i = 1; i < 31; i++)
            //    {
            //        ls_date.Add(i.ToString());
            //    }
            //}
            //else
            //{
            //    for (int i = 1; i < 32; i++)
            //    {
            //        ls_date.Add(i.ToString());
            //    }
            //}
           
            for(int i=1;i<13;i++)
            {
                ls_date.Add(i.ToString());
            }
            int count;
            string sql;
            //select * from (table) where (time) between "2021-01-05 00:00:00" and "2021-01-06 23:59:59"


            for (int i = 1; i < 12; i++)
            {
                sql = "select count(*) from scancz01 where time between \"" + name.ToString() + "/" + i.ToString() + "/01\" and\"" + name.ToString() + "/" + (i + 1).ToString() + "/01\"";
                count = SqlHelper.GetTableRow(sql);
                ls_value.Add(count.ToString());
            }
            sql = "select count(*) from scancz01 where time between \"" + name.ToString() + "/" + "12/01\" and\"" + name.ToString() + "/" + "12/31\"";
            count = SqlHelper.GetTableRow(sql);
            ls_value.Add(count.ToString());
            name += "年数据";
            CreateChartColumn(name, ls_date, ls_value);

        }
        public void CreateChartColumn(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();
            //设置图标的宽度和高度
            //chart.Width = 430;//让图大小跟随容器，不设置固定值
            //chart.Height = 450;
            chart.Margin = new Thickness(0, 0, 10, 5);
            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0
            yAxis.AxisMinimum = 0;
            //设置图表中Y轴的后缀
            yAxis.Suffix = "个";

            chart.AxesY.Add(yAxis);

            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            // 设置数据线的格式
            dataSeries.RenderAs = RenderAs.StackedColumn;//柱状Stacked

            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                //设置X轴点
                dataPoint.AxisXLabel = valuex[i];
                //设置Y轴点
                dataPoint.YValue = double.Parse(valuey[i]);
                //添加一个点击事件
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                //添加数据点
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.
            Grid gr = new Grid();
            gr.Children.Add(chart);
            cancz.Children.Add(gr);
        }
        void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataPoint dp = sender as DataPoint;
            MessageBox.Show(dp.AxisXLabel.ToString() + "月产品:" + dp.YValue.ToString()+"pcs");
        }
        #endregion
        #endregion 方法
    }
}
