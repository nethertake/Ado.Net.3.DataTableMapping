using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace Ado.Net._3.HW.DataTableMapping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _connectionString = @"Data Source = DESKTOP-PG10UGI\SQLEXPRESS; Initial Catalog = CRCMS_new; User Id = sa; Password = Mc123456";
        public MainWindow()
        {
            InitializeComponent();
            GetData();
            GetData2();
            GetData3();
            GetData4();
        }

        public void GetData()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from dic_Group", con);
            //SqlCommand cmd = new SqlCommand("Select * from dic_Group", con);
            //SqlDataAdapter adapter2 = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("Database");
            adapter.Fill(ds);
          
            List<Groups> groups = new List<Groups>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Groups group = new Groups();
                group.GroupId += string.Format(row["GroupId"].ToString());
                group.Name += string.Format(row["Name"].ToString());
                groups.Add(group);
            }
            ListViewGroup.ItemsSource = groups;
        }

        public void GetData2()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from dic_Status", con);
            DataSet ds2 = new DataSet("Database2");
            adapter2.Fill(ds2);
            List<Status> statuses = new List<Status>();
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                Status status = new Status();
                status.StatusId += string.Format(row["StatusId"].ToString());
                status.NameEn += string.Format(row["NameEn"].ToString());
                status.NameRu += string.Format(row["NameRu"].ToString());
                status.StatusTypeId += string.Format(row["StatusTypeId"].ToString());
                statuses.Add(status);
            }
            ListViewStatus.ItemsSource = statuses;
        }

        public void GetData3()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from dic_Pavilion", con);
            DataSet ds3 = new DataSet("Database2");
            adapter2.Fill(ds3);
            List<Pavilion> pavilions = new List<Pavilion>();
            foreach (DataRow row in ds3.Tables[0].Rows)
            {
                Pavilion pavilion = new Pavilion();
                pavilion.PavilionId += string.Format(row["PavilionId"].ToString());
                pavilion.Name += string.Format(row["Name"].ToString());
                pavilions.Add(pavilion);
            }
            ListViewPavilion.ItemsSource = pavilions;

        }

        public void GetData4()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from dic_Model", con);
            DataSet ds4 = new DataSet("Database2");
            adapter2.Fill(ds4);

            System.Data.Common.DataTableMapping mapping =
            adapter2.TableMappings.Add("Database2", "dic_Model");
            mapping.ColumnMappings.Add("Code", "CodeModel");
            mapping.ColumnMappings.Add("Name ", "NameModel");
            mapping.ColumnMappings.Add("SeriesId ", "Series");
            adapter2.Fill(ds4);

            List<Model> models = new List<Model>();
            foreach (DataRow row in ds4.Tables[0].Rows)
            {
                Model model = new Model();
                model.ModelId += string.Format(row["ModelId"].ToString());
                model.Code += string.Format(row["Code"].ToString());
                model.Name += string.Format(row["Name"].ToString());
                model.SeriesId += string.Format(row["SeriesId"].ToString());
                models.Add(model);
            }
            ListViewModel.ItemsSource = models;

 
            

           

        }

        public class Pavilion
        {
            public string PavilionId { get; set; }
            public string Name { get; set; }


        }

        public class Model
        {
            public string ModelId { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string SeriesId { get; set; }

        }
        public class Groups
        {
            public string GroupId { get; set; }
            public string Name { get; set; }
        }

        public class Status
        {
            public string StatusId { get; set; }
            public string NameEn { get; set; }
            public string NameRu { get; set; }
            public string StatusTypeId { get; set; }

        }
    
    }
}
