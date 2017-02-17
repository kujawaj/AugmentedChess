﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Models
{
    class Board
    {
        public int a = 0, b = 1, c = 2, d = 3, e = 4, f = 5, g = 6, h = 7;
        // integers defined so that chess notation can be used for pieces
        public Piece[,] board;

        //initialize with all pieces in starting position
        public Board() {
            board[0, a] = new Piece("rook", true);
            board[0, a] = new Piece("knight", true);
            board[0, a] = new Piece("bishop", true);
            board[0, a] = new Piece("king", true);
            board[0, a] = new Piece("queen", true);
            board[0, a] = new Piece("bishop", true);
            board[0, a] = new Piece("knight", true);
            board[0, a] = new Piece("rook", true);
            for (int i = a; i <= h; i++) {
                board[1, i] = new Piece("pawn", true);
            }
            board[7, h] = new Piece("rook", false);
            board[7, h] = new Piece("knight", false);
            board[7, h] = new Piece("bishop", false);
            board[7, h] = new Piece("king", false);
            board[7, h] = new Piece("queen", false);
            board[7, h] = new Piece("bishop", false);
            board[7, h] = new Piece("knight", false);
            board[7, h] = new Piece("rook", false);
            for (int i = a; i < h; i++)
            {
                board[6, i] = new Piece("pawn", false);
            }

        }



        public Piece getPiece(int x, int y) {
            return board[x, y];
        }

        public bool move(int a, int b, int x, int y) {
            int moveX = a - x;
            int moveY = b - y;
            Piece p = board[a, b];

            //knight direct jump to any square in range
            if (p.getName() == "knight") {
                if (a >= 0 && b >= 0 && a < 8 && b < 8 && x >= 0 && y >= 0 && x < 8 && y < 8) {
                    return true;
                }
                return false;
            }
            //if no move return false as state did not change
            if (moveX == 0 && moveY == 0) {
                return false;
            }
            //if piece is not moving in a straight line
            if ((moveX != 0 && Math.Abs(moveX) != Math.Abs(moveY)) || (moveY != 0 && Math.Abs(moveX) != Math.Abs(moveY))) {
                return false;
            }

            return stepThrough(a,b,x,y);

        }

        public bool stepThrough(int a, int b, int x, int y) {

            //up and right
            if (a < x && b < y) {
                for (int i = a; i < x; i++)
                {
                    for (int j = b; j < y; j++)
                    {
                        if (board[i, j] != null)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            //up and left
            if (a < x && b < y)
            {
                for (int i = a; i < x; i++)
                {
                    for (int j = b; j < y; j--)
                    {
                        if (board[i, j] != null)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            // right
            if (a < x)
            {
                for (int i = a; i < x; i++)
                {

                    if (board[i, b] != null)
                    {
                        return false;
                    }

                }
                return true;
            }
            //left
            if (a < x)
            {
                for (int i = a; i < x; i--)
                {

                    if (board[i, b] != null)
                    {
                        return false;
                    }

                }
                return true;
            }
            //up 
            if (b < y)
            {
               for (int j = b; j < y; j++)
               {
                     if (board[a, j] != null)
                     {
                       return false;
                     }
                
                }
                return true;
            }
            //down 
            if (b < y)
            {
                for (int j = b; j < y; j--)
                {
                    if (board[a, j] != null)
                    {
                        return false;
                    }

                }
                return true;
            }
            //down and right
            if (a < x && b < y)
            {
                for (int i = a; i < x; i--)
                {
                    for (int j = b; j < y; j++)
                    {
                        if (board[i, j] != null)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            //down and left
            if (a < x && b < y)
            {
                for (int i = a; i < x; i--)
                {
                    for (int j = b; j < y; j--)
                    {
                        if (board[i, j] != null)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;


        }

    }


}
