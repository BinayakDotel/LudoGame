using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : PlayerPiece
{
    private void Start()
    {
        this.current_position = 42;
        GameEvents.instance.onDiceRolled += DetermineMovable;
    }

    public void DetermineMovable()
    {
        if (PlayerPiece.pieceTurn == PlayerPieceTurn.red)
        {
            DiceManager dice = DiceManager.Instance;

            if (dice.face_value == 1)
            {
                this.getOutsideHome();
            }
            if (this.steps_moved <= this.pathInfo.commonPath.Count && this.pieceState != PlayerPieceState.inside_home)
            {
                print("TRIGGRED RED MOVEMENT");

                this.pieceState = PlayerPieceState.pending;
            }
            /*for (int i = 0; i < dice.redPlayer.Count; i++)
            {
                if (dice.face_value == 1 && this.players_inside > 0)
                {
                    dice.redPlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                }
                else
                {
                    if (dice.redPlayer[i].pieceState == PlayerPiece.PlayerPieceState.idle)
                    {
                        dice.redPlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                    }

                }
                dice.obj_pending.Add(dice.redPlayer[i]);
            }*/
            print("MOVE RED");
        }
    }
}
