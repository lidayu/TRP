using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;

namespace MessageBoxTEST
{
    /// <summary>
    /// Interaction logic for TaskList.xaml
    /// </summary>
    public partial class TaskList : Window
    {
        public TaskList()
        {
            InitializeComponent();

            ObservableCollection<Member> memberData = new ObservableCollection<Member>();
            memberData.Add(new Member()
            {
                Name = "Joe",
                Age = "23",
                Sex = SexOpt.Male,
                Pass = true,
                Email = new Uri("mailto:Joe@school.com"),
                Edit=new DelegateCommand<object>(this.OnEditButton)
            });
            memberData.Add(new Member()
            {
                Name = "Mike",
                Age = "20",
                Sex = SexOpt.Male,
                Pass = false,
                Email = new Uri("mailto:Mike@school.com"),
                Edit=new DelegateCommand<object>(this.OnEditButton)
            });
            memberData.Add(new Member()
            {
                Name = "Lucy",
                Age = "25",
                Sex = SexOpt.Female,
                Pass = true,
                Email = new Uri("mailto:Lucy@school.com"),
                Edit=new DelegateCommand<object>(this.OnEditButton)
            });

            this.dataGrid.DataContext = memberData;
         
        }

        private void OnEditButton(object para)
        {
        //    Member selectedMember = this.dataGrid.SelectedItem as Member;
        //    int index = dataGrid.SelectedIndex; //当前行号
        //    var row = dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[index]) as DataGridRow;
            //row.Background = new SolidColorBrush(Colors.Red);//设置选中行的颜色
           // this.dataGrid.SelectedIndex = -1;
 
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Member selectedMember= this.dataGrid.SelectedItem as Member;
        }
    }
    public enum SexOpt { Male, Female };

    public class Member
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public SexOpt Sex { get; set; }
        public bool Pass { get; set; }
        public Uri Email { get; set; }

        public DelegateCommand<object> Edit { get; set; }
    }
}
