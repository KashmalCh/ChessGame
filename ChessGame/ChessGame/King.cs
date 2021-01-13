using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    class King : ChessPieces
    {
         public King(MyColor C , String N) : base(C,N)
        {

        }
         public override bool AmIKing()
         {
             return true;
         }
  
         public override bool IsMoveLegal(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
         {

             if (Math.Abs(Er - Sr) == 1 )
             {
                 if (Math.Abs(Sc - Ec) <= 1) return true;
                 else return false;
             }
             else if(Math.Abs(Ec - Sc) == 1)
             {
                 if (Math.Abs(Er - Sr) <= 1) return true;
                 else return false;
             }
             else return false;
         }

    }
}
