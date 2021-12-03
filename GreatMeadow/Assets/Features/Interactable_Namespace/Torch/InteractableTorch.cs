using Features.Character_Namespace;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Utils.Variables_Namespace;

public class InteractableTorch : InteractableBehaviour
{
    [SerializeField] private Vector2Variable playerSpawnPos;
    [SerializeField] private Vector2Variable torchSpawnPos;
    [SerializeField] private Vector2Variable torchPosition;
    [SerializeField] private Light2D torchLight;
    private Animator animator;
    private static readonly int PickUpTorch = Animator.StringToHash("PickUpTorch");

    /**
    * Set spawn position of torch TODO add vector2value as param for position
    */
    public void SetTorchPosition()
    {
        torchSpawnPos.vec2Value = playerSpawnPos.vec2Value; //for testing
        Debug.Log("InteractableTorch spawn pos: " + torchSpawnPos.vec2Value);
        transform.position = torchPosition.vec2Value;
    }

    /**
     * Pick Up Torch
     */
    public override void Interact(PlayerController2D playerController)
    {
        Debug.Log("Pick up");
        animator = GetComponent<Animator>();
        animator.SetTrigger(PickUpTorch);
        torchLight.intensity = 0f;
        playerController.GetComponentInChildren<PlayerTorch>().RefillTorch();
    }
}