using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool _canMove = true;
    private Vector2 _startSwaip = Vector2.zero;

    public static event Action<Vector3> OnMoveTo;

    private void OnEnable()
    {
        Move.OnCanMove += CanMove;
    }
    private void OnDisable()
    {
        Move.OnCanMove -= CanMove;
    }

    void Update()
    {
        if (_canMove)
        {
            if (Input.anyKeyDown)
            {
                KeyCode key = GetKeyPressed();
                switch (key)
                {
                    case KeyCode.W:
                        OnMoveTo?.Invoke(Vector3.up);
                        break;
                    case KeyCode.D:
                        OnMoveTo?.Invoke(Vector3.right);
                        break;
                    case KeyCode.S:
                        OnMoveTo?.Invoke(Vector3.down);
                        break;
                    case KeyCode.A:
                        OnMoveTo?.Invoke(Vector3.left);
                        break;
                }
            }

        }
        Swaips();
    }
    private KeyCode GetKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.W)) return KeyCode.W;
        if (Input.GetKeyDown(KeyCode.A)) return KeyCode.A;
        if (Input.GetKeyDown(KeyCode.S)) return KeyCode.S;
        if (Input.GetKeyDown(KeyCode.D)) return KeyCode.D;
        return KeyCode.None;
    }
    private void CanMove(bool can)
    {
        _canMove = can;
    }
    // ðåàë³çàö³ÿ ñâàéï³â
    private void Swaips()
    {
        if (Input.touchCount == 0||!_canMove)
            return;

  

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startSwaip = Input.GetTouch(0).position;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 end = Input.GetTouch(0).position;
            Vector2 length=end - _startSwaip;
            if (Math.Abs(length.x) > Constants.SWIPE_MIN_LENGTH && Math.Abs(length.y) > Constants.SWIPE_MIN_LENGTH)
                return;
            if (Math.Abs(length.x) > Constants.SWIPE_MIN_LENGTH)
            {
                if (length.x > 0)
                {
                    OnMoveTo?.Invoke(Vector3.right);
                    return;
                }
                else
                {
                    OnMoveTo?.Invoke(Vector3.left);
                    return;
                }
            }
            if (Math.Abs(length.y) > Constants.SWIPE_MIN_LENGTH)
            {
                if (length.y > 0)
                {
                    OnMoveTo?.Invoke(Vector3.up);
                    return;
                }
                else
                {
                    OnMoveTo?.Invoke(Vector3.down);
                    return;
                }
            }




        }
    }
}
