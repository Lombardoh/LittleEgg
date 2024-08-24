using UnityEngine;

public class AnimatorManagerBase : MonoBehaviour
{
    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimatorValues(string key, bool states)
    {
        animator.SetBool(key, states);
    }
}
