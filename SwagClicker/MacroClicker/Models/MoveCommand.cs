using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InputManager;
using SwagClicker.Utils;

namespace SwagClicker.Models
{
    internal class MoveCommand : AbstractCommand
    {
        protected Vector2 Position;

        public MoveCommand(TimeSpan time, Vector2 position) : base(time)
        {
            Position = position;
        }

        public override bool Play(TimeSpan currTimeSpan)
        {
            if (currTimeSpan <= Time) return false;
            Mouse.Move(Position.X, Position.Y);
            return true;
        }

        public override string ToString()
        {
            return $"M|{Time.TotalMilliseconds}|{Position.ToString()}";
        }

        public static MoveCommand FromString(string line)
        {
            var args = line.Split('|');
            return new MoveCommand(TimeSpan.FromMilliseconds(double.Parse(args[1])), Vector2.fromString(args[2]));
        }
    }
}