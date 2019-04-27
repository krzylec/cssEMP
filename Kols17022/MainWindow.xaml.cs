using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Kols17022.DAL;
using Kols17022.models;

namespace Kols17022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkersDbService _workersDbService;
        private ObservableCollection<EMP> EmpList;
        public MainWindow()
        {
            InitializeComponent();
            _workersDbService= new WorkersDbService();
            var emps = _workersDbService.GetEmpList();
            EmpList = new ObservableCollection<EMP>(emps);

            DataGrid.ItemsSource = EmpList;
            ComboBox.ItemsSource = _workersDbService.GetDeptList();
            ComboBox.SelectedIndex = 0;




        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(JobTextBox.Text))
            {
                var selectedDep = ComboBox.SelectionBoxItem as DEPT;
                EMP EmpToSend = new EMP()
                {
                    EMPNO = _workersDbService.GetMaxIndex() + 1,
                    ENAME = NameTextBox.Text,
                    DEPT = selectedDep,
                    JOB = JobTextBox.Text,
                    SAL = 1200

                };
                    _workersDbService.AddEMP(EmpToSend);
                    EmpList.Add(EmpToSend);
                    MessageBox.Show("dodano");
            }
                
            
        }

        private void SzukajButton_OnClick(object sender, RoutedEventArgs e)
        {
            var res = EmpList.Where(k => k.ENAME.StartsWith(SzukajTextBox.Text));
            EmpList = new ObservableCollection<EMP>(res);
            DataGrid.ItemsSource = EmpList;
           // MessageBox.Show("wyszukano dla" + SzukajTextBox.Text);
        }

        private void PokazButton_OnClick(object sender, RoutedEventArgs e)
        {
            var emps = _workersDbService.GetEmpList();
            EmpList = new ObservableCollection<EMP>(emps);
            DataGrid.ItemsSource = EmpList;
        }
    }
}
