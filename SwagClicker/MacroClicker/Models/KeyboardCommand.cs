using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using InputManager;
using SwagClicker.Models;
using SwagClicker.Utils;

namespace SwagClicker.FullSwag.Models
{
    class KeyboardCommand : AbstractCommand
    {
        protected Vector2 Position;
        protected bool Down;
        protected Keys Key;


        public KeyboardCommand(TimeSpan time, Vector2 position, bool down, Keys key) : base(time)
        {
            Position = position;
            Down = down;
            Key = key;
        }

        public override bool Play(TimeSpan currTimeSpan)
        {
            if (currTimeSpan <= Time) return false;
            Mouse.Move(Position.X, Position.Y);

            if (Down)
            {
                Keyboard.KeyDown(Key);
            }
            else
            {
                Keyboard.KeyUp(Key);
            }
            return true;
        }

        public override string ToString()
        {
            return $"K|{Time.TotalMilliseconds}|{Position.ToString()}|{Down}|{(int) Key}";
        }

        public static KeyboardCommand FromString(string line)
        {
            var args = line.Split('|');
            var ret = new KeyboardCommand(TimeSpan.FromMilliseconds(double.Parse(args[1])), Vector2.fromString(args[2]),
                bool.Parse(args[3]), (Keys) int.Parse(args[4]));
            return ret;
        }
    }
}