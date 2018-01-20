using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe_pain
{
    class Board
    {
        private List<BoardTile> board;
        private Player currentPlayer;
        private bool gameOver = false;

        public Board()
        {
            board = new List<BoardTile>(9);
            currentPlayer = Player.PLAYER1;
            gameOver = false;
            for (int i = 0; i < 9; ++i)
            {
                BoardTile empty = new BoardTile();
                empty = BoardTile.EMPTY;
                board.Add(empty);
            }
        }

        public Player CurrentPlayer
        {
            get { return currentPlayer; }
        }

        public bool GameOver
        {
            get { return gameOver; }
        }

        public BoardTile get(int i, int j)
        {
            return board[i + j * 3];
        }

        public Player getPlayer(int i, int j)
        {
            return get(i, j) == BoardTile.X ? Player.PLAYER2 : Player.PLAYER1;
        }

        public void set(int i, int j)
        {
            board[i + j * 3] = currentPlayer == Player.PLAYER1 ? BoardTile.O : BoardTile.X;
        }

        private void setEmpty(int i, int j)
        {
            board[i + j * 3] = BoardTile.EMPTY;
        }

        private void switchPlayers()
        {
            if (currentPlayer == Player.PLAYER1)
                currentPlayer = Player.PLAYER2;
            else
                currentPlayer = Player.PLAYER1;
        }

        private void isGameOver()
        {
            // vertical
            if ((get(0, 0) == get(0, 1) && get(0, 1) == get(0, 2)) && get(0, 0) != BoardTile.EMPTY)
                gameOver = true;
            else if ((get(1, 0) == get(1, 1) && get(1, 1) == get(1, 2)) && get(1, 0) != BoardTile.EMPTY)
                gameOver = true;
            else if ((get(2, 0) == get(2, 1) && get(2, 1) == get(2, 2)) && get(2, 0) != BoardTile.EMPTY)
                gameOver = true;
            // horizontal
            else if ((get(0, 0) == get(1, 0) && get(1, 0) == get(2, 0)) && get(0, 0) != BoardTile.EMPTY)
                gameOver = true;
            else if ((get(0, 1) == get(1, 1) && get(1, 1) == get(2, 1)) && get(0, 1) != BoardTile.EMPTY)
                gameOver = true;
            else if ((get(0, 2) == get(1, 2) && get(1, 2) == get(2, 2)) && get(0, 2) != BoardTile.EMPTY)
                gameOver = true;
            // diagonal
            else if ((get(0, 0) == get(1, 1) && get(1, 1) == get(2, 2)) && get(0, 0) != BoardTile.EMPTY)
                gameOver = true;
            else if ((get(2, 0) == get(1, 1) && get(1, 1) == get(0, 2)) && get(2, 0) != BoardTile.EMPTY)
                gameOver = true;

            bool isFull = true;
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    if (get(j, i) == BoardTile.EMPTY)
                        isFull = false;

            if (isFull)
                gameOver = true;
        }

        public int tileClick(int i, int j)
        {
            if (gameOver)
            {
                for (int z = 0; z < 3; ++z)
                    for (int k = 0; k < 3; ++k)
                        setEmpty(z, k);

                gameOver = false;

                return 1;
            }

            if (get(i, j) == BoardTile.EMPTY)
            {
                set(i, j);
                isGameOver();
                if (!gameOver)
                    switchPlayers();
            }

            return 0;
        }
    }

    enum BoardTile
    {
        EMPTY,
        X,
        O
    }

    enum Player
    {
        PLAYER1,
        PLAYER2
    }
}
