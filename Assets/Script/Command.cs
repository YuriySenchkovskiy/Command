using System;
using UnityEngine;

namespace Script
{
    public abstract class Command
    {
        public abstract void Execute(Animator anim);
    }

    public class PerformJump : Command
    {
        public override void Execute(Animator anim)
        {
            anim.SetTrigger("isJumping");
        }
    }
    
    public class PerformKick : Command
    {
        public override void Execute(Animator anim)
        {
            anim.SetTrigger("isKicking");
        }
    }
    
    public class PerformPanch : Command
    {
        public override void Execute(Animator anim)
        {
            anim.SetTrigger("isPunching");
        }
    }
    
    public class DoNothing : Command
    {
        public override void Execute(Animator anim)
        {
            
        }
    }
    
    public class MoveForward : Command
    {
        public override void Execute(Animator anim)
        {
            anim.SetTrigger("isWalking");
        }
    }
}