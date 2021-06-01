using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int _breakableBlocks;

    public void CountBreakableBlocks()
    {
        _breakableBlocks++;
    }
}
