using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public override void Tick()
    {
        if (!character.CheckFloor()) character.SetState(new FallingState(character));

        if (Input.GetAxis("Horizontal") > .1f || Input.GetAxis("Horizontal") < -.1f) character.SetState(new WalkingState(character));

        if (Input.GetButtonDown("Jump")) character.SetState(new JumpingState(character));
    }

    public IdleState(Character character) : base(character)
    {

    }
}
