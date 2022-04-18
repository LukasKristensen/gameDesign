using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Equipment;
using InventoryItems;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

/* Note: animations are called via the controller for both the character and capsule using animator null checks
 */

namespace PellesAssets
{
	public class FPSController : Friendly
	{
		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		public float MoveSpeed = 4.0f;
		[Tooltip("Sprint speed of the character in m/s")]
		public float SprintSpeed = 6.0f;
		[Tooltip("Rotation speed of the character")]
		public float RotationSpeed = 1.0f;
		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate = 10.0f;

		[Space(10)]
		[Tooltip("The height the player can jump")]
		public float JumpHeight = 1.2f;
		[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
		public float Gravity = -15.0f;

		[Space(10)]
		[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
		public float JumpTimeout = 0.1f;
		[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
		public float FallTimeout = 0.15f;

		[Header("Player Grounded")]
		[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
		public bool Grounded = true;
		[Tooltip("Useful for rough ground")]
		public float GroundedOffset = -0.14f;
		[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
		public float GroundedRadius = 0.5f;
		[Tooltip("What layers the character uses as ground")]
		public LayerMask GroundLayers;

		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;
		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 90.0f;
		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -90.0f;

		// cinemachine
		private float _cinemachineTargetPitch;

		// player
		private float _speed;
		private float _rotationVelocity;
		private float _verticalVelocity;
		private float _terminalVelocity = 53.0f;

		// timeout deltatime
		private float _jumpTimeoutDelta;
		private float _fallTimeoutDelta;

		private CharacterController _controller;
		private GameObject _mainCamera;
		[SerializeField] private bool isSprinting;
		private FPSInputs _fpsInputs;
		public Inventory _inventory;
		public EquippableAsset Spear;
		public EquippableAsset Hammer;
		public EquippableAsset currentRightHand;
		[SerializeField] private float rayCastRange;
		private UIDocument upgradeMenu;
		private VisualElement backgroundMenu;
		private Label upgradePlasticCost;
		private Label upgradeMetalCost;
		
		private const float _threshold = 0.01f;
	
		
		private void Start()
		{
			// get a reference to our main camera
			if (_mainCamera == null)
			{
				_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}
			_controller = GetComponent<CharacterController>();
			_fpsInputs = new FPSInputs();
			_fpsInputs.Default.Enable();
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			// reset our timeouts on start
			_jumpTimeoutDelta = JumpTimeout;
			_fallTimeoutDelta = FallTimeout;
			_fpsInputs.Default.Jump.performed += AttemptJump;
			_fpsInputs.Default.Interact.performed += Interact;
			_fpsInputs.Default.Attack.performed += Fire;
			_fpsInputs.Default.Equip1.performed += Swap;
			upgradeMenu = GetComponent<UIDocument>();
			var root = upgradeMenu.rootVisualElement;
			backgroundMenu =root.Q<VisualElement>("Background");
			upgradePlasticCost = root.Q<Label>("plastic-cost-label");
			upgradeMetalCost = root.Q<Label>("metal-cost-label");
			if (currentRightHand == Spear)
			{
				DrawEquipment(Hammer);
			}
			else
			{
				DrawEquipment(Spear);
			}
			if (currentRightHand == Spear)
			{
				DrawEquipment(Hammer);
			}
			else
			{
				DrawEquipment(Spear);
			}
			if (currentRightHand == Spear)
			{
				DrawEquipment(Hammer);
			}
			else
			{
				DrawEquipment(Spear);
			}
			
			_inventory.Metal = 0;
			_inventory.Plastic = 0;
		}

		private void Swap(InputAction.CallbackContext obj)
		{
			if (currentRightHand == Spear)
			{
				DrawEquipment(Hammer);
			}
			else
			{
				DrawEquipment(Spear);
			}
		}

		private void Fire(InputAction.CallbackContext obj)
		{
			currentRightHand?.instant?.Fire(obj);
		}

		private void Interact(InputAction.CallbackContext obj)
		{
			if (!Physics.Raycast(transform.position, CinemachineCameraTarget.transform.forward, out RaycastHit hit,
				rayCastRange)) return;
			if (hit.collider.TryGetComponent(out IInteractable interactable))
			{
				interactable.Interact( this,_inventory);
			}
		}

		private void Update()
		{
			CheckForHoverables();
			_inventory.health = health;
		}

		

		private void FixedUpdate()
		{
			JumpAndGravity();
			GroundedCheck();
			Move();
			CameraRotation();
		}
		
		private void CheckForHoverables()
		{
			if (Physics.Raycast(transform.position,CinemachineCameraTarget.transform.forward,out RaycastHit hit,rayCastRange))
			{
				if (hit.collider.TryGetComponent(out IHoverable hoverable))
				{
					Cost cost = hoverable.OnHover();
					backgroundMenu.visible = true;
					upgradeMetalCost.text = cost.Metal.ToString();
					upgradePlasticCost.text = cost.Plastic.ToString();
					return;
				}
			}
			backgroundMenu.visible = false;
		}
		

		private void GroundedCheck()
		{
			Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
			Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
		}

		private void CameraRotation()
		{
			Vector2 lookVector = _fpsInputs.Default.Look.ReadValue<Vector2>();
			// if there is an input
			_cinemachineTargetPitch += lookVector.y * RotationSpeed * Time.deltaTime * -1;
			_rotationVelocity = lookVector.x * RotationSpeed * Time.deltaTime;

			// clamp our pitch rotation
			_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

			// Update Cinemachine camera target pitch
			CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

			// rotate the player left and right
			transform.Rotate(Vector3.up * _rotationVelocity);
		}

		private void Move()
		{
			// set target speed based on move speed, sprint speed and if sprint is pressed
			float targetSpeed = isSprinting ? SprintSpeed : MoveSpeed;

			// a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon
			Vector2 movementVector = _fpsInputs.Default.Movement.ReadValue<Vector2>();
			// note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is no input, set the target speed to 0
			if (movementVector == Vector2.zero) targetSpeed = 0.0f;

			// a reference to the players current horizontal velocity
			float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

			float speedOffset = 0.1f;
			//float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

			// accelerate or decelerate to target speed
			if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
			{
				// creates curved result rather than a linear one giving a more organic speed change
				// note T in Lerp is clamped, so we don't need to clamp our speed
				_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed , Time.deltaTime * SpeedChangeRate);

				// round speed to 3 decimal places
				_speed = Mathf.Round(_speed * 1000f) / 1000f;
			}
			else
			{
				_speed = targetSpeed;
			}

			// normalise input direction
			Vector3 inputDirection = new Vector3(movementVector.x, 0.0f, movementVector.y).normalized;

			// note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is a move input rotate player when the player is moving
			if (movementVector != Vector2.zero)
			{
				// move
				inputDirection = transform.right * movementVector.x + transform.forward * movementVector.y;
			}
			
			// move the player
			_controller.Move(inputDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
		}

		private void AttemptJump(InputAction.CallbackContext obj)
		{
			
			if (!Grounded || !(_jumpTimeoutDelta <= 0.0f)) return;
			
			// the square root of H * -2 * G = how much velocity needed to reach desired height
			_verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
		}
		private void JumpAndGravity()
		{
			if (Grounded)
			{
				// reset the fall timeout timer
				_fallTimeoutDelta = FallTimeout;

				// stop our velocity dropping infinitely when grounded
				if (_verticalVelocity < 0.0f)
				{
					_verticalVelocity = -2f;
				}
				// jump timeout
				if (_jumpTimeoutDelta >= 0.0f)
				{
					_jumpTimeoutDelta -= Time.deltaTime;
				}
			}
			else
			{
				// reset the jump timeout timer
				_jumpTimeoutDelta = JumpTimeout;

				// fall timeout
				if (_fallTimeoutDelta >= 0.0f)
				{
					_fallTimeoutDelta -= Time.deltaTime;
				}
			}

			// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
			if (_verticalVelocity < _terminalVelocity)
			{
				_verticalVelocity += Gravity * Time.deltaTime;
			}
		}
		

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position,transform.position+transform.forward*rayCastRange);
			Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
			
			Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

			Gizmos.color = Grounded ? transparentGreen : transparentRed;
			// when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
			Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z), GroundedRadius);
			
		}

		public void Equip(EquippableAsset equippableAsset)
		{
			switch (equippableAsset.type)
			{
				case EquippableType.Hammer:
					Hammer = equippableAsset;
					DrawEquipment(Hammer);
					break;
				case EquippableType.Spear:
					Spear = equippableAsset;
					if(Spear.teir==0){
						DrawEquipment(Spear);
					}
					else
					{
						DrawEquipment(Spear,Spear.instant.gameObject);
					}
					break;
				case EquippableType.Shield:
					break;
				case EquippableType.Sword:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
		private void DrawEquipment(EquippableAsset equippableAsset)
		{
			currentRightHand?.Holster();
			currentRightHand = equippableAsset;
			equippableAsset.Draw(transform);
		}
		private void DrawEquipment(EquippableAsset equippableAsset,GameObject previousTeir)
		{
			currentRightHand?.Holster(previousTeir);
			currentRightHand = equippableAsset;
			equippableAsset.Draw(transform);
		}
	}
}