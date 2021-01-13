using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessGame
{
  class ChessCells :Button
    {
       public  int RowIndex;
       public int ColIndex;
        public ChessPieces Piece;
       public  MyColor CellColor ;

       public ChessCells (int RI , int CI , ChessPieces P , MyColor CC , int W , int H , int Dim )
        {
           RowIndex = RI;
           ColIndex = CI;
            Piece = P;
            CellColor = CC;
            this.Width = W / Dim - 9;
            this.Height = H / Dim - 9;
            this.BackColor = Color.White;
           if(CC == MyColor.Black)
           {
               this.BackColor = Color.DarkGray;
           }
           if(Piece!=null)
           {
               Draw(this);
           }
           
        }

        void Draw(ChessCells Cell)
       {
           Cell.Image = Image.FromFile("..\\..\\Resources\\" + Cell.Piece.Name);
       }



    }
}
