using UnityEngine;

namespace Character
{
   [RequireComponent(typeof(CharacterController))]
   public class Character : MonoBehaviour
   {
      [HideInInspector, SerializeField] private CharacterController _characterContr;
      [SerializeField] private float _moveSpeed = 2.0f;
      private Vector3 _velocity = Vector3.zero;
      private const float GravityModifier = 10.0f;

      [SerializeField] private Camera _camera;
      [SerializeField] private float _rotationSpeed = 5.0f;

      private void OnValidate()
      {
         _characterContr = GetComponent<CharacterController>();
      }

      private void Update()
      {
         var horInput = Input.GetAxis("Horizontal");
         var verInput = Input.GetAxis("Vertical");
         
         Move(horInput, verInput);
      }

      private void Move(float horInput, float verInput)
      {
         var direction = new Vector3(horInput, 0.0f, verInput).normalized;

         var cameraDirection = _camera.transform.TransformDirection(direction);
         cameraDirection.y = 0.0f;
         cameraDirection.Normalize();

         var moveVector = cameraDirection * _moveSpeed;

         if (moveVector != Vector3.zero)
         {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(cameraDirection), Time.deltaTime * _rotationSpeed);
         }
         
         if (_characterContr.isGrounded)
         {
            if (_velocity.y < 0)
            {
               _velocity.y = 0;
            }
         }
         
         _velocity.y += -GravityModifier * Time.deltaTime;
         _characterContr.Move((moveVector + _velocity) * Time.deltaTime);
      }
   }
}
