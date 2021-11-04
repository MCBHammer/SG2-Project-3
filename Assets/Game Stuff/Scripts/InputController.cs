using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public event Action PressedLeave = delegate { };
    public event Action PressedAttack = delegate { };
    public event Action PressedCharge = delegate { };
    public event Action PressedShield = delegate { };

    private void Update()
    {
        DetectLeave();
        DetectAttack();
        DetectCharge();
        DetectShield();
    }

    private void DetectLeave()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressedLeave?.Invoke();
        }
    }

    private void DetectAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PressedAttack?.Invoke();
        }
    }

    private void DetectCharge()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PressedCharge?.Invoke();
        }
    }

    private void DetectShield()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressedShield?.Invoke();
        }
    }
}
