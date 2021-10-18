﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class Queen : ChessBase
    {
        public Queen(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            Vector2[] directions = new Vector2[]
            {
                 new Vector2(-1, 1),
                 new Vector2(1, 1),
                 new Vector2(1, -1),
                 new Vector2(-1, -1),
                 new Vector2(0, 1),
                 new Vector2(0, -1),
                 new Vector2(1, 0),
                 new Vector2(-1, 0)
            };

            List<ChessPosition> nextSteps = new List<ChessPosition>();

            for (int i = 0; i < directions.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);
                while (nextPosition.Vertical <= 8 && nextPosition.Vertical >= 1
&& nextPosition.Horizontal >= 1 && nextPosition.Horizontal <= 8)
                {
                    try
                    {
                        nextPosition.Horizontal += (int)directions[i].X;
                        nextPosition.Vertical += (int)directions[i].Y;
                    }
                    catch (ArgumentException ex)
                    {
                        break;
                    }

                    ChessBase chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

                    if (chess is null)
                        nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                    else if (chess.ChessColor != this.ChessColor)
                    {
                        nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                        break;
                    }
                    else
                        break;
                }
            }

            return nextSteps;
        }
    }
}