namespace VRGear
{
    public class Module
    {
        public virtual void UiInit()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void LateUpdate()
        {
        }

        public virtual void Save()
        {
        }

        public virtual void Load()
        {
        }

        public virtual void PlayerJoin(VRC.Player player)
        {
        }

        public virtual void PlayerLeft(VRC.Player player)
        {
        }

        public virtual void AvatarChange(VRC.Core.ApiAvatar avatar)
        {
        }
    }
}