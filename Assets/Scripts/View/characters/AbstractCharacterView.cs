using PacEngine.characters;
using PacEngine.utils;
using UnityEngine;
using DG.Tweening;

public abstract class AbstractCharacterView : MonoBehaviour
{
    public AbstractCharacter EngineCharacter { get; private set; }

    protected Animator animator;
    private float animatorSpeed;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        animatorSpeed = animator.speed;
    }

    public void LinkEngineCharacter(AbstractCharacter engineCharacter)
    {
        EngineCharacter = engineCharacter;
        engineCharacter.OnMove += Move;
        engineCharacter.OnTeleport += Teleport;
    }

    public virtual void Move(Vector position)
    {
        animator.SetFloat("xVelocity", EngineCharacter.HeadingDirection.x);
        animator.SetFloat("yVelocity", EngineCharacter.HeadingDirection.y);
        animator.speed = animatorSpeed;
        transform.DOLocalMove(new Vector3(position.y, position.x), EngineCharacter.TimeToTravelOneTile)
            .SetEase(Ease.Linear)
            .OnComplete( () => {
                animator.speed = 0;
                EngineCharacter.DoneViewMove();
            });
    }

    public virtual void Teleport(Vector position)
    {
        transform.localPosition = new Vector3(position.y, position.x);
    }
}
