using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : PlayerPiece
{
    private void Start()
    {
        this.current_position = 1;
        GameEvents.instance.onDiceRolled += DetermineMovable;
    }

    public void DetermineMovable()
    {
        if (PlayerPiece.pieceTurn == PlayerPieceTurn.green)
        {
            DiceManager dice = DiceManager.Instance;

            if (dice.face_value == 1)
            {
                this.getOutsideHome();
            }
            if (this.steps_moved <= this.pathInfo.commonPath.Count && this.pieceState != PlayerPieceState.inside_home)
            {
                print("TRIGGRED GREEN MOVEMENT");

                this.pieceState = PlayerPieceState.pending;
            }

            /*for (int i = 0; i < dice.greenPlayer.Count; i++)
            {
                if (dice.face_value == 1 && this.players_inside > 0)
                {
                    dice.greenPlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                }
                else
                {
                    if (dice.greenPlayer[i].pieceState == PlayerPiece.PlayerPieceState.idle)
                    {
                        dice.greenPlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                    }

                }
                dice.obj_pending.Add(dice.greenPlayer[i]);
            }*/
        }
    }
}
