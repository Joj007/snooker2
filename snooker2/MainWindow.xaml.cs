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
using System.IO;

namespace snooker2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        new List<Versenyzo> versenyzoList;
        public MainWindow()
        {
            versenyzoList = File.ReadAllLines("../../../snooker.txt").ToList().Skip(1).Select(n=>new Versenyzo(n)).ToList();
            InitializeComponent();
            dgTablazat.ItemsSource = versenyzoList;
            cbOrszag.ItemsSource = versenyzoList.Select(n=>n.Orszag).OrderBy(n=>n).Distinct();

            btnF3.Click += (s, e) =>{MessageBox.Show($"3. feladat: A világranglistán {versenyzoList.Count} versenyző  szerepel");};
            btnF4.Click += (s, e) => { MessageBox.Show($"4. feladat: A versenyzők átlagosan {Math.Round(versenyzoList.Sum(n => n.Nyeremeny)*1.0 / versenyzoList.Count*1.0, 2) } fontot kerestek"); };
            //cbOrszag.SelectionChanged += (s, e) => { dgTablazat.ItemsSource = versenyzoList.Where(n => n.Orszag == cbOrszag.Text).ToList(); };
            btnF5.Click += (s, e) =>
            {
                Versenyzo legjobb = versenyzoList.Where(n=>n.Orszag == cbOrszag.Text).MaxBy(n=>n.Nyeremeny);
                lblHelyezes.Content = legjobb.Helyezes;
                lblNev.Content = legjobb.Nev;
                lblOrszag.Content = legjobb.Orszag;
                lblNyeremeny.Content = legjobb.Nyeremeny * int.Parse(txtArfolyam.Text);
            };
            btnF6.Click += (s, e) => {MessageBox.Show(versenyzoList.Where(n => n.Orszag == txtVanIlyenOrszag.Text).Count() == 0 ? ("A versenyzők között nincs ilyen nemzetiségű versenyző") : ("A versenyzők között van ilyen nemzetiségű versenyző")); };
            btnF7.Click += (s, e) => { 
            
            };
        }


    }
}
