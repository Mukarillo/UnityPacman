using PacEngine.characters;
using PacEngine.utils;
using UnityEngine;
using DG.Tweening;

public abstract class AbstractCharacterView : MonoBehaviour
{
    public AbstractCharacter EngineCharacter { get; private set; }

    public void LinkEngineCharacter(AbstractCharacter engineCharacter)
    {
        EngineCharacter = engineCharacter;
        engineCharacter.OnMove += Move;
        engineCharacter.OnTeleport += Teleport;
    }

    public virtual void Move(Vector position)
    {
        transform.DOLocalMove(new Vector3(position.y, position.x), EngineCharacter.TimeToTravelOneTile)
            .SetEase(Ease.Linear)
            .OnComplete(EngineCharacter.DoneViewMove);
    }

    public virtual void Teleport(Vector position)
    {
        transform.localPosition = new Vector3(position.y, position.x);
    }
}
