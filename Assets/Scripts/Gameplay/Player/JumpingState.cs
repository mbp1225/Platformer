using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State
{

    public override void Tick()
    {
        character.Jump();

        if (Input.GetAxis("Horizontal") > .1f)
        {
            character.Move(1);
        }
        else if ((Input.GetAxis("Horizontal") < -.1f))
        {
            character.Move(-1);
        }

        if (character.currentVerticalSpeed > -.1f && character.currentVerticalSpeed < .1f) character.SetState(new FallingState(character));
    }

    public JumpingState(Character character) : base(character)
    {

    }

    public override void OnStateEnter()
    {
        character.currentVerticalSpeed = character.jumpSpeed;
    }
}
