using System;
using System.Linq;
using UnityEngine;
using VRGear.Utils;
using RootMotion.FinalIK;
using Logger = VRGear.Utils.Logger;

namespace VRGear.Modules
{
    public class Hands : Module
    {
        private readonly Serializer<Model> _serializer;
        private VRIK _controller;
        private Model _model;
        private Model.HandState _state;

        public Hands()
        {
            _serializer = new Serializer<Model>(nameof(Hands), ResourceType.Data);
            _model = Model.Default;
        }

        public override void LateUpdate()
        {
            if (Input.GetKey(_model.Modifier) && Input.GetKeyDown(_model.Code))
            {
                _controller = Player.CurrentPlayer.GetComponentInChildren<VRIK>();
                _state = _state == Enum.GetValues(typeof(Model.HandState)).Cast<Model.HandState>().Last() ? 0 : _state + 1;
                Logger.Instance.Log($"State changed to: {_state.ToString()}",
                    _state == Model.HandState.None ? ConsoleColor.Green : ConsoleColor.Yellow);
            }

            if (_controller == null) return;

            if (_state is Model.HandState.Left or Model.HandState.Both)
            {
                _controller.solver.leftArm.positionWeight = 1;
                _controller.solver.leftArm.rotationWeight = 1;
            }
            else
            {
                _controller.solver.leftArm.positionWeight = 0;
                _controller.solver.leftArm.rotationWeight = 0;
            }

            if (_state is Model.HandState.Right or Model.HandState.Both)
            {
                _controller.solver.rightArm.positionWeight = 1;
                _controller.solver.rightArm.rotationWeight = 1;
            }
            else
            {
                _controller.solver.rightArm.positionWeight = 0;
                _controller.solver.rightArm.rotationWeight = 0;
            }
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

        [Serializable]
        public class Model
        {
            public enum HandState
            {
                None = 0,
                Left = 1,
                Right = 2,
                Both = 3
            }

            public KeyCode Code { get; set; }
            public KeyCode Modifier { get; set; }
            public HandState State { get; set; }

            public static Model Default =>
                new()
                {
                    Code = KeyCode.Alpha2,
                    Modifier = KeyCode.LeftControl,
                    State = HandState.None
                };
        }
    }
}