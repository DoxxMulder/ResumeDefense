using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
    }
}
