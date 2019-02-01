namespace Tumo
{
    public static class TmIdGenerater
    {
        static int idCount = 1000;
        public static string GetId()
        {
            string tmId = "";
            idCount++;
            if (idCount > 4000)
            {
                idCount = 1000;
            }
            tmId = TmTimerTool.CurrentTime() + idCount;
            return tmId;
        }
    }
}
