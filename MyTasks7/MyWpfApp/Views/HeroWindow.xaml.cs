﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using System.Windows.Shapes;

namespace MyWpfApp
{
    /// <summary>
    /// Interaction logic for HeroWindow.xaml
    /// </summary>
    public partial class HeroWindow : Window
    {
        public Hero Hero { get; private set; }
        private string _error = string.Empty;

        public HeroWindow(Hero h)
        {
            InitializeComponent();
            Hero = h;
            DataContext = Hero;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var valResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var valContext = new ValidationContext(Hero);

            if (!Validator.TryValidateObject(Hero, valContext, valResults, true))
            {
                MessageBox.Show($"{valResults.FirstOrDefault().ErrorMessage}");
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
