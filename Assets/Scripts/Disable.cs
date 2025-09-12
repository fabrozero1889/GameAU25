using UnityEngine;

public class PortalAnimHelper : MonoBehaviour
{
    [SerializeField] Animator anim;
    public void DisableAnimator() { if (!anim) anim = GetComponent<Animator>(); if (anim) anim.enabled = false; }
}
