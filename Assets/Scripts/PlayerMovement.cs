using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [HideInInspector]
    public bool isFacingRight = true;

    public void TurnLeft()
    {
        if (isFacingRight)
        {
            FlipPlayer();
            isFacingRight = !isFacingRight;
        }
    }

    public void TurnRight()
    {
        if (!isFacingRight)
        {
            FlipPlayer();
            isFacingRight = !isFacingRight;
        }        
    }

    private void FlipPlayer()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
