using PacEngine.characters.ghosts;
using PacEngine.utils;
using UnityEngine;

public abstract class AbstractGhostCharacterView : AbstractCharacterView
{
    AbstractGhostCharacter EngineGhostCharacter => (AbstractGhostCharacter)EngineCharacter;

    public Transform target;

    public override void Teleport(Vector position)
    {
        base.Teleport(position);

        var targetPos = EngineGhostCharacter.GetTarget();
        target.localPosition = new Vector3(targetPos.y, targetPos.x);
    }
}
