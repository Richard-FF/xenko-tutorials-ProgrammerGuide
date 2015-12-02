using System;
using System.Threading.Tasks;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Graphics;
using SiliconStudio.Xenko.UI;
using SiliconStudio.Xenko.UI.Controls;
using SiliconStudio.Xenko.UI.Panels;

namespace MyGame
{
    public class CameraControl : AsyncScript
    {
        public Entity Camera;

        private float angle;
        private bool moveCamera;

        public override async Task Execute()
        {
            // Button
            var button = new ToggleButton
            {
                Content = new TextBlock
                {
                    Text = "Move Camera",
                    Font = Asset.Load<SpriteFont>("Font")
                }
            };
            button.Click += (sender, args) => moveCamera = !moveCamera;

            // Panel
            Entity.Get<UIComponent>().RootElement = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 20, 0),
                Children = { button }
            };

            while (Game.IsRunning)
            {
                await Script.NextFrame();

                if (!moveCamera) continue;

                var elapsedTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;

                // Rotation camera
                angle += (float)Math.PI * elapsedTime * 0.1f;
                Camera.Transform.Position.X = 3f * (float)Math.Sin(angle);
                Camera.Transform.Position.Z = 3f * (float)Math.Cos(angle);
                Camera.Transform.Rotation = -Quaternion.RotationY(angle);
            }
        }
    }
}
