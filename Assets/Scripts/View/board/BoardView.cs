using UnityEngine;

public class BoardView : MonoBehaviour
{
    [SerializeField] private PacmanView pacman;
    public PacmanView Pacman => pacman;

    [SerializeField] private BlinkyView blinky;
    public BlinkyView Blinky => blinky;

    [SerializeField] private PinkyView pinky;
    public PinkyView Pinky => pinky;

    [SerializeField] private InkyView inky;
    public InkyView Inky => inky;

    [SerializeField] private ClydeView clyde;
    public ClydeView Clyde => clyde;
}
