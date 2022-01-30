using System;
using UnityEngine;
using VRGear.Utils;
using Logger = VRGear.Utils.Logger;

namespace VRGear.Modules
{
    public class Fly : Module
    {
        private readonly Serializer<Model> _serializer;
        private Model _model;

        public Fly()
        {
            _serializer = new Serializer<Model>(nameof(Fly), ResourceType.Data);
            _model = Model.Default;
        }

        public override void Save()
        {
            _model.State = Model.Default.State;
            _serializer.Serialize(_model);
        }

        public override void Load()
        {
            if (_serializer.CanDeserialize)
                _model = _serializer.Deserialize();
            else
                Save();
        }

        public override void Update()
        {
            if (_model == null) return;

            if (Input.GetKey(_model.Modifier) && Input.GetKeyDown(_model.Code))
            {
                _model.State = !_model.State;

                Player.CurrentPlayer.GetComponent<CharacterController>().enabled = !_model.State;
                Logger.Instance.Log($"Fly {(_model.State ? "enabled" : "disabled")}", _model.State ? ConsoleColor.Yellow : ConsoleColor.Green);
            }

            if (!_model.State) return;

            if (Input.mouseScrollDelta.y != 0)
            {
                _model.Speed += (int) Mathf.Round(Input.mouseScrollDelta.y);
                _model.Speed = Mathf.Clamp(_model.Speed, 1, 1000);
            }

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            var localCameraTransform = Player.LocalPlayerCamera.transform;

            Player.CurrentPlayer.transform.position +=
                (vertical * localCameraTransform.forward +
                 horizontal * localCameraTransform.right)
                * _model.Speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.E))
                Player.CurrentPlayer.transform.position += Vector3.up * _model.Speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.Q))
                Player.CurrentPlayer.transform.position -= Vector3.up * _model.Speed * Time.deltaTime;
        }

        [Serializable]
        public class Model
        {
            public KeyCode Code { get; set; }
            public KeyCode Modifier { get; set; }
            public int Speed { get; set; }
            public bool State { get; set; }

            public static Model Default =>
                new()
                {
                    Code = KeyCode.F,
                    Modifier = KeyCode.F,
                    Speed = 2,
                    State = false
                };
        }
    }
}