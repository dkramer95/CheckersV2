using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers.Model;
using Checkers.Controller;
using System.Collections.Generic;

namespace Checkers.Tests
{
    [TestClass]
    public class PieceControllerTests
    {
        [TestMethod]
        public void GetPiecesThatCanMoveTest()
        {
            HumanPlayer p = new HumanPlayer();
            Piece piece1 = new Piece();
            Piece piece2 = new Piece();
            p.Pieces.Add(piece1);
            p.Pieces.Add(piece2);

            PieceController con = new PieceController();
            con.addMove(new Move(p.Pieces[1], new Position('A', 2), new Position('B', 2), new List<Piece>()));
            con.addMove(new Move(p.Pieces[0], new Position('A', 2), new Position('B', 2), new List<Piece> { new Piece() }));
            con.addMove(new Move(p.Pieces[0], new Position('A', 2), new Position('B', 2), new List<Piece>()));

            List<Piece> piecesThatCanMove = con.GetPiecesThatCanMove(p);
            Assert.IsTrue(piecesThatCanMove.Contains(p.Pieces[0]));
            Assert.IsTrue(piecesThatCanMove.Contains(p.Pieces[1]));
        }

        [TestMethod]
        public void GetPiecesThatCanJumpTest()
        {
            HumanPlayer p = new HumanPlayer();
            Piece piece1 = new Piece();
            piece1.Color = Color.Red;
            Piece piece2 = new Piece();
            piece2.Color = Color.Black;
            p.Pieces.Add(piece1);
            p.Pieces.Add(piece2);

            PieceController con = new PieceController();
            con.addMove(new Move(p.Pieces[1], new Position('A', 2), new Position('B', 2), new List<Piece>()));
            con.addMove(new Move(p.Pieces[0], new Position('A', 2), new Position('B', 2), new List<Piece> { new Piece() }));
            con.addMove(new Move(p.Pieces[0], new Position('A', 2), new Position('B', 2), new List<Piece>()));

            List<Piece> piecesThatCanJump = con.GetPiecesThatCanJump(p);
            Assert.IsTrue(piecesThatCanJump.Contains(p.Pieces[0]));
            Assert.IsFalse(piecesThatCanJump.Contains(p.Pieces[1]));
        }

        [TestMethod]
        public void GetPieceMovementOptionsTest()
        {
            List<Piece> lightPieces = new List<Piece>
            {
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red },
                new Piece { Color = Color.Red }
            };

            List<Piece> darkPieces = new List<Piece>
            {
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black },
                new Piece { Color = Color.Black }
            };

            HumanPlayer p1 = new HumanPlayer();
            p1.Pieces = darkPieces;
            HumanPlayer p2 = new HumanPlayer();
            p2.Pieces = lightPieces;

            Board.Reset();
            Board.Populate(p1.Pieces, p2.Pieces);
            PieceController con = new PieceController();
            con.UpdateMoves(p1);
            Assert.IsTrue(con.GetPiecesThatCanMove(p1).Count == 4);
            Assert.IsTrue(con.GetPiecesThatCanJump(p1).Count == 0);
        }
    }
}
