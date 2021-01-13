using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace ChessGame
{
     enum MyColor { White, Black };
     abstract class ChessPieces
     {
         public MyColor Colors;
         public string Name;
         public bool IsFirstTime = true;
         public ChessPieces(MyColor Col, String N)
         {
             Colors = Col;
             Name = N;
         }
         public virtual bool AmIKing()
         {
             return false;
         }
         public virtual bool AmIRook()
         {
             return false;
         }
         public virtual bool AmIPawn()
         {
             return false;
         }
         public abstract bool IsMoveLegal(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P);


    
         public static bool IsHorizontol(int Sr, int Sc, int Er, int Ec)
         {
             return Sr == Er;
         }
         public static bool IsVertical(int Sr, int Sc, int Er, int Ec)
         {
             return Sc == Ec;
         }
         public static bool IsDiagonal(int Sr, int Sc, int Er, int Ec)
         {
             return Math.Abs(Ec - Sc) == Math.Abs(Er - Sr);
         }
         public static bool IsVerticalPathClear(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
         {
             int Start = Sr + 1;
             int End = Er - 1;
             if (Sr > Er)
             {
                 Start = Er + 1; ;
                 End = Sr - 1;

             }
             for (int ri = Start; ri <= End; ri++)
             {
                 if (P[ri, Sc] != null) return false;
             }
             return true;
         }
         public static bool IsHorizontalPathClear(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
         {
             int Start = Sc + 1;
             int End = Ec - 1;
             if (Sc > Ec)
             {
                 Start = Ec + 1; ;
                 End = Sc - 1;

             }
             for (int ci = Start; ci <= End; ci++)
             {
                 if (P[Sr, ci] != null) return false;
             }
             return true;
         }
         public static bool IsDiagonalPathClear(int Sr, int Sc, int Er, int Ec, ChessPieces[,] P)
         {
             int Start = Sr + 1;
             int End = Er - 1;
             int Row = Sr + 1;
             int Col = Sc + 1;
            
             if(Er>Sr&&Ec>Sc || Er<Sr&&Ec<Sc )
             {
                 if (Start > End)
                 {
                     Start = Er + 1;
                     End = Sr - 1;
                     Row = Er + 1;
                     Col = Ec + 1;
                 }
                
                 for (int i = Start; i <= End; i++)
                 {
                     if (P[Row, Col] != null) return false;
                     Row++;
                     Col++;
                 }
                 return true;
             }
             else if (Sr>Er && Sc<Ec || Sr<Er&&Ec<Sc)
             {
                 Col = Sc - 1;
                 if (Start > End)
                 {
                     Start = Er + 1;
                     End = Sr - 1;
                     Row = Er + 1;
                     Col = Ec - 1;
                 }
                     
                 for (int j = Start; j <= End; j++)
                 {
                     if (P[Row, Col] != null) return false;
                     Row++;
                     Col--;
                 }
                 return true;
             }
             else
                 return false;
         }
     }
}
