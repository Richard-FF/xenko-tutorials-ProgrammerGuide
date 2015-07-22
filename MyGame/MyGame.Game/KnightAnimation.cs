using SiliconStudio.Paradox.Engine;

namespace MyGame
{
    public class KnightAnimation:StartupScript
    {
        public override void Start()
        {
            base.Start();
            Entity.Get<AnimationComponent>().Play("Idle");
        }
    }
}
