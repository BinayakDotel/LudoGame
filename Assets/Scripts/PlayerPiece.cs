using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    //public static PlayerPiece _instance;
    public enum PlayerPieceState
    {
        moving,
        idle,
        inside_home,
        completed,
        pending,
    }
    public enum PlayerPieceTurn
    {
        green,
        yellow,
        blue,
        red
    }
    public PlayerPieceState pieceState = PlayerPieceState.inside_home;
    public static PlayerPieceTurn pieceTurn;
    public string id;
    public int current_position, steps_moved;

    public PathInfo pathInfo;

    private void Awake()
    {
        pathInfo = FindObjectOfType<PathInfo>();

        pieceTurn = PlayerPieceTurn.green;
    }
    private void OnMouseDown()
    {
        if (this.pieceState == PlayerPieceState.pending)
        {
            this.pieceState = PlayerPieceState.moving;
            StartCoroutine(this.movePlayerCommonPath(DiceManager.Instance.face_value));
        }
        else if (this.pieceState == PlayerPieceState.inside_home)
        {
            StartCoroutine(this.getOutsideHome());
        }
    }
    public IEnumerator movePlayerCommonPath(int steps)
    {
        for (int i = this.current_position; i < this.current_position + steps; i++)
        {
            this.transform.position = pathInfo.commonPath[i].transform.position;
            ++this.steps_moved;

            yield return new WaitForSeconds(0.2f);
        }
        //this.current_position += temp;
        print("made idle");
        this.pieceState = PlayerPieceState.idle;
        GameEvents.instance.UpdateUI();
        this.current_position = this.current_position + steps;
        DiceManager.Instance.obj_pending.Remove(this);

        for (int i = 0; i < DiceManager.Instance.obj_pending.Count; i++)
        {
            DiceManager.Instance.obj_pending[i].pieceState = PlayerPieceState.inside_home;
        }
        DiceManager.Instance.obj_pending.Clear();
    }
    public IEnumerator getOutsideHome()
    {
        this.transform.position = pathInfo.commonPath[this.current_position].transform.position;
        yield return new WaitForSeconds(0.0f);
    }
}
