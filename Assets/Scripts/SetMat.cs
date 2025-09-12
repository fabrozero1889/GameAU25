using UnityEngine;

public class SetMat : MonoBehaviour {
    [SerializeField] Material mat;
    void Awake() {
        GetComponent<Renderer>().sharedMaterial = mat; // o .materials[i] si tenés varios
    }
}
