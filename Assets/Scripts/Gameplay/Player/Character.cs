using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private State currentState;

    [Header("Movement Variables")]
    [SerializeField] float movementSpeed;
    [Space(10)]
    public float jumpSpeed;
    public float currentVerticalSpeed;
    [SerializeField] float verticalSpeedFallof;
    public float fallSpeed;

	private void Start ()
    {
        SetState(new IdleState(this));

        Application.targetFrameRate = 60;
    }
	
	private void Update ()
    {
        currentState.Tick();
	}

    public void SetState(State state)
    {
        if (currentState != null) currentState.OnStateExit();

        currentState = state;
        print(state.ToString());

        if (currentState != null) currentState.OnStateEnter();
    }

    //Movement Methods
    public void Move(int dir)
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
    }

    //Jump Methods
    public bool CheckFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3.left * .25f), Vector2.down, .25f);
        Debug.DrawLine(transform.position + (Vector3.left * .25f), transform.position + (Vector3.left * .25f) + Vector3.down * .25f);

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + (Vector3.right * .25f), Vector2.down, .25f);
        Debug.DrawLine(transform.position + (Vector3.right * .25f), transform.position + (Vector3.right * .25f) + Vector3.down * .25f);

        if (hit && hit.transform.tag == "Floor" || hit2 && hit2.transform.tag == "Floor") return true;
        else if (hit && hit.transform.tag == "Enemy")
        {
            SetState(new JumpingState(this));
            hit.transform.gameObject.GetComponent<Enemy>().Die();
            return false;
        }
        else if (hit2 && hit2.transform.tag == "Enemy")
        {
            SetState(new JumpingState(this));
            hit2.transform.gameObject.GetComponent<Enemy>().Die();
            return false;
        }
        else return false;
    }

    public void Fall()
    {
        transform.position += Vector3.down * currentVerticalSpeed * Time.deltaTime;
        currentVerticalSpeed += verticalSpeedFallof;
    }

    public void Fall(float dist)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        transform.position += Vector3.down * hit.distance;
    }

    public void Jump()
    {
        transform.position += Vector3.up * currentVerticalSpeed * Time.deltaTime;
        currentVerticalSpeed -= verticalSpeedFallof;
    }

    public void Print(string str)
    {
        print(str);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
