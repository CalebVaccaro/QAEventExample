public static class MathExtensions
{
    public static int AddScore(this int score1, int score2)
    {
        return score1 + score2;
    }

    public static bool IsSameScore(this int score1, int score2)
    {
        return score1 == score2;
    }

    public static int SubtractScore(this int score1, int score2)
    {
        return score1 - score2;
    }
}