using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using InputManager;
using SwagClicker.FullSwag.Models;
using SwagClicker.Models;
using SwagClicker.Utils;
using Timer = System.Timers.Timer;

namespace SwagClicker.FullSwag
{
    internal class SwagHelper
    {
        public static int UpdateMills = 5;
        public static TimeSpan CurrentTime;
        public static DateTime StartTime;
        public static List<AbstractCommand> Commands;

        public static MouseClickCommand CurMouse;
        public static Vector2 CurMousePos;

        public SwagHelper()
        {
        }

        private static TimeSpan GetUpdatedTime()
        {
            CurrentTime = DateTime.UtcNow - StartTime;
            return CurrentTime;
        }


        public void MouseClick(MouseHook.MouseEvents mEvent)
        {
            if (!TimerRecord.Enabled) return;
            switch (mEvent)
            {
                case MouseHook.MouseEvents.LeftDown:
                    Commands.Add(new MouseClickCommand(GetUpdatedTime(), CurMousePos, true, Mouse.MouseKeys.Left));
                    break;
                case MouseHook.MouseEvents.LeftUp:
                    Commands.Add(new MouseClickCommand(GetUpdatedTime(), CurMousePos, false, Mouse.MouseKeys.Left));
                    break;
                case MouseHook.MouseEvents.RightDown:
                    Commands.Add(new MouseClickCommand(GetUpdatedTime(), CurMousePos, true, Mouse.MouseKeys.Right));
                    break;
                case MouseHook.MouseEvents.RightUp:
                    Commands.Add(new MouseClickCommand(GetUpdatedTime(), CurMousePos, false, Mouse.MouseKeys.Right));
                    break;
            }
        }

        public void MouseMove(MouseHook.POINT ptLocat)
        {
            if (!TimerRecord.Enabled) return;
            CurMousePos = new Vector2(ptLocat.x, ptLocat.y);
        }

        public void KeyboardAction(Keys key, bool down)
        {
            if (!TimerRecord.Enabled) return;
            Commands.Add(new KeyboardCommand(GetUpdatedTime(), CurMousePos, down, key));
        }

        public readonly Timer TimerRecord = new Timer(UpdateMills)
        {
            AutoReset = true
        };

        public void StartRecord()
        {
            TimerRecord.Interval = UpdateMills;
            TimerRecord.Elapsed += UpdateRecord;
            TimerRecord.Start();
            CurrentTime = TimeSpan.Zero;
            StartTime = DateTime.UtcNow;
            Commands = new List<AbstractCommand>();
        }

        private static void UpdateRecord(object source, ElapsedEventArgs e)
        {
            Commands.Add(new MoveCommand(GetUpdatedTime(), CurMousePos));
        }

        public void StopRecord()
        {
            TimerRecord.Stop();
        }


        public static int CurCommand;

        public readonly Timer TimerPlayback = new Timer(UpdateMills)
        {
            AutoReset = true
        };

        public void StartPlayback()
        {
            if (Commands == null) return;
            CurCommand = 0;
            CurMouse = null;
            CurrentTime = TimeSpan.Zero;
            StartTime = DateTime.UtcNow;
            TimerPlayback.Interval = UpdateMills;
            TimerPlayback.Elapsed += UpdatePlayback;
            TimerPlayback.Start();
        }

        private void UpdatePlayback(object source, ElapsedEventArgs e)
        {
            if (Commands.Count() <= CurCommand)
            {
                TimerPlayback.Stop();
                return;
            }

            GetUpdatedTime();
            if (Commands[CurCommand].Play(CurrentTime))
            {
                CurCommand++;
            }
        }

        public void StopPlayback()
        {
            TimerPlayback.Stop();
        }

        public void SaveCommands()
        {
            if (Commands == null) return;
            var texts = new string[Commands.Count()];
            var cur = 0;
            foreach (var cmd in Commands)
            {
                texts[cur] = cmd.ToString();
                cur++;
            }
            System.IO.File.WriteAllLines(@"WriteLines.txt", texts);
        }

        public void LoadCommands()
        {
            var texts = System.IO.File.ReadAllLines(@"WriteLines.txt");
            Commands = new List<AbstractCommand>();
            foreach (var line in texts)
            {
                if (line.StartsWith("C"))
                {
                    Commands.Add(MouseClickCommand.FromString(line));
                }
                else if (line.StartsWith("M"))
                {
                    Commands.Add(MoveCommand.FromString(line));
                }
                else if (line.StartsWith("K"))
                {
                    Commands.Add(KeyboardCommand.FromString(line));
                }
            }
        }
    }
}