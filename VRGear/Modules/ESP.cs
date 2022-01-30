using System;
using System.Linq;
using UnityEngine;
using VRGear.Utils;
using Player = VRC.Player;

namespace VRGear.Modules
{
    public class ESP : Module
    {
        private readonly Serializer<Model> _serializer;
        private HighlightsFXStandalone _developerHighlightsFX;
        private HighlightsFXStandalone _friendHighlightsFX;
        private HighlightsFXStandalone _knownHighlightsFX;
        private HighlightsFXStandalone _legendaryHighlightsFX;
        private Model _model;
        private HighlightsFXStandalone _moderatorHighlightsFX;
        private HighlightsFXStandalone _newHighlightsFX;
        private Model.EspState _state;
        private HighlightsFXStandalone _trustedHighlightsFX;
        private HighlightsFXStandalone _userHighlightsFX;
        private HighlightsFXStandalone _veteranHighlightsFX;

        private HighlightsFXStandalone _visitorHighlightsFX;

        public ESP()
        {
            _serializer = new Serializer<Model>(nameof(ESP), ResourceType.Data);
            _model = Model.Default;
            _state = Model.EspState.None;
        }

        public override void UiInit()
        {
            var gameObject = HighlightsFX.prop_HighlightsFX_0.gameObject;

            _visitorHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _newHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _userHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _knownHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _trustedHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _veteranHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _legendaryHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _moderatorHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _developerHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();
            _friendHighlightsFX = gameObject.AddComponent<HighlightsFXStandalone>();

            _visitorHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.Visitor);
            _newHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.New);
            _userHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.User);
            _knownHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.Known);
            _trustedHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.Trusted);
            _veteranHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.Veteran);
            _legendaryHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.Legendary);
            _moderatorHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.Moderator);
            _developerHighlightsFX.highlightColor = Trust.GetTrustColor(Trust.TrustLevel.Developer);
            _friendHighlightsFX.highlightColor = Color.yellow;

            const int blurIterations = 2;
            _visitorHighlightsFX.blurIterations = blurIterations;
            _newHighlightsFX.blurIterations = blurIterations;
            _userHighlightsFX.blurIterations = blurIterations;
            _knownHighlightsFX.blurIterations = blurIterations;
            _trustedHighlightsFX.blurIterations = blurIterations;
            _veteranHighlightsFX.blurIterations = blurIterations;
            _legendaryHighlightsFX.blurIterations = blurIterations;
            _moderatorHighlightsFX.blurIterations = blurIterations;
            _developerHighlightsFX.blurIterations = blurIterations;
            _friendHighlightsFX.blurIterations = blurIterations;

            const float blurSize = 2;
            _visitorHighlightsFX.blurSize = blurSize;
            _newHighlightsFX.blurSize = blurSize;
            _userHighlightsFX.blurSize = blurSize;
            _knownHighlightsFX.blurSize = blurSize;
            _trustedHighlightsFX.blurSize = blurSize;
            _veteranHighlightsFX.blurSize = blurSize;
            _legendaryHighlightsFX.blurSize = blurSize;
            _moderatorHighlightsFX.blurSize = blurSize;
            _developerHighlightsFX.blurSize = blurSize;
            _friendHighlightsFX.blurSize = blurSize;
        }

        public override void Update()
        {
            if (!Input.GetKey(_model.Modifier) || !Input.GetKeyDown(_model.Code)) return;

            _state = _state == Enum.GetValues(typeof(Model.EspState)).Cast<Model.EspState>().Last() ? 0 : _state + 1;

            Cache();
        }

        private void Cache()
        {
            foreach (var player in Utils.Player.Players.Where(player => !player.prop_VRCPlayerApi_0.isLocal))
            {
                var trustLevel = Trust.GetTrustLevel(player.prop_APIUser_0);

                if (player.prop_APIUser_0.isFriend)
                    _friendHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                        .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                else
                    switch (trustLevel)
                    {
                        case Trust.TrustLevel.Visitor:
                            _visitorHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.New:
                            _newHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.User:
                            _userHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.Known:
                            _knownHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.Trusted:
                            _trustedHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.Veteran:
                            _veteranHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.Legendary:
                            _legendaryHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.Moderator:
                            _moderatorHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        case Trust.TrustLevel.Developer:
                            _developerHighlightsFX.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion")
                                .GetComponent<MeshRenderer>(), _state is Model.EspState.Players or Model.EspState.Both);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
            }

            foreach (var pickup in ObjectUtils.AllPickups)
                _visitorHighlightsFX.Method_Public_Void_Renderer_Boolean_0(pickup.GetComponent<MeshRenderer>(),
                    _state is Model.EspState.Objects or Model.EspState.Both);
        }

        public override void PlayerJoin(Player player)
        {
            Cache();
        }

        public override void Save()
        {
            _serializer.Serialize(_model);
            _model.State = Model.Default.State;
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
            public enum EspState
            {
                None = 0,
                Objects = 1,
                Players = 2,
                Both = 3
            }

            public KeyCode Code { get; set; }
            public KeyCode Modifier { get; set; }
            public EspState State { get; set; }

            public static Model Default =>
                new()
                {
                    Code = KeyCode.Alpha3,
                    Modifier = KeyCode.LeftControl,
                    State = EspState.None
                };
        }
    }
}