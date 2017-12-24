using System;

namespace DefaultNamespace
{
    public static class ActionStore
    {
        public static float RedFactor = 0.25f;
        public static float GreenFactor = 0;
        private static ColorDirection _colorDirection = ColorDirection.BlueToGreen;

        public static void ModifyColorFactor(float factor)
        {
            switch (_colorDirection)
            {
                case ColorDirection.BlueToGreen:
                    FromBlueToGreen(factor);
                    break;
                case ColorDirection.GreenToBlue:
                    FromGreenToBlue(factor);
                    break;
                case ColorDirection.BlueToPurple:
                    FromBlueToPurple(factor);
                    break;
                case ColorDirection.PurpleToBlue:
                    FromPurpleToBlue(factor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void FromPurpleToBlue(float factor)
        {
            RedFactor -= factor;
            SwitchIfReachLimit(RedFactor <= 0.25f, ColorDirection.BlueToGreen);
        }

        private static void FromGreenToBlue(float factor)
        {
            GreenFactor -= factor;
            SwitchIfReachLimit(GreenFactor <= 0, ColorDirection.BlueToPurple);
        }

        private static void FromBlueToGreen(float factor)
        {
            GreenFactor += factor;
            SwitchIfReachLimit(GreenFactor >= 1, ColorDirection.GreenToBlue);
        }
        
        private static void FromBlueToPurple(float factor)
        {
            RedFactor += factor;
            SwitchIfReachLimit(RedFactor >= 1, ColorDirection.BlueToGreen);
        }

        private static void SwitchIfReachLimit(bool condition, ColorDirection newDirection)
        {
            if (condition)
            {
                _colorDirection = newDirection;
            }
        }
    }

    public enum ColorDirection
    {
        PurpleToBlue,
        BlueToPurple,
        GreenToBlue,
        BlueToGreen
    }
}