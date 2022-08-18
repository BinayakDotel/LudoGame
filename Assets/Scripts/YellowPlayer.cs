using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : PlayerPiece
{
    private void Start()
    {
        this.current_position = 14;
        GameEvents.instance.onDiceRolled += DetermineMovable;
    }
    public void DetermineMovable()
    {
        if (PlayerPiece.pieceTurn == PlayerPieceTurn.yellow)
        {
            DiceManager dice = DiceManager.Instance;

            if (dice.face_value == 1)
            {
                this.getOutsideHome();
            }
            if (this.steps_moved <= this.pathInfo.commonPath.Count && this.pieceState != PlayerPieceState.inside_home)
            {
                print("TRIGGRED Yellow MOVEMENT");

                this.pieceState = PlayerPieceState.pending;
            }
            /*for (int i = 0; i < dice.yellowPlayer.Count; i++)
            {
                if (dice.face_value == 1 && this.players_inside > 0)
                {
                    dice.yellowPlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                }
                else
                {
                    if (dice.yellowPlayer[i].pieceState == PlayerPiece.PlayerPieceState.idle)
                    {
                        dice.yellowPlayer[i].pieceState = PlayerPiece.PlayerPieceState.pending;
                    }

                }
                dice.obj_pending.Add(dice.yellowPlayer[i]);
            }*/
            print("MOVE YELLOW");
        }
    }
}
