using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    
        
    public void FinishJump()
    {
        Player.Instance.Animator.SetTrigger("JumpEnd");
    }
}
