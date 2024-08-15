using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode dash = KeyCode.LeftShift;
    public Vector2 InputVector => inputVector;
    private Vector2 inputVector;

    public bool IsDash { get=>isDash; private set=>isDash=value; }
    private bool isDash;

    private float xInput;
    private float yInput;

    //“ü—Í‚É‘Î‚µ‚Ä‚Ìˆ—
    public void HandleInput()
    {
        //debug—p
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);

        xInput = 0;
        yInput = 0;

        /*
        if (Input.GetKey(forward))
        {
            zInput++;
        }

        if (Input.GetKey(back))
        {
            zInput--;
        }
        */
        if (Input.GetKey(left))
        {
            xInput--;
        }

        if (Input.GetKey(right))
        {
            xInput++;
        }

        isDash = Input.GetKey(dash);

        inputVector = new Vector2(xInput, yInput);

    }

    public void ResetInput()
    {
        inputVector = new Vector2(0, 0);

    }
    private void Update()
    {
        HandleInput();
    }
}
