using UnityEngine;
using Game.Logic;

public class Teleportation : MonoBehaviour
{
    private Camera mainCamera;
    private Transform cameraTransform;
    private TeleportOnEdges teleport;
    private ScreenDiagonal diagonal;
    private ScreenEdges edges;

    private void Awake()
    {
        diagonal = new ScreenDiagonal();
        edges = new ScreenEdges(diagonal);
        teleport = new TeleportOnEdges(edges);
    }

    private void Start()
    {
        mainCamera = Camera.main;
        cameraTransform = GetComponent<Transform>();

        GetDiagonalScreen();
        GetEdgesScreen();
    }

    private void Update()
    {
        TryTeleportation();
    }   

    private void GetDiagonalScreen()
    {
        diagonal.GetHeight(mainCamera);
        diagonal.GetWidth(mainCamera);
    }

    private void GetEdgesScreen()
    {
        edges.GetTop();
        edges.GetBottom();
        edges.GetRight();
        edges.GetLeft();
    }

    private void TryTeleportation()
    {
        teleport.TeleportationToTop(cameraTransform);
        teleport.TeleportationToBottom(cameraTransform);
        teleport.TeleportationToRight(cameraTransform);
        teleport.TeleportationToLeft(cameraTransform);
    }
}
