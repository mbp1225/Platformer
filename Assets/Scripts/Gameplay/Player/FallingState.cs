using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State
{

    public override void Tick()
    {
        character.Fall();

        if (Input.GetAxis("Horizontal") > .1f)
        {
            character.Move(1);
        }
        else if ((Input.GetAxis("Horizontal") < -.1f))
        {
            character.Move(-1);
        }

        if (character.CheckFloor())
        {
            character.Fall(.1f);
            character.SetState(new IdleState(character));
        }
    }

    public override void OnStateEnter()
    {
        character.currentVerticalSpeed = character.fallSpeed;
    }

    public FallingState(Character character) : base(character)
    {

    }
}
