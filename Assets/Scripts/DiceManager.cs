using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    private static DiceManager _instance;

    public static DiceManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public Rigidbody Dice;
    public int face_value;
    public enum DiceState
    {
        rolling,
        idle
    }

    public DiceState dice_state = DiceState.idle;
    public bool can_move;
    public bool next_turn;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        _instance = this;
        next_turn = true;
    }

    private void OnMouseUp()
    {
        dice_state = DiceState.rolling;

        StartCoroutine(SetDiceFaceValue());
    }
    public List<PlayerPiece> obj_pending = new List<PlayerPiece>();
    IEnumerator SetDiceFaceValue()
    {
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = new Vector3(0, 1, 0);
        transform.rotation = Quaternion.identity;

        Dice.AddForce(transform.up * 500);
        Dice.AddTorque(dirX, dirY, dirZ);

        yield return new WaitUntil(() => dice_state == DiceState.idle);
        //yield return new WaitForSeconds(0.1f);
        DecideTurn(face_value);
        GameEvents.instance.DiceRolled();
    }

    public void DecideTurn(int value)
    {
        if (next_turn)
        {
            if (PlayerPiece.pieceTurn == PlayerPiece.PlayerPieceTurn.green)
            {
                UIManager.instance.turn_text = "yellow";
                PlayerPiece.pieceTurn = PlayerPiece.PlayerPieceTurn.yellow;
            }
            else if (PlayerPiece.pieceTurn == PlayerPiece.PlayerPieceTurn.yellow)
            {
                UIManager.instance.turn_text = "blue";

                PlayerPiece.pieceTurn = PlayerPiece.PlayerPieceTurn.blue;
            }
            else if (PlayerPiece.pieceTurn == PlayerPiece.PlayerPieceTurn.blue)
            {
                UIManager.instance.turn_text = "red";

                PlayerPiece.pieceTurn = PlayerPiece.PlayerPieceTurn.red;
            }
            else if (PlayerPiece.pieceTurn == PlayerPiece.PlayerPieceTurn.red)
            {
                UIManager.instance.turn_text = "green";

                PlayerPiece.pieceTurn = PlayerPiece.PlayerPieceTurn.green;
            }
            print("NEXT TURN");
        }
    }

}
