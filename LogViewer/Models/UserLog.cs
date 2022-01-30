using System;

namespace LogViewer.Models
{
    public class UserLog
    {
        [Serializable]
        public class Model
        {
            public Model(string username, string userId, string avatarId, DateTime time)
            {
                Username = username;
                UserId = userId;
                AvatarId = avatarId;
                Time = time;
            }

            public string Username { get; }
            public string UserId { get; }
            public string AvatarId { get; }
            public DateTime Time { get; }
        }
    }
}