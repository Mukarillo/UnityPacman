using PacEngine.characters.ghosts;
using PacEngine.utils;
using UnityEngine;

public abstract class AbstractGhostCharacterView : AbstractCharacterView
{
    private AbstractGhostCharacter EngineGhostCharacter => (AbstractGhostCharacter)EngineCharacter;

    public Transform target;

    public override void Move(Vector position)
    {
        base.Move(position);

        var targetPos = EngineGhostCharacter.GetTarget();
        target.localPosition = new Vector3(targetPos.y, targetPos.x);
    }
}
