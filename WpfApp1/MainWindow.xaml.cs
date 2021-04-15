using System;
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
//using System.Windows.Forms;
using System.ComponentModel;
using Application = System.Windows.Forms.Application;
using Microsoft.Win32;

namespace WpfApp1
{
    
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public int numberOfSelectedDays;
        //List<int> hours = new List<int>();
        List<String> days = new List<String>();
        List<Day> daysWithHours = new List<Day>();
        List<Course> courses = new List<Course>();

        List<int> mondayHours = new List<int>();
        List<int> tuesdayHours = new List<int>();
        List<int> wednesdayHours = new List<int>();
        List<int> thursdayHours = new List<int>();
        List<int> fridayHours = new List<int>();
        





        public MainWindow()
        {
            InitializeComponent();
            
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Resources/icon.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("WpfApp1", Application.ExecutablePath);
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // setting cancel to true will cancel the close request
            // so the application is not closed
            e.Cancel = true;

            this.Hide();

            base.OnClosing(e);
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

      
        private void mondayCheckedChanged(object sender, RoutedEventArgs e)
        {
            if (mondayCheckBox.IsChecked == true)
            {                
                numberOfSelectedDays++;               
                days.Add("Monday");
                mondayListBox.Visibility = Visibility.Visible;
            }
            else if (mondayCheckBox.IsChecked == false)
            {
                numberOfSelectedDays--;
                days.Remove("Monday");
                mondayListBox.Visibility = Visibility.Collapsed;
            }
        }

        private void tuesdayCheckedChanged(object sender, RoutedEventArgs e)
        {
            if (tuesdayCheckBox.IsChecked == true)
            {
                numberOfSelectedDays++;
                days.Add("Tuesday");
                tuesdayListBox.Visibility = Visibility.Visible; ;
                mondayCheckBox.IsEnabled = false;
            }
            else if (tuesdayCheckBox.IsChecked == false)
            {
                numberOfSelectedDays--;
                days.Remove("Tuesday");
                tuesdayListBox.Visibility = Visibility.Collapsed;
                mondayCheckBox.IsEnabled = true;
            }
        }

        private void wednesdayCheckedChanged(object sender, RoutedEventArgs e)
        {
            if (wednesdayCheckBox.IsChecked == true)
            {
                numberOfSelectedDays++;
                days.Add("Wednesday");
                wednesdayListBox.Visibility = Visibility.Visible;
                mondayCheckBox.IsEnabled = false;
                tuesdayCheckBox.IsEnabled = false;
            }
            else if (wednesdayCheckBox.IsChecked == false)
            {
                numberOfSelectedDays--;
                days.Remove("Wednesday");
                wednesdayListBox.Visibility = Visibility.Collapsed;
                mondayCheckBox.IsEnabled = true;
                tuesdayCheckBox.IsEnabled = true;
            }
        }

        private void thursdayCheckedChanged(object sender, RoutedEventArgs e)
        {
            if (thursdayCheckBox.IsChecked == true)
            {
                numberOfSelectedDays++;
                days.Add("Thursday");
                thursdayListBox.Visibility = Visibility.Visible;
                mondayCheckBox.IsEnabled = false;
                tuesdayCheckBox.IsEnabled = false;
                wednesdayCheckBox.IsEnabled = false;
            }
            else if (thursdayCheckBox.IsChecked == false)
            {
                numberOfSelectedDays--;
                days.Remove("Thursday");
                thursdayListBox.Visibility = Visibility.Collapsed;
                mondayCheckBox.IsEnabled = true;
                tuesdayCheckBox.IsEnabled = true;
                wednesdayCheckBox.IsEnabled = true;
            }
        }

        private void fridayCheckedChanged(object sender, RoutedEventArgs e)
        {
            if (fridayCheckBox.IsChecked == true)
            {
                numberOfSelectedDays++;
                days.Add("Friday");
                fridayListBox.Visibility = Visibility.Visible;
                mondayCheckBox.IsEnabled = false;
                tuesdayCheckBox.IsEnabled = false;
                wednesdayCheckBox.IsEnabled = false;
                thursdayCheckBox.IsEnabled = false;
            }
            else if (fridayCheckBox.IsChecked == false)
            {
                numberOfSelectedDays--;
                days.Remove("Friday");
                fridayListBox.Visibility = Visibility.Collapsed;
                mondayCheckBox.IsEnabled = true;
                tuesdayCheckBox.IsEnabled = true;
                wednesdayCheckBox.IsEnabled = true;
                thursdayCheckBox.IsEnabled = true;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            for (int i = 1; i <= days.Count; i++)
            {
                List<int> h = new List<int>();
                Day d = new Day();
                d.Name = days[i - 1].ToLower();
                String s = d.Name + "Hours";
                if(s == "mondayHours")
                {
                    h = mondayHours;

                }else if(s == "tuesdayHours")
                {
                    h = tuesdayHours;
                }
                else if (s == "wednesdayHours")
                {
                    h = wednesdayHours;
                }
                else if (s == "thursdayHours")
                {
                    h = thursdayHours;
                }
                else if (s == "fridayHours")
                {
                    h = fridayHours;
                }
                // MessageBox.Show(x);
                d.Hours = GetHours(h, d.Name);
                daysWithHours.Add(d);
            }

            Course course = new Course
            {
                Name = nameText.Text,
                Link = linkText.Text,           
                Passcode = passcodeText.Text,
                Days = daysWithHours,
            };

            courses.Add(course);
            listViewCourses.ItemsSource = courses;
            
        }
         
        private List<int> GetHours(List<int> hours, String day)
        {
            string s = day;

            for (int i = 8; i <= 20; i++)
            {               
                day += i.ToString();
                CheckBox cb = (CheckBox)FindName(day);
                if(cb.IsChecked == true)
                {                   
                    hours.Add(i);
                }
                day = s;
            }
            return hours;
             
        }

        
    }
}
