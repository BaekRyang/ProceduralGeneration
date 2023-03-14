class FirstType{
    public void Run(){
    int[,] map = new int[11, 11];
    int x = 5;
    int y = 5;

    int iMaxAdditionalRoom = 10;
    int iNowRoom;
    int iCounter = 2;

    map[x, y] = 1;

    //갈 수 있는 방향 목록
    int[] dx = { 0, 0, -1, 1 };
    int[] dy = { -1, 1, 0, 0 };
    //각각 아래, 위, 왼쪽, 오른쪽

    Random rand = new Random();
    iNowRoom = 0;
    while (iNowRoom < iMaxAdditionalRoom)
        //추가 방개수 제한
    {
        int direction = rand.Next(4);
        int nextX = x + dx[direction];
        int nextY = y + dy[direction];

        if(map[nextX, nextY] == 0)
        // 이동한 위치에 이미 방이 생성 되어있지 않은지 확인
        {
            if (nextX >= 0 && nextX < 11 && nextY >= 0 && nextY < 11)
            //정의된 맵 범위 내에 있나?
            {
                if (IsTwoNeighbor(map, nextX, nextY))
                //주변에 이웃이 두개 이상 존재하면 안됨
                {
                    if (rand.Next(2) == 1)
                    //50% 확률로 Discard
                    {
                        //map[nextX, nextY] = 1;
                        map[nextX, nextY] = iCounter;
                        iCounter++;
                        x = nextX;
                        y = nextY;
                        iNowRoom++;
                    }

                }
            }
        }
        
    }

    Console.WriteLine();

    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {

            //if (map[i, j] == 0)
            //{
            //    Console.Write("□");
            //} else if (map[i, j] == 1)
            //{
            //    Console.Write("■");
            //}
            //else
            //{
            //    Console.Write("▧");
            //}
            if (map[i, j] == 0)
            {
                Console.Write("□" + "\t");
            } else if (map[i, j] < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(map[i, j] + "\t");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (map[i, j] > 100)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(map[i, j] + "\t");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(map[i, j] + "\t");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        Console.WriteLine();
        if ((i + 1) % 11 == 0) Console.WriteLine();
    }
}

    bool IsTwoNeighbor(int[,] map, int x, int y)
        {
            int iNeighbor = 0;
            //if (y + 1 < map.GetLength(1)) iNeighbor += map[x, y + 1];
            //if (y - 1 > 0) iNeighbor += map[x, y - 1];
            //if (x + 1 < map.GetLength(0)) iNeighbor += map[x + 1, y];
            //if (x - 1 > 0) iNeighbor += map[x - 1, y];

            if (y + 1 < map.GetLength(1) && map[x, y + 1] != 0) iNeighbor += 1;
            if (y - 1 > 0 && map[x, y - 1] != 0) iNeighbor += 1;
            if (x + 1 < map.GetLength(0) && map[x+1, y] != 0) iNeighbor += 1;
            if (x - 1 > 0 && map[x-1, y] != 0) iNeighbor += 1;

            //Console.Write(iNeighbor);
            return iNeighbor < 2;
        }
}
