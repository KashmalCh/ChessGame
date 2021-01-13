using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class ChessGame : Form
    {
        const int Dim = 8;
        ChessCells KingCellWhite ;
        int PawnR;
        int PawnC;
        int Click;
        bool Win = false;
        ChessCells KingCellBlack;
        ChessCells  [,] Cell = new ChessCells[Dim,Dim];
        ChessPieces[,] Piece = new ChessPieces[Dim, Dim];
        ChessPieces[,] TempPiece = new ChessPieces[Dim, Dim];
        MyColor CellColor = MyColor.Black;
        MyColor PlayerTurn = MyColor.White;
        Boolean TurnChecker = true;
        ChessCells Source;
        ChessCells Destination;
        int counter;

        void Castling()
        {
           
        }

       bool CheckMateB()
        {
           for(int ri=0; ri<Dim; ri++)
           {
               for(int ci=0; ci<Dim; ci++)
               {
                   for(int pi=0; pi<Dim; pi++)
                   {
                       for(int qi=0; qi<Dim; qi++)
                       {
                           CopyPieces();
                           if (TempPiece[ri, ci] != null)
                           {
                               if (TempPiece[ri, ci].IsMoveLegal(ri, ci, pi, qi, TempPiece) && TempPiece[ri, ci].Colors == MyColor.Black)
                               {
                                   if(TempPiece[pi, qi]!=null)
                                   {
                                          if( TempPiece[ri, ci].Colors != TempPiece[pi, qi].Colors)
                                          {
                                              if (CheckMateSelfCheck(ri, ci, pi, qi) == false) return false;
                                          }
                                   }
                                   else
                                   {
                                       if (CheckMateSelfCheck(ri, ci, pi, qi) == false) return false;
                                   }
                                
                                   
                               }
                           }
                       }
                   }
               }
           }

           return true;
        }
    
        public ChessGame()
        {
            InitializeComponent();
        }

  
        void CopyPieces()
        {
            
            for(int ri=0; ri<Dim; ri++)
            {
                for(int ci=0; ci<Dim; ci++)
                {
                    TempPiece[ri, ci] = Piece[ri, ci];
                    if (TempPiece[ri, ci]!=null)
                    TempPiece[ri, ci].Colors = Piece[ri, ci].Colors;

                }
            }
        }
        bool SelfCheck()
        {
    
            CopyPieces();
            TempMove();
            TempCheck();
            if(counter>0)
            {
                
                counter = 0;
                return true;
            }
            else
            {
                counter = 0;
                return false;
            }
        }
        bool CheckMateSelfCheck(int Sr,int Sc, int Dr,int Dc)
        {

            CopyPieces();
            CheckMateTempMove(Sr, Sc, Dr, Dc);
            CheckMateTempCheck();
            if (counter > 0)
            {

                counter = 0;
                return true;
            }
            else
            {
                counter = 0;
                return false;
            }
        }
    
 
      
        void TempCheck()
        {
            TempKingsPlace();

            for (int ri = 0; ri < Dim; ri++)
            {
                for (int ci = 0; ci < Dim; ci++)
                {
                    if (TempPiece[ri,ci] != null)
                    {
                        if (TempPiece[ri, ci].Colors == MyColor.Black)
                        {
                            if (TempPiece[ri, ci].IsMoveLegal(ri, ci, KingCellWhite.RowIndex, KingCellWhite.ColIndex, TempPiece) == true)
                            {
                                if (PlayerTurn == MyColor.Black)
                                {
                                    MessageBox.Show("SelfCheck");
                                    counter++;
                                }
                            }
                        }
                        if (TempPiece[ri, ci].Colors == MyColor.White)
                        {
                            if (TempPiece[ri, ci].IsMoveLegal(ri, ci, KingCellBlack.RowIndex, KingCellBlack.ColIndex, TempPiece) == true)
                            {
                                if (PlayerTurn == MyColor.White)
                                {
                                    MessageBox.Show("SlefCheck");
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
        }
        void CheckMateTempCheck()
        {
            TempKingsPlace();

            for (int ri = 0; ri < Dim; ri++)
            {
                for (int ci = 0; ci < Dim; ci++)
                {
                    if (TempPiece[ri, ci] != null)
                    {
                        if (TempPiece[ri, ci].Colors == MyColor.Black)
                        {
                            if (TempPiece[ri, ci].IsMoveLegal(ri, ci, KingCellWhite.RowIndex, KingCellWhite.ColIndex, TempPiece) == true)
                            {
                                if (PlayerTurn == MyColor.White)
                                {
                                    
                                    counter++;
                                }
                            }
                        }
                        if (TempPiece[ri, ci].Colors == MyColor.White)
                        {
                            if (TempPiece[ri, ci].IsMoveLegal(ri, ci, KingCellBlack.RowIndex, KingCellBlack.ColIndex, TempPiece) == true)
                            {
                                if (PlayerTurn == MyColor.Black)
                                {
                               
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
        }

        void Check()
        {
            KingsPlace();
            for (int ri = 0; ri < Dim; ri++)
            {
                for (int ci = 0; ci < Dim; ci++)
                {
                    if (Cell[ri, ci].Piece != null)
                    {
                        if (Cell[ri, ci].Piece.Colors == MyColor.Black)
                        {
                            if (Cell[ri, ci].Piece.IsMoveLegal(ri, ci, KingCellWhite.RowIndex, KingCellWhite.ColIndex, Piece) == true)
                            {
                                MessageBox.Show("Check");
                                Cell[KingCellWhite.RowIndex,KingCellWhite.ColIndex].BackColor = Color.Red;
                                if(CheckMateW()==true)
                                {
                                    MessageBox.Show("CheckMate");
                                    Win = true;
                                    Box.Controls.Clear(); return;

                                }

                            }
                        }
                        if (Cell[ri, ci].Piece.Colors == MyColor.White)
                        {
                            if (Cell[ri, ci].Piece.IsMoveLegal(ri, ci, KingCellBlack.RowIndex, KingCellBlack.ColIndex, Piece) == true)
                            {
                                MessageBox.Show("Check");
                                Cell[KingCellBlack.RowIndex, KingCellBlack.ColIndex].BackColor = Color.Red;
                                if (CheckMateB() == true)
                                {
                                    MessageBox.Show("CheckMate");
                                    Win = true;
                                    Box.Controls.Clear(); return;
                                }

                            }
                        }
                    }
                }
            }
        }
        bool FinalConditon()
        {
            return true;
        }
        void KingsPlace()
        {
            for(int ri=0; ri<Dim; ri++)
            {
                for(int ci=0; ci<Dim; ci++)
                {
                    if (Cell[ri, ci].Piece != null)
                    {
                        if (Cell[ri, ci].Piece.AmIKing() && Cell[ri, ci].Piece.Colors == MyColor.Black)
                        {
                            KingCellBlack = Cell[ri, ci];
                        }
                        else if (Cell[ri, ci].Piece.AmIKing() && Cell[ri, ci].Piece.Colors == MyColor.White)
                        {
                            KingCellWhite = Cell[ri, ci];
                        }
                    }
                }
            }
        }
        void TempKingsPlace()
        {
            for (int ri = 0; ri < Dim; ri++)
            {
                for (int ci = 0; ci < Dim; ci++)
                {
                    if (TempPiece[ri,ci]!= null)
                    {
                        if (TempPiece[ri, ci].AmIKing() && TempPiece[ri, ci].Colors == MyColor.Black)
                        {
                            KingCellBlack = Cell[ri, ci];
                        }
                        else if (TempPiece[ri, ci].AmIKing() && TempPiece[ri, ci].Colors == MyColor.White)
                        {
                            KingCellWhite = Cell[ri, ci];
                        }
                    }
                }
            }
        }
        private void CellClicked(object sender, EventArgs e)
        { 
            if(TurnChecker)
            {
                SourceSelction(sender, e);
                TurnChecker = false;
                if(Source.Piece==null)
                {
                    MessageBox.Show("You Chose Nothing !!\n\n Kindly Select Again");
                    TurnChecker = true;
                    return;
                }
                else if(Source.Piece.Colors == PlayerTurn)
                {
                    MessageBox.Show("Kindly Choose Your Own Piece !!");
                    TurnChecker = true;
                    return;
                }
                int SR = Source.RowIndex;
                int SC = Source.ColIndex;
                Highlight();
            }
            else
            {
                
             
                    DestinationSelction(sender, e);
                    int SR = Source.RowIndex;
                    int SC = Source.ColIndex;
                    int DR = Destination.RowIndex;
                    int DC = Destination.ColIndex;
                    if (Destination.Piece == null || Destination.Piece.Colors == PlayerTurn)
                    {
                      
                        if (Source.Piece.IsMoveLegal(SR, SC, DR, DC, Piece)&&SelfCheck()==false)
                        {
                            Move();
                        
                            PawnPromote();
                            PrintBoxes();
                            
                        }
                            
                        else
                        {
                            MessageBox.Show(" Wrong Move !! Choose Source Again");
                            TurnChecker = true;
                            PrintBoxes();
                            return;
                        }

                        PrintBoxes();
                        Check();
                        if ((CheckMateW() == true || CheckMateB() == true) && Win == false)
                        {
                            MessageBox.Show("StaleMate");
                            Box.Controls.Clear(); return;
                        }
             
                        TurnChecker = true;
                        ChangeTurn();
                        ChangeTurnText();
                      
                        return;
                    }
                    else
                    {
                        PrintBoxes();
                        MessageBox.Show(" Wrong Move !! Choose Source Again");
                        TurnChecker = true;
                    }
                
              

            }
          
           
        }

        void ChangeTurnText()
        {
            
            if (TurnTeller.Text == "    Black's Turn  ") 
            {
                TurnTeller.BackColor = Color.Black;
                TurnTeller.ForeColor = Color.White;
                TurnTeller.Text = "    White's Turn  ";
            }
            else 
            {
                TurnTeller.BackColor = Color.White;
                TurnTeller.ForeColor = Color.Black;
                TurnTeller.Text = "    Black's Turn  ";
            }
        }
        void ChangeTurn()
        {
            if (PlayerTurn == MyColor.White)
                PlayerTurn = MyColor.Black;
            else
            {
                PlayerTurn = MyColor.White;
            }
        }
         private void Move()
        {
            ChessPieces Temp;
            Source.Piece.IsFirstTime = false;
            int DR = Destination.RowIndex;
            int DC = Destination.ColIndex;
            int SR = Source.RowIndex;
            int SC = Source.ColIndex;
            Piece[DR, DC] = Piece[SR, SC];
             Piece[SR,SC].IsFirstTime = false;
            Piece[SR, SC] = null;
            Temp = Destination.Piece;
            Destination.Piece = Source.Piece;
            Source.Piece = null; 
            ToDraw(Destination);
            Source.Image = null;
        }
         private void TempMove()
         {
             int DR = Destination.RowIndex;
             int DC = Destination.ColIndex;
             int SR = Source.RowIndex;
             int SC = Source.ColIndex;
             TempPiece[DR, DC] = Piece[SR, SC];
             TempPiece[SR, SC] = null;
      
         }
         private void CheckMateTempMove(int SR,int SC, int DR,int DC)
         {
             
             TempPiece[DR, DC] = Piece[SR, SC];
             TempPiece[SR, SC] = null;

         }
      
      
      
          void ToDraw(ChessCells Cell)
         {
             Cell.Image = Image.FromFile("..\\..\\Resources\\" + Cell.Piece.Name);
         }
        private void SourceSelction(object sender, EventArgs e)
        {
            Source = (ChessCells)sender; 
        }
        private void DestinationSelction(object sender, EventArgs e)
        {
            Destination = (ChessCells)sender;
        }
        
        void Init()
        {
            Start.BackColor = Color.Transparent;
            ChessGame.ActiveForm.BackgroundImage = null;
            ChessGame.ActiveForm.BackColor = Color.Black;
            TurnTeller.BackColor = Color.White;
            TurnTeller.ForeColor = Color.Black;
            TurnTeller.Text = "    Black's Turn  ";
            Start.Text = "";
            Box.Controls.Clear();
            for(int Ri=0; Ri<Dim; Ri++)
            {
                for(int Ci=0; Ci<Dim; Ci++)
                {
                    Positions(Ri, Ci);
                    CellColor = ((Ri + Ci) % 2 != 0) ? MyColor.Black : MyColor.White;
                    Cell[Ri, Ci] = new ChessCells(Ri, Ci, Piece[Ri, Ci], CellColor, Box.Width, Box.Height, Dim);
                    Box.Controls.Add(Cell[Ri, Ci]);
                    Cell[Ri, Ci].Click += new System.EventHandler(CellClicked);
                 
                }
            }
        }

        public void Highlight()
        {
            int Dim = 8;
            for (int ri = 0; ri < Dim; ri++)
            {
                for (int ci = 0; ci < Dim; ci++)
                {
                    if (Cell[Source.RowIndex, Source.ColIndex].Piece.IsMoveLegal(Source.RowIndex, Source.ColIndex, ri, ci, Piece) == true)
                    {

                        if (Cell[ri, ci].Piece == null )
                        {
                            Cell[ri, ci].BackColor = Color.LightGreen;
                        }
                        else if (Cell[ri, ci].Piece.Colors == Cell[Source.RowIndex, Source.ColIndex].Piece.Colors)
                        {

                        }
                        else
                        {
                            Cell[ri, ci].BackColor = Color.LightPink;
                        }
                    }
                }
            }
 }
        


        private void Start_Click(object sender, EventArgs e)
        {
            if(Click>0)
            {
                Removal();
                CellColor = MyColor.Black;
                PlayerTurn = MyColor.White;
                TurnChecker = true;
            }
            Init();
            Click++;
        }
        void Removal()
        {
            for(int ri=0; ri<Dim; ri++)
            {
                for(int ci=0; ci<Dim; ci++)
                {
                    Piece[ri, ci] = null;
                    Cell[ri, ci].Piece = Piece[ri, ci];
                    Cell[ri, ci].Image = null;
                }
            }
        }

        void Positions (int Ri, int Ci)
        {
            if (Ci == 0 || Ci == 7)
            {
                if (Ri == 0)
                {
                    Piece[Ri, Ci] = new PieceRook(MyColor.Black, "Black_Rook.png");
                }
                else if (Ri == 7)
                {
                   Piece[Ri, Ci] = new PieceRook(MyColor.White, "White_Rook.png");
                }
            }
            else if (Ci == 1 || Ci == 6)
            {
                if (Ri == 0)
                {
                    Piece[Ri, Ci] = new PieceKnight(MyColor.Black, "Black_Knight.png");
                }
                else if (Ri == 7)
                {
                  Piece[Ri, Ci] = new PieceKnight(MyColor.White, "White_Knight.png");
                }
            }
            else if (Ci == 2 || Ci == 5)
            {
                if (Ri == 0)
                {
                   Piece[Ri, Ci] = new PieceBishop(MyColor.Black, "Black_Bishop.png");
                }
                else if (Ri == 7)
                {
                    Piece[Ri, Ci] = new PieceBishop(MyColor.White, "White_Bishop.png");
                }
            }
            else if (Ci == 3)
            {
                if (Ri == 0)
                {
                    Piece[Ri, Ci] = new Queen(MyColor.Black, "Black_Queen.png");
                }
                else if (Ri == 7)
                {
                    Piece[Ri, Ci] = new Queen(MyColor.White, "White_Queen.png");
                }
            }
            else if (Ci == 4)
            {
                if (Ri == 0)
                {
                    Piece[Ri, Ci] = new King(MyColor.Black, "Black_King.png");
                }
                else if (Ri == 7)
                {
                   Piece[Ri, Ci] = new King(MyColor.White, "White_King.png");
                }
            }
            if (Ri == 1)
            {
               Piece[Ri, Ci] = new PiecePawn(MyColor.Black, "Black_Pawn.png");
            }
           else if (Ri == 6)
              Piece[Ri, Ci] = new PiecePawn(MyColor.White, "White_Pawn.png");
        }

        void PrintBoxes()
        {
            for (int ri = 0; ri < Dim; ri++)
            {
                for (int ci = 0; ci < Dim; ci++)
                {
                    CellColor = ((ri + ci) % 2 != 0) ? MyColor.Black : MyColor.White;
                    if (CellColor == MyColor.Black)
                    {
                        Cell[ri, ci].BackColor = Color.DarkGray;
                    }
                    else
                    {
                        Cell[ri, ci].BackColor = Color.White;
                    }
                }
            }
        }

        void PawnPromote()
        {
            for (int ri = 0; ri < Dim; ri++ )
            {
                for(int ci=0; ci<Dim; ci++)
                {
                    if (Cell[ri, ci].Piece != null)
                    {


                        if (Cell[ri, ci].Piece.AmIPawn() && ri == 7 && Cell[ri, ci].Piece.Colors == MyColor.Black)
                        {
                                PawnR = ri;
                                PawnC = ci;
                                PawnPromotion.Show();
                        }
                        else if(Cell[ri, ci].Piece.AmIPawn() && ri == 0 && Cell[ri, ci].Piece.Colors == MyColor.White)
                        {
                            PawnR = ri;
                            PawnC = ci;
                            PawnPromotion.Show();
                        }
                    }
                }
            }
                
        }

        private void None_CheckedChanged(object sender, EventArgs e)
        {
            PawnPromotion.Hide();
        }

        private void Rook_Click(object sender, EventArgs e)
        {
            if (PawnR == 7)
            {
                Piece[PawnR, PawnC] = new PieceRook(MyColor.Black, "Black_Rook.png");
            }
            else
            {
                Piece[PawnR, PawnC] = new PieceRook(MyColor.White, "White_Rook.png");
            }
            Cell[PawnR, PawnC].Piece = Piece[PawnR, PawnC];
            PawnPromotion.Hide();
            ToDraw(Cell[PawnR, PawnC]);
        }

        private void Bishop_Click(object sender, EventArgs e)
        {
            if (PawnR == 7)
            {
                Piece[PawnR, PawnC] = new PieceBishop(MyColor.Black, "Black_Bishop.png");
            }
            else
            {
                Piece[PawnR, PawnC] = new PieceBishop(MyColor.White, "White_Bishop.png");
            }
            Cell[PawnR, PawnC].Piece = Piece[PawnR, PawnC];
            PawnPromotion.Hide();
            ToDraw(Cell[PawnR, PawnC]);
        }

        private void Knight_Click(object sender, EventArgs e)
        {
            if (PawnR == 7)
            {
                Piece[PawnR, PawnC] = new PieceKnight(MyColor.Black, "Black_Knight.png");
            }
            else
            {
                Piece[PawnR, PawnC] = new PieceKnight(MyColor.White, "White_Knight.png");
            }
            Cell[PawnR, PawnC].Piece = Piece[PawnR, PawnC];
            PawnPromotion.Hide();
            ToDraw(Cell[PawnR, PawnC]);
        }
        bool CheckMateW()
        {
            for (int ri = 0; ri < Dim; ri++)
            {
                for (int ci = 0; ci < Dim; ci++)
                {
                    for (int pi = 0; pi < Dim; pi++)
                    {
                        for (int qi = 0; qi < Dim; qi++)
                        {
                            CopyPieces();
                            if (TempPiece[ri, ci] != null)
                            {
                                if (TempPiece[ri, ci].IsMoveLegal(ri, ci, pi, qi, TempPiece) && TempPiece[ri, ci].Colors == MyColor.White)
                                {
                                    if (TempPiece[pi, qi] != null)
                                    {
                                        if (TempPiece[ri, ci].Colors != TempPiece[pi, qi].Colors)
                                        {
                                            if (CheckMateSelfCheck(ri, ci, pi, qi) == false) return false;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckMateSelfCheck(ri, ci, pi, qi) == false) return false;
                                    }


                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void Queen_Click(object sender, EventArgs e)
        {
            if (PawnR == 7)
            {
                Piece[PawnR, PawnC] = new Queen(MyColor.Black, "Black_Queen.png");
            }
            else
            {
                Piece[PawnR, PawnC] = new Queen(MyColor.White, "White_Queen.png");
            }
            Cell[PawnR, PawnC].Piece = Piece[PawnR, PawnC];
            PawnPromotion.Hide();
            ToDraw(Cell[PawnR, PawnC]);
        }
  
      
    }
}

