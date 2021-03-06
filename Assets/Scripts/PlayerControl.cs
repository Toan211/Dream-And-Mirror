﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControl : MonoBehaviour
{
    public float m_Speed = 5f;
    PlayerMotor m_PlayerMotor;

    private void Awake()
    {
        m_PlayerMotor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            FlagsManager.setFlag(0, true);
        }
        else
        {
            FlagsManager.setFlag(0, false);
        }

        m_PlayerMotor.m_Velociy = getCurrentVelocity();
    }

    Vector2 getCurrentVelocity()
    {
        float horizontalMov = Input.GetAxisRaw("Horizontal") * m_Speed;
        float verticalMov = Input.GetAxisRaw("Vertical") * m_Speed;
        Vector2 velo = new Vector2(horizontalMov, verticalMov);

        return velo;
    }
}
