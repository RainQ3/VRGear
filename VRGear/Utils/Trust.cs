using System;
using VRC.Core;
using UnityEngine;

namespace VRGear.Utils
{
    public static class Trust
    {
        public enum TrustLevel
        {
            Visitor = 0,
            New,
            User,
            Known,
            Trusted,
            Veteran,
            Legendary,
            Moderator,
            Developer,
        }

        public static TrustLevel GetTrustLevel(APIUser user)
        {
            if (user.id == "usr_77979962-76e0-4b27-8ab7-ffa0cda9e223")
                return TrustLevel.Developer;
            if (user.tags.Contains("system_legend"))
                return TrustLevel.Legendary;
            if (user.hasLegendTrustLevel)
                return TrustLevel.Veteran;
            if (user.hasVeteranTrustLevel)
                return TrustLevel.Trusted;
            if (user.hasTrustedTrustLevel)
                return TrustLevel.Known;
            if (user.hasKnownTrustLevel)
                return TrustLevel.User;
            if (user.hasBasicTrustLevel)
                return TrustLevel.New;
            if (user.isUntrusted)
                return TrustLevel.Visitor;

            throw new InvalidOperationException($"Can't get trust level from {user.displayName}");
        }

        public static Color GetTrustColor(TrustLevel trustLevel)
        {
            return trustLevel switch
            {
                TrustLevel.Visitor => new Color32(184, 184, 184, 255),
                TrustLevel.New => new Color32(153, 209, 255, 255),
                TrustLevel.User => new Color32(153, 255, 156, 255),
                TrustLevel.Known => new Color32(255, 201, 153, 255),
                TrustLevel.Trusted => new Color32(192, 153, 255, 255),
                TrustLevel.Veteran => new Color32(255, 236, 128, 255),
                TrustLevel.Legendary => new Color32(255, 128, 172, 255),
                TrustLevel.Moderator => new Color32(255, 105, 105, 255),
                TrustLevel.Developer => new Color32(255, 105, 105, 255),
                _ => new Color(1f, 0f, 0f, 1f)
            };
        }
    }
}