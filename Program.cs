internal class Program
{
    private static void Main(string[] args)
    {
        FirstType fs = new FirstType();
        int iFailed= 0;
        for (int i = 0; i == 0;)
        {
            SecondType ss = new SecondType();
            if(ss.Run()) i++;
            else iFailed++;
        }
        Console.Write("실패 횟수 : " + iFailed);
    }
}