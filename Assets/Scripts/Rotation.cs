using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float ObjRotate;
    void Update()
    {
        transform.Rotate(0, ObjRotate, 0);
    }

}
