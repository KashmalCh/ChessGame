using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    class PieceKnight : ChessPieces
    {
        public PieceKnight(MyColor C , String N) : base(C,N)
        {

        }
     
        
        public override bool IsMoveLegal(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
        {

            if(Math.Abs(Sr-Er) == 2 && Math.Abs(Sc-Ec)==1)
            {
                return true;
            }
            else if(Math.Abs(Sr-Er) == 1 && Math.Abs(Sc-Ec)==2)
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
