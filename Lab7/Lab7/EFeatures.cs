using System;

namespace Lab7
{
    public enum EFeatures: int
    {
        Default = 0,    // 초기화 상태값으로 사용 X
        Men = 1 << 0,
        Women = 1 << 1,
        Rectangle = 1 << 2,
        Round = 1 << 3,
        Aviator = 1 << 4,
        Red = 1 << 5,
        Blue = 1 << 6,
        Black = 1 << 7
    }
}