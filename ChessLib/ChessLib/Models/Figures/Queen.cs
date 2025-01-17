﻿using ChessLib.Models.Enums;
using ChessLib.Models.Figures.FigureMovements;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents queen figure
    /// </summary>
    public sealed class Queen : ChessBase
    {
        /// <summary>
        /// Copy constructor to create queen from pawn
        /// </summary>
        /// <param name="otherChess">Pawn from which copy info</param>
        public Queen(Pawn otherChess) : base(otherChess)
        {
            _movement = new AllDirectionLineStepFinder();
        }

        /// <summary>
        /// Queen constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public Queen(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _movement = new AllDirectionLineStepFinder();
        }

        protected override void InitializeMoveDirections()
        {
            _moveDirections = new Vector2<int>[]
            {
                 new Vector2<int>(-1, 1),
                 new Vector2<int>(1, 1),
                 new Vector2<int>(1, -1),
                 new Vector2<int>(-1, -1),
                 new Vector2<int>(0, 1),
                 new Vector2<int>(0, -1),
                 new Vector2<int>(1, 0),
                 new Vector2<int>(-1, 0)
            };
        }
    }
}