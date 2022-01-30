using System;
using System.Collections.Generic;
using VRGear.Utils;
using Player = VRC.Player;

namespace VRGear.Modules
{
    public class UserLog : Module
    {
        private readonly Serializer<List<Model>> _serializer;
        private List<Model> _model;

        public UserLog()
        {
            _serializer = new Serializer<List<Model>>(nameof(UserLog), ResourceType.Log);
            _model = new List<Model>();
        }

        public override void PlayerJoin(Player player)
        {
            var apiUser = player.prop_APIUser_0;
            var apiAvatar = player.prop_ApiAvatar_0;
            _model.Add(new Model {Username = apiUser.displayName, UserId = apiUser.id, AvatarId = apiAvatar.id, Time = DateTime.Now});
        }

        public override void Save()
        {
            _serializer.Serialize(_model);
        }

        [Serializable]
        public class Model
        {
            public string Username { get; set; }
            public string UserId { get; set; }
            public string AvatarId { get; set; }
            public DateTime Time { get; set; }
        }
    }
}