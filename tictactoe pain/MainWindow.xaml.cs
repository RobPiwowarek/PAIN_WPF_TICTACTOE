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

namespace tictactoe_pain
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TicTacToeMVVM mvvm = new TicTacToeMVVM();
            this.DataContext = mvvm;
            for (int j = 0; j < 3; ++j)
            {
                for (int i = 0; i < 3; ++i)
                {
                    Button button = new Button();
                    Binding content = new Binding("Content");
                    content.Source = mvvm.Tiles[i + 3*j];
                    Binding command = new Binding("ClickTileCommand");
                    command.Source = mvvm.Tiles[i + 3*j];
                    button.SetBinding(Button.CommandProperty, command);
                    button.SetBinding(Button.ContentProperty, content);
                    Grid.SetRow(button, j);
                    Grid.SetColumn(button, i);
                    button.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    button.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                    tileGrid.Children.Add(button);
                }
            }

        }

        
    }
}
