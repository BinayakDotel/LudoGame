using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : PlayerPiece
{
    private void Start()
    {
        this.current_position = 28;
        GameEvents.instance.onDiceRolled += DetermineMovable;
    }

    public void DetermineMovable()
    {
        if (PlayerPiece.pieceTurn == PlayerPieceTurn.blue)
        {
            DiceManager dice = DiceManager.Instance;

            if (dice.face_value == 1)
            {
                this.getOutsideHome();
            }
            if (this.steps_moved <= this.pathInfo.commonPath.Count && this.pieceState != PlayerPieceState.inside_home)
            {
                print("TRIGGRED BLUE MOVEMENT");

                this.pieceState = PlayerPieceState.pending;
            }
            /*for (int i = 0; i < dice.bluePlayer.Count; i++)
            {
                if (dice.face_value == 1 && this.players_inside > 0)
                {
                    dice.bluePlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                }
                else
                {
                    if (dice.bluePlayer[i].pieceState == PlayerPiece.PlayerPieceState.idle)
                    {
                        dice.bluePlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                    }

                }
                dice.obj_pending.Add(dice.bluePlayer[i]);
            }*/
            print("MOVE BLUE");
        }
    }
}
