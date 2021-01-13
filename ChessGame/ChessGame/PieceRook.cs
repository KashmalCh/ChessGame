using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    class PieceRook : ChessPieces
    {
     
        
       public PieceRook (MyColor C , String N) : base(C,N)
        {

        }
       public override bool AmIRook()
       {
           return true;
       }
      
       public override bool IsMoveLegal(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
       {
           if(IsHorizontalPathClear(Sr,Sc,Er,Ec, P) &&  IsVerticalPathClear(Sr,Sc,Er,Ec,P))
           {
               if(IsVertical(Sr,Sc,Er,Ec)|| IsHorizontol(Sr,Sc,Er,Ec))
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           else
           {
               return false;
           }
       }
    }
}
