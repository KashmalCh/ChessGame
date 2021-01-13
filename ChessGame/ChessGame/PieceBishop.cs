using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    class PieceBishop : ChessPieces
    {
        public PieceBishop(MyColor C , String N) : base(C,N)
        {

        }
       
        public override bool IsMoveLegal(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
        {

            if(IsDiagonal(Sr,Sc,Er,Ec)&& IsDiagonalPathClear(Sr,Sc,Er,Ec,P))
            {
                return true;
            }
            else
            {
                 return false;
            }
        }
    }
}
