using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ChessGame
{
    class PiecePawn : ChessPieces
    {
        public PiecePawn(MyColor C, String N)
            : base(C, N)
        {

        }
        public override bool AmIPawn()
        {
            return true;
        }
        public override bool IsMoveLegal(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
        {
            if (Colors == MyColor.Black)
            {
                if (IsDiagonal(Sr, Sc, Er, Ec)&& P[Er,Ec]!=null && Math.Abs(Sr-Er)==1 && Er>Sr)
                {
               
                    if (P[Er, Ec].Colors != P[Sr, Sc].Colors)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else  if (IsVertical(Sr, Sc, Er, Ec) && IsVerticalPathClear(Sr, Sc, Er, Ec, P))
                {
                    if (P[Er, Ec] != null)
                    {
                        return false;
                    }
           
                    if (IsFirstTime == true && (Er - Sr) <= 2 && (Er - Sr) > 0)
                    {
                        return true;
                    }
                    else if (IsFirstTime == false && (Er - Sr < 2 && Er - Sr > 0))
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
            else
            {
                if (IsDiagonal(Sr, Sc, Er, Ec) && P[Er, Ec] != null && Math.Abs(Sr - Er) == 1&&Er<Sr)
                {

                    if (P[Er, Ec].Colors != P[Sr, Sc].Colors)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else if (IsVertical(Sr, Sc, Er, Ec) && IsVerticalPathClear(Sr, Sc, Er, Ec, P))
                {
                    if (P[Er, Ec] != null)
                    {
                        return false;
                    }
                 
                    if (IsFirstTime == true && (Sr - Er) <= 2 && (Sr - Er) > 0)
                    {
                        return true;
                    }
                    else if (IsFirstTime == false && (Sr - Er < 2 && Sr - Er > 0))
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

  }


