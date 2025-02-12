using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectLayer;
    [SerializeField] LayerMask grassLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask playerLayer;

    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask SolidLayer { get => solidObjectLayer; }
    public LayerMask GrassLayer { get => grassLayer; }
    public LayerMask InteractableLayer { get => interactableLayer; }
    public LayerMask PlayerLayer { get => playerLayer; }
}
