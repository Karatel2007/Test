using ES3Types;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static System.IO.Enumeration.FileSystemEnumerable<TResult>;

public class PlayerController : MonoBehaviour, ISaveable
{
    public static PlayerController Instance { get; private set; }

    private const string PLAYER_POS_SAVE_KEY = "playerTransform";

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityScale;
    [SerializeField] private float dropForce;
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject trashBag;
    [SerializeField] private GameObject objectToPick;
    [SerializeField] private GameObject playerCamera;

    private float timer;
    public bool isHolding = false;
    private Transform heldItem;
    public Transform handTransform;

    private bool isWalking;

    private CharacterController controller;
    private Animator handAnimator;
    
    private Image shopItemBar;

    private Vector3 verticalVelocity = Vector3.zero;

   

    [SerializeField] private LayerMask computer;

  

    private void Start()
    {
        Load();
        SaveManager.Instance.AddNewSaveable(this);

        controller = GetComponent<CharacterController>();  
        //handAnimator = hand.GetComponent<Animator>();

        if (Instance != null)
        {
            Debug.LogError("There are more then one PlayerController");
        }
        Instance = this;

        

        PlayerInputs.Instance.OnPlayerInteract += PlayerInputs_OnPlayerInteract;
        PlayerInputs.Instance.OnPLayerJump += PlayerInputs_OnPLayerJump;
        PlayerInputs.Instance.OnPlayerSecondInteract += PlayerInputs_OnPlayerSecondInteract;
        PlayerInputs.Instance.OnPlayerRun += PlayerInputs_OnPlayerRun;
        PlayerInputs.Instance.OnPlayerSave += PlayerInputs_OnPlayerSave;
    }

    private void PlayerInputs_OnPlayerSecondInteract(object sender, System.EventArgs e)
    {
        if (InteractionRaycast(out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out Door door))
            {
                door.Open();
            }
            if (hit.transform.TryGetComponent(out CarInteraction car))
            {
                car.EnterTheCar();
            }
            if (isHolding)
            {
                // Пускання предмету
                if (heldItem != null)
                {

                    if (heldItem.TryGetComponent(out DeliveryBox box))
                    {
                        box.EndWork();
                    }
                    DropItem();
                }
            }
            else
            {

                if (hit.collider.TryGetComponent(out ObjectToPick item))
                {
                    PickUpItem(hit.collider.transform);

                    if (item.TryGetComponent(out DeliveryBox box))
                    {
                        box.StartWork();
                    }
                }
                if (hit.collider.TryGetComponent(out GasPistol pistol))
                {
                    pistol.Pick(handTransform);
                    isHolding = true;
                    //heldItem = pistol.transform;
                }
            }
        }
    }
       

    private void PlayerInputs_OnPLayerJump(object sender, System.EventArgs e)
    {
        verticalVelocity.y = Mathf.Sqrt(jumpForce * 2f * gravityScale);
    }

    private void PlayerInputs_OnPlayerInteract(object sender, System.EventArgs e)
    {
        if (InteractionRaycast(out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out BildableObject fillObject))
            {
                shopItemBar = ShopItemBar.GetBar();
                shopItemBar.gameObject.SetActive(true);
                fillObject.Fill(Time.deltaTime);
                if (fillObject.fill == 0)
                {
                    shopItemBar.gameObject.SetActive(false);
                }
            }
            else if (hit.transform.TryGetComponent(out SpRandO rand))
            {
                rand.Spawn();
            }
            else if (hit.transform.TryGetComponent(out GasStationWork work))
            {
                work.StartWork();

            }
        }
    }

    private void PlayerInputs_OnPlayerRun(object sender, System.EventArgs e)
    {

    }
    private void PlayerInputs_OnPlayerSave(object sender, System.EventArgs e)
    {
        ES3.Save("PlayerPosition", transform.position);
    }

    private void Update()
    {

        Vector2 moveInputVector = PlayerInputs.Instance.GetInputVector();



        Vector3 moveVector = transform.forward * moveInputVector.y + transform.right * moveInputVector.x;

        if (PlayerInputs.Instance.PlayerRun())
        {
            controller.Move(moveVector * Time.deltaTime * runSpeed);
        }
        else
        {
            controller.Move(moveVector * Time.deltaTime * walkSpeed);
        }
        

        if (moveVector != Vector3.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (controller.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -1;
        }

        verticalVelocity.y -= gravityScale * Time.deltaTime;

        controller.Move(verticalVelocity * Time.deltaTime);
    }

 

    private bool InteractionRaycast(out RaycastHit raycastHit)
    {
        Ray Ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(Ray, out RaycastHit hit, 3f))
        {
            raycastHit = hit;
            return true;
        }
        raycastHit = new RaycastHit();
        return false;
    }

    private void PickUpItem(Transform item)
    {
        isHolding = true;
        heldItem = item;
        heldItem.GetComponent<Rigidbody>().isKinematic = true;
        heldItem.SetParent(handTransform);
        heldItem.localPosition = Vector3.zero;
    }
    public void DropItem()
    {
        
        isHolding = false;
        heldItem.SetParent(null);
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * dropForce);
        heldItem = null;
    }

    public void Save()
    {
        ES3.Save(PLAYER_POS_SAVE_KEY, transform.position);
    }

    public void Load()
    {
        if (ES3.KeyExists(PLAYER_POS_SAVE_KEY))
            transform.position = ES3.Load<Vector3>(PLAYER_POS_SAVE_KEY);
    }
}