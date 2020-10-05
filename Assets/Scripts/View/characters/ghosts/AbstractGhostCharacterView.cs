using System;
using System.Collections;
using PacEngine.characters;
using PacEngine.characters.ghosts;
using PacEngine.utils;
using UnityEngine;

public abstract class AbstractGhostCharacterView : AbstractCharacterView
{
    private const string ANIMATOR_FRIGHTENED = "Frightened";
    private const string ANIMATOR_ALMOST_DONE_FRIGHTENED = "AlmostDoneFrightened";
    private const string ANIMATOR_EATEN = "Eaten";

    private AbstractGhostCharacter EngineGhostCharacter => (AbstractGhostCharacter)EngineCharacter;

    public Transform target;

    public override void LinkEngineCharacter(AbstractCharacter engineCharacter)
    {
        base.LinkEngineCharacter(engineCharacter);

        EngineGhostCharacter.OnChangeState += ChangeState;
    }

    private void ChangeState(AbstractGhostCharacter.GhostState state)
    {
        positionOffset = Vector2.zero;
        animator.SetBool(ANIMATOR_ALMOST_DONE_FRIGHTENED, false);

        switch (state)
        {
            case AbstractGhostCharacter.GhostState.FRIGHTENED:
                animator.SetTrigger(ANIMATOR_FRIGHTENED);
                StartCoroutine(WaitAndCall(EngineGhostCharacter.TimeInScatterState * 0.6f, () =>
                {
                    animator.SetBool(ANIMATOR_ALMOST_DONE_FRIGHTENED, true);
                }));
                break;
            case AbstractGhostCharacter.GhostState.EATEN:
                animator.SetBool(ANIMATOR_EATEN, true);
                break;
            case AbstractGhostCharacter.GhostState.CHASE:
            case AbstractGhostCharacter.GhostState.SCATTER:
                animator.SetBool(ANIMATOR_EATEN, false);
                break;
            case AbstractGhostCharacter.GhostState.LOCKED:
            case AbstractGhostCharacter.GhostState.UNLOCKED:
                positionOffset = positionOffset = new Vector2(0.5f, 0f);
                animator.SetBool(ANIMATOR_EATEN, false);
                break;
        }
    }

    public override void Move(Vector position)
    {
        base.Move(position);

        target.gameObject.SetActive(EngineGhostCharacter.State != AbstractGhostCharacter.GhostState.FRIGHTENED);
        if (EngineGhostCharacter.State != AbstractGhostCharacter.GhostState.FRIGHTENED)
        {
            var targetPos = EngineGhostCharacter.GetTarget();
            target.localPosition = new Vector3(targetPos.y, targetPos.x);
        }
    }

    private IEnumerator WaitAndCall(float timeWaiting, Action callback)
    {
        yield return new WaitForSeconds(timeWaiting);
        callback.Invoke();
    }
}
