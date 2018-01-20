using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace tictactoe_pain
{
    class Tile : INotifyPropertyChanged
    {
        private TicTacToeMVVM mvvm;
        private String content;
        private int x;
        private int y;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClickTileCommand { get; set; }

        public String Content
        {
            get
            {
                return content;
            }
            set
            {
                if (mvvm.Board.get(x, y) == BoardTile.EMPTY)
                    content = "";
                else if (mvvm.Board.get(x, y) == BoardTile.O)
                    content = "O";
                else
                    content = "X";

                NotifyPropertyChanged("Content");
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Tile(int i, int j, TicTacToeMVVM vm)
        {
            x = i;
            y = j;
            mvvm = vm;
            ClickTileCommand = new RelayCommand(pars => clickTile());
        }

        void clickTile()
        {
            mvvm.clickTile(x, y);
        }
    }
}

