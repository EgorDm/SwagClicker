using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputManager;
using SwagClicker.Utils;

namespace SwagClicker.Models
{
    class MouseClickCommand : AbstractCommand
    {
        protected Vector2 Position;
        protected bool Down;
        protected Mouse.MouseKeys Key;


        public MouseClickCommand(TimeSpan time, Vector2 position, bool down, Mouse.MouseKeys key) : base(time)
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
                Mouse.ButtonDown(Key);
            }
            else
            {
                Mouse.ButtonUp(Key);
            }
            return true;
        }

        public override string ToString()
        {
            return $"C|{Time.TotalMilliseconds}|{Position.ToString()}|{Down}|{(int)Key}";
        }
        public static MouseClickCommand FromString(string line)
        {
            var args = line.Split('|');
            var ret = new MouseClickCommand(TimeSpan.FromMilliseconds(double.Parse(args[1])), Vector2.fromString(args[2]), bool.Parse(args[3]), (Mouse.MouseKeys)int.Parse(args[4]));
            return ret;
        }
    }


}
