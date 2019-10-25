using PacEngine.utils;
using UnityEngine;

public abstract class AbstractCharacterView : MonoBehaviour
{
    public void Move(Vector position)
    {
        transform.localPosition = new Vector3(position.y, position.x, 0);
    }
}
