using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class InputHandler: MonoBehaviour
    {
        [SerializeField] private GameObject actor;
        private Animator anim;
        private Command keyQ, keyW, keyE, keyR, keyT, upArrow;
        private List<Command> oldCommands = new List<Command>();

        private Coroutine replayCoroutine;
        private bool shouldStartReplay;
        private bool isReplaying;
        
        private void Start()
        {
            keyQ = new PerformJump();
            keyW = new DoNothing();
            keyE = new DoNothing();
            keyR = new PerformKick();
            keyT = new PerformPanch();
            upArrow = new MoveForward();
            anim = actor.GetComponent<Animator>();
            Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
        }

        private void Update()
        {
            if(!isReplaying) HandleInput();
            StartReplay();
        }

        private void StartReplay()
        {
            if (shouldStartReplay && oldCommands.Count > 0)
            {
                shouldStartReplay = false;
                if (replayCoroutine != null)
                {
                    StopCoroutine(replayCoroutine);
                }

                replayCoroutine = StartCoroutine(ReplayComands());
            }
        }

        private IEnumerator ReplayComands()
        {
            isReplaying = true;

            for (int i = 0; i < oldCommands.Count; i++)
            {
                oldCommands[i].Execute(anim);
                yield return new WaitForSeconds(1f);
            }

            isReplaying = false;
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                keyQ.Execute(anim);
                oldCommands.Add(keyQ);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                keyW.Execute(anim);
                oldCommands.Add(keyW);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                keyE.Execute(anim);
                oldCommands.Add(keyE);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                keyR.Execute(anim);
                oldCommands.Add(keyR);
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                keyT.Execute(anim);
                oldCommands.Add(keyT);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                upArrow.Execute(anim);
                oldCommands.Add(upArrow);
            }

            if (Input.GetKeyDown(KeyCode.Space))
                shouldStartReplay = true;
            
            if (Input.GetKeyDown(KeyCode.Z))
                UndoLastCommnad();
        }

        void UndoLastCommnad()
        {
            if (oldCommands.Count > 0)
            {
                Command c = oldCommands[oldCommands.Count - 1];
                c.Execute(anim);
                oldCommands.RemoveAt(oldCommands.Count - 1);
            }
        }
    }
}