using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineDiceFace : MonoBehaviour
{
    private void OnTriggerStay(Collider face)
    {
        if (DiceManager.Instance.Dice.velocity.x == 0f && DiceManager.Instance.Dice.velocity.y == 0f && DiceManager.Instance.Dice.velocity.z == 0f && DiceManager.Instance.dice_state == DiceManager.DiceState.rolling)
        //if (DiceManager.Instance.dice_state == DiceManager.DiceState.rolling)
        {
            int result = 0;
            if (face.name == "s1")
            {
                print("6");
                result = 6;
                DiceManager.Instance.next_turn = false;
            }
            else if (face.name == "s2")
            {
                print("5");
                result = 5;
                DiceManager.Instance.next_turn = true;
            }
            else if (face.name == "s3")
            {
                print("4");
                result = 4;
                DiceManager.Instance.next_turn = true;
            }
            else if (face.name == "s4")
            {
                print("3");
                result = 3;
                DiceManager.Instance.next_turn = true;
            }
            else if (face.name == "s5")
            {
                print("2");
                result = 2;
                DiceManager.Instance.next_turn = true;
            }
            else if (face.name == "s6")
            {
                print("1");
                result = 1;
                DiceManager.Instance.next_turn = false;
            }

            DiceManager.Instance.dice_state = DiceManager.DiceState.idle;
            DiceManager.Instance.face_value = result;
        }
    }
}
