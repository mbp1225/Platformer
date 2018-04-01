using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : State
{

    public override void Tick()
    {
        if (Input.GetAxis("Horizontal") > .1f)
        {
            character.Move(1);
        }
        else if ((Input.GetAxis("Horizontal") < -.1f))
        {
            character.Move(-1);
        }
        else character.SetState(new IdleState(character));

        if (Input.GetButtonDown("Jump")) character.SetState(new JumpingState(character));

        if (!character.CheckFloor()) character.SetState(new FallingState(character));
    }

    public WalkingState(Character character) : base(character)
    {

    }
}
