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
    class TicTacToeMVVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Board board;
        private List<Tile> tiles;

        public ICommand ClickTileCommand { get; set; }

        public Board Board
        {
            get { return board; } 
        }

        public List<Tile> Tiles
        {
            get { return tiles; }
        }
       
        public TicTacToeMVVM()
        {
            board = new Board();
            tiles = new List<Tile>(9);
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    tiles.Add(new Tile(j, i, this));
        }

        public void clickTile(int x, int y)
        {
            int res = board.tileClick(x, y);

            if (res == 1)
            {
                for (int j = 0; j < 3; ++j)
                    for (int i = 0; i < 3; ++i)
                        tiles[i + 3 * j].Content = "";
            }


            tiles[x + 3 * y].Content = "";
        }
    }
}
