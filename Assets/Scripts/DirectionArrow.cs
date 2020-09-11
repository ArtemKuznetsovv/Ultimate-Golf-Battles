using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private Renderer[] childs;

    public void Show(bool toShow)
    {
        foreach (var child in childs)
            child.enabled = toShow;
    }
}
