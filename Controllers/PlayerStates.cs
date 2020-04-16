using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public enum NeutralStates{
        grounded,
        walledLeft,
        walledRight,
        hiding,
        midair
    }
    public enum MovementStates
    {
        walking,
        idle,
        sprinting,
        jumping,
        sneakMoving,
        sneakIdle
    }
    public enum AttackStates
    {
        groundAttack,
        airAttack,
        sneakAttack,
        hiddenAttack,
        ability1,
        neutral
    }
    public NeutralStates neutralStates;
    public MovementStates movementStates;
    public AttackStates attackStates;
}
