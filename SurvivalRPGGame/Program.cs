// © 2022 David Alger <RoastToast-gh@protonmail.com>
using System;

namespace SurvivalRPGGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SurvivalRPGGame())
                game.Run();
        }
    }
}
