﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDrop : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {

        }
    }
}
