using System;
using VRGear.Utils;
using Player = VRC.Player;

namespace VRGear.Modules
{
    public class JumpEverywhere : Module
    {
        private readonly Serializer<Model> _serializer;
        private Model _model;

        public JumpEverywhere()
        {
            _serializer = new Serializer<Model>(nameof(JumpEverywhere), ResourceType.Data);
            _model = Model.Default;
        }

        public override void PlayerJoin(Player player)
        {
            if (player != Utils.Player.CurrentPlayer.prop_Player_0 ||
                Utils.Player.CurrentPlayer.GetComponent<PlayerModComponentJump>() != null) return;

            var jumpComponent = Utils.Player.CurrentPlayer.gameObject.AddComponent<PlayerModComponentJump>();
            jumpComponent.field_Private_Single_0 = _model.Height;
            jumpComponent.field_Private_Single_1 = _model.Height;
        }

        public override void Save()
        {
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
            public int Height { get; set; }

            public static Model Default =>
                new()
                {
                    Height = 5
                };
        }
    }
}