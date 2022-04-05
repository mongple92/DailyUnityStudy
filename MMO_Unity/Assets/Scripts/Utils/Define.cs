using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum UIEvent
    {
        Click,
        Drag,

    }

    public enum MouseEvent
    {
        Press   = 0,
        Click,
    }

    public enum CameraMode
    {
        QuarterView = 0
    }
}
