using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    /// <summary>
    /// This is a pretty filthy script. I was just arbitrarily adding to it as I went.
    /// You won't find any programming prowess here.
    /// This is a supplementary script to help with effects and animation. Basically a juice factory.
    /// </summary>
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private AudioSource _source;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private ParticleSystem _jumpParticles, _launchParticles;
        [SerializeField] private ParticleSystem _moveParticles, _landParticles;
        [SerializeField] private AudioClip[] _footsteps;
        // [SerializeField] private float _maxTilt = 5;
        //  [SerializeField] private float _tiltSpeed = 30;
        [SerializeField, Range(1f, 3f)] private float _maxIdleSpeed = 2;
        [SerializeField] private float _maxParticleFallSpeed = -40;

        private IPlayerController _player;
        private ParticleSystem.MinMaxGradient _currentGradient;
        private Vector2 _movement;
        public PlayerController player;

        void Awake()
        {
            _player = GetComponentInParent<IPlayerController>();

            _player.OnGroundedChanged += OnLanded;
            _player.OnJumping += OnJumping;
            _player.OnDoubleJumping += OnDoubleJumping;
            _player.OnDashingChanged += OnDashing;
            player = GetComponent<PlayerController>();
        }

        void OnDestroy()
        {
            _player.OnGroundedChanged -= OnLanded;
            _player.OnJumping -= OnJumping;
            _player.OnDoubleJumping -= OnDoubleJumping;
            _player.OnDashingChanged -= OnDashing;
        }

        private void OnDoubleJumping()
        {
            _source.PlayOneShot(_doubleJumpClip);
            _doubleJumpParticles.Play();
        }

        private void OnDashing(bool dashing)
        {

            if (dashing)
            {
                _dashParticles.Play();
                _dashRingTransform.up = new Vector3(_player.Input.X, _player.Input.Y);
                _dashRingParticles.Play();
                _source.PlayOneShot(_dashClip);
            }
            else
            {
                _dashParticles.Stop();
            }
        }

        #region Extended

        [Header("EXTENDED")]
        [SerializeField] private ParticleSystem _doubleJumpParticles;
        [SerializeField] private AudioClip _doubleJumpClip, _dashClip;
        [SerializeField] private ParticleSystem _dashParticles, _dashRingParticles;
        [SerializeField] private Transform _dashRingTransform;

        #endregion

        private void OnJumping()
        {
            _anim.SetTrigger(JumpKey);
            _anim.ResetTrigger(GroundedKey);

            // Only play particles when grounded (avoid coyote)
            if (_player.Grounded)
            {
                SetColor(_jumpParticles);
                SetColor(_launchParticles);
                _jumpParticles.Play();
            }
        }



        private void OnLanded(bool grounded)
        {
            if (grounded)
            {
                _anim.SetTrigger(GroundedKey);
//                _source.PlayOneShot(_footsteps[Random.Range(0, _footsteps.Length)]);
                _moveParticles.Play();
                _landParticles.transform.localScale = Vector3.one * Mathf.InverseLerp(0, _maxParticleFallSpeed, _movement.y);
                SetColor(_landParticles);
                _landParticles.Play();
            }
            else
            {
                _moveParticles.Stop();
            }
        }

        void Update()
        {
            if (_player == null) return;

            // Flip the sprite
          
            if (transform.localScale.x == 1 && Input.GetKeyDown(KeyCode.A)&&_player.Grounded)
            {
                _jumpParticles.Play();
                
            }
            if (transform.localScale.x == -1 && Input.GetKeyDown(KeyCode.D)&&_player.Grounded)
            {
                _jumpParticles.Play();
                
                {
                    
                }
            }
              if (_player.Input.X != 0&&!player.isWallSliding){ 
                  transform.localScale = new Vector3(_player.Input.X > 0 ? 1 : -1, 1, 1);
                  
              }
            // Lean while running
            // var targetRotVector = new Vector3(0, 0, Mathf.Lerp(-_maxTilt, _maxTilt, Mathf.InverseLerp(-1, 1, _player.Input.X)));
            //  _anim.transform.rotation = Quaternion.RotateTowards(_anim.transform.rotation, Quaternion.Euler(targetRotVector), _tiltSpeed * Time.deltaTime);

            // Speed up idle while running
            _anim.SetFloat(IdleSpeedKey, Mathf.Lerp(1, _maxIdleSpeed, Mathf.Abs(_player.Input.X)));

            // Detect ground color
            var groundHit = Physics2D.Raycast(transform.position, Vector3.down, 2, _groundMask);
            if (groundHit && groundHit.transform.TryGetComponent(out SpriteRenderer r))
            {
                _currentGradient = new ParticleSystem.MinMaxGradient(r.color * 0.9f, r.color * 1.2f);
                SetColor(_moveParticles);
            }

            _movement = _player.RawMovement; // Previous frame movement is more valuable
        }

        private void OnDisable()
        {
            _moveParticles.Stop();
        }

        private void OnEnable()
        {
            _moveParticles.Play();
        }

        void SetColor(ParticleSystem ps)
        {
            var main = ps.main;
            main.startColor = _currentGradient;
        }

        #region Animation Keys

        private static readonly int GroundedKey = Animator.StringToHash("Grounded");
        private static readonly int IdleSpeedKey = Animator.StringToHash("IdleSpeed");
        private static readonly int JumpKey = Animator.StringToHash("Jump");

        #endregion
    }
}