using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    class Queen :ChessPieces
    {
          public Queen(MyColor C , String N) : base(C,N)
        {
          

            
        }
         
          public override bool IsMoveLegal(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
          {

              if (IsVertical(Sr, Sc, Er, Ec))
              {
                  if (IsVerticalPathClear(Sr, Sc, Er, Ec, P)) return true;
                  else return false;
              }
              else if (IsHorizontol(Sr, Sc, Er, Ec))
              {
                  if (IsHorizontalPathClear(Sr, Sc, Er, Ec, P)) return true;
                  else return false;
              }
              else if (IsDiagonal(Sr, Sc, Er, Ec))
              {
                  if (IsDiagonalPathClear(Sr, Sc, Er, Ec, P)) return true;
                  else return false;
              }
              else
                  return false;
          }
    }
}
